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

using System.Collections.Generic;

namespace HandCoded.Identification
{
    /// <summary>
    /// The <b>Formatter</b> interface defines the method used to format
    /// a set of property data values into an identifier.
    /// </summary>
    public interface IFormatter
    {
        /// <summary>
        /// Uses the set of property values extracted from the context object to
        /// create a formatted identifier string.
        /// </summary>
        /// <param name="values">The set of property values.</param>
        /// <returns>The identifier created from the values.</returns>
	    string Format (Dictionary<string, string> values);
    }
}