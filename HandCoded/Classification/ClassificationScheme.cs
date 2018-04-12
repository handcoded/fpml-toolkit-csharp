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

namespace HandCoded.Classification
{
    /// <summary>
    /// A <b>ClassificationScheme</b> instance provides a container for a set of
    /// related <see cref="Category"/> instances.
    /// </summary>
    public sealed class ClassificationScheme
    {
        /// <summary>
        /// Constructs an empty <b>ClassificationScheme</b> instance.
        /// </summary>
	    public ClassificationScheme ()
	    { }
    	
        /// <summary>
        /// Locates a <see cref="Category"/> within the <b>Classification</b>
	    /// using its name string.
        /// </summary>
        /// <param name="name">The target name string.</param>
        /// <returns>The matching <see cref="Category"/> instance or <c>null</c>
        /// if no match was found.</returns>
	    public Category GetCategoryByName (string name)
	    {
		    return (extent [name]);
	    }

        /// <summary>
        /// Adds a <see cref="Category"/> instance to the extent set.
        /// </summary>
        /// <param name="category">The <see cref="Category"/> instance to add.</param>
	    internal void Add (Category category)
	    {
		    extent [category.Name] = category;
	    }
	
        /// <summary>
        /// The underlying hash table of categories indexed by name.
        /// </summary>
	    private Dictionary<string, Category>	extent
		    = new Dictionary<string, Category> ();
    }
}
