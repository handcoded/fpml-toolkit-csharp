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

using System.Configuration;

using HandCoded.Classification;
using HandCoded.Classification.Xml;
using HandCoded.Framework;

namespace HandCoded.FpML.Classification
{
    /// <summary>
    /// The <b>FpMLTaxonomy</b> class provides easy access the to the
    /// categories defined in the FpML product based taxonomy provided by
    /// HandCoded Software.
    /// </summary>
    public sealed class FpMLTaxonomy
    {
        /// <summary>
        /// 
        /// </summary>
        public sealed class AssetClass
        {
            /// <summary>
            /// A <see cref="Category"/> representing all documents forms.
            /// </summary>
		    public static readonly Category	ASSET_CLASS
			    = defaultClassification.GetCategoryByName ("AssetClass");
    		
            /// <summary>
            /// A <CODE>Category</CODE> representing all documents forms.
            /// </summary>
		    public static readonly Category	INTEREST_RATE
			    = defaultClassification.GetCategoryByName ("InterestRate");

    		/// <summary>
    		/// A <CODE>Category</CODE> representing all documents forms.
    		/// </summary>
		    public static readonly Category	CREDIT
			    = defaultClassification.GetCategoryByName ("Credit");
    		
            /// <summary>
            /// A <CODE>Category</CODE> representing all documents forms.
            /// </summary>
		    public static readonly Category	EQUITY
			    = defaultClassification.GetCategoryByName ("Equity");
    		
            /// <summary>
            /// A <CODE>Category</CODE> representing all documents forms
            /// </summary>
		    public static readonly Category	FOREIGN_EXCHANGE
			    = defaultClassification.GetCategoryByName ("ForeignExchange");
    		
            /// <summary>
            /// A <CODE>Category</CODE> representing all documents forms.
            /// </summary>
		    public static readonly Category	COMMODITY
			    = defaultClassification.GetCategoryByName ("Commodity");

            /// <summary>
            /// Prevents an instance being created.
            /// </summary>
		    private AssetClass ()
		    { }
        }

        /// <summary>
        /// The default FpML Product classification.
        /// </summary>
	    private static ClassificationScheme	defaultClassification
		    = ClassificationSchemeLoader.Load (
                Application.PathTo (ConfigurationManager.AppSettings ["HandCoded.FpML Toolkit.FpMLTaxonomy"]));

        /// <summary>
        /// A <see cref="Category"/> representing all product types.
        /// </summary>
	    public static readonly Category	FPML
		    = defaultClassification.GetCategoryByName ("FpML");

        /// <summary>
        /// Prevents an instance being created.
        /// </summary>
	    private FpMLTaxonomy ()
	    { }
    }
}