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
    /// The <b>ISource</b> interface defines a standard method used to locate
    /// data in a context <see cref="object"/>.
    /// </summary>
    public interface ISource
    {
        /// <summary>
        /// Invokes the <b>Source</b> against the context <see cref="object"/>
	    /// to cause some data to be located for extraction.
        /// </summary>
        /// <param name="context">The <see cref="object"/> to invoke against.</param>
        /// <returns>The data value located by the <b>Source</b> instance.</returns>
	    object FindSource (object context);
    }
}