// Copyright (C),2005-2016 HandCoded Software Ltd.
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
using System.Xml;

using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>EqdRules</b> class contains a <see cref="RuleSet"/> that holds
	/// all of the defined validation <see cref="Rule"/> instances for Equity
	/// Derivative Products.
	/// </summary>
	public sealed class EqdRules : FpMLRuleSet
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
        /// A <see cref="Precondition"/> instance that detects documents containing
	    /// at least one equity derivative product.
        /// </summary>
	    private static readonly Precondition	EQD_PRODUCTS
		    = new ContentPrecondition (
				    new String [] {
						    "equityOption",
						    "equityForward",
						    "brokerEquityOption",
						    "returnSwap",
						    "equitySwapTransactionSupplement",
						    "varianceOptionTransactionSupplement",
						    "varianceSwap",
						    "varianceSwapTransactionSupplement"
				    },
				    new String [] {
						    "EquityOption",
						    "EquityForward",
						    "BrokerEquityOption",
						    "ReturnSwap",
						    "EquitySwapTransactionSupplement",
						    "VarianceOptionTransactionSupplement",
						    "VarianceSwap",
						    "VarianceSwapTransactionSupplement"
				    });

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 4.0 or later
	    /// confirmation document containing at least one equity derivative product.
        /// </summary>
	    private static readonly Precondition R4_0__LATER
		    = Precondition.And (new Precondition [] {
				    EQD_PRODUCTS,
				    Preconditions.R4_0__LATER,
				    Preconditions.CONFIRMATION });
    	
        /// <summary>
	    /// A <see cref="Precondition"/> instance that detects any FpML 4.*
	    /// confirmation document containing at least one equity derivative product.
        /// </summary>
	    private static readonly Precondition R4_0__R4_X
		    = Precondition.And (new Precondition [] {
				    EQD_PRODUCTS,
				    Preconditions.R4_0__R4_X,
				    Preconditions.CONFIRMATION });
	
		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted expiration
		/// date is after the trade date for american options.
		/// </summary>
		public static readonly Rule	RULE02
			= new DelegatedRule (R4_0__LATER, "eqd-2", new RuleDelegate (Rule02));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted expiration
		/// date is after the trade date for american options.
		/// </summary>
		public static readonly Rule	RULE02B
			= new DelegatedRule (R4_0__R4_X, "eqd-2b", new RuleDelegate (Rule02B));

        /// <summary>
		/// A <see cref="Rule"/> instance that ensures the latest exercise time is
		/// after the earliest exercise time for american options.
		/// </summary>
		public static readonly Rule	RULE03
			= new DelegatedRule (R4_0__LATER, "eqd-3", new RuleDelegate (Rule03));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted commencement
		/// date is the same as the trade date for bermudan options.
		/// </summary>
		public static readonly Rule	RULE04
			= new DelegatedRule (R4_0__LATER, "eqd-4", new RuleDelegate (Rule04));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted commencement
		/// date is the same as the trade date for bermudan options.
		/// </summary>
		public static readonly Rule	RULE04B
			= new DelegatedRule (R4_0__R4_X, "eqd-4b", new RuleDelegate (Rule04B));

        /// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted expiration
		/// date is after the trade date for bermudan options.
		/// </summary>
		public static readonly Rule	RULE05
			= new DelegatedRule (R4_0__LATER, "eqd-5", new RuleDelegate (Rule05));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the latest exercise time is
		/// after the earliest exercise time for bermudan options.
		/// </summary>
		public static readonly Rule	RULE06
			= new DelegatedRule (R4_0__LATER, "eqd-6", new RuleDelegate (Rule06));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures bermudan exercise dates are
		/// in order.
		/// </summary>
		/// <remarks>Deprecated.</remarks>
		public static readonly Rule	RULE07
			= new DelegatedRule (R4_0__LATER, "eqd-7", new RuleDelegate (Rule07));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures bermudan exercise dates are
		/// after commencement.
		/// </summary>
		public static readonly Rule	RULE08
			= new DelegatedRule (R4_0__LATER, "eqd-8", new RuleDelegate (Rule08));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures bermudan exercise dates are
		/// before expiry.
		/// </summary>
		public static readonly Rule	RULE09
			= new DelegatedRule (R4_0__LATER, "eqd-9", new RuleDelegate (Rule09));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensurse bermudan exercise dates are
		/// unique.
		/// </summary>
		public static readonly Rule	RULE10
			= new DelegatedRule (R4_0__LATER, "eqd-10", new RuleDelegate (Rule10));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the unadjusted expiration
		/// date is after the trade date for bermudan options.
		/// </summary>
		public static readonly Rule	RULE12
			= new DelegatedRule (R4_0__LATER, "eqd-12", new RuleDelegate (Rule12));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures equity option premium payment
		/// date is on or after the trade date.
		/// </summary>
		public static readonly Rule	RULE13
			= new DelegatedRule (R4_0__LATER, "eqd-13", new RuleDelegate (Rule13));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures broker equity option premium
		/// payment date is on or after the trade date.
		/// </summary>
		public static readonly Rule	RULE14
			= new DelegatedRule (R4_0__LATER, "eqd-14", new RuleDelegate (Rule14));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures European option valuation
		/// date is the same as the expiration date.
		/// </summary>
		public static readonly Rule	RULE15
			= new DelegatedRule (R4_0__LATER, "eqd-15", new RuleDelegate (Rule15));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the number of options in
		/// a multiple exercise American option is correct.
		/// </summary>
		public static readonly Rule	RULE17
			= new DelegatedRule (R4_0__LATER, "eqd-17", new RuleDelegate (Rule17));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the number of options in
		/// a multiple exercise Bermudan option is correct.
		/// </summary>
		public static readonly Rule	RULE18
			= new DelegatedRule (R4_0__LATER, "eqd-18", new RuleDelegate (Rule18));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures premium is the correct
		/// percentage of notional.
		/// </summary>
		public static readonly Rule	RULE19
			= new DelegatedRule (R4_0__LATER, "eqd-19", new RuleDelegate (Rule19));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the payment amount is correct.
		/// </summary>
		public static readonly Rule	RULE20
			= new DelegatedRule (R4_0__LATER, "eqd-20", new RuleDelegate (Rule20));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the calculationAgentPartyReference
		/// is present.
		/// </summary>
		public static readonly Rule	RULE21
			= new DelegatedRule (R4_0__LATER, "eqd-21", new RuleDelegate (Rule21));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the BuyerPartyReference is
		/// different from the SellerPartyReference.
		/// </summary>
		public static readonly Rule	RULE22
			= new DelegatedRule (R4_0__LATER, "eqd-22", new RuleDelegate (Rule22));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the effective date is the
		/// same or later than the trade date.
		/// </summary>
		public static readonly Rule	RULE23
			= new DelegatedRule (R4_0__LATER, "eqd-23", new RuleDelegate (Rule23));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the end date is the same or after
		/// the start date.
		/// </summary>
		public static readonly Rule	RULE24
			= new DelegatedRule (R4_0__LATER, "eqd-24", new RuleDelegate (Rule24));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the payment amount is calculated
		/// correctly.
		/// </summary>
		public static readonly Rule	RULE25
			= new DelegatedRule (R4_0__LATER, "eqd-25", new RuleDelegate (Rule25));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures you cannot exercise more
	    /// options than are defined in the product.
		/// </summary>
		public static readonly Rule	RULE26
			= new DelegatedRule (R4_0__LATER, "eqd-26", new RuleDelegate (Rule26));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures you cannot exercise more
	    /// options than are defined in the product.
		/// </summary>
		public static readonly Rule	RULE26B
			= new DelegatedRule (R4_0__LATER, "eqd-26b", new RuleDelegate (Rule26B));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the minimum number of options
	    /// exercisable is less than the maximum number.
		/// </summary>
		public static readonly Rule	RULE27
			= new DelegatedRule (R4_0__LATER, "eqd-27", new RuleDelegate (Rule27));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the minimum number of options
	    /// is an integer multiple of an integral quantity.
		/// </summary>
		public static readonly Rule	RULE28
			= new DelegatedRule (R4_0__LATER, "eqd-28", new RuleDelegate (Rule28));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures the maximum number of options
	    /// is an integer multiple of an integral quantity.
		/// </summary>
		public static readonly Rule	RULE29
			= new DelegatedRule (R4_0__LATER, "eqd-29", new RuleDelegate (Rule29));

		/// <summary>
		/// A <see cref="Rule"/> instance that ensures forward started options
	    /// have an effective date later than the trade date.
		/// </summary>
		public static readonly Rule	RULE31
			= new DelegatedRule (R4_0__LATER, "eqd-31", new RuleDelegate (Rule31));

		/// <summary>
		/// The <see cref="RuleSet"/> used to hold the <see cref="Rule"/>
		/// instances.
		/// </summary>
		private static readonly RuleSet	rules = RuleSet.ForName ("EqdRules");

		/// <summary>
		/// Ensures that no instances can be constructed.
		/// </summary>
		private EqdRules ()
		{ }

		// --------------------------------------------------------------------

		private static bool Rule02 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule02 (name, nodeIndex.GetElementsByName ("equityAmericanExercise"), errorHandler));
		}

		private static bool Rule02 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	expiration	= XPath.Path (context, "expirationDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "tradeHeader", "tradeDate");

				if ((expiration == null) || (trade == null) || GreaterOrEqual (Types.ToDate (expiration), Types.ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "American exercise expiration date " + ToToken (expiration) +
                    " should be the same or later than trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule02B (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule02B (name, nodeIndex.GetElementsByName ("equityAmericanExercise"), errorHandler));
		}

		private static bool Rule02B (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	expiration	= XPath.Path (context, "expirationDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "header", "contractDate");

				if ((expiration == null) || (trade == null) || GreaterOrEqual (Types.ToDate (expiration), Types.ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "American exercise expiration date " + ToToken (expiration) +
                    " should be the same or later than trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

        // --------------------------------------------------------------------

		private static bool Rule03 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule03 (name, nodeIndex.GetElementsByName ("equityAmericanExercise"), errorHandler));
		}

		private static bool Rule03 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				if (Implies (
						Equal (XPath.Path (context, "latestExerciseTimeType"), "SpecificTime"),
						Exists (XPath.Path (context, "latestExerciseTime"))))
					continue;

				errorHandler ("305", context,
					"American exercise structure should include a latest " +
					"exercise time, since time type is set to SpecificTime",
					name, null);
			
				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule04 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule04 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule04 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	commence	= XPath.Path (context, "commencementDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "tradeHeader", "tradeDate");

				if ((commence == null) || (trade == null) || GreaterOrEqual (Types.ToDate (commence), Types.ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise commencement date " + ToToken (commence) +
                    " should not be before the trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule04B (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule04B (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule04B (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	commence	= XPath.Path (context, "commencementDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "header", "contractDate");

				if ((commence == null) || (trade == null) || GreaterOrEqual (Types.ToDate (commence), Types.ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise commencement date " + ToToken (commence) +
                    " should not be before the trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule05 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule05 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule05 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	expiration	= XPath.Path (context, "expirationDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "tradeHeader", "tradeDate");

				if ((expiration == null) || (trade == null) || GreaterOrEqual (Types.ToDate (expiration), Types.ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise expiration date " + ToToken (expiration) +
                    " should not be before trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule06 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule06 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule06 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				if (Implies (
						Equal (XPath.Path (context, "latestExerciseTimeType"), "SpecificTime"),
						Exists (XPath.Path (context, "latestExerciseTime"))))
					continue;

				errorHandler ("305", context,
					"Bermuda exercise structure should include a latest " +
					"exercise time, since time type is set to SpecificTime",
					name, null);
			
				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule07 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule07 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule07 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in XPath.Paths (list, "bermudaExerciseDates", "date")) {
				XmlElement		next	= DOM.GetNextSibling (context);

				if ((next == null) || Less (Types.ToDate (context), Types.ToDate (next)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise dates " + ToToken (context) + " and " +
                    ToToken (next) + " are not in order",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule08 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule08 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule08 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in XPath.Paths (list, "bermudaExerciseDates", "date")) {
				XmlElement	commence	= XPath.Path (context, "..", "..", "commencementDate", "adjustableDate", "unadjustedDate");

				if ((commence == null) || Greater (Types.ToDate (context), Types.ToDate (commence)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise date " + ToToken (context) +
					" should be after exercise period commencement date " +
                    ToToken (commence),
					name, null);
								
				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule09 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule09 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule09 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in XPath.Paths (list, "bermudaExerciseDates", "date")) {
				XmlElement	expiration	= XPath.Path (context, "..", "..", "expirationDate", "adjustableDate", "unadjustedDate");

				if ((expiration == null) || LessOrEqual (ToDate (context), ToDate (expiration)))
					continue;

				errorHandler ("305", context,
                    "Bermuda exercise date " + ToToken (context) +
					" should be on or before exercise period expiration date " +
                    ToToken (expiration),
					name, null);
								
				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule10 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule10 (name, nodeIndex.GetElementsByName ("equityBermudaExercise"), errorHandler));
		}

		private static bool Rule10 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in XPath.Paths (list, "bermudaExerciseDates", "date")) {
				XmlElement	other	= DOM.GetNextSibling (context);

				for (; other != null; other = DOM.GetNextSibling (other)) {
					if (NotEqual (ToDate (context), ToDate (other))) continue;

					errorHandler ("305", context,
                        "Duplicate bermuda exercise date, " + ToToken (other),
                        name, ToToken (other));

					result = false;
				}
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule12 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule12 (name, nodeIndex.GetElementsByName ("equityEuropeanExercise"), errorHandler));
		}

		private static bool Rule12 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	expiration	= XPath.Path (context, "expirationDate", "adjustableDate", "unadjustedDate");
				XmlElement	trade		= XPath.Path (context, "..", "..", "..", "tradeHeader", "tradeDate");

				if ((expiration == null) || (trade == null) || GreaterOrEqual (ToDate (expiration), ToDate (trade)))
					continue;

				errorHandler ("305", context,
                    "European exercise expiration date " + ToToken (expiration) +
                    " should not be before the trade date " + ToToken (trade),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule13 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule13 (name, nodeIndex.GetElementsByName ("trade"), errorHandler));
		}

		private static bool Rule13 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	premiumDate	= XPath.Path (context, "equityOption", "equityPremium", "paymentDate", "unadjustedDate");
				XmlElement	tradeDate	= XPath.Path (context, "tradeHeader", "tradeDate");

				if ((premiumDate == null) || (tradeDate == null) || GreaterOrEqual (ToDate (premiumDate), ToDate (tradeDate)))
					continue;

				errorHandler ("305", context,
                    "Equity premium payment date " + ToToken (premiumDate) +
                    " must be on or after trade date " + ToToken (tradeDate),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule14 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule14 (name, nodeIndex.GetElementsByName ("trade"), errorHandler));
		}

		private static bool Rule14 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	premiumDate	= XPath.Path (context, "brokerEquityOption", "equityPremium", "paymentDate", "unadjustedDate");
				XmlElement	tradeDate	= XPath.Path (context, "tradeHeader", "tradeDate");

				if ((premiumDate == null) || (tradeDate == null) || GreaterOrEqual (ToDate (premiumDate), ToDate (tradeDate)))
					continue;

				errorHandler ("305", context,
                    "Broker equity premium payment date " + ToToken (premiumDate) +
                    " must be on or after trade date " + ToToken (tradeDate),
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule15 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule15 (name, nodeIndex.GetElementsByName ("equityExercise"), errorHandler));
		}

		private static bool Rule15 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	valuationDate	= XPath.Path (context, "equityValuation", "valuationDate", "adjustableDate", "unadjustedDate");
				XmlElement	expirationDate	= XPath.Path (context, "equityEuropeanExercise", "expirationDate", "adjustableDate", "unadjustedDate");

				if ((valuationDate == null) || (expirationDate == null) || Equal (ToDate (valuationDate), ToDate (expirationDate)))
					continue;

				errorHandler ("305", context,
					"The valuation and expiration dates for a European option must be same",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule17 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule17 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule17 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler));
		}

		private static bool Rule17 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	multiple	= XPath.Path (context, "equityExercise", "equityAmericanExercise", "equityMultipleExercise");
				XmlElement	number		= XPath.Path (context, "numberOfOptions");

				if ((multiple == null) || (number == null)) continue;

				XmlElement	integral	= XPath.Path (multiple, "integralMultipleExercise");
				XmlElement	maximum		= XPath.Path (multiple, "maximumNumberOfOptions");

				if ((integral == null) || (maximum == null) || GreaterOrEqual (ToDecimal (integral) * ToDecimal (maximum), ToDecimal (number)))
					continue;

				errorHandler ("305", context,
					"maximumNumberOfOptions * integralMultipleExercise should " +
					"not be greater than numberOfOptions",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule18 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule18 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule18 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler));
		}

		private static bool Rule18 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	multiple	= XPath.Path (context, "equityExercise", "equityBermudaExercise", "equityMultipleExercise");
				XmlElement	number		= XPath.Path (context, "numberOfOptions");

				if ((multiple == null) || (number == null)) continue;

				XmlElement	integral	= XPath.Path (multiple, "integralMultipleExercise");
				XmlElement	maximum		= XPath.Path (multiple, "maximumNumberOfOptions");

				if ((integral == null) || (maximum == null) || LessOrEqual (ToDecimal (integral) * ToDecimal (maximum), ToDecimal (number)))
					continue;

				errorHandler ("305", context,
					"maximumNumberOfOptions * integralMultipleExercise should " +
					"not be greater than numberOfOptions",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule19 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule19 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule19 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler));
		}

		private static bool Rule19 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	notionalCcy	= XPath.Path (context, "notional", "currency");
				XmlElement	paymentCcy	= XPath.Path (context, "equityPremium", "paymentAmount", "currency");

				if ((notionalCcy == null) || (paymentCcy == null) || !IsSameCurrency (notionalCcy, paymentCcy)) continue;

				XmlElement	totalValue	= XPath.Path (context, "notional", "amount");
				XmlElement	percentage	= XPath.Path (context, "equityPremium", "percentageOfNotional");
				XmlElement	amount		= XPath.Path (context, "equityPremium", "paymentAmount", "amount");

				if ((totalValue == null) || (percentage == null) || (amount == null) ||
					Equal (Round (ToDecimal (amount), 2), Round (ToDecimal (totalValue) * ToDecimal (percentage), 2)))
					continue;

				errorHandler ("305", context,
					"The equity premium amount does not agree with the figures given for " +
					"the notional and premium percentage",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule20 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule20 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule20 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler));
		}

		private static bool Rule20 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	priceCcy	= XPath.Path (context, "equityPremium", "pricePerOption", "currency");
				XmlElement	paymentCcy	= XPath.Path (context, "equityPremium", "paymentAmount", "currency");

				if ((priceCcy == null) || (paymentCcy == null) || !IsSameCurrency (priceCcy, paymentCcy)) continue;

				XmlElement	number		= XPath.Path (context, "numberOfOptions");
				XmlElement	entitlement	= XPath.Path (context, "optionEntitlement");
				XmlElement	priceEach	= XPath.Path (context, "equityPremium", "pricePerOption", "amount");
				XmlElement	amount		= XPath.Path (context, "equityPremium", "paymentAmount", "amount");

				if ((number == null) || (entitlement == null) || (priceEach == null) || (amount == null) ||
					Equal (Round (ToDecimal (amount), 2), Round (ToDecimal (priceEach) * ToDecimal (number) * ToDecimal (entitlement), 2)))
					continue;

				errorHandler ("305", context,
					"The equity premium amount does not agree with the figures given for " +
					"the number of options, price per option and entitlement",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule21 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule21 (name, nodeIndex.GetElementsByName ("calculationAgent"), errorHandler));
		}

		private static bool Rule21 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				if (!context.ParentNode.LocalName.Equals ("trade")) continue;

				if (Exists (
						XPath.Path (context, "calculationAgentPartyReference")))
					continue;

				errorHandler ("305", context,
					"Calculation agent field must contain a calculation agent party reference",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule22 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule22 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule22 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler)
				& Rule22 (name, nodeIndex.GetElementsByName ("equityForward"), errorHandler));
		}

		private static bool Rule22 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	buyer	= XPath.Path (context, "buyerPartyReference");
				XmlElement	seller	= XPath.Path (context, "sellerPartyReference");

				if ((buyer == null) || (seller == null) ||
					NotEqual (buyer.GetAttribute ("href"), seller.GetAttribute ("href")))
					continue;
		
				errorHandler ("305", context,
					"The buyerPartyReference/@href must not be the same as the " +
					"sellerPartyReference/@href",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule23 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (
				  Rule23 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule23 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler)
				& Rule23 (name, nodeIndex.GetElementsByName ("equityForward"), errorHandler));
		}

		private static bool Rule23 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	effectiveDate	= XPath.Path (context, "equityEffectiveDate");
				XmlElement	tradeDate		= XPath.Path (context, "..", "tradeHeader", "tradeDate");

				if ((effectiveDate == null) || (tradeDate == null) ||
						GreaterOrEqual (Types.ToDate (effectiveDate), Types.ToDate (tradeDate)))
					continue;

				errorHandler ("305", context,
					"The equity effective date must be on or after the trade date",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule24 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule24 (name, nodeIndex.GetElementsByName ("schedule"), errorHandler));
		}

		private static bool Rule24 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	startDate	= XPath.Path (context, "startDate");
				XmlElement	endDate		= XPath.Path (context, "endDate");

				if ((startDate == null) || (endDate == null) ||
						LessOrEqual (Types.ToDate (startDate), Types.ToDate (endDate)))
					continue;

				errorHandler ("305", context,
					"The equity schedule start date can not be after the end date",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

		private static bool Rule25 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			return (Rule25 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler));
		}

		private static bool Rule25 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;

			foreach (XmlElement context in list) {
				XmlElement	priceCcy	= XPath.Path (context, "equityPremium", "pricePerOption", "currency");
				XmlElement	paymentCcy	= XPath.Path (context, "equityPremium", "paymentAmount", "currency");

				if (!IsSameCurrency (priceCcy, paymentCcy)) continue;

				XmlElement	number		= XPath.Path (context, "numberOfOptions");
				XmlElement	priceEach	= XPath.Path (context, "equityPremium", "pricePerOption", "amount");
				XmlElement	amount		= XPath.Path (context, "equityPremium", "paymentAmount", "amount");

				if ((number == null) || (priceEach == null) || (amount == null) ||
					Equal (Round (ToDecimal (amount), 2), Round (ToDecimal (priceEach) * ToDecimal (number), 2)))
					continue;

				errorHandler ("305", context,
					"The equity premium amount does not agree with the figures given for " +
					"the number of options and price per option",
					name, null);

				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

    	private static bool Rule26 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (
					  Rule26 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityOption"), errorHandler)
					& Rule26 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityDerivativeShortFormBase"), errorHandler));
			
			return (
				  Rule26 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler)
				& Rule26 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule26 (name, nodeIndex.GetElementsByName ("equityOptionTransactionSupplement"), errorHandler));
		}

		private static bool Rule26 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement number 	= XPath.Path (context, "numberOfOptions");
				XmlElement maximum	= XPath.Path (context, "equityExercise", "equityAmericanExercise", "equityMultipleExercise", "maximumNumberOfOptions");
				
				if ((number == null) || (maximum == null) ||
						LessOrEqual (ToDecimal (maximum), ToDecimal (number))) continue;
				
				errorHandler ("305", context,
						"The exercise structure specifies a greater number of options " +
						"than the product definition",
						name, ToToken (maximum));
				result = false;
			}
			return (result);
		}

		// --------------------------------------------------------------------

    	private static bool Rule26B (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (
					  Rule26B (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityOption"), errorHandler)
					& Rule26B (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityDerivativeShortFormBase"), errorHandler));
			
			return (
				  Rule26B (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler)
				& Rule26B (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule26B (name, nodeIndex.GetElementsByName ("equityOptionTransactionSupplement"), errorHandler));
		}

		private static bool Rule26B (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement number 	= XPath.Path (context, "numberOfOptions");
				XmlElement maximum	= XPath.Path (context, "equityExercise", "equityBermudaExercise", "equityMultipleExercise", "maximumNumberOfOptions");
				
				if ((number == null) || (maximum == null) ||
						LessOrEqual (ToDecimal (maximum), ToDecimal (number))) continue;
				
				errorHandler ("305", context,
						"The exercise structure specifies a greater number of options " +
						"than the product definition",
						name, ToToken (maximum));
				result = false;
			}
			return (result);
		}

        // --------------------------------------------------------------------

		private static bool Rule27 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule27 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityMultipleExercise"), errorHandler));
			
			return (Rule27 (name, nodeIndex.GetElementsByName ("equityMultipleExercise"), errorHandler));
		}
	
		private static bool Rule27 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement minimum	= XPath.Path (context, "minimumNumberOfOptions");
				XmlElement maximum	= XPath.Path (context, "maximumNumberOfOptions");
				
				if ((minimum == null) || (maximum == null) ||
						LessOrEqual (ToDecimal (minimum), ToDecimal (maximum))) continue;
				
				errorHandler ("305", context,
						"The maximum number of options must be greater or equal " +
						"to the minimum number of options",
						name, ToToken (maximum));
				result = false;
			}
			return (result);
		}

        // --------------------------------------------------------------------

		private static bool Rule28 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule28 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityMultipleExercise"), errorHandler));
			
			return (Rule28 (name, nodeIndex.GetElementsByName ("equityMultipleExercise"), errorHandler));
		}
	
		private static bool Rule28 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement minimum	= XPath.Path (context, "minimumNumberOfOptions");
				XmlElement integral = XPath.Path (context, "integralMultipleExercise");
				
				if ((minimum == null) || (integral == null)) continue;
				
				decimal	mod = ToDecimal (minimum) % ToDecimal (integral);
				
				if (mod.CompareTo (Decimal.Zero) == 0) continue;
						
				errorHandler ("305", context,
						"The minimum number of options must be a multiple of " +
						"multiple exercise quantity",
						name, ToToken (minimum));
				result = false;
			}
			return (result);
		}

        // --------------------------------------------------------------------

		private static bool Rule29 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule29 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityMultipleExercise"), errorHandler));
			
			return (Rule29 (name, nodeIndex.GetElementsByName ("equityMultipleExercise"), errorHandler));
		}
	
		private static bool Rule29 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement maximum	= XPath.Path (context, "maximumNumberOfOptions");
				XmlElement integral = XPath.Path (context, "integralMultipleExercise");
				
				if ((maximum == null) || (integral == null)) continue;
				
				decimal	mod = ToDecimal (maximum) % ToDecimal (integral);
				
				if (mod.CompareTo (Decimal.Zero) == 0) continue;
						
				errorHandler ("305", context,
						"The minimum number of options must be a multiple of " +
						"multiple exercise quantity",
						name, ToToken (maximum));
				result = false;
			}
			return (result);
		}

        // --------------------------------------------------------------------

		private static bool Rule31 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation)
				return (Rule31 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "EquityDerivativeBase"), errorHandler));
			
			return (
				  Rule31 (name, nodeIndex.GetElementsByName ("brokerEquityOption"), errorHandler)
				& Rule31 (name, nodeIndex.GetElementsByName ("equityOption"), errorHandler)
				& Rule31 (name, nodeIndex.GetElementsByName ("equityOptionTransactionSupplement"), errorHandler));
		}

		private static bool Rule31 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result	= true;
			
			foreach (XmlElement	context	in list) {
				XmlElement effective = XPath.Path (context, "equityEffectiveDate");
				XmlElement tradeDate = XPath.Path (context, "..", "tradeHeader", "tradeDate");
				
				if ((effective == null) || (tradeDate == null) ||
						Greater (ToDate (effective), ToDate (tradeDate))) continue;
				
				errorHandler ("305", context,
						"If present the equity effective date must be after " +
						"the trade date",
						name, ToToken (effective));
				result = false;
			}
			return (result);
		}
	}
}