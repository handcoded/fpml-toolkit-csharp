// Copyright (C),2006-2011 HandCoded Software Ltd.
// All rights reserved.
//
// This software is the confidential and proprietary information of HandCoded
// Software Ltd. ("Confidential Information").  You shall not disclose such
// Confidential Information and shall use it only in accordance with the terms
// of the license agreement you entered into with HandCoded Software.
//
// HANDCODED SOFTWARE MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE
// SUITABILITY OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE, OR NON-INFRINGEMENT. HANDCODED SOFTWARE SHALL NOT BE
// LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING
// OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

using HandCoded.Framework;
using HandCoded.Xml;

using log4net;

namespace HandCoded.Identification.Xml
{
    /// <summary>
    /// Creates a <see cref="RuleBook"/> by parsing the contents of an XML
    /// configuration file and constructing the appropriate objects.
    /// </summary>
    public sealed class RuleBookLoader
    {
        /// <summary>
        /// Creates a <see cref="RuleBook"/> by parsing the content of the
	    /// indicated configuration file.
        /// </summary>
        /// <param name="filename">The configuration filename.</param>
        /// <returns>A <see cref="RuleBook"/> instance created using the
	    ///	details in the configuration file.</returns>
        public static RuleBook Load (string filename)
        {
		    RuleBook			ruleBook = new RuleBook ();

            FileStream	stream	= File.OpenRead (Application.PathTo (filename));
            XmlDocument document = XmlUtility.NonValidatingParse (stream);

		    XmlNodeList list = DOM.GetChildElements (document.DocumentElement);
		    foreach (XmlElement context in list) {
			    if (context.LocalName.Equals ("identifier")) {
				    string	name 	= context.GetAttribute ("name");
    				
				    Property [] properties  = LoadProperties (XPath.Paths (context, "property"));
				    IFormatter formatter = (IFormatter) LoadClass (XPath.Paths (context, "formatter"));
    				
				    ruleBook.Add (new IdentifierRule (name, properties, formatter));
			    }
			    else
				    log.Warn ("Unexpected element '" + context.LocalName + "'");
		    }

            return (ruleBook);
        }

		/// <summary>
		/// The <see cref="ILog"/> instance used to record problems.
		/// </summary>
		private static ILog		log
			= LogManager.GetLogger (typeof (RuleBookLoader));

        /// <summary>
        /// A dictionary of previously created object instances.
        /// </summary>
        private static Dictionary<string, object> instances
            = new Dictionary<string,object> ();

        /// <summary>
        /// The default extract to use if none is specified.
        /// </summary>
        private static IExtractor   defaultExtractor
            = (IExtractor) LoadClass ("HandCoded.Identification.Xml.StringExtractor");

        /// <summary>
        /// Ensures an instance cannot be constructed.
        /// </summary>
        private RuleBookLoader ()
        { }

        /// <summary>
        /// Creates an array of <see cref="Property"/> instances from the
        /// configuration file details.
        /// </summary>
        /// <param name="list">A <see cref="XmlNodeList"/> of all the property elements.</param>
        /// <returns>An array of the constructed instances.</returns>
	    private static Property [] LoadProperties (XmlNodeList list)
	    {
		    Property [] result = new Property [list.Count];
    		
		    for (int index = 0; index < list.Count; ++index)
			    result [index] = LoadProperty ((XmlElement) list [index]);
		    return (result);
	    }
    	
        /// <summary>
        /// Creates a <see cref="Property"/> instance from the configuration
        /// file details.
        /// </summary>
        /// <param name="context">The <see cref="XmlElement"/> for the property.</param>
        /// <returns>A constructed <see cref="Property"/> instance.</returns>
	    private static Property LoadProperty (XmlElement context)
	    {
		    string		name 		= context.GetAttribute ("name");
		    IExtractor 	extractor 	= LoadExtractor (XPath.Paths (context, "extractor"));
		    XmlNodeList	list		= XPath.Paths (context, "source");
    				
		    ISource [] sources = new ISource [list.Count];
		    for (int index = 0; index < list.Count; ++index)
			    sources [index] = LoadSource ((XmlElement) list [index]);
    			
		    return (new Property (name, extractor, sources));	
	    }
    	
        /// <summary>
        /// Creates an <see cref="XmlSource"/> that will extract data from the
        /// target source location.
        /// </summary>
        /// <param name="context">The <see cref="XmlElement"/> describing the source.</param>
        /// <returns>A new <see cref="ISource"/> instance that will be used to
        /// extract data from a document.</returns>
	    private static ISource LoadSource (XmlElement context)
	    {
		    return (new XmlSource (context.GetAttribute ("xpath")));
	    }

        /// <summary>
        /// Finds a class to use to control data extraction. If none is specified
	    /// then a default instance is used.
        /// </summary>
        /// <param name="list">The <see cref="XmlNodeList"/> of class references.></param>
        /// <returns>An instance of the created class or <c>null</c>.</returns>
        public static IExtractor LoadExtractor (XmlNodeList list)
        {
            IExtractor      result = (IExtractor) LoadClass (list);

            return ((result != null) ? result : defaultExtractor);
        }
    	
        /// <summary>
        /// Attempts to load a class dynamically, selecting the appropriate
        /// one for the execution platform.
        /// </summary>
        /// <param name="list">The <see cref="XmlNodeList"/> of class references.></param>
        /// <returns>An instance of the created class or <c>null</c>.</returns>
	    private static object LoadClass (XmlNodeList list)
	    {
    		
		    foreach (XmlElement element in list) {
			    if (element.GetAttribute ("platform").Equals (".Net"))
                    return (LoadClass (element.GetAttribute ("class")));
		    }
		    return (null);
	    }

        /// <summary>
        /// Creates an instance of the indicated class. If an instance has
        /// already been constructed then reuse it.
        /// </summary>
        /// <param name="className">The target class name</param>
        /// <returns>The constructed instance or <c>null</c>.</returns>
        private static object LoadClass (string className)
        {
            object          result = null;

            if (!instances.TryGetValue (className, out result)) {
			    try {
				    result = Type.GetType (className).GetConstructor (System.Type.EmptyTypes).Invoke (null);
			    }
			    catch (Exception error) {
				    log.Fatal ("Failed to create instance of class '" + className + "'", error);
			    }
            }
            return (result);
        }
    }
}