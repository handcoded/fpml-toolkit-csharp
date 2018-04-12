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

using System.Collections.Generic;
using System.Xml;

using HandCoded.Finance;
using HandCoded.Meta;
using HandCoded.Xml;

namespace HandCoded.FpML.Infoset
{
    /// <summary>
    /// The <b>ProductInfoset</b> class provides utility functions that can be
    /// used to convert the DOM representation of an FpML trade into a stripped down
    /// product infoset. The product infoset is created by passing the document
    /// through a conversion instance.
    /// </summary>
    public sealed class ProductInfoset
    {
        /// <summary>
        /// Creates the product infoset for the fragment of FpML indicated by the
        /// <see cref="XmlElement"/> argument.
        /// </summary>
        /// <param name="element">The root <see cref="XmlElement"/> of the FpML fragment.</param>
        /// <returns>An <see cref="XmlDocument"/> containing the product infoset.</returns>
        public static XmlDocument CreateInfoset (XmlElement element)
        {
            return (conversion.Convert (element, null));
        }

        /// <summary>
        /// The <b>FPML_5_3__INFOSET_1_0</b> class contains the logic to convert
        /// an FpML 5-3 product into its product infoset form.
        /// </summary>
		private sealed class FPML_5_3__INFOSET_1_0 : HandCoded.Meta.DirectConversion
		{
			/// <summary>
			/// Constructs a <b>INFOSET_1_0</b> instance.
			/// </summary>
			public FPML_5_3__INFOSET_1_0 ()
				: base (Releases.R5_3_CONFIRMATION, R1_0)
			{ }

			/// <summary>
			/// Applies the <b>Conversion</b> to a <see cref="XmlDocument"/> instance
			/// to create a new <see cref="XmlDocument"/>.
			/// </summary>
			/// <param name="source">The <see cref="XmlDocument"/> to be converted.</param>
			/// <param name="helper">A <see cref="IHelper"/> used to guide conversion.</param>
			/// <returns>A new <see cref="XmlDocument"/> containing the transformed data.</returns>
			public override XmlDocument Convert (XmlDocument source, HandCoded.Meta.IHelper helper)
			{
                return (Convert (source.DocumentElement, helper));
			}

            /// <summary>
            /// Applies the <b>Conversion</b> to the indicated <see cref="XmlElement"/>
            /// instance to create a new <see cref="XmlDocument"/>.
            /// </summary>
            /// <param name="oldRoot">The <see cref="XmlElement"/> to be converted.</param>
			/// <param name="helper">A <see cref="IHelper"/> used to guide conversion.</param>
			/// <returns>A new <see cref="XmlDocument"/> containing the transformed data.</returns>
            public XmlDocument Convert (XmlElement oldRoot, HandCoded.Meta.IHelper helper)
            {
 				XmlDocument		target 	= TargetRelease.NewInstance ("productInfoset");
			
				// Transcribe each of the first level child elements
				foreach (XmlNode node in oldRoot.ChildNodes)
                    if (node.NodeType == XmlNodeType.Element)
					    Traverse (node, target, target.DocumentElement);

                return (target);
            }

            /// <summary>
            /// Compares the fixed rate values in two streams to determine thier
            /// relative ordering.
            /// </summary>
            /// <param name="lhs">The <see cref="XmlNode"/> for the left hand stream.</param>
            /// <param name="rhs">The <see cref="XmlNode"/> for the right hand stream.</param>
            /// <returns>An integer value indicating the relative ordering.</returns>
            private static int CompareSwapStreamFixedRates (XmlNode lhs, XmlNode rhs)
            {
                decimal lhsRate = ExtractSwapStreamFixedRate ((XmlElement) lhs);
                decimal rhsRate = ExtractSwapStreamFixedRate ((XmlElement) rhs);

                return (lhsRate.CompareTo (rhsRate));
            }

