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
using System.Text;
using System.Xml.Schema;

using HandCoded.Meta;
using HandCoded.Xml.Resolver;

using log4net;

namespace HandCoded.Xml
{
	/// <summary>
	/// The <b>SchemaSet</b> class hold a collection of ...
	/// </summary>
	public sealed class SchemaSet
	{
		/// <summary>
		/// Contains the <see cref="XmlSchemaSet"/>.
		/// </summary>
		public XmlSchemaSet XmlSchemaSet {
			get {
				return (getSchemaSet (XmlUtility.DefaultCatalog));
			}
		}

		/// <summary>
		/// Constructs a <b>SchemaSet</b>.
		/// </summary>
		public SchemaSet ()
		{ }

		/// <summary>
		/// Resolve the location of the indicated <see cref="SchemaRelease"/> (and
		/// any that it imports) to the schema set using default XML catalog to
		/// resolve the schema location.
		/// </summary>
		/// <param name="release">The <see cref="SchemaRelease"/> to be added.</param>
		public void Add (SchemaRelease release)
		{
			if (!schemas.Contains (release)) {
                schemas.Add (release);
                schemaSet = null;
            }
		}
		
        /// <summary>
        /// Builds and returns the <code cref="XmlSchemaSet"/> for the requested
        /// schemas, resolving the URIs against the indicated <code cref="Catalog"/>
        /// instance.
        /// </summary>
        /// <param name="catalog">The <see cref="Catalog"/> used to resolve namespaces.</param>
        /// <returns>An initialised <see cref="XmlSchemaSet"/> for the XML parser.</returns>
        public XmlSchemaSet getSchemaSet (Catalog catalog)
        {
            if (schemaSet == null) {
                XmlSchemaSet    result = new XmlSchemaSet ();


                foreach (SchemaRelease release in schemas) {
			        List<SchemaRelease>	imports = release.ImportSet;
        			
			        foreach (SchemaRelease schema in imports) {
                        if (!result.Contains (schema.NamespaceUri)) {
				            Uri		uri = catalog.ResolveUri (null, schema.NamespaceUri);

				            if (uri != null)
                                try {
                                    result.Add (schema.NamespaceUri, Unwrap (uri.LocalPath));
                                }
                                catch (Exception) {
                                    log.Fatal ("Failed to resolve schema for '" + schema.NamespaceUri + "'");
                                }
				            else
					            log.Fatal ("Failed to resolve schema for '" + schema.NamespaceUri + "'");
                        }
			        }
                }

                schemaSet = result;
            }
            return (schemaSet);
        }

		/// <summary>
		/// Produces a debugging string describing the object.
		/// </summary>
		/// <returns>The debugging information string.</returns>
        public override string ToString ()
        {
            StringBuilder   builder = new StringBuilder ();

            foreach (XmlSchema schema in schemaSet.Schemas ()) {
                if (builder.Length > 0) builder.Append (",");

                builder.Append ("[");
                builder.Append (schema.TargetNamespace);
                builder.Append (" - ");
                builder.Append (schema.SourceUri);
                builder.Append ("]");
            }
            return ("{" + builder.ToString () + "}");
        } 
		
        /// <summary>
        /// A <see cref="ILog"/> instance used to report serious errors.
        /// </summary>
		private static ILog			log
			= LogManager.GetLogger (typeof (SchemaSet));

        /// <summary>
        /// The set of <see cref="SchemaRelease"/> added to the set.
        /// </summary>
		private List<SchemaRelease>	schemas		= new List<SchemaRelease> ();
				
        /// <summary>
        /// The compiled schema representation of the schemas.
        /// </summary>
		private XmlSchemaSet		schemaSet	= null;	

		/// <summary>
		/// Scans a path and removes and URI style encoded characters.
		/// </summary>
		/// <param name="path">The path to be processed.</param>
		/// <returns>The processed path.</returns>
		private String Unwrap (String path)
		{
			StringBuilder	buffer	= new StringBuilder ();

			for (int index = 0; index < path.Length;) {
				char		ch;

				switch (ch = path [index++]) {
				case '%':
					switch (ch = path [index++]) {
					case '2':
						switch (ch = path [index++]) {
						case '3':	buffer.Append ('#'); break;
						case '5':	buffer.Append ('%'); break;
						case '7':	buffer.Append ('\''); break;
						case 'b': case 'B':
									buffer.Append ('+'); break;
						case 'f': case 'F':
									buffer.Append ('/'); break;
						default:
							buffer.Append ('%');
							buffer.Append ('2');
							buffer.Append (ch);
							break;
						}
						break;

					case '3':
						switch (ch = path [index++]) {
						case 'a': case 'A':
									buffer.Append (':'); break;
						case 'b': case 'B':
									buffer.Append (';'); break;
						case 'f': case 'F':
									buffer.Append ('?'); break;

						default:
							buffer.Append ('%');
							buffer.Append ('3');
							buffer.Append (ch);
							break;
						}
						break;

					default:
						buffer.Append ('%');
						buffer.Append (ch);
						break;
					}
					break;
			
				default:
					buffer.Append (ch);
					break;
				}
			}
			return (buffer.ToString ());
		}
	}
}