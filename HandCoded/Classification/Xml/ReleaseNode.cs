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

using HandCoded.Meta;

namespace HandCoded.Classification.Xml
{
    internal sealed class ReleaseNode : ExprNode
    {
        public ReleaseNode (Specification specification, Release release)
        {
            this.specification = specification;
            this.release = release;
        }

        public override bool Evaluate (object context)
        {
            XmlDocument ownerDocument = ((XmlElement) context).OwnerDocument;
            return (this.specification.GetReleaseForDocument (ownerDocument) == this.release);
        }

        private readonly Release release;
        private readonly Specification specification;
    }
}