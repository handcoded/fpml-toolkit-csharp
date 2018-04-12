// Copyright (C),2006-2012 HandCoded Software Ltd.
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

using HandCoded.Identification;

namespace HandCoded.FpML.Identification
{
    /// <summary>
    /// The <b>UPIExtractor</b> class combines the individual source strings
    /// using a '~' character as a delimiter.
    /// </summary>
    public sealed class UPIExtractor : IExtractor
    {
        /// <summary>
        /// Constructs a <b>UPIExtractor</b> instance.
        /// </summary>
	    public UPIExtractor ()
	    { }
    	
        /// <summary>
        /// Extract a value of a property using the context object and the given
        /// source instances to find it.
        /// </summary>
        /// <param name="context">The source <see cref="Object"/> to obtain data from.</param>
        /// <param name="sources">An array of <see cref="ISource"/> instances that define
	    /// where the data is located.</param>
        /// <returns>The extracted data <see cref="string"/> or <c>null</c></returns>
	    public String Extract (Object context, ISource [] sources)
	    {
		    if (context != null) {
			    lock (buffer) {
				    buffer.Length = 0;
    				
				    for (int index = 0; index < sources.Length; ++index) {
                        if (index != 0) buffer.Append ('~');
					    buffer.Append ((String) sources [index].FindSource (context));
                    }
    				
				    return (buffer.ToString ());
			    }
		    }
		    return (null);
	    }
    	
        /// <summary>
        /// <see cref="StringBuilder"/> used to buffer the intermediate value.
        /// </summary>
	    private static StringBuilder		buffer = new StringBuilder ();
    }
}
