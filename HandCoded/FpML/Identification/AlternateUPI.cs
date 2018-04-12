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

using System.Xml;

using HandCoded.Classification;
using HandCoded.FpML.Classification;
using HandCoded.FpML.Infoset;
using HandCoded.Identification;
using HandCoded.Identification.Xml;

namespace HandCoded.FpML.Identification
{
    /// <summary>
    /// Instances of the <b>AlternateUPI</b> contain a derived product identifier
    /// based on product characteristic values.
    /// </summary>
    public sealed class AlternateUPI
    {
        /// <summary>
        /// Contains the UPI code string.
        /// </summary>
        public string Code {
            get {
                return (code);
            }
        }

        /// <summary>
        /// Derives a <b>UPI</b> from the values in a trade description
	    /// represented by the indicated DOM <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="context">The root <see cref="XmlElement"/> of the trade.</param>
        /// <returns>The derived <b>UPI</b> instance or <c>null</c>.</returns>
	    public static AlternateUPI ForTrade (XmlElement context)
	    {
		    XmlDocument	infoset		= ProductInfoset.CreateInfoset (context);
    		
		    if (infoset != null)
			    return (ForProductInfoset (infoset.DocumentElement,
						    ISDATaxonomy.PRODUCT_TYPE.Classify (infoset)));

		    return (null);
	    }
    	
        /// <summary>
        /// Derives a <b>UPI</b> from the values in a trade description
	    /// represented by the indicated DOM <see cref="XmlElement"/> based on the
        /// target product taxonomy classification.
        /// </summary>
        /// <param name="context">The root <see cref="XmlElement"/> of the trade.</param>
        /// <param name="productType">The target product taxonomy classification.</param>
        /// <returns>The derived <b>UPI</b> instance or <c>null</c>.</returns>
	    public static AlternateUPI ForTrade (XmlElement context, Category productType)
	    {
		    XmlDocument	infoset		= ProductInfoset.CreateInfoset (context);
    		
		    if (infoset != null)
			    return (ForProductInfoset (infoset.DocumentElement, productType));

		    return (null);
	    }

        /// <summary>
        /// Derives a <b>UPI</b> from the values in the product infoset
	    /// represented by the indicated DOM <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="infoset">The root <see cref="XmlElement"/> of the product infoset.</param>
        /// <returns>The derived <b>UPI</b> instance or <c>null</c>.</returns>
	    public static AlternateUPI ForProductInfoset (XmlElement infoset)
	    {
		    return (ForProductInfoset (infoset, ISDATaxonomy.ProductTypeForInfoset (infoset)));
	    }
    	
        /// <summary>
        /// Derives a <b>UPI</b> from the values in the product infoset
	    /// represented by the indicated DOM <see cref="XmlElement"/> based on the
        /// target product taxonomy classification.
        /// </summary>
        /// <param name="infoset">The root <see cref="XmlElement"/> of the product infoset.</param>
        /// <param name="productType">The target product taxonomy classification.</param>
        /// <returns>The derived <b>UPI</b> instance or <c>null</c>.</returns>
	    public static AlternateUPI ForProductInfoset (XmlElement infoset, Category productType)
	    {
		    if (productType != null) {
			    IdentifierRule	rule	= ruleBook.Find (productType.Name);
    			
			    return ((rule != null) ? new AlternateUPI (rule.GetIdentifier (infoset)) : null);			
		    }
		    return (null);
	    }

        /// <summary>
        /// The <see cref="RuleBook"/> that defines how to format UPI infosets.
        /// </summary>
	    private readonly static RuleBook	ruleBook
		    = RuleBookLoader.Load ("files-fpmlext/upi-alternate.xml");

        /// <summary>
        /// The <b>UPI</b> code string.
        /// </summary>
	    private	readonly string code;

        /// <summary>
        /// Constructs a <b>UPI</b> instance for the indicates code value.
        /// </summary>
        /// <param name="code">The UPI code value.</param>
	    private AlternateUPI (string code)
	    {
		    this.code = code;
	    }    
    }
}