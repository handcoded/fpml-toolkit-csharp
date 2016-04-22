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
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;

using log4net;

using HandCoded.Framework;
using HandCoded.Meta;
using HandCoded.Validation;
using HandCoded.Xml.Resolver;
using HandCoded.Xml.Writer;

namespace HandCoded.Xml
{
	/// <summary>
	/// A collection of utility functions for traversing the structure of
	/// a DOM tree represented by a <see cref="XmlDocument"/> and its
	/// constitutent <see cref="XmlNode"/> instances.
	/// </summary>
	public sealed class XmlUtility
	{
		/// <summary>
		/// A constant value indicating that only DTD based documents are
		/// expected.
		/// </summary>
		public const int	DTD_ONLY		= 1;
	
		/// <summary>
		/// A constant value indicating that only schema based documents are
		/// expected.
		/// </summary>
		public const int	SCHEMA_ONLY		= 2;
	
		/// <summary>
		/// A constant value indicating that either a DTD or schema based
		/// documents could be provided.
		/// </summary>
		public const int	DTD_OR_SCHEMA	= 3;

		/// <summary>
		/// Contains the default <see cref="Catalog"/>.
		/// </summary>
		public static Catalog DefaultCatalog {
			get {
				return (defaultCatalog);
			}
			set {
				defaultCatalog = value;
			}
		}

		/// <summary>
		/// Contains the default <see cref="SchemaSet"/>.
		/// </summary>
		public static SchemaSet DefaultSchemaSet {
			get {
				return (defaultSchemaSet);
			}
		}

		/// <summary>
		/// Performs a non-validating parse of the indicated XML <see cref="String"/>
		/// discarding any errors generated.
		/// </summary>
		/// <param name="xml">The XML <see cref="string"/> to be processed.</param>
		/// <returns>A <see cref="XmlDocument"/> instance if the parse succeeded
		/// or <b>null</b> if it failed.</returns>
		public static XmlDocument NonValidatingParse (string xml)
		{
			XmlDocument			document	= new XmlDocument ();

			try {
				document.LoadXml (xml);
				return (document);
			}
			catch (XmlException) {
				return (null);
			}
		}

		/// <summary>
		/// Performs a non-validating parse of the indicated XML <see cref="Stream"/>
		/// discarding any errors generated.
		/// </summary>
		/// <param name="stream">The XML <see cref="Stream"/> to be processed.</param>
		/// <returns>A <see cref="XmlDocument"/> instance if the parse succeeded
		/// or <b>null</b> if it failed.</returns>
		public static XmlDocument NonValidatingParse (Stream stream)
		{
			XmlDocument			document	= new XmlDocument ();
			XmlReaderSettings	settings	= new XmlReaderSettings ();

            settings.DtdProcessing   = DtdProcessing.Prohibit;
			settings.ValidationFlags = XmlSchemaValidationFlags.None;
			settings.ValidationType	 = ValidationType.None;
			settings.XmlResolver	 = defaultCatalog;

			XmlReader			reader		= XmlReader.Create (stream, settings);

			try {
				document.Load (reader);
				return (document);
			}
			catch (XmlException) {
				return (null);
			}
		}

		/// <summary>
		/// Performs a validating parse of the indicated XML <see cref="string"/>
		/// using the most optimal technique given the mode. If the type of
		/// grammar is unknown then a non-validating parse is done first and
		/// the document inspected to see if it references a DOCTYPE.
		/// </summary>
		/// <param name="grammer">Indicates only schema based documents to be processed.</param>
		/// <param name="xml">The XML <see cref="string"/> to be processed.</param>
		/// <param name="schemas">The collection of cached schemas for validation</param>
		/// <param name="resolver">The <see cref="XmlResolver"/> used to locate DTDs.</param>
		/// <param name="eventHandler">The <see cref="ValidationEventHandler"/> used to report parse errors</param>
		/// <returns>A <see cref="XmlDocument"/> instance if the parse succeeded
		/// or <b>null</b> if it failed.</returns>
		public static XmlDocument ValidatingParse (int grammer, string xml,
			XmlSchemaSet schemas, XmlResolver resolver, ValidationEventHandler eventHandler)
		{
			XmlDocument			document	= new XmlDocument ();
			XmlReaderSettings	settings	= new XmlReaderSettings ();
			XmlReader			reader;

			if (grammer == DTD_OR_SCHEMA) {
				if ((document = NonValidatingParse (xml)) == null) return (null);

				grammer = (document.DocumentType != null) ? DTD_ONLY : SCHEMA_ONLY;
			}

			if (grammer == DTD_ONLY) {
                settings.DtdProcessing  = DtdProcessing.Prohibit;
				settings.ValidationType = ValidationType.DTD;
				settings.XmlResolver	= resolver;
			}

			if (grammer == SCHEMA_ONLY) {
				settings.ValidationType = ValidationType.Schema;
				settings.Schemas		= schemas;
			}

            settings.ValidationEventHandler += eventHandler;
			reader = XmlReader.Create (new StringReader (xml), settings);

			try {
				document.Load (reader);
				return (document);
			}
			catch (XmlException) {
				return (null);
			}
		}

