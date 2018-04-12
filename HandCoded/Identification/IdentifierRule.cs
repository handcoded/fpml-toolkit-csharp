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

namespace HandCoded.Identification
{
    /// <summary>
    /// The <b>IdentifierRule</b> class encapsulates the logic for extracting
    /// properties from an <see cref="object"/> and formatting them into an
    /// identifier.
    /// </summary>
    public sealed class IdentifierRule
    {
        /// <summary>
        /// Contains the rule name.
        /// </summary>
	    public string Name {
	        get {
                return (name);
            }
        }

        /// <summary>
        /// Constructs a <b>IdentifierRule</b> with the indicated name,
        /// property set and formatter instance.
        /// </summary>
        /// <param name="name">The name of the rule.</param>
        /// <param name="properties">The <see cref="Property"/> set.</param>
        /// <param name="formatter">The identifier <see cref="IFormatter"/>.</param>
	    public IdentifierRule (string name, Property [] properties, IFormatter formatter)
	    {
		    this.name = name;
		    this.properties = properties;
		    this.formatter = formatter;
	    }

        /// <summary>
        /// Derives the identifier associated with the context <see cref="object"/>.
        /// </summary>
        /// <param name="context">The context <see cref="object"/>.</param>
        /// <returns>The derived identifier string or <c>null</c>.</returns>
	    public string GetIdentifier (object context)
	    {
		    Dictionary<string, string>	values = new Dictionary<string, string> ();
		    string			temp;
    		
		    foreach (Property property in properties) {
			    if ((temp = property.GetValue (context)) != null)
				    values [property.Name] = temp;
		    }		
		    return (formatter.Format (values));
	    }

        /// <summary>
        /// The name of this type of identifier.
        /// </summary>
	    private readonly String		name;
    	
        /// <summary>
        /// The set of <see cref="Property"/> instances that define it.
        /// </summary>
	    private readonly Property [] properties;
    	
        /// <summary>
        /// The <see cref="IFormatter"/> used to combine the properties.
        /// </summary>
	    private readonly IFormatter	formatter;
    }
}