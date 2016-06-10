// Copyright (C),2005-2012 HandCoded Software Ltd.
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

using System;
using System.Collections.Generic;
using System.Xml;

using HandCoded.Meta;
using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
    /// <summary>
    /// The <b>NamespacePrecondition</b> class checks that the FpML root
    /// element uses an element belonging to a specific namespace URI.
    /// </summary>
    public sealed class NamespacePrecondition : Precondition
    {
        /// <summary>
        /// Constructs a <b>NamespacePrecondition</b> instance for the
	    /// specified <see cref="SchemaRelease"/> instance.
        /// </summary>
        /// <param name="release">The target <see cref="SchemaRelease"/>.</param>
	    public NamespacePrecondition (SchemaRelease release)
            : this (release.NamespaceUri)
	    { }
	
        /// <summary>
        /// Constructs a <b>NamespacePrecondition</b> instance for the
	    /// specified namespace URI.
        /// </summary>
        /// <param name="namespaceUri">The target namespace URI.</param>
	    public NamespacePrecondition (string namespaceUri)
	    {
		    this.namespaceUri = namespaceUri;
	    }

        /// <summary>
        /// Evaluates this <b>Precondition</b> against the contents of the
        /// indicated <see cref="NodeIndex"/>.
        /// </summary>
        /// <param name="nodeIndex">The <see cref="NodeIndex"/> of a <see cref="XmlDocument"/>.</param>
        /// <param name="cache">A cache of previously evaluated precondition results.</param>
        /// <returns>A <c>bool</c> value indicating the applicability of this
        /// <b>Precondition</b> to the <see cref="XmlDocument"/>.</returns>
        public override bool Evaluate (NodeIndex nodeIndex, Dictionary<Precondition, bool> cache)
        {
		    XmlElement		rootElement;
    		
		    // Find the document element
		    XmlNodeList list = nodeIndex.GetElementsByName ("FpML");
		    if (list.Count > 0)
			    rootElement = (XmlElement) list [0];
		    else {
			    list = nodeIndex.GetAttributesByName ("fpmlVersion");
			    if (list.Count > 0)
				    rootElement = ((XmlAttribute) list [0]).OwnerElement;
			    else
				    return (false);
		    }

            string ns = rootElement.NamespaceURI;
            return ((ns != null) ? (ns.CompareTo (namespaceUri) == 0) : false);
        }

        /// <summary>
        /// The target namespace URI.
        /// </summary>
	    private readonly String	namespaceUri;
    }
}