		/// <summary>
		/// Performs a validating parse of the indicated XML <see cref="string"/>
		/// using the most optimal technique given the mode. If the type of
		/// grammar is unknown then a non-validating parse is done first and
		/// the document inspected to see if it references a DOCTYPE.
		/// </summary>
		/// <param name="grammer">Indicates only schema based documents to be processed.</param>
		/// <param name="stream">The XML <see cref="Stream"/> to be processed.</param>
		/// <param name="schemas">The collection of cached schemas for validation</param>
		/// <param name="resolver">The <see cref="XmlResolver"/> used to locate DTDs.</param>
		/// <param name="eventHandler">The <see cref="ValidationEventHandler"/> used to report parse errors</param>
		/// <returns>A <see cref="XmlDocument"/> instance if the parse succeeded
		/// or <b>null</b> if it failed.</returns>
		public static XmlDocument ValidatingParse (int grammer, Stream stream,
			XmlSchemaSet schemas, XmlResolver resolver, ValidationEventHandler eventHandler)
		{
			XmlDocument			document	= new XmlDocument ();
			XmlReaderSettings	settings	= new XmlReaderSettings ();
			XmlReader reader;

			if (grammer == DTD_OR_SCHEMA)
			{
				if (!stream.CanSeek)
					throw new Exception ("The XML Stream must be capable of supporting seek");

				if ((document = NonValidatingParse (stream)) == null) return (null);

				grammer = (document.DocumentType != null) ? DTD_ONLY : SCHEMA_ONLY;
				stream.Seek (0, SeekOrigin.Begin);
			}

			if (grammer == DTD_ONLY)
			{
                settings.DtdProcessing = DtdProcessing.Prohibit;
				settings.ValidationType = ValidationType.DTD;
				settings.XmlResolver = resolver;
			}

			if (grammer == SCHEMA_ONLY)
			{
				settings.ValidationType = ValidationType.Schema;
				settings.ValidationFlags = XmlSchemaValidationFlags.ReportValidationWarnings;
				settings.Schemas = schemas;
			}

			settings.ValidationEventHandler += eventHandler;
			reader = XmlReader.Create (stream, settings);

			try
			{
				document.Load (reader);
				return (document);
			}
			catch (XmlException)
			{
				return (null);
			}
		}

		/// <summary>
		/// Produces a detailed dump of the given <see cref="XmlNode"/> instance
		/// and its descendents on the console output stream.
		/// </summary>
		/// <param name="node">The <see cref="XmlNode"/> to be dumped.</param>
		public static void DumpNode (XmlNode node)
		{
			DumpNode (node, System.Console.Out, 0);
		}
	
		/// <summary>
		/// Produces a detailed dump of the given <see cref="XmlNode"/> instance
		/// and its descendents via the indicated <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="node">The <see cref="XmlNode"/> to be dumped.</param>
		/// <param name="writer">The <see cref="TextWriter"/> to use for output.</param>	
		public static void DumpNode (XmlNode node, TextWriter writer)
		{
			DumpNode (node, writer, 0);
		}

        /// <summary>
        /// A <see cref="ILog"/> instance used to report serious errors.
        /// </summary>
		private static ILog			log
			= LogManager.GetLogger (typeof (XmlUtility));

		/// <summary>
		/// The default catalog used to resolve XML DTDs and Schemas.
		/// </summary>
		private static Catalog		defaultCatalog		= null;

		/// <summary>
		/// The default schema collection used to validate schema based documents.
		/// </summary>
		private static SchemaSet	defaultSchemaSet	= new SchemaSet ();