            /// <summary>
            /// Locates the element containing the initial fixed rate value and converts
            /// it to a <see cref="decimal"/> value.
            /// </summary>
            /// <param name="stream">The <see cref="XmlNode"/> for the interest rate stream.</param>
            /// <returns>The fixed rate interest value.</returns>
            private static decimal ExtractSwapStreamFixedRate (XmlElement stream)
            {
                XmlElement  rate = XPath.Path (stream, "calculationPeriodAmount", "calculation", "fixedRateSchedule", "initialValue");

                return (Types.ToDecimal (rate));
            }

            private static int CompareSwapStreamFloatingRates (XmlNode lhs, XmlNode rhs)
            {
                string  lhsIndex = ExtractSwapStreamFloatingRate ((XmlElement) lhs);
                string  rhsIndex = ExtractSwapStreamFloatingRate ((XmlElement) rhs);

                return (lhsIndex.CompareTo (rhsIndex));              
            }

            private static string ExtractSwapStreamFloatingRate (XmlElement stream)
            {
                XmlElement  index   = XPath.Path (stream, "calculationPeriodAmount", "calculation", "floatingRateCalculation", "floatingRateIndex");
                XmlElement  tenor   = XPath.Path (stream, "calculationPeriodAmount", "calculation", "floatingRateCalculation", "indexTenor");

                if (tenor != null) {
                    XmlElement  factor  = XPath.Path (tenor, "periodMultipler");
                    XmlElement  period  = XPath.Path (tenor, "period");

                    return (Types.ToToken (index) + "/" + Types.ToToken (factor) + "/" +Types.ToToken (period));
                }
                return (Types.ToToken (index));
            }

            private static void DeriveTenor (Date start, Date end, XmlDocument document, XmlElement parent)
            {
                int         dateDiff    = end.DayOfMonth - start.DayOfMonth;
                int         monthDiff   = end.Month - start.Month;
                int         yearDiff    = end.Year - start.Year;
                int         daysDiff    = end.DayNumber - start.DayNumber;
                Interval    tenor       = null;

                if (daysDiff < 28) {
                    if (daysDiff % 7 == 0)
                        tenor = new Interval (daysDiff / 7, Period.WEEK);
                    else
                        tenor = new Interval (daysDiff, Period.DAY);
                }
                else {
                    if (monthDiff != 0)
                        tenor = new Interval (monthDiff + 12 * yearDiff, Period.MONTH);
                    else
                        tenor = new Interval (yearDiff, Period.YEAR);
                }

                // Build the XML structure
                if (tenor != null) {
                    XmlElement  element;

                    element = document.CreateElement ("periodMultiplier", R1_0.NamespaceUri);
                    element.InnerText = tenor.Multiplier.ToString ();
                    parent.AppendChild (element);

                    element = document.CreateElement ("period", R1_0.NamespaceUri);
                    element.InnerText = tenor.Period.ToString ();
                    parent.AppendChild (element);
                }
            }

            private static XmlElement FindTrade (XmlElement context)
            {
                XmlNode     parent  = context.ParentNode;

                while ((parent != null) && (parent.NodeType == XmlNodeType.Element)) {
                    if ((parent as XmlElement).LocalName.Equals ("trade"))
                        return (parent as XmlElement);

                    parent = parent.ParentNode;
                }
                return (null);
            }

