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

using HandCoded.Meta;
using HandCoded.Xml;
using log4net;

namespace HandCoded.Classification.Xml
{
    /// <summary>
    /// The <b>ClassificationSchemeLoader</b> class processes the contents of
    /// an XML configuration file defining a classification scheme and constructs
    /// the objects needed to apply it to objects at runtime.
    /// </summary>
    public sealed class ClassificationSchemeLoader
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename">The configuration filename</param>
        /// <returns></returns>
        public static ClassificationScheme Load (string filename)
        {
            ClassificationScheme scheme = new ClassificationScheme();
            Dictionary<string, Category> dictionary = new Dictionary<string, Category>();
            try {
                FileStream stream = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filename));
                XmlDocument document = XmlUtility.NonValidatingParse(stream);
                foreach (XmlElement element in DOM.GetChildElements (document.DocumentElement)) {
                    if (element.LocalName.Equals ("category")) {
                        Category category;
                        string attribute = element.GetAttribute("id");
                        string name = element.GetAttribute("name");
                        string str3 = element.GetAttribute("abstract");
                        string str4 = element.GetAttribute("superClasses");
                        ExprNode expression = LoadExpr(DOM.GetFirstChild(element));
                        bool concrete = (expression != null) && ((str3 == null) || !str3.Equals("true"));
                        if ((str4 != null) && (str4.Length != 0)) {
                            string[] strArray = str4.Split(new char[] { ' ' });
                            Category[] parents = new Category[strArray.Length];
                            for (int i = 0; i < strArray.Length; i++) {
                                parents [i] = dictionary [strArray [i]];
                            }
                            category = new XmlCategory (scheme, name, concrete, parents, expression);
                        }
                        else {
                            category = new XmlCategory (scheme, name, concrete, expression);
                        }
                        if ((attribute != null) && (attribute.Length != 0)) {
                            dictionary [attribute] = category;
                        }
                    }
                    stream.Close ();
                }
                return scheme;
            }
            catch (Exception exception) {
                log.Fatal ("Failed to load classification from " + filename, exception);
            }
            return null;
        }

        private static ILog log = LogManager.GetLogger(typeof(ClassificationSchemeLoader));

        private ClassificationSchemeLoader ()
        {
        }

        private static ExprNode LoadExpr (XmlElement element)
        {
            if (element != null) {
                Specification specification;
                if (element.LocalName.Equals ("if")) {
                    ExprNode node;
                    ExprNode node2;
                    ExprNode node3;
                    XmlElement parent = XPath.Path(element, "test");
                    XmlElement element3 = XPath.Path(element, "then");
                    XmlElement element4 = XPath.Path(element, "else");
                    if (parent.HasAttribute ("test")) {
                        node = new XPathNode (parent.GetAttribute ("test"));
                    }
                    else {
                        node = LoadExpr (DOM.GetFirstChild (parent));
                    }
                    if (element3.HasAttribute ("test")) {
                        node2 = new XPathNode (element3.GetAttribute ("test"));
                    }
                    else {
                        node2 = LoadExpr (DOM.GetFirstChild (element3));
                    }
                    if (element4.HasAttribute ("test")) {
                        node3 = new XPathNode (element4.GetAttribute ("test"));
                    }
                    else {
                        node3 = LoadExpr (DOM.GetFirstChild (element4));
                    }
                    return new IfNode (node, node2, node3);
                }
                if (element.LocalName.Equals ("release")) {
                    specification = Specification.ForName (element.GetAttribute ("specification"));
                    return new ReleaseNode (specification, specification.GetReleaseForVersion (element.GetAttribute ("version")));
                }
                if (element.LocalName.Equals ("range")) {
                    specification = Specification.ForName (element.GetAttribute ("specification"));
                    Release lower = null;
                    Release upper = null;
                    string attribute = element.GetAttribute("lower");
                    if (attribute != null) {
                        lower = specification.GetReleaseForVersion (attribute);
                    }
                    attribute = element.GetAttribute ("upper");
                    if (attribute != null) {
                        upper = specification.GetReleaseForVersion (attribute);
                    }
                    return new RangeNode (specification, lower, upper);
                }
                if (element.LocalName.Equals ("xpath")) {
                    return new XPathNode (element.GetAttribute ("test"));
                }
            }
            return null;
        }
    }
}