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
    /// The <b>IRuleContext</b> interface defines a standard API for locating
    /// the document <see cref="XmlElement"/> instances that are contexts for
    /// a FpML rule.
    /// </summary>
    interface IRuleContext
    {
        /// <summary>
        /// Returns a <see cref="XmlNodeList"/> containing all the elements
        /// defined in the <see cref="NodeIndex"/> that match the context
        /// specification.
        /// </summary>
        /// <param name="nodeIndex">A <see cref="NodeIndex"/> for the test document.</param>
        /// <returns>A <see cref="XmlNodeList"/> containing all the matching
        /// <see cref="XmlElement"/> instances, if any.</returns>
	    XmlNodeList GetMatchingElements (NodeIndex nodeIndex);
    }
}