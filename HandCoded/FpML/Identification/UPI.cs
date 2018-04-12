// Copyright (C),2006-2012 HandCoded Software Ltd.
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

using System.Security.Cryptography;
using System.Text;
using System.Xml;

using HandCoded.Classification;
using HandCoded.DataEncoding;
using HandCoded.FpML.Classification;
using HandCoded.FpML.Infoset;
using HandCoded.Identification;
using HandCoded.Identification.Xml;

namespace HandCoded.FpML.Identification
{
    /// <summary>
    /// Each instance of the <b>UPI</b> class contains a 'Universal Product
    /// Identifier' code. The <b>UPI</b> class provides utility methods to
    /// derive identifiers from trades or product infosets.
    /// </summary>
    public sealed class UPI
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
        /// Contains the UPI hash string
        /// </summary>
        public string Hash {
            get {
                return (hash);
            }
        }

        /// <summary>
        /// Derives a <b>UPI</b> from the values in a trade description
	    /// represented by the indicated DOM <see cref="XmlElement"/>.
        /// </summary>
         /// <param name="context">The root <see cref="XmlElement"/> of the trade.</param>
        /// <returns>The derived <b>UPI</b> instance or <c>null</c>.</returns>
	    public static UPI ForTrade (XmlElement context)
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
	    public static UPI ForTrade (XmlElement context, Category productType)
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
	    public static UPI ForProductInfoset (XmlElement infoset)
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
	    public static UPI ForProductInfoset (XmlElement infoset, Category productType)
	    {
		    if (productType != null) {
			    IdentifierRule	rule	= ruleBook.Find (productType.Name);
    			
			    return ((rule != null) ? new UPI (rule.GetIdentifier (infoset)) : null);			
		    }
		    return (null);
	    }

        /// <summary>
        /// Returns the value of the instance as a <see cref="string"/>.
        /// </summary>
        /// <returns>The instance as a <see cref="string"/>.</returns>
        public override string  ToString ()
        {
 	         return (code + " {" + hash + "}");
        }

        /// <summary>
        /// The <see cref="RuleBook"/> that defines how to format UPI identifiers.
        /// </summary>
	    private readonly static RuleBook	ruleBook
		    = RuleBookLoader.Load ("files-fpmlext/upi-identifiers.xml");

        /// <summary>
        /// The <see cref="HashAlgorithm"/> used to create hash values
        /// </summary>
        private readonly static HashAlgorithm hashAlgorithm
            = new SHA256Managed ();

        /// <summary>
        /// Shared buffer area used to construct the final hashed code.
        /// </summary>
        private static StringBuilder        buffer  = new StringBuilder ();
    	
        /// <summary>
        /// The <b>UPI</b> code string.
        /// </summary>
	    private	readonly string code;
    	
        /// <summary>
        /// The <b>UPI</b> hash string.
        /// </summary>
	    private	readonly string hash;

        /// <summary>
        /// Constructs a <b>UPI</b> instance for the indicates code value.
        /// </summary>
        /// <param name="code">The UPI code value.</param>
	    private UPI (string code)
	    {
		    if ((this.code = code) != null) {
                lock (hashAlgorithm) {
                    byte [] digest = hashAlgorithm.ComputeHash (Encoding.UTF8.GetBytes (code));

                    hash = Base32.Encode (digest);
                }
            }
            else
                hash = null;
	    }
    }
}