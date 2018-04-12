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
    /// A <b>RuleBook</b> instance holds a set of <see cref="IdentifierRule"/>
    /// instances.
    /// </summary>
    public sealed class RuleBook
    {
        /// <summary>
        /// Constructs an empty <b>RuleBook</b>.
        /// </summary>
	    public RuleBook ()
	    { }
    	
        /// <summary>
        /// Adds an <see cref="IdentifierRule"/> to the <b>RuleBook</b>
	    /// rule collection.
        /// </summary>
        /// <param name="identifier">The <see cref="IdentifierRule"/> to be added.</param>
	    public void Add (IdentifierRule identifier)
	    {
		    identifiers [identifier.Name] = identifier;
	    }
    	
        /// <summary>
        /// Attempts to locates an <see cref="IdentifierRule"/> with the indicated
	    /// name.
        /// </summary>
        /// <param name="name">The name of the required rule.</param>
        /// <returns>An <see cref="IdentifierRule"/> if a match is found, <c>null</c>
        /// otherwise.</returns>
	    public IdentifierRule Find (string name)
	    {
		    return (identifiers.ContainsKey (name) ? identifiers [name] : null);
	    }

        /// <summary>
        /// The extent set of <see cref="IdentifierRule"/> instances.
        /// </summary>
	    private Dictionary<string, IdentifierRule> identifiers
		    = new Dictionary<string, IdentifierRule> ();
    }
}