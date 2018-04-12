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
using System.Xml;
using System.Xml.XPath;

using log4net;

namespace HandCoded.Classification.Xml
{
    internal sealed class XPathNode : ExprNode
    {
        public XPathNode (string test)
        {
            this.test = test;
        }

        public override bool Evaluate (object context)
        {
            XmlElement element = context as XmlElement;

            try {
                XmlNamespaceManager resolver = new XmlNamespaceManager(new NameTable());

                if ((element.NamespaceURI != null) && (element.NamespaceURI.Length > 0)) {
                    resolver.AddNamespace ("dyn", element.NamespaceURI);
                }
                XPathNavigator navigator = element.CreateNavigator();
                return (ToBool (navigator.Evaluate (this.test, resolver)));
            }
            catch (Exception exception) {
                log.Fatal ("Failed to evaluate XPath (" + this.test + ")", exception);
            }
            return (false);
        }

        private bool ToBool (object result)
        {
            if (result is bool) {
                return (bool) result;
            }
            if (result is double) {
                return (((double) result) != 0.0);
            }
            if (result is string) {
                return (((string) result).Length > 0);
            }
            return ((result is XPathNodeIterator) && ((result as XPathNodeIterator).Count != 0));
        }

        private static ILog log = LogManager.GetLogger(typeof(XPathNode));
        private readonly string test;
    }
}