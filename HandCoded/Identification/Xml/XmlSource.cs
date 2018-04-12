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
using System.Text;
using System.Xml;
using System.Xml.XPath;

using log4net;

namespace HandCoded.Identification.Xml
{
    /// <summary>
    /// An instance of the <b>XmlSource</b> instance can be used to extract
    /// the string value of an XPath expression from an DOM tree.
    /// </summary>
    sealed class XmlSource : ISource
    {
        /// <summary>
        /// Constructs a <b>XmlSource</b> for the indicated XPath expression.
        /// </summary>
        /// <param name="expr">The XPath expression.</param>
        public XmlSource (string expr)
        {
            this.expr = expr;
        }

        /// <summary>
        /// Invokes the <b>Source</b> against the context <see cref="object"/>
	    /// to cause some data to be located for extraction.
        /// </summary>
        /// <param name="context">The <see cref="object"/> to invoke against.</param>
        /// <returns>The data value located by the <b>Source</b> instance.</returns>
	    public object FindSource (object context)
        {
            XmlElement  element = context as XmlElement;

            try {
                XmlNamespaceManager nsManager = new XmlNamespaceManager (new NameTable ());

                if ((element.NamespaceURI != null) && (element.NamespaceURI.Length > 0))
                    nsManager.AddNamespace ("dyn", element.NamespaceURI);

                XPathNavigator navigator = element.CreateNavigator ();
                XPathExpression expression = XPathExpression.Compile (expr, nsManager);

                StringBuilder builder = new StringBuilder ();

                if (expression.ReturnType == XPathResultType.NodeSet) {
                    XPathNodeIterator nodes = navigator.Select(expression);
                    while (nodes.MoveNext())
                        builder.Append (nodes.Current.ToString ());
                }
                else if (expression.ReturnType == XPathResultType.String)
                    builder.Append (navigator.Evaluate (expression));
                else if (expression.ReturnType == XPathResultType.Number)
                    builder.Append (navigator.Evaluate (expression));
                else if (expression.ReturnType == XPathResultType.Boolean)
                    builder.Append (((bool) navigator.Evaluate(expression)) ? "true" : "false");

                return (builder.ToString ());
            }
		    catch (Exception error) {
                log.Fatal ("Failed to evaluate XPath (" + expr + ")", error);
            }
            return (null);
        }

		/// <summary>
		/// The <see cref="ILog"/> instance used to record problems.
		/// </summary>
		private static ILog		log
			= LogManager.GetLogger (typeof (XmlSource));

        /// <summary>
        /// The XPath expression.
        /// </summary>
        private readonly string expr;
    }
}