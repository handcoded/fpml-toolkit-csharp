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
using System.Xml;

using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
    /// <summary>
    /// An instance of <b>TypeContext</b> defines the context for a
    /// <see cref="SchemeRule"/> based on an XML Schema type name.
    /// </summary>
    public sealed class TypeContext : IRuleContext
    {
        /// <summary>
        /// Constructs a <b>TypeContext</b> for a given type name.
        /// </summary>
        /// <param name="typeName">The context type name.</param>
	    public TypeContext (string typeName)
	    {
		    this.typeName = typeName;
	    }

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
		    return (nodeIndex.GetElementsByType (FpMLRuleSet.DetermineNamespace (nodeIndex), typeName));
	    }

        /// <summary>
        /// The name of the type to find instances of.
        /// </summary>
        private readonly string typeName;
    }
}