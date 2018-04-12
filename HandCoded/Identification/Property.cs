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
    /// Each instance of the <b>Property</b> class represents a data value
    /// used in the formation of an identifier.
    /// </summary>
    public sealed class Property
    {
        /// <summary>
        /// Contains the name of the <b>Property</b>.
        /// </summary>
	    public string Name {
	        get {
		        return (name);
            }
	    }

        /// <summary>
        /// Constructs a <b>Property</b> with the indicated name, extractor and
        /// source instances.
        /// </summary>
        /// <param name="name">The name of the <b>Property</b>.</param>
        /// <param name="extractor">The <see cref="IExtractor"/> instance.</param>
        /// <param name="sources">The data <see cref="ISource"/> instances.</param>
	    public Property (string name, IExtractor extractor, ISource [] sources)
	    {
		    this.name 	   = name;
		    this.extractor = extractor;
		    this.sources   = sources;
	    }

        /// <summary>
        /// Returns the value if this <b>Property</b> for the indicated context
        /// <see cref="object"/>.
        /// </summary>
        /// <param name="context">The context <see cref="object"/>.</param>
        /// <returns>The value derived by extracting and combining the data sources.</returns>
	    public string GetValue (object context)
	    {
		    return (extractor.Extract(context, sources));
	    }
    	
        /// <summary>
        /// The <b>Property</b> name.
        /// </summary>
	    private readonly string	name;
    	
        /// <summary>
        /// The <see cref="IExtractor"/> instance used to extract the value.
        /// </summary>
	    private readonly IExtractor	extractor;
    	
        /// <summary>
        /// An array of <see cref="ISource"/> instance used to locate the values.
        /// </summary>
	    private readonly ISource []	sources;
    }
}