            /// <summary>
			/// Recursively walk through the input document until the start of a
            /// product definition is located. At that point start transcribing
            /// the details.
			/// </summary>
			/// <param name="context">The <see cref="XmlNode"/> to be examined.</param>
			/// <param name="document">The new <see cref="XmlDocument"/> instance.</param>
			/// <param name="parent">The new parent <see cref="XmlNode"/>.</param>
			private void Traverse (XmlNode context, XmlDocument document, XmlElement parent)
			{
 				switch (context.NodeType) {
				case XmlNodeType.Element:
					{
						XmlElement		element = context as XmlElement;

                        // Start copying when we reach a product element
                        if (XPath.Match (element, "swap") ||                    // IR
                            XPath.Match (element, "fra") ||
                            XPath.Match (element, "bulletPayment") ||
                            XPath.Match (element, "capFloor") ||
                            XPath.Match (element, "swaption") ||
                            XPath.Match (element, "bondOption") ||
                            XPath.Match (element, "fxSingleLeg") ||             // FX
                            XPath.Match (element, "fxSwap") ||
                            XPath.Match (element, "fxOption") ||
                            XPath.Match (element, "fxDigitalOption") ||
                            XPath.Match (element, "termDeposit") ||
                            XPath.Match (element, "commoditySwap") ||           // CO
                            XPath.Match (element, "commoditySwaption") ||
                            XPath.Match (element, "commodityOption") ||
                            XPath.Match (element, "commodityForward") ||
                            XPath.Match (element, "creditDefaultSwap") ||       // CD
                            XPath.Match (element, "creditDefaultSwapOption") ||
                            XPath.Match (element, "strategy"))
                            Transcribe (element, document, parent);
                        else
					        foreach (XmlNode node in element.ChildNodes)
                                if (node.NodeType == XmlNodeType.Element)
						            Traverse (node, document, element);
			
						break;
					}
                }
            }

