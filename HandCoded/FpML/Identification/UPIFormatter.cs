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
using System.Collections.Generic;
using System.Text;

using HandCoded.Identification;

namespace HandCoded.FpML.Identification
{
    /// <summary>
    /// The <b>UPIFormatter</b> class implements a <see cref="IFormatter"/>
    /// for UPI strings that uses a simple format string contained in a
    /// <see cref="Property"/> called 'FormatString'.
    /// </summary>
    public sealed class UPIFormatter : IFormatter
    {
        /// <summary>
        /// Constructs a <b>UPIFormatter</b>.
        /// </summary>
        public UPIFormatter ()
        { }

        /// <summary>
        /// Uses the set of property values extracted from the context object to
        /// create a formatted identifier string.
        /// </summary>
        /// <param name="values">The set of property values.</param>
        /// <returns>The identifier created from the values.</returns>
	    public string Format (Dictionary<String, String> values)
	    {
		    char []			format = values ["FormatString"].ToCharArray ();
		    int				index  = 0;
    		
		    lock (buffer) {
			    buffer.Length = 0;
    			
			    while (index < format.Length) {
				    if (format [index] == '%') {
					    name.Length = 0;
					    ++index;
    					
					    while ((index < format.Length) && (format [index] != '%'))
						    name.Append (format [index++]);
    					
					    buffer.Append (values [name.ToString ()]);
					    ++index;					
				    }
				    else
					    buffer.Append (format [index++]);
			    }
			    return (buffer.ToString ().Trim ());
		    }
	    }
    	
        /// <summary>
        /// A <see cref="StringBuilder"/> used to buffer the identifier as it is
	    /// built up.
        /// </summary>
	    private static StringBuilder buffer  = new StringBuilder ();

        /// <summary>
        /// A <see cref="StringBuilder"/> used to buffer property names as they
        /// as parsed.
        /// </summary>
        private static StringBuilder name    = new StringBuilder ();
    }
}