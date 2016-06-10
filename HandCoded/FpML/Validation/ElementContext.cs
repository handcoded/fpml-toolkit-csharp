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

using System.Xml;

using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
    /// <summary>
    /// An instance of <b>ElementContext</b> defines the context for a
    /// <see cref="SchemeRule"/> based on a set of element names optionally
    /// qualified by the parent element name.
    /// </summary>
    public sealed class ElementContext : IRuleContext
    {
        /// <summary>
        /// Constructs an <b>ElementContext</b> given an array of parent
        /// element names (or <c>null</c>) and an array of element names.
        /// </summary>
        /// <remarks>If both arrays are provided them they must be the same length.</remarks>
        /// <param name="parentNames">An array of parent element names (or <c>null</c>).</param>
        /// <param name="elementNames">An array of context element names.</param>
        public ElementContext (string [] parentNames, string [] elementNames)
	    {
		    this.parentNames  = parentNames;
		    this.elementNames = elementNames;
	    }

        /// <summary>
        /// Constructs an <b>ElementContext</b> given an array of element names.
        /// </summary>
        /// <param name="elementNames">An array of context element names.</param>
	    public ElementContext (string [] elementNames)
            : this (null, elementNames)
	    { }
	
        /// <summary>
        /// Constructs an <b>ElementContext</b> for a given qualified element name.
        /// </summary>
        /// <param name="parentName">The name of the parent element.</param>
        /// <param name="elementName">The context element name.</param>
	    public ElementContext (string parentName, string elementName)
            : this (new string [] { parentName }, new string [] { elementName })
	    { }

        /// <summary>
        /// Constructs an <b>ElementContext</b> for a given element name.
        /// </summary>
        /// <param name="elementName">The context element name.</param>
	    public ElementContext (string elementName)
            : this (null, new string [] { elementName })
        { }
	
        /// <summary>
        /// Returns a <see cref="XmlNodeList"/> containing all the elements
        /// defined in the <see cref="NodeIndex"/> that match the context
        /// specification.
        /// </summary>
        /// <param name="nodeIndex">A <see cref="NodeIndex"/> for the test document.</param>
        /// <returns>A <see cref="XmlNodeList"/> containing all the matching
        /// <see cref="XmlElement"/> instances, if any.</returns>
	    public XmlNodeList GetMatchingElements (NodeIndex nodeIndex)
	    {
		    if (parentNames == null)
			    return (nodeIndex.GetElementsByName (elementNames));
		    else {
			    MutableNodeList		result = new MutableNodeList ();
    			
			    for (int index = 0; index < elementNames.Length; ++index) {
				    XmlNodeList matches = nodeIndex.GetElementsByName (elementNames [index]);
    				
				    if (parentNames [index] == null)
					    result.AddAll (matches);
				    else {
					    for (int count = 0; count < matches.Count; ++count) {
						    XmlElement	element = (XmlElement) matches [count];
						    XmlNode	    parent	= element.ParentNode;
    						
						    if (parent.NodeType  == XmlNodeType.Element) {
							    if (parent.LocalName.Equals (parentNames [index]))
								    result.Add (element);
						    }
					    }
				    }
			    }
			    return (result);
		    }
        }

        /// <summary>
        /// A list of the local parent element names corresponding to the
	    /// <c>elementNames</c>. If the array has a <c>null</c> value
        /// then no parent element qualification is performed.
        /// </summary>
	    private readonly string []	parentNames;

        /// <summary>
        /// A list of local element names that this rule will validate.
        /// </summary>
	    private readonly string []	elementNames;
    }
}