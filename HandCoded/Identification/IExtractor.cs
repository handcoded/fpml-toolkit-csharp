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

namespace HandCoded.Identification
{
    /// <summary>
    /// The <b>IExtractor</b> interface defines the method used to extract the
    /// value of a property from sources within the context object.
    /// </summary>
    public interface IExtractor
    {
        /// <summary>
        /// Extract a value of a property using the context object and the given
        /// source instances to find it.
        /// </summary>
        /// <param name="context">The source <see cref="object"/> to obtain data from.</param>
        /// <param name="sources">An array of <see cref="ISource"/> instances that define
	    /// where the data is located.</param>
        /// <returns>The extracted data <see cref="string"/> or <c>null</c></returns>
	    string Extract (object context, ISource [] sources);
    }
}