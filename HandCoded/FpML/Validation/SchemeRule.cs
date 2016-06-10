// Copyright (C),2005-2015 HandCoded Software Ltd.
// All rights reserved.
//
// This software is licensed in accordance with the terms of the 'Open Source
// License (OSL) Version 3.0'. Please see 'license.txt' for the details.
//
// HANDCODED SOFTWARE LTD MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE
// SUITABILITY OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE, OR NON-INFRINGEMENT. HANDCODED SOFTWARE LTD SHALL NOT BE
// LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING
// OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.

using System.Xml;

using HandCoded.FpML.Meta;
using HandCoded.FpML.Schemes;
using HandCoded.Meta;
using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>SchemeRule</b> class provides the logic to validate FpML scheme
	/// code values for all versions of FpML.
	/// </summary>
	public class SchemeRule : Rule
	{
		/// <summary>
		/// Constructs a <b>SchemeRule</b> with the given name and that applies in
		/// the circumstances defined by its <see cref="Precondition"/>.
		/// </summary>
		/// <param name="precondition">A <see cref="Precondition"/> instance.</param>
		/// <param name="name">The unique name for the rule.</param>
		/// <param name="elementContext">The element name based context.</param>
		/// <param name="typeContext">The type name based context (or <c>null</c>)</param>
		/// <param name="attributeName">The name of the attribute containing the scheme URI.</param>
		public SchemeRule (Precondition precondition, string name,
                    ElementContext elementContext, TypeContext typeContext, string attributeName)
			: base (precondition, name)
		{
			this.elementContext = elementContext;
			this.typeContext  = typeContext;
			this.attributeName = attributeName;
		}

		/// <summary>
		/// Constructs a <b>SchemeRule</b> with the given name and that applies in
		/// the circumstances defined by its <see cref="Precondition"/>.
		/// </summary>
		/// <param name="precondition">A <see cref="Precondition"/> instance.</param>
		/// <param name="name">The unique name for the rule.</param>
		/// <param name="elementContext">The element name based context.</param>
		/// <param name="attributeName">The name of the attribute containing the scheme URI.</param>
		public SchemeRule (Precondition precondition, string name,
                    ElementContext elementContext, string attributeName)
			: this (precondition, name, elementContext, null, attributeName)
		{ }

		/// <summary>
		/// Validates all the elements registered at construction using the
		/// <see cref="NodeIndex"/> to locate them as quickly as possible.
		/// </summary>
		/// <param name="nodeIndex">The <see cref="NodeIndex"/> of the test document.</param>
		/// <param name="errorHandler">The <see cref="ValidationErrorHandler"/> used to report issues.</param>
		/// <returns><c>true</c> if the code values pass the checks, <c>false</c>
		/// otherwise.</returns>
		protected override bool Validate (NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
            if (nodeIndex.HasTypeInformation && (typeContext != null))
                return (Validate (typeContext.GetMatchingElements (nodeIndex), errorHandler));

            return (Validate (elementContext.GetMatchingElements (nodeIndex), errorHandler));
		}

		/// <summary>
		/// Validates the data content of a set of elements by locating the scheme
		/// identified by the scheme attribute or a default on the root element
		/// for pre FpML-4-0 instances.
		/// </summary>
		/// <param name="list">An <see cref="XmlNodeList"/> of elements to check.</param>
		/// <param name="errorHandler">The <see cref="ValidationErrorHandler"/> used to report issues.</param>
		/// <returns><c>true</c> if the code values pass the checks, <c>false</c>
		/// otherwise.</returns>
		protected bool Validate (XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			if (list.Count > 0) {
				XmlElement	fpml	= DOM.GetParent (list [0] as XmlElement);
				string		version	= null;

				// Find the FpML root node
				while (fpml != null) {
					if (fpml.LocalName.Equals ("FpML")) {
						version = fpml.GetAttribute ("version");
						break;
					}
					if (fpml.HasAttribute ("fpmlVersion")) {
						version = fpml.GetAttribute ("fpmlVersion");
						break;
					}
					fpml = DOM.GetParent (fpml);
				}

                Release release = Releases.FPML.GetReleaseForVersion (version);
                if (release == null) {
                    errorHandler ("305", null,
                        "The document release is not on the schema set -- Check configuration",
                        DisplayName, null);
                }

				SchemeCollection	schemes = (release as ISchemeAccess).SchemeCollection;
                if (schemes == null) {
                    errorHandler ("305", null,
                        "No schemes data is available for this FpML version -- Check configuration",
                        DisplayName, null);
                }

				foreach (XmlElement context in list) {
					// If there is no local override then look for a default on the FpML
					// element in pre 3-0 versions.
					string uri = context.GetAttribute (attributeName);
					if (((uri == null) || (uri.Length == 0)) && (version != null)) {
						string [] components = version.Split ('-');
						if ((components.Length > 1) && (components [0].CompareTo ("4") < 0)) {
							ISchemeAccess provider
								= Specification.ReleaseForDocument (context.OwnerDocument) as ISchemeAccess;

							string name = provider.SchemeDefaults.GetDefaultAttributeForScheme (attributeName);
							if (name != null) uri = fpml.GetAttribute (name);
						}
					}

					if ((uri == null) || (uri.Length == 0)) {
						errorHandler ("305", context,
							"A qualifying scheme URI has not been defined for this element",
							DisplayName, context.LocalName);

						result = false;
						continue;
					}

					Scheme scheme = schemes.FindSchemeForUri (uri);
					if (scheme == null) {
						errorHandler ("305", context,
							"An unrecognized scheme URI has been used as a qualifier",
							DisplayName, uri);

						result = false;
						continue;
					}
					
					string value = context.InnerText.Trim ();
					if (scheme.IsValid (value)) continue;

					errorHandler ("305", context,
						"The code value '" + value + "' is not valid in scheme '" + scheme.Uri + "'",
						DisplayName, value);

					result = false;
				}
			}
			return (result);
		}

        /// <summary>
        /// 
        /// </summary>
        private readonly ElementContext elementContext;

        /// <summary>
        /// 
        /// </summary>
        private readonly TypeContext typeContext;

		/// <summary>
		/// The name of attribute containing the scheme URI.
		/// </summary>
		private readonly string		attributeName;
	}
}