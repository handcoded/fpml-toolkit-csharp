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

using HandCoded.Identification;

namespace HandCoded.FpML.Identification
{
    class UPISwapEmbeddedOptionExtractor : IExtractor
    {
        /// <summary>
        /// Constructs a <b>SwapEmbeddedOptionExtractor</b> instance.
        /// </summary>
        public UPISwapEmbeddedOptionExtractor ()
        { }
	
        /// <summary>
        /// Extract a value of a property using the context object and the given
        /// source instances to find it.
        /// </summary>
        /// <param name="context">The source <see cref="object"/> to obtain data from.</param>
        /// <param name="sources">An array of <see cref="ISource"/> instances that define
        /// where the data is located.</param>
        /// <returns>The extracted data <see cref="string"/> or <c>null</c></returns>
        public String Extract (Object context, ISource [] sources)
        {
	        if ((context != null) && (sources.Length == 3)) {
                bool    early   = Boolean.Parse ((string)(sources [0].FindSource (context)));
                bool    cancel  = Boolean.Parse ((string)(sources [1].FindSource (context)));
                bool    extend  = Boolean.Parse ((string)(sources [2].FindSource (context)));

                if (early || cancel || extend)
                    return (((early)  ? "T" : "") +
                            ((cancel) ? "C" : "") +
                            ((extend) ? "X" : ""));
            }
	        return ("");
        }
    }
}