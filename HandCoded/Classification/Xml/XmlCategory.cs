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

using System;

using HandCoded.Classification;

namespace HandCoded.Classification.Xml
{
    internal sealed class XmlCategory : Category
    {
        public XmlCategory (ClassificationScheme scheme, string name, bool concrete, ExprNode expression)
            : base (scheme, name, concrete)
        {
            this.expression = expression;
        }

        public XmlCategory (ClassificationScheme scheme, string name, bool concrete, Category [] parents, ExprNode expression)
            : base (scheme, name, concrete, parents)
        {
            this.expression = expression;
        }

        protected override bool IsApplicable (object value)
        {
            return ((this.expression != null) ? this.expression.Evaluate (value) : true);
        }
            
        private readonly ExprNode expression;
    }
}