		/// <summary>
		/// Ensures no instances can be constructed.
		/// </summary>
		private XmlUtility()
		{ }

		/// <summary>
		/// Recursively dumps out an <see cref="XmlNode"/> and its descendents
		/// to the indicated <see cref="TextWriter"/> in a simple indented style.
		/// </summary>
		/// <param name="node">The <see cref="XmlNode"/> to be dumped.</param>
		/// <param name="writer">The <see cref="TextWriter"/> to use for output.</param>
		/// <param name="indent">The current level of indentation.</param>
		private static void DumpNode (XmlNode node, TextWriter writer, int indent)
		{
			if (node != null) {
				for (int i = 0; i < indent; ++i)
					writer.Write ("  ");

				switch (node.NodeType) {
				case XmlNodeType.Document:
					{
						writer.WriteLine ("[Document]");
						DumpNode ((node as XmlDocument).DocumentType, writer, indent + 1);
						DumpNode ((node as XmlDocument).DocumentElement, writer, indent + 1);
						break;
					}

				case XmlNodeType.Element:
					{
						writer.Write ("[Element]");
						writer.Write ((node as XmlElement).Name);
						writer.WriteLine (" {" + node.NamespaceURI + "}");
						
						foreach (XmlNode attr in (node as XmlElement).Attributes)
							DumpNode (attr, writer, indent + 1);

						foreach (XmlNode child in (node as XmlElement).ChildNodes)
							DumpNode (child, writer, indent + 1);

						break;
					}

				case XmlNodeType.Attribute:
					{
						writer.Write ("[Attribute]");
						writer.Write ((node as XmlAttribute).Name);	
						writer.Write ("=" + (node as XmlAttribute).Value);
						writer.WriteLine (" {" + node.NamespaceURI + "}");
						break;
					}

				case XmlNodeType.Text:
					{
						writer.Write ("[Text]");
						writer.WriteLine ((node as XmlText).Value);
						break;
					}	
				}
			}
		}

        /// <summary>
        /// Initialise the default schema set using its configuration file.
        /// </summary>
        static XmlUtility ()
        {
            log.Debug ("Bootstrapping Default Schema Set");

            try {
                FileStream  stream = new FileStream (
                    Application.PathTo (
                        ConfigurationManager.AppSettings ["HandCoded.FpML Toolkit.DefaultSchemaSet"]),
                    FileMode.Open);

                XmlDocument document = new XmlDocument ();
                document.Load (stream);

                foreach (XmlElement context in XPath.Paths (document.DocumentElement, "schemaReference")) {
				    XmlAttribute specificationName = context.GetAttributeNode ("specification");
				    XmlAttribute versionNumber = context.GetAttributeNode ("version");
				    XmlAttribute namespaceUri = context.GetAttributeNode ("namespaceUri");
    				
				    if ((specificationName == null) || (versionNumber == null)) {
					    log.Error ("Mandatory attribute(s) are missing from a schema reference");
					    continue;
				    }
    								
				    Specification specification = Specification.ForName (specificationName.Value);
				    if (specification == null) {
					    log.Warn ("Invalid specification name '" + specificationName.Value
							    +"' in configuration file.");
					    continue;
				    }
    				
				    Release	release = null;
    				
				    if (namespaceUri != null) {
					    release = specification.GetReleaseForVersionAndNamespace (
							    versionNumber.Value, namespaceUri.Value);
    					
					    if (release == null) {
						    log.Warn ("Invalid version and namespace URI "
								    + versionNumber.Value + " / "
								    + namespaceUri.Value);
						    continue;										
					    }
				    }
				    else {
					    release = specification.GetReleaseForVersion (
							    versionNumber.Value);
    					
					    if (release == null) {
						    log.Warn ("Invalid version" + versionNumber.Value);
						    continue;					
					    }
				    }
    				
				    if (!(release is SchemaRelease)) {
					    log.Warn ("Reference to a non schema release '"
							    + specificationName.Value +"' / '"
							    + versionNumber.Value + "'");
					    continue;
				    }
    				
				    defaultSchemaSet.Add ((SchemaRelease) release);
                }
            }
            catch (Exception error) {
                log.Fatal ("Unable to load default schema set", error);
            }

            log.Debug ("Completed");
        }
	}
}