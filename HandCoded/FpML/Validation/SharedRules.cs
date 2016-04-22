// Copyright (C),2005-2012 HandCoded Software Ltd.
// All rights reserved.
//
// This software is licensed in accordance with the terms of the 'Open Source
// License (OSL) Version 3.0'. Please see 'license.txt' for the details.
//
// HANDCODED SOFTWARE LTD MAKES NO REPRESENTATIONS OR WARRANTIES ABOUT THE
// SUITABILITY OF THE SOFTWARE, EITHER EXPRESS OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE, OR NON-INFRINGEMENT. HANDCODED SOFTWARE LTD SHALL NOT BE
// LIABLE FOR ANY DAMAGES SUFFERED BY LICENSEE AS A RESULT OF USING, MODIFYING
// OR DISTRIBUTING THIS SOFTWARE OR ITS DERIVATIVES.

using System;
using System.Collections.Generic;
using System.Xml;

using HandCoded.Finance;
using HandCoded.FpML.Util;
using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>SharedRules</b> class contains a <see cref="RuleSet"/> that holds
	/// all of the defined validation <see cref="Rule"/> instances for shared
	/// components.
	/// </summary>
	public class SharedRules : FpMLRuleSet
	{
		/// <summary>
		/// Contains the <see cref="RuleSet"/>.
		/// </summary>
		public static RuleSet Rules {
			get {
				return (rules);
			}
		}

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 1-0 or
	    /// later confirmation view document.
        /// </summary>
	    private static readonly Precondition R1_0__LATER
		    = Precondition.And (
				    Preconditions.R1_0__LATER,
				    Preconditions.CONFIRMATION);
	
        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 1-0 thru
	    /// 2-0 confirmation view document.
        /// </summary>
        private static readonly Precondition R1_0__R2_0
	        = Precondition.And (
			        Preconditions.R1_0__R2_0,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 1-0 thru
	    /// 3-0 confirmation view document.
        /// </summary>
	    private static readonly Precondition R1_0__R3_0
	        = Precondition.And (
			        Preconditions.R1_0__R3_0,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 3-0 or
	    /// later confirmation view document.
        /// </summary>
	    private static readonly Precondition R3_0__LATER
	        = Precondition.And (
			        Preconditions.R3_0__LATER,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 4-2 thru
	    /// 4-* confirmation view document.
        /// </summary>
	    private static readonly Precondition R4_2__R4_X
	        = Precondition.And (
			        Preconditions.R4_2__R4_X,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 4-2 or
        /// later confirmation view document.
        /// </summary>
        private static readonly Precondition R4_2__LATER
            = Precondition.And (
                    Preconditions.R4_2__LATER,
                    Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 5-0 or
	    /// later confirmation view document.
        /// </summary>
	    private static readonly Precondition R5_0__LATER
	        = Precondition.And (
			        Preconditions.R5_0__LATER,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 5-0 thru
	    /// 5-3 confirmation view document.
        /// </summary>
	    private static readonly Precondition R5_0__R5_3
	        = Precondition.And (
			        Preconditions.R5_0__R5_3,
			        Preconditions.CONFIRMATION);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 5-4 or
	    /// later confirmation view document.
        /// </summary>
        private static readonly Precondition R5_4__LATER
	        = Precondition.And (
			        Preconditions.R5_4__LATER,
			        Preconditions.CONFIRMATION);

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures that business centers are
		/// only present if the date adjustment convention allows them.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule RULE01
			= new DelegatedRule (R1_0__LATER, "shared-1", new RuleDelegate (Rule01));

		/// <summary>
		/// A <see cref="Rule"/> that ensures that period multiplier is 'D' if the
		/// &lt;dayType&gt; element is present.
		/// </summary>
		/// <remarks>Applies to FpML 1.0, 2.0 and 3.0.</remarks>
		public static readonly Rule	RULE02
			= new DelegatedRule (R1_0__R3_0, "shared-2", new RuleDelegate (Rule02));

		/// <summary>
		/// A <see cref="Rule"/> that ensures that period multiplier is not zero when
		/// the day type is 'Business'
		/// </summary>
		/// <remarks>Applies to FpML 1.0, 2.0 and 3.0.</remarks>
		public static readonly Rule	RULE03
			= new DelegatedRule (R1_0__R3_0, "shared-3", new RuleDelegate (Rule03));

		/// <summary>
		/// A <see cref="Rule"/> that ensures that the businessDayConvention is
		/// NONE when the day type is Business.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE04
			= new DelegatedRule (R1_0__LATER, "shared-4", new RuleDelegate (Rule04));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the payer and receivers are
		/// different.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE05
            = new DelegatedRule (R1_0__LATER, "shared-5", new RuleDelegate (Rule05));

		/// <summary>
		/// A <see cref="Rule"/> that ensures latestExerciseTime is after the
		/// earliestExerciseTime for American exercises.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE06
			= new DelegatedRule (R3_0__LATER, "shared-6", new RuleDelegate (Rule06));

		/// <summary>
		/// A <see cref="Rule"/> that ensures latestExerciseTime is after the
		/// earliestExerciseTime for American exercises.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE07
            = new DelegatedRule (R3_0__LATER, "shared-7", new RuleDelegate (Rule07));

		/// <summary>
		/// A <see cref="Rule"/> that ensures unadjustedFirstDate is before
		/// unadjustedLastDate.
		/// </summary>
        /// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE08
            = new DelegatedRule (R3_0__LATER, "shared-8", new RuleDelegate (Rule08));

		/// <summary>
		/// A <see cref="Rule"/> that ensures business centers are not defined
		/// or referenced if the businessDayConvention is NONE or NotApplicable.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE09
            = new DelegatedRule (R3_0__LATER, "shared-9", new RuleDelegate (Rule09));

		/// <summary>
		/// A <see cref="Rule"/> that ensures calculationAgentPartyReference/@href
		/// attributes are unique.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE10
            = new DelegatedRule (R1_0__LATER, "shared-10", new RuleDelegate (Rule10));

		/// <summary>
		/// A <see cref="Rule"/> that ensures businessDateRange references to
		/// business centers are within the same trade.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE11
            = new DelegatedRule (R3_0__LATER, "shared-11", new RuleDelegate (Rule11));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// buyerPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 1.0 and 2.0.</remarks>
		public static readonly Rule	RULE12_XLINK
			= new DelegatedRule (R1_0__R2_0, "shared-12[XLINK]", new RuleDelegate (Rule12_XLINK));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// buyerPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE12
			= new DelegatedRule (R3_0__LATER, "shared-12", new RuleDelegate (Rule12));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// sellerPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 1.0 and 2.0.</remarks>
		public static readonly Rule	RULE13_XLINK
			= new DelegatedRule (R1_0__R2_0, "shared-13[XLINK]", new RuleDelegate (Rule13_XLINK));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// sellerPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE13
			= new DelegatedRule (R3_0__LATER, "shared-13", new RuleDelegate (Rule13));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// calculationAgentPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 1.0 and 2.0.</remarks>
		public static readonly Rule	RULE14_XLINK
			= new DelegatedRule (R1_0__R2_0, "shared-14[XLINK]", new RuleDelegate (Rule14_XLINK));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the referential integrity of
		/// calculationAgentPartyReference/@href instances.
		/// </summary>
		/// <remarks>Applies to FpML 3.0 and later.</remarks>
		public static readonly Rule	RULE14
			= new DelegatedRule (R3_0__LATER, "shared-14", new RuleDelegate (Rule14));

		/// <summary>
		/// A <see cref="Rule"/> that ensures that period multiplier is 'D' if the
		/// &lt;dayType&gt; element is present.
		/// </summary>
		/// <remarks>Applies to FpML 1.0 and later.</remarks>
		public static readonly Rule	RULE15
			= new DelegatedRule (R1_0__LATER, "shared-15", new RuleDelegate (Rule15));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the reference integrity of trade side
		/// party references.
		/// </summary>
        /// <remarks>Applies to FpML 4.2 thru 4.*.</remarks>
		public static readonly Rule	RULE16
			= new DelegatedRule (R4_2__R4_X, "shared-16", new RuleDelegate (Rule16));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the reference integrity of trade side
		/// account references.
		/// </summary>
		/// <remarks>Applies to FpML 4.2 thru 4.*.</remarks>
		public static readonly Rule	RULE17
			= new DelegatedRule (R4_2__R4_X, "shared-17", new RuleDelegate (Rule17));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all party instances represent unique
	    /// entities.
		/// account references.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE18
			= new DelegatedRule (R5_0__LATER, "shared-18", new RuleDelegate (Rule18));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all account instances represent unique
	    /// entities.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 thru 5.3.</remarks>
		public static readonly Rule	RULE19A
			= new DelegatedRule (R5_0__R5_3, "shared-19a", new RuleDelegate (Rule19A));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all account instances represent unique
	    /// entities.
		/// </summary>
		/// <remarks>Applies to FpML 5.4 and later.</remarks>
		public static readonly Rule	RULE19B
			= new DelegatedRule (R5_4__LATER, "shared-19b", new RuleDelegate (Rule19B));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all adjustable dates in a set are unique.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE20
			= new DelegatedRule (R5_0__LATER, "shared-20", new RuleDelegate (Rule20));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all account instances represent unique.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE21
			= new DelegatedRule (R5_0__LATER, "shared-21", new RuleDelegate (Rule21));

		/// <summary>
		/// A <see cref="Rule"/> that ensures calculation agent references are unique.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE22
			= new DelegatedRule (R5_0__LATER, "shared-22", new RuleDelegate (Rule22));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all reference bank references are unique.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE23
			= new DelegatedRule (R5_0__LATER, "shared-23", new RuleDelegate (Rule23));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all routing identifers are unique.
		/// </summary>
		/// <remarks>Applies to all FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE24
			= new DelegatedRule (R5_0__LATER, "shared-24", new RuleDelegate (Rule24));

		/// <summary>
		/// A <see cref="Rule"/> that ensures all step dates in a schedule are unique.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE25
			= new DelegatedRule (R5_0__LATER, "shared-25", new RuleDelegate (Rule25));

		/// <summary>
		/// A <see cref="Rule"/> that ensures a currency is specified when a bond has
        /// a par value.
		/// </summary>
		/// <remarks>Applies to FpML 5.0 and later.</remarks>
		public static readonly Rule	RULE26
			= new DelegatedRule (R5_0__LATER, "shared-26", new RuleDelegate (Rule26));

		/// <summary>
		/// A <see cref="Rule"/> that ensures the buyers and sellers are different.
		/// </summary>
		/// <remarks>Applies to all FpML versions.</remarks>
		public static readonly Rule	RULE29
			= new DelegatedRule (R1_0__LATER, "shared-29", new RuleDelegate (Rule29));

		/// <summary>
		/// The <see cref="RuleSet"/> used to hold the <see cref="Rule"/>
		/// instances.
		/// </summary>
		private static readonly RuleSet	rules = RuleSet.ForName ("SharedRules");

		/// <summary>
		/// Ensures that no instances can be constructed.
		/// </summary>
		private SharedRules ()
		{ }

		//---------------------------------------------------------------------

		private static bool Rule01 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
            if (nodeIndex.HasTypeInformation) {
	            String ns = nodeIndex.Document.DocumentElement.NamespaceURI;
	            return (Rule01 (name, nodeIndex.GetElementsByType (ns, "BusinessDayAdjustments"), errorHandler));					
            }
					
			return (
				Rule01 (name, nodeIndex.GetElementsByName ("dateAdjustments"), errorHandler)
			  & Rule01 (name, nodeIndex.GetElementsByName ("calculationPeriodDatesAdjustments"), errorHandler)
			  & Rule01 (name, nodeIndex.GetElementsByName ("paymentDatesAdjustments"), errorHandler)
		      & Rule01 (name, nodeIndex.GetElementsByName ("resetDatesAdjustments"), errorHandler));
		}
			
		private static bool Rule01 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Iff (
						Or (
							Exists (context ["businessCenters"]),
							Exists (context ["businessCentersReference"])),
						And (
							NotEqual (context ["businessDayConvention"], "NONE"),
							NotEqual (context ["businessDayConvention"], "NotApplicable"))))
					continue;

				errorHandler ("305", context,
					"Date adjustment contained business centers even though its business " +
					"day convention was set to " + context ["businessDayConvention"].InnerText,
					name, context ["businessDayConvention"].InnerText);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------
		
		private static bool Rule02 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				Rule02 (name, nodeIndex.GetElementsByName ("cashSettlementValuationDate"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("feePaymentDate"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("fixingDateOffset"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("fixingDates"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("initialFixingDate"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("paymentDaysOffset"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("rateCutOffDaysOffset"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("relativeDate"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("varyingNotionalInterimExchangePaymentDates"), errorHandler)
				& Rule02 (name, nodeIndex.GetElementsByName ("varyingNotionalFixingDates"), errorHandler));
		}

		private static bool Rule02 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Implies (
						Exists (context ["dayType"]),
						Equal (context ["period"], "D")))
					continue;

				errorHandler ("305", context,
					"Offset contains a day type but the period is '" +
					context ["period"].InnerText + "', not 'D'",
					name, context ["period"].InnerText);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule03 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule03 (name, nodeIndex.GetElementsByName ("cashSettlementValuationDate"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("feePaymentDate"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("fixingDateOffset"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("fixingDates"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("initialFixingDate"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("paymentDaysOffset"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("rateCutOffDaysOffset"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("relativeDate"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("varyingNotionalInterimExchangePaymentDates"), errorHandler)
				& Rule03 (name, nodeIndex.GetElementsByName ("varyingNotionalFixingDates"), errorHandler));
		}

		private static bool Rule03 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Implies (
						Equal (context ["dayType"], "Business"),
						NotEqual (context ["periodMultiplier"], 0)))
					continue;

				errorHandler ("305", context,
					"Offset has day type set to 'Business' but the period " +
					"multiplier is set to zero.",
					name, context ["periodMultiplier"].InnerText);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule04 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				Rule04 (name, nodeIndex.GetElementsByName ("cashSettlementValuationDate"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("feePaymentDate"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("fixingDateOffset"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("fixingDates"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("initialFixingDate"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("relativeDate"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("varyingNotionalFixingDates"), errorHandler)
				& Rule04 (name, nodeIndex.GetElementsByName ("varyingNotionalInterimExchangePaymentDates"), errorHandler));
		}

		private static bool Rule04 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Implies (
						Equal (context ["dayType"], "Business"),
						Equal (context ["businessDayConvention"], "NONE")))
					continue;

				errorHandler ("305", context,
					"Relative date offset has day type set to 'Business' but " +
					"the business day convention is not 'NONE'",
					name, context ["businessDayConvention"].InnerText);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule05 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule05 (name, nodeIndex.GetElementsByName ("payerPartyReference"), errorHandler));
		}

		private static bool Rule05 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
                XmlElement  receiver = context.ParentNode ["receiverPartyReference"];
                
				if (receiver == null) continue;
                
                if (Equal (context.GetAttribute ("href"), receiver.GetAttribute ("href"))) {
				    errorHandler ("305", context.ParentNode,
					    "payer and receiver party references must be different",
					    name, context.GetAttribute ("href"));

				    result = false;
                }
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule06 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule06 (name, nodeIndex.GetElementsByName ("americanExercise"), errorHandler));
		}

		private static bool Rule06 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				XmlElement	earliest	= XPath.Path (context, "earliestExerciseTime", "hourMinuteTime");
				XmlElement	latest		= XPath.Path (context, "latestExerciseTime", "hourMinuteTime");

				if ((earliest == null) || (latest == null) ||
					Less (ToTime (earliest), ToTime (latest))) continue;

				errorHandler ("305", context,
					"American exercise earliest exercise time " + earliest.InnerText +
					" must be before latest exercise time " + latest.InnerText,
					name, null);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule07 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule07 (name, nodeIndex.GetElementsByName ("bermudaExercise"), errorHandler));
		}

		private static bool Rule07 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				XmlElement	earliest = XPath.Path (context, "earliestExerciseTime", "hourMinuteTime");
				XmlElement	latest   = XPath.Path (context, "latestExerciseTime", "hourMinuteTime");

				if ((earliest == null) || (latest == null)) continue;
                
                Time t1 = ToTime(earliest);
                Time t2 = ToTime (latest);
                    
                if ((t1 == null) || (t2 == null) || Less (t1, t2))
					continue;

				errorHandler ("305", context,
					"Bermuda exercise earliest exercise time " + earliest.InnerText +
					" must be before latest exercise time " + latest.InnerText,
					name, null);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule08 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				Rule08 (name, nodeIndex.GetElementsByName ("businessDateRange"), errorHandler)
				& Rule08 (name, nodeIndex.GetElementsByName ("cashSettlementPaymentDate"), errorHandler)
			    & Rule08 (name, nodeIndex.GetElementsByName ("scheduleBounds"), errorHandler));
		}

		private static bool Rule08 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if ((context ["unadjustedFirstDate"] == null) ||
					(context ["unadjustedLastDate"] == null) ||
					Less (context ["unadjustedFirstDate"].InnerText,
							context ["unadjustedLastDate"].InnerText))
					continue;

				errorHandler ("305", context,
					"Date range's unadjusted first date " +
					context ["unadjustedFirstDate"].InnerText +
					" must be before unadjusted last date " +
					context ["unadjustedLastDate"].InnerText,
					name, null);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule09 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in nodeIndex.GetElementsByName ("cashSettlementPaymentDate"))
				result &= Rule09 (name, context.GetElementsByTagName ("businessDateRange"), errorHandler);

			return (result);
		}

		private static bool Rule09 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Iff (
						Or (
							Exists (context ["businessCenters"]),
							Exists (context ["businessCentersReference"])),
						And (
							NotEqual (context ["businessDayConvention"], "NONE"),
							NotEqual (context ["businessDayConvention"], "NotApplicable"))))
					continue;

				errorHandler ("305", context,
					"Business date range business day convention is '" +
					context ["businessDayConvention"].InnerText +
					"' but business centers have been included.",
					name, context ["businessDayConvention"].InnerText);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule10 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule10 (name, nodeIndex.GetElementsByName ("calculationAgent"), errorHandler));
		}

		private static bool Rule10 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				XmlNodeList agents = context.GetElementsByTagName ("calculationAgentPartyReference");

				for (int i = 0; i < (agents.Count - 1); ++i) {
					for (int j = i + 1; j < agents.Count; ++j) {
						if (Equal ((agents [i] as XmlElement).GetAttribute ("href"),
									(agents [j] as XmlElement).GetAttribute ("href"))) {
							errorHandler ("305", context,
								"Duplicate calculation agent reference",
								name, (agents [i] as XmlElement).GetAttribute ("href"));

							result = false;
						}
					}
				}
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule11 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule11 (name, nodeIndex.GetElementsByName ("businessDateRange"), errorHandler));
		}

		private static bool Rule11 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				XmlElement	referree = context ["businessCentersReference"];

				if (referree != null) {
					XmlElement	referred = referree.OwnerDocument.GetElementById (referree.GetAttribute ("href"));

					XmlNode common = XPath.CommonAncestor (referree, referred);
					if ((common != null) && common.Name.Equals ("trade"))
						continue;
			
					errorHandler ("305", context,
						"Business centers reference " +	context.GetAttribute ("href") +
						" in date range does not reference business centers in the same trade.",
						name, context.GetAttribute ("href"));

					result = false;
				}
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule12_XLINK (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule12_XLINK (name, nodeIndex.GetElementsByName ("buyerPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule12_XLINK (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");

				if ((href == null) || (href.Length < 2) || (href [0] != '#')) {
					errorHandler ("305", context,
						"The @href attribute is not a valid XPointer",
						name, href);
					result = false;
					continue;
				}

				XmlElement	referred = nodeIndex.GetElementById (href.Substring (1));

				if ((referred != null) && (referred.LocalName.Equals ("party") || referred.LocalName.Equals ("tradeSide"))) continue;

				errorHandler ("305", context,
					"Buyer party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}
		//---------------------------------------------------------------------

		private static bool Rule12 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule12 (name, nodeIndex.GetElementsByName ("buyerPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule12 (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");
				XmlElement	referred = nodeIndex.GetElementById (href);

				if ((referred != null) && (referred.LocalName.Equals ("party") || referred.LocalName.Equals ("tradeSide"))) continue;

				errorHandler ("305", context,
					"Buyer party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule13_XLINK (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule13_XLINK (name, nodeIndex.GetElementsByName ("sellerPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule13_XLINK (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");

				if ((href == null) || (href.Length < 2) || (href [0] != '#')) {
					errorHandler ("305", context,
						"The @href attribute is not a valid XPointer",
						name, href);
					result = false;
					continue;
				}

				XmlElement	referred = nodeIndex.GetElementById (href.Substring (1));

				if ((referred != null) && (referred.LocalName.Equals ("party") || referred.LocalName.Equals ("tradeSide"))) continue;

				errorHandler ("305", context,
					"Seller party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule13 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule13 (name, nodeIndex.GetElementsByName ("sellerPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule13 (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");
				XmlElement	referred = nodeIndex.GetElementById (href);

				if ((referred != null) && (referred.LocalName.Equals ("party") || referred.LocalName.Equals ("tradeSide"))) continue;

				errorHandler ("305", context,
					"Seller party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule14_XLINK (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule14_XLINK (name, nodeIndex.GetElementsByName ("calculationAgentPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule14_XLINK (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");

				if ((href == null) || (href.Length < 2) || (href [0] != '#')) {
					errorHandler ("305", context,
						"The @href attribute is not a valid XPointer",
						name, href);
					result = false;
					continue;
				}

				XmlElement	referred = nodeIndex.GetElementById (href.Substring (1));

				if ((referred != null) && referred.LocalName.Equals ("party")) continue;

				errorHandler ("305", context,
					"Calculation agent party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule14 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule14 (name, nodeIndex.GetElementsByName ("calculationAgentPartyReference"), errorHandler, nodeIndex));
		}

		private static bool Rule14 (string name, XmlNodeList list, ValidationErrorHandler errorHandler, NodeIndex nodeIndex)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				string		href	 = context.GetAttribute ("href");
				XmlElement	referred = nodeIndex.GetElementById (href);

				if ((referred != null) && referred.LocalName.Equals ("party")) continue;

				errorHandler ("305", context,
					"Calculation agent party reference '" + context.GetAttribute ("href") +
					"' does not match a party defined in the document.",
					name, context.GetAttribute ("href"));

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule15 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				Rule15 (name, nodeIndex.GetElementsByName ("gracePeriod"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("paymentDaysOffset"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("rateCutOffDaysOffset"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("relativeDate"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("fixingDateOffset"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("initialFixingDate"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("fixingDates"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("cashSettlementValuationDate"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("varyingNotionalInterimExchangePaymentDates"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("varyingNotionalFixingDates"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("feePaymentDate"), errorHandler)
				& Rule15 (name, nodeIndex.GetElementsByName ("relativeDates"), errorHandler));
		}

		private static bool Rule15 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
				if (Iff (
						Exists (context ["dayType"]),
						And (					
					        Equal (context ["period"], "D"),
							NotEqual (context ["periodMultiplier"], 0))))
						continue;

				errorHandler ("305", context,
					"daytype must only be present if and only if the period " +
					"is 'D' and the periodMultiplier is non-zero",
					name, null);

				result = false;
			}
			return (result);
		}

		//---------------------------------------------------------------------

		private static bool Rule16 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in XPath.Paths (nodeIndex.GetElementsByName ("tradeSide"), "*", "party")) {
				string		href	= context.GetAttribute ("href");
				XmlElement	target	= nodeIndex.GetElementById (href);

				if (target.LocalName.Equals ("party")) continue;

				errorHandler ("305", context,
					"The value of the href attribute does not refer to a party structure",
					name, href);

				result = false;
			}
			return (result);
		}
		
		//---------------------------------------------------------------------

		private static bool Rule17 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in XPath.Paths (nodeIndex.GetElementsByName ("tradeSide"), "*", "account")) {
				string		href	= context.GetAttribute ("href");
				XmlElement	target  = nodeIndex.GetElementById (href);

				if (target.LocalName.Equals ("account")) continue;

				errorHandler ("305", context,
					"The value of the href attribute does not refer to an account structure",
					name, href);

				result = false;
			}
			return (result);
		}

  		//---------------------------------------------------------------------

        private static bool Rule18 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
        {
            if (nodeIndex.HasTypeInformation)
                return (Rule18 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "Party"), errorHandler));
            return (Rule18 (name, nodeIndex.GetElementsByName ("party"), errorHandler));
        }

        private static bool Rule18 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
        {
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();
			List<String>    names = new List<String> ();

            foreach (XmlElement context in list) {
                XmlElement  partyId     = XPath.Path (context, "partyId");
                XmlElement  partyName   = XPath.Path (context, "partyName");

                if (partyId != null) {
                    Identifier  identifier = new Identifier (partyId, "partyIdScheme");

                    if (identifiers.Contains (identifier)) {
                        errorHandler ("305", context,
                            "Party identifiers must be unique",
                            name, identifier.ToString ());
                        result = false;
                    }
                    else
	                    identifiers.Add (identifier);
                }

				// The FpML rule should not include this part
	            if (partyName != null) {
                    string      text = partyName.InnerText;

                    if (names.Contains (text)) {
                        errorHandler ("305", context,
                            "Party names must be unique",
                            name, text);
                        result = false;
                    }
                    else
                        names.Add (text);
                }
            }

            identifiers.Clear ();
            names.Clear ();

            return (result);
        }

        //---------------------------------------------------------------------

        private static bool Rule19A (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
        {
            if (nodeIndex.HasTypeInformation)
                return (Rule19A (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "Account"), errorHandler));
            return (Rule19A (name, nodeIndex.GetElementsByName ("account"), errorHandler));
        }

        private static bool Rule19A (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
        {
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();
			List<String>    names = new List<String> ();

            foreach (XmlElement context in list) {
                XmlElement  accountId     = XPath.Path (context, "accountId");
                XmlElement  accountName   = XPath.Path (context, "accountName");

                if (accountId != null) {
                    Identifier  identifier = new Identifier (accountId, "accountIdScheme");

                    if (identifiers.Contains (identifier)) {
                        errorHandler ("305", context,
                            "Account identifiers must be unique",
                            name, identifier.ToString ());
                        result = false;
                    }
                    else
	                    identifiers.Add (identifier);
                }

				// The FpML rule should not include this part
	            if (accountName != null) {
                    string      text = accountName.InnerText;

                    if (names.Contains (text)) {
                        errorHandler ("305", context,
                            "Account names must be unique",
                            name, text);
                        result = false;
                    }
                    else
                        names.Add (text);
                }
            }

            identifiers.Clear ();
            names.Clear ();

            return (result);
        }

        //---------------------------------------------------------------------

        private static bool Rule19B (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
        {
            if (nodeIndex.HasTypeInformation)
                return (Rule19B (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "Account"), errorHandler));
            return (Rule19B (name, nodeIndex.GetElementsByName ("account"), errorHandler));
        }

        private static bool Rule19B (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
        {
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();

            foreach (XmlElement context in list) {
                XmlElement  accountId     = XPath.Path (context, "accountId");

                if (accountId != null) {
                    Identifier  identifier = new Identifier (accountId, "accountIdScheme");

                    if (identifiers.Contains (identifier)) {
                        errorHandler ("305", context,
                            "Account identifiers must be unique",
                            name, identifier.ToString ());
                        result = false;
                    }
                    else
	                    identifiers.Add (identifier);
                }
            }
            identifiers.Clear ();

            return (result);
        }

        //---------------------------------------------------------------------

		private static bool Rule20 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule20 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "AdjustableDates"), errorHandler));

            return (
				  Rule20 (name, nodeIndex.GetElementsByName ("adjustableDates"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("calculationPeriods"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("fixingDates"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("fxFixingSchedule"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("fxObservationDates"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("paymentDates"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("periods"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("pricingDates"), errorHandler));
		}
		
		private static bool Rule20 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool    		result	= true;
			List<Date>	    dates	= new List<Date> ();
			
			foreach (XmlElement context	in list) {
				XmlNodeList		nodes	= XPath.Paths (context, "unadjustedDate");
				
				foreach (XmlElement node in nodes) {
					Date			date 	= Types.ToDate (node);
					
					if (dates.Contains (date)) {
						errorHandler ("305", node,
							"Duplicate unadjustedDate",
							name, date.ToString ());
						result = false;
					}
					else
						dates.Add (date);
				}
				
				dates.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule21 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule21 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "BusinessCenters"), errorHandler));
			return (Rule21 (name, nodeIndex.GetElementsByName ("businessCenters"), errorHandler));
		}
		
		private static bool Rule21 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();
			
			foreach (XmlElement context in list) {
				XmlNodeList	nodes		= XPath.Paths (context, "businessCenter");
				
				foreach (XmlElement node in nodes) {
					Identifier	identifier  = new Identifier (node, "businessCenterScheme");
					
					if (identifiers.Contains (identifier)) {
						errorHandler ("305", node,
							"Duplicate business center",
							name, identifier.ToString ());
						result = false;
					}
					else
						identifiers.Add (identifier);
				}
				identifiers.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule22 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule22 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "CalculationAgent"), errorHandler));
			return (Rule22 (name, nodeIndex.GetElementsByName ("calculationAgent"), errorHandler));
		}
		
		private static bool Rule22 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool			result	= true;
			List<String>	idrefs	= new List<String> ();

			foreach (XmlElement context in list) {
				XmlNodeList		nodes	= XPath.Paths (context, "calculationAgentPartyReference");
				
				foreach (XmlElement node in nodes) {
					String			idref	= node.GetAttribute ("href");
					
					if (idrefs.Contains (idref)) {
						errorHandler ("305", node,
							"Duplicate calculationAgentPartyReference",
							name, idref);
						result = false;
					}
					else
						idrefs.Add (idref);
				}
				idrefs.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule23 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule23 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "CashSettlementReferenceBanks"), errorHandler));
			return (Rule23 (name, nodeIndex.GetElementsByName ("cashSettlementReferenceBanks"), errorHandler));
		}
		
		private static bool Rule23 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();
			
			foreach (XmlElement context in list) {
				XmlNodeList	nodes		= XPath.Paths (context, "referenceBank", "referenceBankId");
				
				foreach (XmlElement node in nodes) {
					Identifier	identifier  = new Identifier (node, "referenceBankIdScheme");
					
					if (identifiers.Contains (identifier)) {
						errorHandler ("305", node,
							"Duplicate reference bank Id",
							name, identifier.ToString ());
						result = false;
					}
					else
						identifiers.Add (identifier);
				}
				identifiers.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule24 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule24 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RoutingIds"), errorHandler));
			return (Rule24 (name, nodeIndex.GetElementsByName ("routingIds"), errorHandler));
		}
		
		private static bool Rule24 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool			result	= true;
			List<Identifier> identifiers = new List<Identifier> ();
			
			foreach (XmlElement context in list) {
				XmlNodeList	nodes		= XPath.Paths (context, "routingId");
				
				foreach (XmlElement node in nodes) {
					Identifier	identifier  = new Identifier (node, "routingIdCodeScheme");
					
					if (identifiers.Contains (identifier)) {
						errorHandler ("305", node,
							"Duplicate routing Id",
							name, identifier.ToString ());
						result = false;
					}
					else
						identifiers.Add (identifier);
				}
				identifiers.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule25 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule25 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "Schedule"), errorHandler));
			
			return (
				  Rule25 (name, nodeIndex.GetElementsByName ("floatingRateMultiplierSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("spreadSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("fixedRateSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("feeRateSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("capRateSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("floorRateSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("knownAmountSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("notionalStepSchedule"), errorHandler)
				& Rule25 (name, nodeIndex.GetElementsByName ("feeAmountSchedule"), errorHandler));
		}
		
		private static bool Rule25 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool			result	= true;
			List<Date> 	    dates = new List<Date> ();
			
			foreach (XmlElement context in list) {
				XmlNodeList	nodes		= XPath.Paths (context, "step", "stepDate");
				
				foreach (XmlElement node in nodes) {
					Date		date	  	= Types.ToDate (node);
					
					if (dates.Contains (date)) {
						errorHandler ("305", node,
							"Duplicate step date",
							name, date.ToString ());
						result = false;
					}
					else
						dates.Add (date);
				}
				dates.Clear ();
			}
			return (result);
		}

        //---------------------------------------------------------------------

		private static bool Rule26 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule26 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "Bond"), errorHandler));
			return (Rule26 (name, nodeIndex.GetElementsByName ("bond"), errorHandler));
		}
		
		private static bool Rule26 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement context in list) {
				XmlElement	parValue = XPath.Path (context, "parValue");
				XmlElement	currency = XPath.Path (context, "currency");
				
				if ((parValue == null) || (currency != null)) continue;
				
				errorHandler ("305", context,
					"If parValue is present then the currency must be specified",
					name, null);
				result = false;				
			}
			
			return (result);
		}

        //---------------------------------------------------------------------

        private static bool Rule29 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule29 (name, nodeIndex.GetElementsByName ("buyerPartyReference"), errorHandler));
		}

		private static bool Rule29 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result = true;

			foreach (XmlElement context in list) {
                XmlElement  seller = context.ParentNode ["sellerPartyReference"];
                
				if (seller == null) continue;
                
                if (Equal (context.GetAttribute ("href"), seller.GetAttribute ("href"))) {
				    errorHandler ("305", context.ParentNode,
					    "buyer and seller party references must be different",
					    name, context.GetAttribute ("href"));

				    result = false;
                }
			}
			return (result);
		}
	}
}