			/// <summary>
			/// Recursively processes an FpML 5-x document to produce a new document
            /// containin the stripped down product infosets.
			/// </summary>
			/// <param name="context">The <see cref="XmlNode"/> to be copied.</param>
			/// <param name="document">The new <see cref="XmlDocument"/> instance.</param>
			/// <param name="parent">The new parent <see cref="XmlNode"/>.</param>
			private void Transcribe (XmlNode context, XmlDocument document, XmlElement parent)
			{
                if (context != null) {
				    switch (context.NodeType) {
                    case XmlNodeType.Attribute:
                        {
                            XmlAttribute attribute = (XmlAttribute) context;

                            // Remove unnecessary ID attributes
                            if (XPath.Match (attribute, "businessCenters", "id") ||
                                XPath.Match (attribute, "swapStream", "id") ||
                                XPath.Match (attribute, "swapStream", "resetDates", "id") ||
                                XPath.Match (attribute, "europeanExercise", "id") ||
                                XPath.Match (attribute, "americanExercise", "id") ||
                                XPath.Match (attribute, "bermudaExercise", "id"))
                                break;

                            if (XPath.Match (attribute, "currencyScheme") &&
                                attribute.Value.Equals ("http://www.fpml.org/ext/iso4217"))
                                break;

                            parent.SetAttribute (attribute.Name, attribute.Value);
                            break;
                        }

				    case XmlNodeType.Element:
					    {
						    XmlElement		element = context as XmlElement;

                            // Strip an existing taxonomy data and identification
                            if (XPath.Match (element, "productType") ||
                                XPath.Match (element, "assetClass") ||
                                XPath.Match (element, "productid"))
                                break;

                            // Remove party specific references
                            if (XPath.Match (element, "buyerPartyReference") ||
                                XPath.Match (element, "buyerAccountReference") ||
                                XPath.Match (element, "sellerPartyReference") ||
                                XPath.Match (element, "sellerAccountReference") ||
                                XPath.Match (element, "payerPartyReference") ||
                                XPath.Match (element, "payerAccountReference") ||
                                XPath.Match (element, "receiverPartyReference") ||
                                XPath.Match (element, "receiverAccountReference") ||
                                XPath.Match (element, "partyReference") ||
                                XPath.Match (element, "calculationAgentPartyReference"))
                                break;

                            // Remove monetary amounts
                            if (XPath.Match (element, "notional", "amount") ||
                                XPath.Match (element, "paymentAmount", "amount") ||
                                XPath.Match (element, "stubAmount", "amount"))
                                break;

                            // Remove calculation period references
                            if (XPath.Match (element, "paymentDates", "calculationPeriodDatesReference") ||
                                XPath.Match (element, "resetDates", "calculationPeriodDatesReference") ||
                                XPath.Match (element, "stubCalculationPeriodAmount", "calculationPeriodDatesReference"))
                                break;

                            // Remove reset dates references
                            if (XPath.Match (element, "fixingDates", "dateRelativeTo") ||
                                XPath.Match (element, "fixingDateOffset", "dateRelativeTo") ||
                                XPath.Match (element, "relativeDate", "dateRelativeTo"))
                                break;

                            // Remove dates
                            if (XPath.Match (element, "paymentDate", "unadjustedDate") ||
                                XPath.Match (element, "adjustableDate", "unadjustedDate") ||
                                XPath.Match (element, "paymentDates", "firstPaymentDate") ||
                                XPath.Match (element, "fra", "adjustedEffectiveDate") ||
                                XPath.Match (element, "fra", "adjustedTerminationDate"))
                                break;

                            // Replace businessCentersReference with a copy of the target
                            if (XPath.Match (element, "businessCentersReference")) {
                                Transcribe (element.OwnerDocument.GetElementById (element.GetAttribute ("href")), document, parent);
                                break;
                            }

                            // Strip schedules
                            if (XPath.Match (element, "notionalStepSchedule", "initialValue") ||
                                XPath.Match (element, "fixedRateSchedule", "initialValue") ||
                                XPath.Match (element, "spreadSchedule", "initialValue") ||
                                XPath.Match (element, "capRateSchedule", "initialValue") ||
                                XPath.Match (element, "floorRateSchedule", "initialValue"))
                                break;

                            // Keep an indication of step presence but remove values
                            if (XPath.Match (element, "step")) {
                                XmlElement prevElement = DOM.GetPreviousSibling (element);

                                if ((prevElement != null) && XPath.Match (prevElement, "step"))
                                    break;
                            }
                            if (XPath.Match (element, "step", "stepDate") ||
                                XPath.Match (element, "step", "stepValue"))
                                break;

                            // Remove rates
                            if (XPath.Match (element, "initialStub", "stubRate") ||
                                XPath.Match (element, "finalStub", "stubRate") ||
                                XPath.Match (element, "fra", "fixedRate"))
                                break;

                            // Remove other odd elements
                            if (XPath.Match (element, "fra", "calculationPeriodNumberOfDays"))
                                break;
   
                            // Clone the original element
						    XmlElement 		clone = document.CreateElement (element.LocalName, R1_0.NamespaceUri);
					        parent.AppendChild (clone);

                            // Keep an indication of cashflows but remove values
                            if (XPath.Match (element, "swapStream", "cashflows"))
                                break;

                            // Normalise swaps
                            if (XPath.Match (element, "swap")) {
                                OrderSwapStreams (element, document, clone);

                                Transcribe (element ["earlyTerminationProvision"], document, clone);
                                Transcribe (element ["cancelableProvision"], document, clone);
                                Transcribe (element ["extendibleProvision"], document, clone);
                                break;
                            }

                            // Make swap streams relative
                            if (XPath.Match (element, "swapStream", "calculationPeriodDates")) {
                                XmlElement  effectiveDate;
                                XmlElement  terminationDate;

                                if ((effectiveDate = XPath.Path (element, "firstRegularPeriodDate", "unadjustedDate")) == null)
                                    effectiveDate = XPath.Path (element, "effectiveDate", "unadjustedDate");

                                if ((terminationDate = XPath.Path (element, "lastRegularPeriodDate", "unadjustedDate")) == null)
                                    terminationDate = XPath.Path (element, "terminationDate", "unadjustedDate");

                                // Replace absolute dates with tenors
                                if ((effectiveDate != null) && (terminationDate != null)) {
                                    XmlElement tenor = document.CreateElement ("relativeTerminationDate", R1_0.NamespaceUri);
                                    clone.AppendChild (tenor);

                                    DeriveTenor (Types.ToDate (effectiveDate), Types.ToDate (terminationDate), document, tenor);
                                    Transcribe (element ["dayType"], document, tenor);

                                    Transcribe (element ["calculationPeriodDatesAdjustments"], document, clone);
                                    Transcribe (element ["stubPeriodType"], document, clone);
                                    Transcribe (element ["calculationPeriodFrequency"], document, clone);
                                    break;
                                }
                            }

                            // Make FRAs relative
                            if (XPath.Match (element, "fra")) {
                                XmlElement  effectiveDate   = XPath.Path (element, "adjustedEffectiveDate");
                                XmlElement  terminationDate = XPath.Path (element, "adjustedTerminationDate");

                                if ((effectiveDate != null) && (terminationDate != null)) {
                                    XmlElement tenor = document.CreateElement ("relativeTerminationDate", R1_0.NamespaceUri);
                                    clone.AppendChild (tenor);

                                    DeriveTenor (Types.ToDate (effectiveDate), Types.ToDate (terminationDate), document, tenor);
                                }
                            }

                            // Derive Expiration date tenor
                            if (XPath.Match (element, "europeanExercise", "expirationDate")) {
                                XmlElement      tradeDate  = XPath.Path (FindTrade (element), "tradeHeader", "tradeDate");
                                XmlElement      expiryDate = XPath.Path (element, "adjustableDate", "unadjustedDate");

                                if ((tradeDate != null) && (expiryDate != null)) {
                                    XmlElement tenor = document.CreateElement ("relativeExpirationDate", R1_0.NamespaceUri);
                                    clone.AppendChild (tenor);

                                    DeriveTenor (Types.ToDate (tradeDate), Types.ToDate (expiryDate), document, tenor);

                                    XmlElement adjustments = XPath.Path (element, "adjustableDate", "dateAdjustments");
                                    if (adjustments != null)
                                        Transcribe (adjustments, document, clone);
                                    break;
                                }
                            }

						    // Transfer and update attributes
						    foreach (XmlAttribute attr in element.Attributes)
							    Transcribe (attr, document, clone);
    						
						    // Recursively copy the child node across
						    foreach (XmlNode node in element.ChildNodes)
							    Transcribe (node, document, clone);

                            break;
					    }

                    case XmlNodeType.Text:
                        {
                            parent.AppendChild (document.CreateTextNode (((XmlText) context).Value));
                            break;
                        }
                    }					
 				}
            }

