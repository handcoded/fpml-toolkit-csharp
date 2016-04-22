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

using System;
using System.Xml;

using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>SchemeRules</b> class contains a <see cref="RuleSet"/>
	/// initialised with validation rules for scheme values.
	/// </summary>
	public class SchemeRules {
		/// <summary>
		/// Contains the <see cref="RuleSet"/>.
		/// </summary>
		public static RuleSet Rules {
			get {
				return (rules);
			}
		}
	
		// FpML 1.0 ------------------------------------------------------------ 

		/// <summary>
		/// Rule 1: The value of any <b>averagingMethod</b> element must be valid
		/// within the domain defined by its <b>@averagingMethodScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE01
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-1", 
                    new ElementContext ("averagingMethod"), "averagingMethodScheme");

		/// <summary>
		/// Rule 2: The value of any <b>businessCenter</b> element must be valid
		/// within the domain defined by its <b>businessCenterScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE02
			= new SchemeRule (Preconditions.R1_0__LATER, "scheme-2",
                    new ElementContext ("businessCenter"),
                    new TypeContext ("BusinessCenter"), "businessCenterScheme");
		
		/// <summary>
		/// Rule 3: The value of any <b>businessDayConvention</b> element must be valid
		/// within the domain defined by its <b>@businessDayConventionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE03
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-3",
                    new ElementContext ("businessDayConvention"), "businessDayConventionScheme");

		/// <summary>
		/// Rule 4: The value of any <b>compoundingMethod</b> element must be valid
		/// within the domain defined by its <b>@compoundingMethodScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE04
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-4",
                    new ElementContext ("compoundingMethod"), "compoundingMethodScheme");

		/// <summary>
		/// Rule 5: The value of any <b>Currency</b> type element must be valid
		/// within the domain defined by its <b>@currencyScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE05
			= new SchemeRule (Preconditions.R1_0__LATER, "scheme-5",
                    new ElementContext (
		                new String [] {
	                        "currency", "settlementCurrency", "referenceCurrency",
	                        "cashSettlementCurrency", "payoutCurrency", "optionOnCurrency",
	                        "faceOnCurrency", "baseCurrency", "currency1", "currency2" }),
                    new TypeContext ("Currency"), "currencyScheme");
		
		/// <summary>
		/// Rule 6: The value of any <b>dateRelativeTo</b> element must be valid
		/// within the domain defined by its <b>@dateRelativeToScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE06
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-6",
                    new ElementContext ("dateRelativeTo"), "dateRelativeToScheme");

		/// <summary>
		/// Rule 7: The value of any <b>dayCountFraction</b> element must be valid
		/// within the domain defined by its <b>@dayCountFractionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to all FpML releases EXCEPT 4-0.</remarks>
		public static readonly Rule	RULE07
			= new SchemeRule (Preconditions.NOT_R4_0, "scheme-7",
                    new ElementContext ("dayCountFraction"),
                    new TypeContext ("DayCountFraction"), "dayCountFractionScheme");

		/// <summary>
		/// Rule 8: The value of any <b>dayType</b> element must be valid
		/// within the domain defined by its <b>@dayTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE08
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-8", 
                    new ElementContext ("dayType"), "dayTypeScheme");

		/// <summary>
		/// Rule 9: The value of any <b>discountingType</b> element must be valid
		/// within the domain defined by its <b>@discountingTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE09
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-9", 
                    new ElementContext ("discountingType"), "discountingTypeScheme");

		/// <summary>
		/// Rule 10: The value of any <b>floatingRateIndex</b> type element must be valid
		/// within the domain defined by its <b>@floatingRateIndexScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to all FpML releases.</remarks>
		public static readonly Rule	RULE10
			= new SchemeRule (Preconditions.R1_0__LATER, "scheme-10",
                    new ElementContext(
                            new string [] { null, "interestShortfall" },
                            new string [] { "floatingRateIndex", "rateSource" }),
                    new TypeContext("FloatingRateIndex"), "floatingRateIndexScheme");

		/// <summary>
		/// Rule 11: The value of any <b>negativeInterestRateTreatment</b> element must be valid
		/// within the domain defined by its <b>@negativeInterestRateTreatmentScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE11
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-11", 
                    new ElementContext ("negativeInterestRateTreatment"), "negativeInterestRateTreatmentScheme");

		/// <summary>
		/// Rule 12: The value of any <b>payRelativeTo</b> element must be valid
		/// within the domain defined by its <b>@payRelativeToScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE12
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-12", 
                    new ElementContext ("payRelativeTo"), "payRelativeToScheme");

		/// <summary>
		/// Rule 13: The value of any <b>period</b> element must be valid
		/// within the domain defined by its <b>@periodScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE13
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-13", 
                    new ElementContext ("period"), "periodScheme");

		/// <summary>
		/// Rule 14: The value of any <b>rateTreatment</b> element must be valid
		/// within the domain defined by its <b>@rateTreatmentScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE14
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-14", 
                    new ElementContext ("rateTreatment"), "rateTreatmentScheme");

		/// <summary>
		/// Rule 15: The value of any <b>resetRelativeTo</b> element must be valid
		/// within the domain defined by its <b>@resetRelativeToScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE15
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-15", 
                    new ElementContext ("resetRelativeTo"), "resetRelativeToScheme");

		/// <summary>
		/// Rule 16: The value of any <b>rollConvention</b> element must be valid
		/// within the domain defined by its <b>@rollConventionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE16
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-16", 
                    new ElementContext ("rollConvention"), "rollConventionScheme");

		/// <summary>
		/// Rule 17: The value of any <b>roundingDirection</b> element must be valid
		/// within the domain defined by its <b>@roundingDirectionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE17
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-17", 
                    new ElementContext ("roundingDirection"), "roundingDirectionScheme");

		/// <summary>
		/// Rule 18: The value of any <b>stepRelativeTo</b> element must be valid
		/// within the domain defined by its <b>@stepRelativeToScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE18
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-18", 
                    new ElementContext ("stepRelativeTo"), "stepRelativeToScheme");

		/// <summary>
		/// Rule 19: The value of any <b>weeklyRollConvention</b> element must be valid
		/// within the domain defined by its <b>@weeklyRollConventionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 1-0, 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE19
			= new SchemeRule (Preconditions.R1_0__R3_0, "scheme-19", 
                    new ElementContext ("weeklyRollConvention"), "weeklyRollConventionScheme");

		// FpML 2.0 ------------------------------------------------------------

		/// <summary>
		/// Rule 20: The value of any <b>calculationAgentParty</b> element must be valid
		/// within the domain defined by its <b>@calculationAgentPartyScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE20
			= new SchemeRule (Preconditions.R2_0__R3_0, "scheme-20", 
                    new ElementContext ("calculationAgentParty"), "calculationAgentPartyScheme");

		/// <summary>
		/// Rule 21: The value of any <b>rateSource</b> element must be valid
		/// within the domain defined by its <b>@informationProviderScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 2-0 and later.</remarks>
		public static readonly Rule	RULE21
			= new SchemeRule (Preconditions.R2_0__LATER, "scheme-21",
                    new ElementContext ("informationSource", "rateSource"),
                    new TypeContext ("InformationProvider"), "informationProviderScheme");

		/// <summary>
		/// Rule 22: The value of any <b>buyer</b> or <b>seller</b> element must be valid
		/// within the domain defined by its <b>@payerReceiverScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE22
			= new SchemeRule (Preconditions.R2_0__R3_0, "scheme-22",
                    new ElementContext (
			            new String [] { "buyer", "seller" }), "payerReceiverScheme");

		/// <summary>
		/// Rule 23: The value of any <b>quotationRateType</b> element must be valid
		/// within the domain defined by its <b>@quotationRateTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 2-0 and 3-0.</remarks>
		public static readonly Rule	RULE23
			= new SchemeRule (Preconditions.R2_0__R3_0, "scheme-23", 
                    new ElementContext ("quotationRateType"), "quotationRateTypeScheme");

		// FpML 3.0 ------------------------------------------------------------
		
		/// <summary>
		/// Rule 24: The value of any <b>clearanceSystem</b> element must be valid
		/// within the domain defined by its <b>clearanceSystemScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and 4-1 or later.</remarks>
		public static readonly Rule	RULE24A
			= new SchemeRule (Precondition.Or (Preconditions.R3_0__LATER, Preconditions.R4_1__LATER), "scheme-24a", 
                    new ElementContext ("clearanceSystem"),
                    new TypeContext ("ClearanceSystem"), "clearanceSystemScheme");
		
		/// <summary>
		/// Rule 24: The value of any <b>clearanceSystem</b> element must be valid
		/// within the domain defined by its <b>clearanceSystemIdScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4-0 only.</remarks>
		public static readonly Rule	RULE24B
			= new SchemeRule (Preconditions.R4_0, "scheme-24b", 
                    new ElementContext ("clearanceSystem"),
                    new TypeContext ("ClearanceSystem"), "clearanceSystemIdScheme");

		/// <summary>
		/// Rule 26: The value of any <b>country</b> element must be valid
		/// within the domain defined by its <b>@countryScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE26
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-26", 
                    new ElementContext ("country"),
                    new TypeContext ("CountryCode"), "countryScheme");

		/// <summary>
		/// Rule 27: The value of any <b>cutName</b> element must be valid
		/// within the domain defined by its <b>@cutNameScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE27
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-27", 
                    new ElementContext ("cutName"),
                new TypeContext ("CutName"), "cutNameScheme");
		
		/// <summary>
		/// Rule 28: The value of any <b>exerciseStyle</b> element must be valid
		/// within the domain defined by its <b>@exerciseStyleScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE28
			= new SchemeRule (Preconditions.R3_0, "scheme-28", 
                    new ElementContext ("exerciseStyle"), "exerciseStyleScheme");
		
		/// <summary>
		/// Rule 29: The value of any <b>fxBarrierType</b> element must be valid
		/// within the domain defined by its <b>@fxBarrierTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE29
			= new SchemeRule (Preconditions.R3_0, "scheme-29", 
                    new ElementContext ("fxBarrierType"), "fxBarrierTypeScheme");
		
		/// <summary>
		/// Rule 30: The value of any <b>governingLaw</b> element must be valid
		/// within the domain defined by its <b>governingLawScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE30
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-30", 
                    new ElementContext ("governingLaw"),
                    new TypeContext ("GoverningLaw"), "governingLawScheme");
		
		/// <summary>
		/// Rule 31: The value of any <b>masterAgreementType</b> element must be valid
		/// within the domain defined by its <b>masterAgreementTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE31
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-31", 
                    new ElementContext ("masterAgreementType"),
                    new TypeContext ("MasterAgreementType"), "masterAgreementTypeScheme");
		
		/// <summary>
		/// Rule 32: The value of any <b>methodOfAdjustment</b> element must be valid
		/// within the domain defined by its <b>@methodOfAdjustmentScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE32
			= new SchemeRule (Preconditions.R3_0, "scheme-32", 
                    new ElementContext ("methodOfAdjustment"), "methodOfAdjustmentScheme");
		
		/// <summary>
		/// Rule 33: The value of any <b>nationalisationOrInsolvency</b> element must be valid
		/// within the domain defined by its <b>@nationalisationOrInsolvencyOrDelistingScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE33
			= new SchemeRule (Preconditions.R3_0, "scheme-33",
                    new ElementContext (
					    new String [] {	"nationalisationOrInsolvency", "delisting" }),
					"nationalisationOrInsolvencyOrDelistingScheme");
		
		/// <summary>
		/// Rule 35: The value of any <b>partyContactDetails</b> element must be valid
		/// within the domain defined by its <b>@partyContactDetailsScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE35
			= new SchemeRule (Preconditions.R3_0, "scheme-35", 
                    new ElementContext ("partyContactDetails"), "partyContactDetailsScheme");
		
		/// <summary>
		/// Rule 36: The value of any <b>payout</b> element must be valid
		/// within the domain defined by its <b>@payoutScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE36
			= new SchemeRule (Preconditions.R3_0, "scheme-36", 
                    new ElementContext ("payoutStyle"), "payoutScheme");

		/// <summary>
		/// Rule 37: The value of any <b>premiumQuoteBasis</b> element must be valid
		/// within the domain defined by its <b>@premiumQuoteBasisScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE37
			= new SchemeRule (Preconditions.R3_0, "scheme-37", 
                    new ElementContext ("premiumQuoteBasis"), "premiumQuoteBasisScheme");

		/// <summary>
		/// Rule 38: The value of any <b>quoteBasis</b> element must be valid
		/// within the domain defined by its <b>@quoteBasisScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE38
			= new SchemeRule (Preconditions.R3_0, "scheme-38", 
                    new ElementContext ("quoteBasis"), "quoteBasisScheme");

		/// <summary>
		/// Rule 39: The value of any <b>routingCodeId</b> element must be valid
		/// within the domain defined by its <b>routingCodeIdScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE39
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-39", 
                    new ElementContext ("routingCodeId"),
                    new TypeContext ("RoutingId"), "routingCodeIdScheme");
		
		/// <summary>
		/// Rule 40: The value of any <b>settlementMethod</b> element must be valid
		/// within the domain defined by its <b>settlementScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE40
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-40", 
                    new ElementContext ("settlementMethod"),
                    new TypeContext ("SettlementMethod"), "settlementMethodScheme");
		
		/// <summary>
		/// Rule 41: The value of any <b>settlementPriceSource</b> element must be valid
		/// within the domain defined by its <b>settlementPriceSourceScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0 and later.</remarks>
		public static readonly Rule	RULE41
			= new SchemeRule (Preconditions.R3_0__LATER, "scheme-41", 
                    new ElementContext ("settlementPriceSource"),
                    new TypeContext ("SettlementPriceSource"), "settlementPriceSourceScheme");
		
		/// <summary>
		/// Rule 42: The value of any <b>settlementType</b> element must be valid
		/// within the domain defined by its <b>@settlementTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE42
			= new SchemeRule (Preconditions.R3_0, "scheme-42", 
                    new ElementContext ("settlementType"), "settlementTypeScheme");

		/// <summary>
		/// Rule 43: The value of any <b>shareExtraordinaryEvent</b> element must be valid
		/// within the domain defined by its <b>@shareExtraordinaryEventScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE43
			= new SchemeRule (Preconditions.R3_0, "scheme-43", 
                    new ElementContext ("shareExtraordinaryEvent"), "shareExtraordinaryEventScheme");

		/// <summary>
		/// Rule 44: The value of any <b>sideRateBasis</b> element must be valid
		/// within the domain defined by its <b>@sideRateBasisScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE44
			= new SchemeRule (Preconditions.R3_0, "scheme-44", 
                    new ElementContext ("sideRateBasis"), "sideRateBasisScheme");

		/// <summary>
		/// Rule 45: The value of any <b>standardSettlementStyle</b> element must be valid
		/// within the domain defined by its <b>@standardSettlementStyleScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE45
			= new SchemeRule (Preconditions.R3_0, "scheme-45", 
                    new ElementContext ("standardSettlementStyle"), "standardSettlementStyleScheme");

		/// <summary>
		/// Rule 46: The value of any <b>strikeQuoteBasis</b> element must be valid
		/// within the domain defined by its <b>@strikeQuoteBasisScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE46
			= new SchemeRule (Preconditions.R3_0, "scheme-46", 
                    new ElementContext ("strikeQuoteBasis"), "strikeQuoteBasisScheme");

		/// <summary>
		/// Rule 47: The value of any <b>timeType</b> element must be valid
		/// within the domain defined by its <b>@timeTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE47
			= new SchemeRule (Preconditions.R3_0, "scheme-47",
                    new ElementContext (
					    new String [] {
						    "latestExerciseTimeType", "equityExpirationTimeType",
                            "valuationTimeType" }),	"timeTypeScheme");

		/// <summary>
		/// Rule 48: The value of any <b>touchCondition</b> element must be valid
		/// within the domain defined by its <b>@touchConditionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE48
			= new SchemeRule (Preconditions.R3_0, "scheme-48", 
                    new ElementContext ("touchCondition"), "touchConditionScheme");

		/// <summary>
		/// Rule 49: The value of any <b>triggerCondition</b> element must be valid
		/// within the domain defined by its <b>@triggerConditionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 3-0.</remarks>
		public static readonly Rule	RULE49
			= new SchemeRule (Preconditions.R3_0, "scheme-49", 
                    new ElementContext ("triggerCondition"), "triggerConditionScheme");

		// FpML 4.0 ------------------------------------------------------------

		/// <summary>
		/// Rule 50: The value of any <b>additionalTerm</b> element must be valid
		/// within the domain defined by its <b>@additionalTermScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.0 and 4.1.</remarks>
		public static readonly Rule	RULE50
			= new SchemeRule (Preconditions.R4_0__R4_1, "scheme-50", 
                    new ElementContext ("additionalTerm"),
                    new TypeContext ("AdditionalTerm"), "additionalTermScheme");

		/// <summary>
		/// Rule 25: The value of any <b>contractualDefinitions</b> element must
		/// be valid within the domain defined by its <b>@contractualDefinitionsScheme</b>
		/// attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4-0 and later.</remarks>
		public static readonly Rule	RULE25
			= new SchemeRule (Preconditions.R4_0__LATER, "scheme-25", 
                    new ElementContext ("contractualDefinitions"),
                    new TypeContext ("ContractualDefinition"), "contractualDefinitionsScheme");

		/// <summary>
		/// Rule 51: The value of any <b>contractualSupplement</b> element must
		/// be valid within the domain defined by its <b>contractualSupplementScheme</b>
		/// attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.0 and later.</remarks>
		public static readonly Rule	RULE51
			= new SchemeRule (Preconditions.R4_0__LATER, "scheme-51", 
                    new ElementContext ("contractualSupplement"),
                    new TypeContext ("ContractualSupplement"), "contractualSupplementScheme");
		
		/// <summary>
		/// Rule 52: The value of any <b>fxFeatureType</b> element must be valid
		/// within the domain defined by its <b>@fxFeatureTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4-0 only.</remarks>
		public static readonly Rule	RULE52
			= new SchemeRule (Preconditions.R4_0, "scheme-52", 
                    new ElementContext ("fxFeatureType"), "fxFeatureTypeScheme");
		
		/// <summary>
		/// Rule 53: The value of any <b>marketDisruption</b> element must be valid
		/// within the domain defined by its <b>marketDisruptionScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.0 and later.</remarks>
		public static readonly Rule	RULE53
			= new SchemeRule (Preconditions.R4_0__LATER, "scheme-53",
                    new ElementContext (
					    new string [] { "averagingPeriodIn", "averagingPeriodOut" },
					    new string [] { "marketDisruption", "marketDisruption" }), "marketDisruptionScheme");
		
		/// <summary>
		/// Rule 54: The value of any <b>masterConfirmationType</b>b> element must be valid
		/// within the domain defined by its <b>masterConfirmationTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.0 and later.</remarks>
		public static readonly Rule	RULE54
			= new SchemeRule (Preconditions.R4_0__LATER, "scheme-54", 
                    new ElementContext ("masterConfirmationType"),
                    new TypeContext ("MasterConfirmationType"), "masterConfirmationTypeScheme");
		
		/// <summary>
		/// Rule 55: The value of any <b>restructuringType</b> element must be valid
		/// within the domain defined by its <b>restructuringTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.0 and later.</remarks>
		public static readonly Rule	RULE55
			= new SchemeRule (Preconditions.R4_0__LATER, "scheme-55", 
                    new ElementContext ("restructuringType"),
                    new TypeContext ("RestructuringType"), "restructuringScheme");

        /// <summary>
        /// Rule 71: The value of any <b>additionalTerm</b> element must be valid
        /// within the domain defined by its <b>additionalTermScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.0 and 4.1</remarks>
        public static readonly Rule RULE71
            = new SchemeRule(Preconditions.R4_0__R4_1, "scheme-71",
                    new ElementContext("additionalTerm"),
                    new TypeContext("AdditionalTerm"), "additionalTermScheme");

        // FpML 4.1 ------------------------------------------------------------

		/// <summary>
		/// Rule 56: The value of any <b>assetMeasure</b> element must be valid
		/// within the domain defined by its <b>assetMeasureScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE56
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-56", 
                    new ElementContext ("measureType"),
                    new TypeContext ("AssetMeasureType"), "assetMeasureScheme");
		
		/// <summary>
		/// Rule 57: The value of any <b>brokerConfirmationType</b> element must be valid
		/// within the domain defined by its <b>brokerConfirmationTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE57
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-57", 
                    new ElementContext ("brokerConfirmationType"),
                    new TypeContext ("BrokerConfirmationType"), "brokerConfirmationTypeScheme");
		
		/// <summary>
		/// Rule 58: The value of any <b>compoundingFrequency</b> element must be valid
		/// within the domain defined by its <b>compoundingFrequencyScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE58
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-58", 
                    new ElementContext ("compoundingFrequency"),
                    new TypeContext ("CompoundingFrequency"), "compoundingFrequencyScheme");
		
		/// <summary>
		/// Rule 59: The value of any <b>couponType</b> element must be valid
		/// within the domain defined by its <b>couponTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE59
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-59", 
                    new ElementContext ("couponType"),
                    new TypeContext ("CouponType"), "couponTypeScheme");
		
		/// <summary>
		/// Rule 60: The value of any <b>creditSeniority</b> element must be valid
		/// within the domain defined by its <b>creditSeniorityScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE60
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-60", 
                    new ElementContext ("creditSeniority"),
                    new TypeContext ("CreditSeniority"), "creditSeniorityScheme");
		
		/// <summary>
		/// Rule 61: The value of any <b>indexAnnexSource</b> element must be valid
		/// within the domain defined by its <b>indexAnnexSourceScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE61
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-61", 
                    new ElementContext ("indexAnnexSource"),
                    new TypeContext ("IndexAnnexSource"), "indexAnnexSourceScheme");
		
		/// <summary>
		/// Rule 62: The value of any <b>interpolationMethod</b> element must be valid
		/// within the domain defined by its <b>interpolationMethodScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE62
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-62", 
                    new ElementContext ("interpolationMethod"),
                    new TypeContext ("InterpolationMethod"), "interpolationMethodScheme");
		
		/// <summary>
		/// Rule 63: The value of any <b>matrixTerm</b> element must be valid
		/// within the domain defined by its <b>matrixTermScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE63
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-63", 
                    new ElementContext ("matrixTerm"),
                    new TypeContext ("MatrixTerm"), "matrixTermScheme");
		
		/// <summary>
		/// Rule 64: The value of any <b>matrixType</b> element must be valid
		/// within the domain defined by its <b>matrixTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE64
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-64", 
                    new ElementContext ("matrixType"),
                    new TypeContext ("MatrixType"), "matrixTypeScheme");
		
		/// <summary>
		/// Rule 65: The value of any <b>perturbationType</b> element must be valid
		/// within the domain defined by its <b>perturbationTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE65
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-65", 
                    new ElementContext ("perturbationType"),
                    new TypeContext ("PerturbationType"), "perturbationTypeScheme");
		
		/// <summary>
		/// Rule 66: The value of any <b>priceQuoteUnit</b> element must be valid
		/// within the domain defined by its <b>priceQuoteUnitScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE66
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-66", 
                    new ElementContext ("priceQuoteUnits"),
                    new TypeContext ("PriceQuoteUnits"), "priceQuoteUnitsScheme");
		
		/// <summary>
		/// Rule 67: The value of any <b>pricingInputType</b> element must be valid
		/// within the domain defined by its <b>pricingInputTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE67
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-67", 
                    new ElementContext ("pricingInputType"),
                    new TypeContext ("PricingInputType"), "pricingInputTypeScheme");
		
		/// <summary>
		/// Rule 68: The value of any <b>queryParameterOperator</b> element must be valid
		/// within the domain defined by its <b>queryParameterOperatorScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE68
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-68", 
                    new ElementContext ("queryParameterOperator"),
                    new TypeContext ("QueryParameterOperator"), "queryParameterOperatorScheme");
		
		/// <summary>
		/// Rule 69: The value of any <b>quoteTiming</b> element must be valid
		/// within the domain defined by its <b>quoteTimingScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE69
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-69", 
                    new ElementContext ("quoteTiming"),
                    new TypeContext ("QuoteTiming"), "quoteTimingScheme");
		
		/// <summary>
		/// Rule 70: The value of any <b>valuationSetDetail</b> element must be valid
		/// within the domain defined by its <b>valuationSetDetailScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1.</remarks>
		public static readonly Rule	RULE70
			= new SchemeRule (Preconditions.R4_1, "scheme-70", 
                    new ElementContext ("valuationSetDetail"),
                    new TypeContext ("ValuationSetDetail"), "valuationSetDetailScheme");
		
		/// <summary>
		/// Rule 72: The value of any <b>derivativeCalculationMethod</b> element must be valid
		/// within the domain defined by its <b>derivativeCalculationMethodScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.1 and later.</remarks>
		public static readonly Rule	RULE72
			= new SchemeRule (Preconditions.R4_1__LATER, "scheme-72", 
                    new ElementContext ("derivativeCalculationMethod"),
                    new TypeContext ("DerivativeCalulationMethod"), "derivativeCalculationMethodScheme");

		// FpML 4.2 ------------------------------------------------------------

		/// <summary>
		/// Rule 73: The value of any <b>cashflowType</b> type element must
        /// be valid within the domain defined by its <b>cashflowTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 4.2 and later.</remarks>
		public static readonly Rule	RULE73
			= new SchemeRule (Preconditions.R4_2__LATER, "scheme-73",
                    new ElementContext("cashflowType"),
                    new TypeContext ("CashflowType"), "cashflowTypeScheme");

        /// <summary>
        /// Rule 74: The value of any <b>cashflowType</b> type element must
        /// be valid within the domain defined by its <b>cashflowTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE74
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-74",
                    new ElementContext("entityType"),
                    new TypeContext("EntityType"), "entityTypeScheme");

        /// <summary>
        /// Rule 75: The value of any <b>productType</b> type element must
        /// be valid within the domain defined by its <b>productTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE75
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-75",
                    new ElementContext("productType"),
                    new TypeContext("ProductType"), "productTypeScheme");

        /// <summary>
        /// Rule 76: The value of any <b>reasonCode</b> type element must
        /// be valid within the domain defined by its <b>reasonCodeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE76
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-76",
                    new ElementContext("reasonCode"),
                    new TypeContext("ReasonCode"), "reasonCodeScheme");

        /// <summary>
        /// Rule 77: The value of any <b>matrixSource</b> type element must
        /// be valid within the domain defined by its <b>settledEntityMatrixSourceScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE77
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-77",
                    new ElementContext("matrixSource"),
                    new TypeContext("MatrixSource"), "settledEntityMatrixSourceScheme");

        /// <summary>
        /// Rule 78: The value of any <b>scheduledDate/type</b> type element must
        /// be valid within the domain defined by its <b>scheduledDateTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE78
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-78",
                    new ElementContext("scheduledDate", "type"),
                    new TypeContext("ScheduledDateType"), "scheduledDateTypeScheme");

        /// <summary>
        /// Rule 79: The value of any <b>spreadSchedule/type</b> type element must
        /// be valid within the domain defined by its <b>spreadScheduleTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE79
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-79",
                    new ElementContext("spreadSchedule", "type"),
                    new TypeContext("SpreadScheduleType"), "spreadScheduleTypeScheme");

        /// <summary>
        /// Rule 80: The value of any <b>FpML/status</b> type element must
        /// be valid within the domain defined by its <b>tradeCashflowsStatusScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.2 and later.</remarks>
        public static readonly Rule RULE80
            = new SchemeRule(Preconditions.R4_2__LATER, "scheme-80",
                    new ElementContext(
                            new string [] { "FpML", "nettedTradeCashflowsMatchResult" },
                            new string [] { "status", "status" }),
                    new TypeContext("TradeCashflowsStatus"), "tradeCashflowsStatusScheme");

	    // FpML 4.3 ------------------------------------------------------------

        /// <summary>
	    /// Rule 81: The value of any <b>FacilityType</b> type element must
	    /// be valid within the domain defined by its <b>facilityTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.3 and later.</remarks>
	    public static readonly Rule	RULE81
		    = new SchemeRule (Preconditions.R4_3__LATER, "scheme-81", 
				    new ElementContext ("facilityType"),
				    new TypeContext ("FacilityType"), "facilityTypeScheme");

        /// <summary>
        /// Rule 82: The value of any <b>Lien</b> type element must
        /// be valid within the domain defined by its <b>lienScheme</b> attribute.
        /// </summary>
	    /// <remarks>Applies to FpML 4.3 and later.</remarks>
	    public static readonly Rule	RULE82
		    = new SchemeRule (Preconditions.R4_3__LATER, "scheme-82", 
				    new ElementContext ("lien"),
				    new TypeContext ("Lien"), "lienScheme");

	    /// <summary>
	    /// Rule 83: The value of any <b>UnderlyingAssetTranche</b> type element must
        /// be valid within the domain defined by its <b>loanTrancheScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.3 and later.</remarks>
	    public static readonly Rule	RULE83
		    = new SchemeRule (Preconditions.R4_3__LATER, "scheme-83", 
				    new ElementContext ("tranche"),
				    new TypeContext ("UnderlyingAssetTranche"), "loanTrancheScheme");
	
        /// <summary>
        /// Rule 84: The value of any <b>MortgateSector</b> type element must
        /// be valid within the domain defined by its <b>mortgageSectorScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.3 and later.</remarks>
	    public static readonly Rule	RULE84
		    = new SchemeRule (Preconditions.R4_3__LATER, "scheme-84", 
				    new ElementContext ("sector"),
				    new TypeContext ("MortgateSector"), "mortgageSectorScheme");

	    /// <summary>
	    /// Rule 85: The value of any <b>PositionMatchStatus</b> type element must
        /// be valid within the domain defined by its <b>positionStatusScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.3 and later.</remarks>
	    public static readonly Rule	RULE85
		    = new SchemeRule (Preconditions.R4_3__R4_X, "scheme-85", 
				    new ElementContext ("positionMatchResult", "status"),
				    new TypeContext ("PositionMatchStatus"), "positionStatusScheme");
	
	    // FpML 4.4 ------------------------------------------------------------

        /// <summary>
        /// Rule 86: The value of any <b>CreditSupportAgreementType</b> type element must
        /// be valid within the domain defined by its <b>creditSupportAgreementTypeScheme</b>
        /// attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.4 and later.</remarks>
	    public static readonly Rule	RULE86
		    = new SchemeRule (Preconditions.R4_4__LATER, "scheme-86", 
				    new ElementContext ("creditSupportAgreement", "type"),
				    new TypeContext ("CreditSupportAgreementType"), "creditSupportAgreementTypeScheme");
	
	    // FpML 4.5 ------------------------------------------------------------
	
        /// <summary>
        /// Rule 87: The value of any <b>CommodityBusinessCalendar</b> type element must
        /// be valid within the domain defined by its <b>commodityBusinessCalendarScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE87
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-87", 
				    new ElementContext (
						    new String [] { "startTime", "endTime" },
						    new String [] { "businessCalendar", "businessCalendar" }),
				    new TypeContext ("CommodityBusinessCalendar"), "commodityBusinessCalendarScheme");

        /// <summary>
        /// Rule 88: The value of any <b>CommodityFrequencyType</b> type element must
        /// be valid within the domain defined by its <b>commodityFrequencyTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE88
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-88", 
				    new ElementContext ("dayDistribution"),
				    new TypeContext ("CommodityFrequencyType"), "commodityFrequencyTypeScheme");
	
	    /// <summary>
	    /// Rule 89: The value of any <b>CommodityFxType</b> type element must
        /// be valid within the domain defined by its <b>commodityFxTypeScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE89
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-89", 
				    new ElementContext ("fxType"),
				    new TypeContext ("CommodityFxType"), "commodityFxTypeScheme");

	    /// <summary>
	    /// Rule 90: The value of any <b>DisruptionFallback</b> type element must
        /// be valid within the domain defined by its <b>commodityMarketDisruptionFallbackScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE90
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-90", 
				    new ElementContext ("disruptionFallback", "fallback"),
				    new TypeContext ("DisruptionFallback"), "commodityMarketDisruptionFallbackScheme");

	    /// <summary>
	    /// Rule 91: The value of any <b>MarketDisruptionEvent</b> type element must
        /// be valid within the domain defined by its <b>commodityMarketDisruptionScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE91
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-91", 
				    new ElementContext ("marketDisruptionEvent"),
				    new TypeContext ("MarketDisruptionEvent"), "commodityMarketDisruptionScheme");

	    /// <summary>
	    /// Rule 92: The value of any <b>MasterAgreementVersion</b> type element must
        /// be valid within the domain defined by its <b>masterAgreementVersionScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE92
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-92", 
				    new ElementContext ("masterAgreementVersion"),
				    new TypeContext ("MasterAgreementVersion"), "masterAgreementVersionScheme");

	    /// <summary>
	    /// Rule 93: The value of any <b>CommodityQuantityFrequency</b> type element must
        /// be valid within the domain defined by its <b>quantityFrequencyScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE93
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-93", 
				    new ElementContext ("quantityFrequency"),
				    new TypeContext ("CommodityQuantityFrequency"), "quantityFrequencyScheme");

	    /// <summary>
	    /// Rule 94: The value of any <b>QuantityUnit</b> type element must
        /// be valid within the domain defined by its <b>quantityUnitScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.5 and later.</remarks>
	    public static readonly Rule	RULE94
		    = new SchemeRule (Preconditions.R4_5__LATER, "scheme-94", 
				    new ElementContext (
						    new String [] { "unit", "quantityUnit", "priceUnit" }),
				    new TypeContext ("QuantityUnit"), "quantityUnitScheme");
	
	    // FpML 4.6 ------------------------------------------------------------
	
        /// <summary>
        /// Rule 95: The value of any <b>BullionDeliveryLocation</b> type element must
        /// be valid within the domain defined by its <b>bullionDeliveryLocationScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
	    public static readonly Rule	RULE95
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-95", 
				    new ElementContext ("deliveryLocation"),
				    new TypeContext ("BullionDeliveryLocation"), "bullionDeliveryLocationScheme");

        /// <summary>
        /// Rule 96: The value of any <b>CoalQualityAdjustments</b> type element must
        /// be valid within the domain defined by its <b>commodityCoalProductTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6.</remarks>
	    public static readonly Rule	RULE96_OLD
		    = new SchemeRule (Preconditions.R4_6, "scheme-96[OLD]", 
				    new ElementContext (
						    new String [] { "coal", "coal" },
						    new String [] { "btuQualityAdjustments", "so2QualityAdjustments" }),
				    new TypeContext ("CoalQualityAdjustments"), "commodityCoalProductTypeScheme");

        /// <summary>
        /// Rule 96: The value of any <b>CoalQualityAdjustments</b> type element must
        /// be valid within the domain defined by its <b>commodityCoalQualityAdjustmentsScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE96
            = new SchemeRule (Preconditions.R4_7__LATER, "scheme-96",
                    new ElementContext (
                            new String [] { "coal", "coal" },
                            new String [] { "btuQualityAdjustments", "so2QualityAdjustments" }),
                    new TypeContext ("CoalQualityAdjustments"), "commodityCoalQualityAdjustmentsScheme");

        /// <summary>
        /// Rule 97: The value of any <b>CoalTransportationEquipment</b> type element must
        /// be valid within the domain defined by its <b>commodityCoalTransportationEquipmentScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
        public static readonly Rule RULE97
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-97", 
				    new ElementContext ("transportationEquipment"),
				    new TypeContext ("CoalTransportationEquipment"), "commodityCoalTransportationEquipmentScheme");

        /// <summary>
        /// Rule 98: The value of any <b>OilProductType</b> type element must
        /// be valid within the domain defined by its <b>commodityOilProductTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
	    public static readonly Rule	RULE98
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-98", 
				    new ElementContext ("oil", "type"),
				    new TypeContext ("OilProductType"), "commodityOilProductTypeScheme");

        /// <summary>
        /// Rule 99: The value of any <b>CommodityPayRelativeToEvent</b> type element must
        /// be valid within the domain defined by its <b>commodityPayRelativeToEventScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
        public static readonly Rule RULE99
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-99", 
				    new ElementContext ("payRelativeToEvent"),
				    new TypeContext ("CommodityPayRelativeToEvent"), "commodityPayRelativeToEventScheme");

	    /// <summary>
	    /// Rule 100: The value of any <b>CommodityDeliveryRisk</b> type element must
        /// be valid within the domain defined by its <b>deliveryRiskScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
	    public static readonly Rule	RULE100
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-100", 
				    new ElementContext ("risk"),
				    new TypeContext ("CommodityDeliveryRisk"), "deliveryRiskScheme");

        /// <summary>
        /// Rule 101: The value of any <b>DeterminationMethod</b> type element must
        /// be valid within the domain defined by its <b>determinationMethodScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
	    public static readonly Rule	RULE101
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-101", 
				    new ElementContext ("determinationMethod"),
				    new TypeContext ("DeterminationMethod"), "determinationMethodScheme");

        /// <summary>
        /// Rule 102: The value of any <b>ElectricityTransmissionContingencyType</b> type element must
        /// be valid within the domain defined by its <b>electricityTransmissionContingencyScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
        public static readonly Rule	RULE102
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-102", 
				    new ElementContext ("contingency"),
				    new TypeContext ("ElectricityTransmissionContingencyType"), "electricityTransmissionContingencyScheme");

        /// <summary>
        /// Rule 103: The value of any <b>GasQuality</b> type element must
        /// be valid within the domain defined by its <b>gasQualityScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
	    public static readonly Rule	RULE103
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-103", 
				    new ElementContext ("gas", "quality"),
				    new TypeContext ("GasQuality"), "gasQualityScheme");

        /// <summary>
        /// Rule 104: The value of any <b>MasterConfirmationAnnexType</b> type element must
        /// be valid within the domain defined by its <b>masterConfirmationAnnexTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.6 and later.</remarks>
        public static readonly Rule RULE104
		    = new SchemeRule (Preconditions.R4_6__LATER, "scheme-104", 
				    new ElementContext ("masterConfirmationAnnexType"),
				    new TypeContext ("MasterConfirmationAnnexType"), "masterConfirmationAnnexTypeScheme");

        /// <summary>
        /// Rule 105: The value of any <b>TZLocation</b> type element must
        /// be valid within the domain defined by its <b>tzLocationScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE105
		    = new SchemeRule (Preconditions.R4_6, "scheme-105", 
				    new ElementContext (
						    new String [] { "time", "supplyStartTime", "supplyEndTime" },
						    new String [] { "location", "location", "location" }),
				    new TypeContext ("TZLocation"), "tzLocationScheme");
		
	    // FpML 4.7 ------------------------------------------------------------

        /// <summary>
        /// Rule 106: The value of any <b>CoalProductSource</b> type element must
        /// be valid within the domain defined by its <b>commodityCoalProductSourceScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE106
		    = new SchemeRule (Preconditions.R4_7__LATER, "scheme-106", 
				    new ElementContext ("coal", "type"),
				    new TypeContext ("CoalProductSource"), "commodityCoalProductSourceScheme");

        /// <summary>
        /// Rule 107: The value of any <b>CoalQualityAdjustments</b> type element must
        /// be valid within the domain defined by its <b>commodityCoalQualityAdjustmentsScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE107
		    = new SchemeRule (Preconditions.R4_7__LATER, "scheme-107", 
				    new ElementContext (
						    new String [] { "coal", "coal" },
						    new String [] { "btuQualityAdjustments", "so2QualityAdjustments" }),
				    new TypeContext ("CoalQualityAdjustments"), "commodityCoalQualityAdjustmentsScheme");

        /// <summary>
        /// Rule 108: The value of any <b>SettlementPriceDefaultElection</b> type element must
        /// be valid within the domain defined by its <b>settlementPriceDefaultElectionScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE108
		    = new SchemeRule (Preconditions.R4_7__LATER, "scheme-108", 
				    new ElementContext ("settlementPriceDefaultElection"),
				    new TypeContext ("SettlementPriceDefaultElection"), "settlementPriceDefaultElectionScheme");

        /// <summary>
        /// Rule 109: The value of any <b>TimezoneLocation</b> type element must
        /// be valid within the domain defined by its <b>timezoneLocationScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.7 and later.</remarks>
        public static readonly Rule RULE109
		    = new SchemeRule (Preconditions.R4_7__LATER, "scheme-109", 
				    new ElementContext (
						    new String [] { "time", "supplyStartTime", "supplyEndTime" },
						    new String [] { "location", "location", "location" }),
				    new TypeContext ("TimezoneLocation"), "timezoneLocationScheme");

        // FpML 4.8 ------------------------------------------------------------

        /// <summary>
        /// Rule 110: The value of any <b>CommodityExpireRelativeToEvent</b> type element must
        /// be valid within the domain defined by its <b>commodityExpireRelativeToEventScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 4.8 and later.</remarks>
        public static readonly Rule RULE110
		    = new SchemeRule (Preconditions.R4_8__LATER, "scheme-110", 
				    new ElementContext ("expireRelativeToEvent"),
				    new TypeContext ("CommodityExpireRelativeToEvent"), "commodityExpireRelativeToEventScheme");
		
	    // FpML 5.0 ------------------------------------------------------------

        /// <summary>
        /// Rule 111: The value of any <b>AssetClass</b> type element must
        /// be valid within the domain defined by its <b>assetClassScheme</b> attribute.
        /// </summary>
        /// <remarks></remarks>
        public static readonly Rule RULE111
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-111", 
				    new ElementContext ("assetClass"),
				    new TypeContext ("AssetClass"), "assetClassScheme");

        /// <summary>
        /// Rule 112: The value of any <b>CreditRating</b> type element must
        /// be valid within the domain defined by its <b>creditRatingScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>
        public static readonly Rule RULE112
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-112", 
				    new ElementContext ("creditRating"),
				    new TypeContext ("CreditRating"), "creditRatingScheme");

        /// <summary>
        /// Rule 113: The value of any <b>EventStatus</b> type element must
        /// be valid within the domain defined by its <b>eventStatusScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>
        public static readonly Rule RULE113
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-113", 
				    new ElementContext ("statusItem", "status"),
				    new TypeContext ("EventStatus"), "eventStatusScheme");

        /// <summary>
        /// Rule 114: The value of any <b>IndustryClassification</b> type element must
        /// be valid within the domain defined by its <b>industryClassificationScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>
	    public static readonly Rule	RULE114
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-114", 
				    new ElementContext ("classification"),
				    new TypeContext ("IndustryClassification"), "industryClassificationScheme");

        /// <summary>
        /// Rule 115: The value of any <b>PartyRole</b> type element must
        /// be valid within the domain defined by its <b>partyRoleScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>		
	    public static readonly Rule	RULE115
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-115", 
				    new ElementContext ("relatedParty", "role"),
				    new TypeContext ("PartyRole"), "partyRoleScheme");

        /// <summary>
        /// Rule 116: The value of any <b>PartyRoleType</b> type element must
        /// be valid within the domain defined by its <b>partyRoleTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>	
	    public static readonly Rule	RULE116
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-116", 
				    new ElementContext ("relatedParty", "type"),
				    new TypeContext ("PartyRoleType"), "partyRoleTypeScheme");

        /// <summary>
        /// Rule 117: The value of any <b>PositionUpdateReasonCode</b> type element must
        /// be valid within the domain defined by its <b>positionUpdateReasonCodeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>
        public static readonly Rule RULE117
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-117", 
				    new ElementContext ("reason", "code"),
				    new TypeContext ("PositionUpdateReasonCode"), "positionUpdateReasonCodeScheme");

        /// <summary>
        /// Rule 118: The value of any <b>ReportingCurrencyType</b> type element must
        /// be valid within the domain defined by its <b>reportingCurrencyTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.0 and later.</remarks>
	    public static readonly Rule	RULE118
		    = new SchemeRule (Preconditions.R5_0__LATER, "scheme-118", 
				    new ElementContext ("currencyType"),
				    new TypeContext ("ReportingCurrencyType"), "reportingCurrencyTypeScheme");
		
	    // FpML 5.2 ------------------------------------------------------------

        /// <summary>
        /// Rule 119: The value of any <b>ClearingStatus</b> type element must
        /// be valid within the domain defined by its <b>clearingStatusScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE119
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-119", 
				    new ElementContext ("clearingStatusValue"),
				    new TypeContext ("ClearingStatusValue"), "clearingStatusScheme");
	
	    /// <summary>
	    /// Rule 120: The value of any <b>DisputeResolutionCode</b> type element must
	    /// be valid within the domain defined by its <b>collateralDisputeResolutionMethodReasonScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
	    public static readonly Rule	RULE120
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-120", 
				    new ElementContext ("disputeResolutionMethod", "resolutionCode"),
				    new TypeContext ("DisputeResolutionCode"), "collateralDisputeResolutionMethodReasonScheme");
    		
        /// <summary>
	    /// Rule 121: The value of any <b>InterestResponseReasonCode</b> type element must
	    /// be valid within the domain defined by its <b>collateralInterestResponseReasonScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE121
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-121", 
				    new ElementContext ("interestResponseReason", "reasonCode"),
				    new TypeContext ("InterestResponseReasonCode"), "collateralInterestResponseReasonScheme");
		
        /// <summary>
	    /// Rule 122: The value of any <b>MarginCallResponseReasonCode</b> type element must
	    /// be valid within the domain defined by its <b>collateralMarginCallResponseReasonScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE122
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-122", 
				    new ElementContext ("marginCallResponseReason", "reasonCode"),
				    new TypeContext ("MarginCallResponseReasonCode"), "collateralMarginCallResponseReasonScheme");
		
	    /// <summary>
        /// Rule 123: The value of any <b>CollateralResponseReasonCode</b> type element must
        /// be valid within the domain defined by its <b>collateralResponseReasonScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE123
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-123", 
				    new ElementContext ("collateralResponseReason", "reasonCode"),
				    new TypeContext ("CollateralResponseReasonCode"), "collateralResponseReasonScheme");
		
	    /// <summary>
        /// Rule 124: The value of any <b>CollateralRetractionReasonCode</b> type element must
	    /// be valid within the domain defined by its <b>collateralRetractionReasonScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE124
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-124", 
				    new ElementContext ("collateralRetractionReason", "reasonCode"),
				    new TypeContext ("CollateralRetractionReasonCode"), "collateralRetractionReasonScheme");
		
	    /// <summary>
        /// Rule 125: The value of any <b>SubstitutionReasonCode</b> type element must
	    /// be valid within the domain defined by its <b>collateralSubstitutionResponseReasonScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE125
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-125", 
				    new ElementContext ("substitutionResponseReason", "reasonCode"),
				    new TypeContext ("SubstitutionReasonCode"), "collateralSubstitutionResponseReasonScheme");
		
	    /// <summary>
        /// Rule 126: The value of any <b>OriginatingEvent</b> type element must
        /// be valid within the domain defined by its <b>originatingEventScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE126
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-126", 
				    new ElementContext ("originatingEvent"),
				    new TypeContext ("OriginatingEvent"), "originatingEventScheme");
		
	    /// <summary>
        /// Rule 127: The value of any <b>TerminatingEvent</b> type element must
	    /// be valid within the domain defined by its <b>terminatingEventScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.2 and later.</remarks>
        public static readonly Rule RULE127
		    = new SchemeRule (Preconditions.R5_2__LATER, "scheme-127", 
				    new ElementContext ("terminatingEvent"),
				    new TypeContext ("TerminatingEvent"), "terminatingEventScheme");

        // FpML 5-3 ------------------------------------------------------------

   		/// <summary>
        /// Rule 34: The value of any <b>OptionType</b> type element must be valid
		/// within the domain defined by its <b>@optionTypeScheme</b> attribute.
		/// </summary>
		/// <remarks>Applies to FpML 5.3 and later.</remarks>
		public static readonly Rule	RULE34
			= new SchemeRule (Preconditions.R5_3__LATER, "scheme-34", 
                    new ElementContext (
                        new string [] { "genericProduct" },
                        new string [] { "optionType" }),
                    new TypeContext ("OptionType"), "optionTypeScheme");
		
	    /// <summary>
        /// Rule 128: The value of any <b>AllocationReportingStatus</b> type element must
	    /// be valid within the domain defined by its <b>allocationReportingStatusScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE128
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-128", 
				    new ElementContext ("allocationStatus"),
				    new TypeContext ("AllocationReportingStatus"), "allocationReportingStatusScheme");

	    /// <summary>
        /// Rule 129: The value of any <b>BusinessProcess</b> type element must
	    /// be valid within the domain defined by its <b>businessProcessScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE129
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-129", 
				    new ElementContext ("businessProcess"),
				    new TypeContext ("BusinessProcess"), "businessProcessScheme");
    	
	    /// <summary>
        /// Rule 130: The value of any <b>TradeCategory</b> type element must
	    /// be valid within the domain defined by its <b>categoryScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE130
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-130", 
				    new ElementContext ("partyTradeInformation", "category"),
				    new TypeContext ("TradeCategory"), "categoryScheme");
    	
	    /// <summary>
        /// Rule 131: The value of any <b>CollateralizationType</b> type element must
	    /// be valid within the domain defined by its <b>collateralTypeScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE131
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-131", 
				    new ElementContext ("collateralizationType", "category"),
				    new TypeContext ("CollateralizationType"), "collateralTypeScheme");
    	
	    /// <summary>
        /// Rule 132: The value of any <b>CompressionType</b> type element must
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE132
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-132", 
				    new ElementContext ("compressionType"),
				    new TypeContext ("CompressionType"), "compressionTypeScheme");
    	
	    /// <summary>
        /// Rule 133: The value of any <b>ConfirmationMethod</b> type element must
	    /// be valid within the domain defined by its <b>confirmationMethodScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE133
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-133", 
				    new ElementContext ("confirmationMethod"),
				    new TypeContext ("ConfirmationMethod"), "confirmationMethodScheme");

        /// <summary>
        /// Rule 134: The value of any <b>CreditDocument</b> type element must
        /// be valid within the domain defined by its <b>creditDocumentScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE134
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-134", 
				    new ElementContext ("creditDocument"),
				    new TypeContext ("CreditDocument"), "creditDocumentScheme");
    	
	    /// <summary>
        /// Rule 135: The value of any <b>EmbeddedOptionType</b> type element must
	    /// be valid within the domain defined by its <b>embeddedOptionTypeScheme</b> attribute.
	    /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE135
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-135", 
				    new ElementContext ("embeddedOptionType"),
				    new TypeContext ("EmbeddedOptionType"), "embeddedOptionTypeScheme");

        /// <summary>
        /// Rule 136: The value of any <b>ExecutionType</b> type element must
        /// be valid within the domain defined by its <b>executionTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE136
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-136", 
				    new ElementContext ("executionType"),
				    new TypeContext ("ExecutionType"), "executionTypeScheme");

        /// <summary>
        /// Rule 137: The value of any <b>ExecutionVenueType</b> type element must
        /// be valid within the domain defined by its <b>executionVenueTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE137
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-137", 
				    new ElementContext ("executionVenueType"),
				    new TypeContext ("ExecutionVenueType"), "executionVenueTypeScheme");

        /// <summary>
        /// Rule 138: The value of any <b>ExposureType</b> type element must
        /// be valid within the domain defined by its <b>executionVenueTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE138
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-138", 
				    new ElementContext ("exposureType"),
				    new TypeContext ("ExposureType"), "exposureTypeScheme");

        /// <summary>
        /// Rule 139: The value of any <b>OrganizationCharacteristic</b> type element must
        /// be valid within the domain defined by its <b>organizationCharacteristicScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE139
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-139", 
				    new ElementContext ("crganizationCharacteristic"),
				    new TypeContext ("OrganizationCharacteristic"), "organizationCharacteristicScheme");

        /// <summary>
        /// Rule 140: The value of any <b>OrganizationType</b> type element must
        /// be valid within the domain defined by its <b>organizationTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE140
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-140", 
				    new ElementContext ("organizationType"),
				    new TypeContext ("OrganizationType"), "organizationTypeScheme");

        /// <summary>
        /// Rule 141: The value of any <b>ExposurePartyType</b> type element must
        /// be valid within the domain defined by its <b>partyTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE141
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-141", 
				    new ElementContext ("counterpartyType"),
				    new TypeContext ("ExposurePartyType"), "partyTypeScheme");

        /// <summary>
        /// Rule 142: The value of any <b>PersonRole</b> type element must
        /// be valid within the domain defined by its <b>personRoleScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE142
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-142", 
				    new ElementContext ("relatedPerson", "role"),
				    new TypeContext ("PersonRole"), "personRoleScheme");

        /// <summary>
        /// Rule 143: The value of any <b>PricingModel</b> type element must
        /// be valid within the domain defined by its <b>pricingModelScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE143
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-143", 
				    new ElementContext ("pricingModel"),
				    new TypeContext ("PricingModel"), "pricingModelScheme");

        /// <summary>
        /// Rule 144: The value of any <b>Region</b> type element must
        /// be valid within the domain defined by its <b>regionScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE144
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-144", 
				    new ElementContext ("region"),
				    new TypeContext ("Region"), "regionScheme");

        /// <summary>
        /// Rule 145: The value of any <b>ReportingPurpose</b> type element must
        /// be valid within the domain defined by its <b>reportingPurposeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE145
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-145", 
				    new ElementContext ("reportingPurpose"),
				    new TypeContext ("ReportingPurpose"), "reportingPurposeScheme");

        /// <summary>
        /// Rule 146: The value of any <b>ReportingRegimeName</b> type element must
        /// be valid within the domain defined by its <b>reportingRegimeNameScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE146
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-146", 
				    new ElementContext ("reportingRegime", "name"),
				    new TypeContext ("ReportingRegimeName"), "reportingRegimeNameScheme");

        /// <summary>
        /// Rule 147: The value of any <b>ReportingRole</b> type element must
        /// be valid within the domain defined by its <b>reportingRoleScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE147
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-147", 
				    new ElementContext ("reportingRole"),
				    new TypeContext ("ReportingRole"), "reportingRoleScheme");

        /// <summary>
        /// Rule 148: The value of any <b>RequestedWithdrawalAction</b> type element must
        /// be valid within the domain defined by its <b>requestedWithdrawalActionScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE148
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-148", 
				    new ElementContext ("withdrawal", "requestedAction"),
				    new TypeContext ("RequestedWithdrawalAction"), "requestedWithdrawalActionScheme");

        /// <summary>
        /// Rule 149: The value of any <b>ResourceType</b> type element must
        /// be valid within the domain defined by its <b>resourceTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE149
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-149", 
				    new ElementContext ("resourceType"),
				    new TypeContext ("ResourceType"), "resourceTypeScheme");

        /// <summary>
        /// Rule 150: The value of any <b>ServiceAdvisoryCategory</b> type element must
        /// be valid within the domain defined by its <b>serviceAdvisoryCategoryScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE150
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-150", 
				    new ElementContext ("advisory", "category"),
				    new TypeContext ("ServiceAdvisoryCategory"), "serviceAdvisoryCategoryScheme");

        /// <summary>
        /// Rule 151: The value of any <b>ServiceProcessingCycle</b> type element must
        /// be valid within the domain defined by its <b>serviceAdvisoryCategoryScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE151
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-151", 
				    new ElementContext ("processingStatus", "cycle"),
				    new TypeContext ("ServiceProcessingCycle"), "serviceProcessingCycleScheme");

        /// <summary>
        /// Rule 152: The value of any <b>ServiceProcessingEvent</b> type element must
        /// be valid within the domain defined by its <b>serviceProcessingEventScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE152
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-152", 
				    new ElementContext ("processingStatus", "event"),
				    new TypeContext ("ServiceProcessingEvent"), "serviceProcessingEventScheme");

        /// <summary>
        /// Rule 153: The value of any <b>ServiceStatus</b> type element must
        /// be valid within the domain defined by its <b>serviceStatusScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE153
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-153", 
				    new ElementContext ("serviceNotification", "status"),
				    new TypeContext ("ServiceStatus"), "serviceStatusScheme");

        /// <summary>
        /// Rule 154: The value of any <b>SupervisoryBody</b> type element must
        /// be valid within the domain defined by its <b>supervisoryBodyScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE154
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-154", 
				    new ElementContext ("supervisoryBody"),
				    new TypeContext ("SupervisoryBody"), "supervisoryBodyScheme");

        /// <summary>
        /// Rule 155: The value of any <b>TransactionCharacteristic</b> type element must
        /// be valid within the domain defined by its <b>transactionCharacteristicScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE155
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-155", 
				    new ElementContext ("transactionCharacteristic"),
				    new TypeContext ("TransactionCharacteristic"), "transactionCharacteristicScheme");

        /// <summary>
        /// Rule 156: The value of any <b>BusinessUnitRole</b> type element must
        /// be valid within the domain defined by its <b>unitRoleScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE156
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-156", 
				    new ElementContext ("relatedBusinessUnit", "role"),
				    new TypeContext ("BusinessUnitRole"), "unitRoleScheme");

        /// <summary>
        /// Rule 157: The value of any <b>VerificationMethod</b> type element must
        /// be valid within the domain defined by its <b>verificationMethodScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE157
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-157", 
				    new ElementContext ("verificationMethod"),
				    new TypeContext ("VerificationMethod"), "verificationMethodScheme");

        /// <summary>
        /// Rule 158: The value of any <b>VerificationStatus</b> type element must
        /// be valid within the domain defined by its <b>verificationStatusScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE158
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-158", 
				    new ElementContext ("verificationStatusNotification", "status"),
				    new TypeContext ("VerificationStatus"), "verificationStatusScheme");

        /// <summary>
        /// Rule 159: The value of any <b>WithdrawalReason</b> type element must
        /// be valid within the domain defined by its <b>withdrawalReasonScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.3 and later.</remarks>
        public static readonly Rule RULE159
		    = new SchemeRule (Preconditions.R5_3__LATER, "scheme-159", 
				    new ElementContext ("withdrawal", "reason"),
				    new TypeContext ("WithdrawalReason"), "withdrawalReasonScheme");

	    // FpML 5.4 ------------------------------------------------------------

        /// <summary>
        /// Rule 160: The value of any <b>AccountType</b> type element must
        /// be valid within the domain defined by its <b>accountTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE160
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-160", 
				    new ElementContext ("accountType"),
				    new TypeContext ("AccountType"), "accountTypeScheme");

        /// <summary>
        /// Rule 161: The value of any <b>CommodityMetalBrandManager</b> type element must
        /// be valid within the domain defined by its <b>commodityMetalBrandManagerScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE161
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-161", 
				    new ElementContext ("brand", "brandManager"),
				    new TypeContext ("CommodityMetalBrandManager"), "commodityMetalBrandManagerScheme");

        /// <summary>
        /// Rule 162: The value of any <b>CommodityMetalBrandName</b> type element must
        /// be valid within the domain defined by its <b>commodityMetalBrandNameScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE162
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-162", 
				    new ElementContext ("brand", "name"),
				    new TypeContext ("CommodityMetalBrandName"), "commodityMetalBrandNameScheme");

        /// <summary>
        /// Rule 163: The value of any <b>Material</b> type element must
        /// be valid within the domain defined by its <b>commodityMetalProductTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE163
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-163", 
				    new ElementContext ("metal", "material"),
				    new TypeContext ("Material"), "commodityMetalProductTypeScheme");

        /// <summary>
        /// Rule 164: The value of any <b>CommodityMetalShape</b> type element must
        /// be valid within the domain defined by its <b>commodityMetalShapeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE164
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-164", 
				    new ElementContext ("metal", "shape"),
				    new TypeContext ("CommodityMetalShape"), "commodityMetalShapeScheme");

        /// <summary>
        /// Rule 165: The value of any <b>DeclearReason</b> type element must
        /// be valid within the domain defined by its <b>declearReasonScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE165
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-165", 
				    new ElementContext ("deClear", "reason"),
				    new TypeContext ("DeclearReason"), "declearReasonScheme");

        /// <summary>
        /// Rule 166: The value of any <b>EnvironmentalProductApplicableLaw</b> type element must
        /// be valid within the domain defined by its <b>environmentalProductApplicableLawScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE166
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-166", 
				    new ElementContext ("environmental", "applicableLaw"),
				    new TypeContext ("EnvironmentalProductApplicableLaw"), "environmentalProductApplicableLawScheme");

        /// <summary>
        /// Rule 167: The value of any <b>CommodityProductGrade</b> type element must
        /// be valid within the domain defined by its <b>productGradeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE167
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-167", 
				    new ElementContext ("oil", "grade"),
				    new TypeContext ("CommodityProductGrade"), "productGradeScheme");

        /// <summary>
        /// Rule 168: The value of any <b>DataProvider</b> element must
        /// be valid within the domain defined by its <b>weatherDataProviderScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE168
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-168", 
				    new ElementContext ("dataProvider"),
				    new TypeContext ("DataProvider"), "weatherDataProviderScheme");

        /// <summary>
        /// Rule 169: The value of any <b>ReferenceLevelUnit</b> element must
        /// be valid within the domain defined by its <b>weatherIndexReferenceLevelScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE169
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-169", 
				    new ElementContext ("referenceLevelUnit"),
				    new TypeContext ("ReferenceLevelUnit"), "weatherIndexReferenceLevelScheme");

        /// <summary>
        /// Rule 170: The value of any <b>WeatherStationAirport</b> element must
        /// be valid within the domain defined by its <b>weatherStationAirportScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE170
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-170", 
				    new ElementContext ("weatherStationAirport"),
				    new TypeContext ("WeatherStationAirport"), "weatherStationAirportScheme");

        /// <summary>
        /// Rule 171: The value of any <b>WeatherStationWBAN</b> element must
        /// be valid within the domain defined by its <b>weatherStationWBANScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE171
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-171", 
				    new ElementContext ("weatherStationWBAN"),
				    new TypeContext ("WeatherStationWBAN"), "weatherStationWBANScheme");

        /// <summary>
        ///  Rule 172: The value of any <b>WeatherStationWMO</b> element must
        /// be valid within the domain defined by its <b>weatherStationWMOScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.4 and later.</remarks>
        public static readonly Rule RULE172
		    = new SchemeRule (Preconditions.R5_4__LATER, "scheme-172", 
				    new ElementContext ("weatherStationWMO"),
				    new TypeContext ("WeatherStationWMO"), "weatherStationWMOScheme");
    	
	    // FpML 5.5 ------------------------------------------------------------

        /// <summary>
        /// Rule 173: The value of any <b>CreditApprovalModel</b> type element must
        /// be valid within the domain defined by its <b>creditApprovalModelScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE173
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-173", 
				    new ElementContext ("creditApprovalModel"),
				    new TypeContext ("CreditApprovalModel"), "creditApprovalModelScheme");

        /// <summary>
        /// Rule 174: The value of any <b>CreditLimitCheckReasonCode</b> type element must
        /// be valid within the domain defined by its <b>creditLimitCheckReasonScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE174
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-174", 
				    new ElementContext ("reason", "reasonCode"),
				    new TypeContext ("CreditLimitCheckReasonCode"), "creditLimitCheckReasonScheme");

        /// <summary>
        /// Rule 175: The value of any <b>LimitType</b> type element must
        /// be valid within the domain defined by its <b>creditLimitCheckReasonScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE175
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-175", 
				    new ElementContext ("limitType"),
				    new TypeContext ("LimitType"), "creditLimitTypeScheme");

        /// <summary>
        /// Rule 176: The value of any <b>EntityClassification</b> type element must
        /// be valid within the domain defined by its <b>entityClassificationScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE176
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-176", 
				    new ElementContext ("entityClassification"),
				    new TypeContext ("EntityClassification"), "entityClassificationScheme");

        /// <summary>
        /// Rule 177: The value of any <b>EventType</b> type element must
        /// be valid within the domain defined by its <b>EventTypeScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE177
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-177", 
				    new ElementContext ("eventType"),
				    new TypeContext ("EventType"), "EventTypeScheme");

        /// <summary>
        /// Rule 178: The value of any <b>exerciseStyle</b> type element must
        /// be valid within the domain defined by its <b>exerciseStyleScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE178
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-178", 
				    new ElementContext ("exerciseStyle"),
				    new TypeContext ("GenericExerciseStyle"), "exerciseStyleScheme");

        /// <summary>
        /// Rule 179: The value of any <b>FxTemplateTerms</b> type element must
        /// be valid within the domain defined by its <b>fxTemplateTermsScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE179
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-179", 
				    new ElementContext ("applicableTerms"),
				    new TypeContext ("FxTemplateTerms"), "fxTemplateTermsScheme");

        /// <summary>
        /// Rule 180: The value of any <b>InterconnectionPoint</b> type element must
        /// be valid within the domain defined by its <b>interconnectionPointScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE180
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-180", 
				    new ElementContext ("interconnectionPoint"),
				    new TypeContext ("InterconnectionPoint"), "interconnectionPointScheme");

        /// <summary>
        /// Rule 181: The value of any <b>RequestedCollateralAllocationAction</b> type element must
        /// be valid within the domain defined by its <b>requestedCollateralAllocationActionScheme</b> attribute.
        /// </summary>
        /// <remarks>Applies to FpML 5.5 and later.</remarks>
        public static readonly Rule RULE181
		    = new SchemeRule (Preconditions.R5_5__LATER, "scheme-181", 
				    new ElementContext ("requestCollateralAllocation", "requestedAction"),
				    new TypeContext ("RequestedCollateralAllocationAction"), "requestedCollateralAllocationActionScheme");
	
	    // FpML 5.6 ------------------------------------------------------------

		/// <summary>
		/// The <see cref="RuleSet"/> used to hold the <see cref="Rule"/>
		/// instances.
		/// </summary>
		private static readonly RuleSet	rules = RuleSet.ForName ("SchemeRules");

		/// <summary>
		/// Ensures no instances can be constructed.
		/// </summary>
		private SchemeRules ()
		{ }
	}
}