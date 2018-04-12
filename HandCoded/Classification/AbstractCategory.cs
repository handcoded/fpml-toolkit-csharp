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

namespace HandCoded.Classification
{
	/// <summary>
	/// An <b>AbstractCategory</b> is used to relate a set of sub-category
	/// instances. 
	/// </summary>
	public class AbstractCategory : Category
	{
		/// <summary>
		/// Construct an <b>AbstractCategory</b> with the given name.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>AbstractCategory</b>.</param>
		public AbstractCategory (ClassificationScheme scheme, string name)
			: base (scheme, name, false)
		{ }

		/// <summary>
		/// Construct an <b>AbstractCategory</b> that is a sub-classification of another
		/// <see cref="Category"/>.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>AbstractCategory</b>.</param>
		/// <param name="parent">The parent <see cref="Category"/>.</param>
		public AbstractCategory (ClassificationScheme scheme, string name, Category parent)
			: base (scheme, name, false, parent)
		{ }

		/// <summary>
		/// Construct an <b>AbstractCategory</b> that is a sub-classification of other
		/// <see cref="Category"/> instances.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>AbstractCategory</b>.</param>
		/// <param name="parents">The parent <see cref="Category"/> instances.</param>
		public AbstractCategory (ClassificationScheme scheme, string name, Category [] parents)
			: base (scheme, name, false, parents)
		{ }

        /// <summary>
        /// Determines if this <b>Category</b> (and its sub-categories)
        /// is applicable to the given <see cref="Object"/>.
        /// </summary>
        /// <param name="value">The <see cref="Object"/> to be tested.</param>
        /// <returns><c>true</c> if the <see cref="Object"/> is applicable,
        /// <c>false</c> otherwise.</returns>
        protected override bool IsApplicable (Object value)
        {
            return (true);
        }
	}
}