            private void OrderSwapStreams (XmlElement context, XmlDocument document, XmlElement parent)
            {
                List<XmlNode> fixedStreams = new List<XmlNode> ();
                List<XmlNode> floatStreams = new List<XmlNode> ();
                // TODO inflation

                foreach (XmlNode node in XPath.Paths (context, "swapStream")) {
                    if (XPath.Path ((XmlElement) node, "calculationPeriodAmount", "calculation", "fixedRateSchedule") != null)
                        fixedStreams.Add (node);
                    else if (XPath.Path ((XmlElement) node, "calculationPeriodAmount", "calculation", "floatingRateCalculation") != null)
                        floatStreams.Add (node);
                }

                fixedStreams.Sort (CompareSwapStreamFixedRates);
                floatStreams.Sort (CompareSwapStreamFloatingRates);

                foreach (XmlNode node in fixedStreams)
                    Transcribe (node, document, parent);

                foreach (XmlNode node in floatStreams)
                    Transcribe (node, document, parent);
            }

		}

		/// <summary>
		/// A <see cref="HandCoded.Meta.Specification"/> instance representing the
        /// infoset specification as a whole.
		/// </summary>
		private static readonly Specification PRODUCT_INFOSET
			= new Specification ("PRODUCT_INFOSET");

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// the version 1-0 product infoset.
		/// </summary>
		private static readonly SchemaRelease	R1_0
			= new SchemaRelease (PRODUCT_INFOSET, "1-0", "urn:handcoded:product-infoset",
                    "product-infoset.xsd", "info", null, "productInfoset");

        /// <summary>
        /// The <b>FPML_5_3__INFOSET_1_0</b> instance used to perform the conversion.
        /// </summary>
        private static readonly FPML_5_3__INFOSET_1_0 conversion
            = new FPML_5_3__INFOSET_1_0 ();
    	
        /// <summary>
        /// Prevent any instances from being created.
        /// </summary>
	    private ProductInfoset ()
	    { }
    }
}