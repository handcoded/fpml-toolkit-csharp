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
	/// The <b>DelegatedRefinableCategory</b> class adapts a
	/// <see cref="RefinableCategory"/> to use delegate functions.
	/// </summary>
	public sealed class DelegatedRefinableCategory : RefinableCategory
	{
		/// <summary>
		/// Construct a <b>DelegatedRefinableCategory</b> with the given name.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>DelegatedRefinableCategory</b>.</param>
		/// <param name="function">The delegate to use for applicability.</param>
		public DelegatedRefinableCategory (ClassificationScheme scheme, string name, ApplicableDelegate function)
			: base (scheme, name)
		{
			this.function = function;
		}

		/// <summary>
		/// Construct a <b>DelegatedRefinableCategory</b> that is a sub-classification
		/// of another <see cref="Category"/>.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>DelegatedRefinableCategory</b>.</param>
		/// <param name="parent">The parent <see cref="Category"/>.</param>
		/// <param name="function">The delegate to use for classification.</param>
		public DelegatedRefinableCategory (ClassificationScheme scheme, string name, Category parent, ApplicableDelegate function)
			: base (scheme, name, parent)
		{
			this.function = function;
		}

		/// <summary>
		/// Construct a <b>DelegatedRefinableCategory</b> that is a sub-classification
		/// of other <see cref="Category"/> instances.
		/// </summary>
        /// <param name="scheme">The owning <see cref="ClassificationScheme"/>.</param>
		/// <param name="name">The name of this <b>DelegatedRefinableCategory</b>.</param>
		/// <param name="parents">The parent <see cref="Category"/> instances.</param>
		/// <param name="function">The delegate to use for classification.</param>
		public DelegatedRefinableCategory (ClassificationScheme scheme, string name, Category [] parents, ApplicableDelegate function)
			: base (scheme, name, parents)
		{
			this.function = function;
		}

		/// <summary>
		/// Determines if this <b>RefinableCategory</b> (and its sub-categories)
		/// is applicable to the given <see cref="Object"/>.
		/// </summary>
		/// <param name="value">The <see cref="Object"/> to be tested.</param>
		/// <returns><c>true</c> if the <see cref="Object"/> is applicable,
		/// <c>false</c> otherwise.</returns>
		protected override bool IsApplicable(Object value)
		{
			return (function (value));
		}

		/// <summary>
		/// Delegate used to determine applicability.
		/// </summary>
		private readonly ApplicableDelegate	function;
	}
}