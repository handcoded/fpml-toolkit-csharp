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

using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
    /// <summary>
    /// The <b>MessageRules</b> class contains a <see cref="RuleSet"/>
    /// initialised with FpML defined validation rules for messages.
    /// </summary>
    public sealed class MessageRules : FpMLRuleSet
    {
        /// <summary>
        /// Provides access to the message validation rule set.
        /// </summary>
        public static RuleSet Rules
        {
            get
            {
                return (rules);
            }
        }

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects reporting, recordkeeping
        /// or transparency view documents.
        /// </summary>
        private static readonly Precondition REPO_RECO_TRAN
            = Precondition.Or (Preconditions.REPORTING,
                Precondition.Or (Preconditions.RECORDKEEPING, Preconditions.TRANSPARENCY));

        /// <summary>
        /// A rule that ensures that only novation messages can have more than
        /// two onBehalfOf elements.
        /// </summary>
        public static readonly Rule RULE05
            = new DelegatedRule (REPO_RECO_TRAN, "msg-5", Rule05);

        /// <summary>
        /// A <see cref="RuleSet"/> containing all the standard FpML defined
        /// validation rules for the collateral process.
        /// </summary>
        private static readonly RuleSet rules = RuleSet.ForName ("MessageRules");

        /// <summary>
        /// Ensures no instances can be created.
        /// </summary>
        private MessageRules ()
        { }

        // --------------------------------------------------------------------

        private static bool Rule05 (string name, NodeIndex nodeIndex, ValidationErrorHandler errorHandler)
        {
            if (nodeIndex.GetElementsByName ("onBehalfOf").Count > 2) {
                if (nodeIndex.GetElementsByName ("novation").Count > 0)
                    return (true);

                errorHandler ("305", nodeIndex.Document.DocumentElement,
                        "Only novation messages can be on behalf of more than two parties",
                        name, null);

                return (false);
            }
            return (true);
        }
    }
}