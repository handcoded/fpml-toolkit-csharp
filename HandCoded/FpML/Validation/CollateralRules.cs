// Copyright (C),2005-2013 HandCoded Software Ltd.
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

using System.Xml;

using HandCoded.Finance;
using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>CollateralRules</b> class contains a <see cref="RuleSet"/> that
    /// holds all of the defined validation <see cref="Rule"/> instances for
    /// the collateral business process.
	/// </summary>
    public sealed class CollateralRules : FpMLRuleSet
    {
        /// <summary>
        /// Contains the <see cref="RuleSet"/>.
        /// </summary>
        public static RuleSet Rules
        {
            get
            {
                return (rules);
            }
        }

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5.1 or later
        /// reporting view documents.
        /// </summary>
        private static readonly Precondition R5_1__LATER
            = Precondition.And (new Precondition [] {
                    Preconditions.R5_1__LATER,
                    Preconditions.REPORTING });

        /// <summary>
        /// A rule instance that ensures that the variation margin amounts agree
        /// if both are given.
        /// </summary>
        public static readonly Rule RULE01
            = new DelegatedRule (R5_1__LATER, "col-1", new RuleDelegate (Rule01));

        /// <summary>
        /// A rule instance that ensures that the segregated independent amounts
	    /// agree if both are given.
        /// </summary>
        public static readonly Rule RULE02
            = new DelegatedRule (R5_1__LATER, "col-2", new RuleDelegate (Rule02));

        /// <summary>
        /// A rule instance that ensures that if two exposures exists they must
        /// have different directions.
        /// </summary>
        public static readonly Rule RULE03
            = new DelegatedRule (R5_1__LATER, "col-3", new RuleDelegate (Rule03));

        /// <summary>
        /// A rule instance that ensures that pending collateral giver and taker
	    /// roles are reversed if there is more than one exchange.
        /// </summary>
        public static readonly Rule RULE04
            = new DelegatedRule (R5_1__LATER, "col-4", new RuleDelegate (Rule04));

        /// <summary>
        /// A rule instance that ensures that the margin caller and receiver are
	    /// not the same party.
        /// </summary>
        public static readonly Rule RULE05
            = new DelegatedRule (R5_1__LATER, "col-5", new RuleDelegate (Rule05));

        /// <summary>
        /// A rule instance that ensures that the held collateral holder and poster are
	    /// have reversed roles if there are two variation margin structures.
        /// </summary>
        public static readonly Rule RULE08
            = new DelegatedRule (R5_1__LATER, "col-8", new RuleDelegate (Rule08));

        /// <summary>
        /// A rule instance that ensures that the substitution issuer and receiver
	    /// are different parties.
        /// </summary>
        public static readonly Rule RULE09
            = new DelegatedRule (R5_1__LATER, "col-9", new RuleDelegate (Rule09));

        /// <summary>
        /// A rule instance that ensures that the interest period start date falls
	    /// before the end date.
        /// </summary>
        public static readonly Rule RULE10
            = new DelegatedRule (R5_1__LATER, "col-10", new RuleDelegate (Rule10));

        /// <summary>
        /// A rule instance that ensures that the daily interest calculation dates
	    /// are unique.
        /// </summary>
        public static readonly Rule RULE11
            = new DelegatedRule (R5_1__LATER, "col-11", new RuleDelegate (Rule11));

		/// <summary>
		/// The <see cref="RuleSet"/> used to hold the <see cref="Rule"/>
		/// instances.
		/// </summary>
		private static readonly RuleSet	rules = RuleSet.ForName ("CollateralRules");

		/// <summary>
		/// Ensures that no instances can be constructed.
		/// </summary>
		private CollateralRules ()
		{ }

        //---------------------------------------------------------------------------

        private static bool Rule01 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule01 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RequestMargin"), errorHandler));					
				
			return (
				  Rule01 (name, nodeIndex.GetElementsByName ("requestMargin"), errorHandler));
		}
		
		private static bool Rule01 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool    	result  =	true;
			
			foreach (XmlElement context in list) {
				XmlElement	callResult	= XPath.Path (context, "marginCallResult", "variationMargin");
				XmlElement	requirement	= XPath.Path (context, "marginRequirement", "variationMargin");
				
				if (!Exists (callResult) || !Exists (requirement)) continue;
				
				XmlElement	callCurrency = XPath.Path (callResult, "marginCallAmount", "currency");
				XmlElement	reqdCurrency = XPath.Path (requirement, "deliver", "currency");
				
				if ((callCurrency == null) || (reqdCurrency == null) ||
						!IsSameCurrency (callCurrency, reqdCurrency)) continue;
				
				XmlElement	callAmount = XPath.Path (callResult, "marginCallAmount", "amount");
                XmlElement  deliverAmount = XPath.Path (requirement, "deliver", "amount");
                XmlElement  returnAmount = XPath.Path (requirement, "return", "amount");
				
				decimal	callValue = ToDecimal (callAmount);
				decimal	reqdValue = ToDecimal (deliverAmount) + ToDecimal (returnAmount);
				
				if (callValue.CompareTo (reqdValue) == 0)
					continue;
				
				errorHandler ("305", context,
						"The value of the variationMargin amounts are not equal",
						name, null);
				result = false;
			}
			return (result);
		}

        //---------------------------------------------------------------------------
	
        private static bool Rule02 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule02 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RequestMargin"), errorHandler));					
				
			return (
				  Rule02 (name, nodeIndex.GetElementsByName ("requestMargin"), errorHandler));
		}
			
		private static bool Rule02 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool    	result  =	true;
			
			foreach (XmlElement context in list) {
				XmlElement	callResult	= XPath.Path (context, "marginCallResult", "segregatedIndependentAmount");
				XmlElement	requirement	= XPath.Path (context, "marginRequirement", "segregatedIndependentAmount");
				
				if (!Exists (callResult) || !Exists (requirement)) continue;
				
				XmlElement	callCurrency = XPath.Path (callResult, "marginCallAmount", "currency");
				XmlElement	reqdCurrency = XPath.Path (requirement, "deliver", "currency");
				
				if ((callCurrency == null) || (reqdCurrency == null) ||
						!IsSameCurrency (callCurrency, reqdCurrency)) continue;
				
				XmlElement	callAmount = XPath.Path (callResult, "marginCallAmount", "amount");
                XmlElement  deliverAmount = XPath.Path (requirement, "deliver", "amount");
                XmlElement  returnAmount = XPath.Path (requirement, "return", "amount");
				
				decimal	callValue = ToDecimal (callAmount);
				decimal	reqdValue = ToDecimal (deliverAmount) + ToDecimal (returnAmount);
				
				if (callValue.CompareTo (reqdValue) == 0)
					continue;
				
				errorHandler ("305", context,
						"The value of the segregatedIndependentAmounts are not equal",
						name, null);
				
				result = false;
			}
			return (result);
		}

        //---------------------------------------------------------------------------
	
        private static bool Rule03 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule03 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "MarkToMarket"), errorHandler));					
				
			return (
				  Rule03 (name, nodeIndex.GetElementsByName ("markToMarket"), errorHandler));
		}
			
		private static bool Rule03 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlNodeList	exposures = XPath.Paths (context, "exposure");
				
				if (exposures.Count != 2) continue;
				
				XmlElement	exposed1 = XPath.Path ((XmlElement) exposures [0], "exposedPartyReference");
				XmlElement	obligated1 = XPath.Path ((XmlElement) exposures [0], "obligatedPartyReference");
				XmlElement	exposed2 = XPath.Path ((XmlElement) exposures [1], "exposedPartyReference");
				XmlElement	obligated2 = XPath.Path ((XmlElement) exposures [1], "obligatedPartyReference");
				
				if ((exposed1 == null) || (exposed2 == null) ||
						(obligated1 == null) || (obligated2 == null) ||
						((exposed1.GetAttribute ("href").CompareTo (exposed2.GetAttribute ("href")) != 0) &&
						 (obligated1.GetAttribute ("href").CompareTo (obligated2.GetAttribute ("href")) != 0)))
					continue;
				
				errorHandler ("305", context,
						"The exposure elements must be in different directions",
						name, null);
				
				result = false;
			}
			return (result);
		}

        //---------------------------------------------------------------------------

        private static bool Rule04 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule04 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "CollateralBalance"), errorHandler));					
				
			return (
				  Rule04 (name, nodeIndex.GetElementsByName ("collateral"), errorHandler));
		}
			
		private static bool Rule04 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlNodeList	pending	= XPath.Paths (context, "variationMargin", "pendingCollateral");
				
				if (pending.Count != 2) continue;
				
				XmlElement	giver1 = XPath.Path ((XmlElement) pending [0], "giverPartyReference");
				XmlElement	taker1 = XPath.Path ((XmlElement) pending [0], "takerPartyReference");
				XmlElement	giver2 = XPath.Path ((XmlElement) pending [1], "giverPartyReference");
				XmlElement	taker2 = XPath.Path ((XmlElement) pending [1], "takerPartyReference");
				
				if ((giver1 == null) || (giver2 == null) ||	(taker1 == null) || (taker2 == null) ||
						((giver1.GetAttribute ("href").CompareTo (giver2.GetAttribute ("href")) != 0) &&
						 (taker1.GetAttribute ("href").CompareTo (taker2.GetAttribute ("href")) != 0)))
					continue;
				
				errorHandler ("305", context,
						"The pending collateral elements must be in different directions",
						name, null);
				
				result = false;
			}
			return (result);
		}
	
        //---------------------------------------------------------------------------

        private static bool Rule05 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule05 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RequestMargin"), errorHandler));					
				
			return (
				  Rule05 (name, nodeIndex.GetElementsByName ("requestMargin"), errorHandler));
		}
			
	    private static bool Rule05 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
	    {
		    bool		result  =	true;
			
		    foreach (XmlElement	context in list) {
			    XmlElement	issuer	= XPath.Path (context, "marginCallIssuerPartyReference");
			    XmlElement	receiver = XPath.Path (context, "marginCallReceiverPartyReference");
		
			    if ((issuer == null) || (receiver == null)) continue;
				
			    if (issuer.GetAttribute ("href").CompareTo (receiver.GetAttribute ("href")) != 0)
				    continue;
				
			    errorHandler ("305", context,
					    "The call issuer and call receiver can not be the same party",
					    name, issuer.GetAttribute ("href"));
				
			    result = false;
		    }
			
		    return (result);
	    }
	
        //---------------------------------------------------------------------------

        private static bool Rule08 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule08 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "CollateralBalance"), errorHandler));					
				
			return (
				  Rule08 (name, nodeIndex.GetElementsByName ("collateral"), errorHandler));
		}
			
		private static bool Rule08 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlNodeList	held	= XPath.Paths (context, "variationMargin", "heldCollateral");
				
				if (held.Count != 2) continue;
				
				XmlElement	holder1 = XPath.Path ((XmlElement) held [0], "holdingPartyReference");
				XmlElement	poster1 = XPath.Path ((XmlElement) held [0], "postingPartyReference");
				XmlElement	holder2 = XPath.Path ((XmlElement) held [1], "holdingPartyReference");
				XmlElement	poster2 = XPath.Path ((XmlElement) held [1], "postingPartyReference");
				
				if ((holder1 == null) || (holder2 == null) ||	(poster1 == null) || (poster2 == null) ||
						((holder1.GetAttribute ("href").CompareTo (holder2.GetAttribute ("href")) != 0) &&
						 (poster1.GetAttribute ("href").CompareTo (poster2.GetAttribute ("href")) != 0)))
					continue;
				
				errorHandler ("305", context,
						"The held collateral elements must be in different directions",
						name, null);
				
				result = false;
			}
			return (result);
		}
	
        //---------------------------------------------------------------------------

        private static bool Rule09 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (
					  Rule09 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RequestSubstitution"), errorHandler)
					& Rule09 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "RequestSubstitutionRetracted"), errorHandler));					
				
			return (
				    Rule09 (name, nodeIndex.GetElementsByName ("requestSubstitution"), errorHandler)
				  & Rule09 (name, nodeIndex.GetElementsByName ("requestSubstitutionRetracted"), errorHandler));
		}
			
		private static bool Rule09 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlElement	issuer   = XPath.Path (context, "substitutionIssuerPartyReference");
				XmlElement	receiver = XPath.Path (context, "substitutionReceiverPartyReference");

				if ((issuer == null) || (receiver == null) ||
						(issuer.GetAttribute ("href").CompareTo (receiver.GetAttribute ("href")) != 0)) continue;
					
				errorHandler ("305", context,
						"The substitution issuer and reciever must be different parties",
						name, issuer.GetAttribute ("href"));
				
				result = false;
			}
			return (result);
		}
		
        //---------------------------------------------------------------------------

        private static bool Rule10 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule10 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "InterestPeriod"), errorHandler));
				
			return (Rule10 (name, nodeIndex.GetElementsByName ("interestPeriod"), errorHandler));
		}
			
		private static bool Rule10 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlElement	startDate = XPath.Path (context, "startDate");
				XmlElement	endDate   = XPath.Path (context, "endDate");

				if ((startDate == null) || (endDate == null) ||
						LessOrEqual (ToDate (startDate), ToDate (endDate))) continue;
					
				errorHandler ("305", context,
						"The interest period start date must be before the end date",
						name, null);
				
				result = false;
			}
			return (result);
		}
	
        //---------------------------------------------------------------------------
	
        private static bool Rule11 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
		{
			if (nodeIndex.HasTypeInformation) 
				return (Rule11 (name, nodeIndex.GetElementsByType (DetermineNamespace (nodeIndex), "InterestCalculationDetails"), errorHandler));
				
			return (Rule11 (name, nodeIndex.GetElementsByName ("interestCalculationDetails"), errorHandler));
		}
			
		private static bool Rule11 (string name, XmlNodeList list, ValidationErrorHandler errorHandler)
		{
			bool		result  =	true;
			
			foreach (XmlElement context in list) {
				XmlNodeList	dateList = XPath.Paths (context, "dailyInterestCalculation", "calculationDate");

				Date []		dates = new Date [dateList.Count];
				for (int count = 0; count < dates.Length; ++count)
					dates [count] = ToDate (dateList [count]);
				
				for (int outer = 0; outer < (dates.Length - 1); ++outer) {
					for (int inner = outer + 1; inner < dates.Length; ++inner) {
						if (dates [outer].CompareTo (dates [inner]) == 0) {
							errorHandler ("305", context,
									"The daily interest calculation dates must be unique",
									name, dates [outer].ToString ());
							
							result = false;
						}
					}
				}
			}
			return (result);
		}
    }
}