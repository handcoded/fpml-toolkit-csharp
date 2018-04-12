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

namespace HandCoded.Classification
{
	/// <summary>
	/// A <b>RefinableCategory</b> instance can be used to provide a 'catch-all'
	/// category should its sub-categories fail to isolate a specific variant.
	/// </summary>
	public abstract class RefinableCategory : Category
	{
		/// <summary>
		/// Construct a <b>RefinableCategory</b> with the given name.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>RefinableCategory</b>.</param>
        protected RefinableCategory (ClassificationScheme scheme, string name)
			: base (scheme, name, true)
		{ }

		/// <summary>
		/// Construct a <b>RefinableCategory</b> that is a sub-classification of another
		/// <see cref="Category"/>.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>RefinableCategory</b>.</param>
		/// <param name="parent">The parent <see cref="Category"/>.</param>
		protected RefinableCategory (ClassificationScheme scheme, string name, Category parent)
			: base (scheme, name, true, parent)
		{ }

		/// <summary>
		/// Construct a <b>RefinableCategory</b> that is a sub-classification of other
		/// <see cref="Category"/> instances.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>RefinableCategory</b>.</param>
		/// <param name="parents">The parent <see cref="Category"/> instances.</param>
		protected RefinableCategory (ClassificationScheme scheme, string name, Category [] parents)
			: base (scheme, name, true, parents)
		{ }
	}
}