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
using System.Xml;

using HandCoded.Classification;
using HandCoded.Classification.Xml;
using HandCoded.Framework;

namespace HandCoded.FpML.Classification
{
    /// <summary>
    /// The <b>ISDATaxonomy</b> class provides easy access the to the
    /// categories defined in the taxonomy provided by the ISDA product
    /// working groups initiated in response to the Dodd-Frank Act.
    /// </summary>
    public sealed class ISDATaxonomy
    {
        /// <summary>
        /// Attempts to classify the indicated infoset using the asset class taxonomy.
        /// </summary>
        /// <param name="infoset">The product infoset as a DOM tree.</param>
        /// <returns>The <see cref="Category"/> instance representing the asset class
	    /// corresponding to the product infoset.</returns>
	    public static Category AssetClassForInfoset (XmlElement infoset)
	    {
		    return ((infoset != null) ? ASSET_CLASS.Classify (infoset) : null);
	    }

        /// <summary>
        /// Attempts to classify the indicated infoset using the product type taxonomy.
        /// </summary>
        /// <param name="infoset">The product infoset as a DOM tree.</param>
        /// <returns>The <see cref="Category"/> instance representing the product type
        /// corresponding to the product infoset.</returns>
        public static Category ProductTypeForInfoset (XmlElement infoset)
	    {
		    return ((infoset != null) ? PRODUCT_TYPE.Classify (infoset) : null);
	    }

        /// <summary>
        /// The ISDA asset class taxonomy.
        /// </summary>
	    private static ClassificationScheme	assetClassClassification
		    = ClassificationSchemeLoader.Load (
                Application.PathTo (ConfigurationManager.AppSettings ["HandCoded.FpML Toolkit.ISDAAssetClass"]));

        /// <summary>
        /// The ISDA product type taxonomy.
        /// </summary>
	    private static ClassificationScheme	productTypeClassification
		    = ClassificationSchemeLoader.Load (
                Application.PathTo (ConfigurationManager.AppSettings ["HandCoded.FpML Toolkit.ISDAProductType"]));

        /// <summary>
        /// A <see cref="Category"/> representing all asset classes.
        /// </summary>
	    public static readonly Category	ASSET_CLASS
		    = assetClassClassification.GetCategoryByName ("{ISDA}");

        /// <summary>
        /// A <see cref="Category"/> representing all product types.
        /// </summary>
	    public static readonly Category	PRODUCT_TYPE
		    = productTypeClassification.GetCategoryByName ("{ISDA}");

        /// <summary>
        /// Prevents an instance being created.
        /// </summary>
	    private ISDATaxonomy ()
	    { }
    }
}