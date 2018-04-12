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
    internal sealed class RangeNode : ExprNode
    {
        public RangeNode (Specification specification, Release lower, Release upper)
        {
            this.specification = specification;
            this.lower = (lower != null) ? HandCoded.FpML.Util.Version.Parse (lower.Version) : null;
            this.upper = (upper != null) ? HandCoded.FpML.Util.Version.Parse (upper.Version) : null;
        }

        public override bool Evaluate (object context)
        {
            XmlDocument ownerDocument = ((XmlElement) context).OwnerDocument;
            HandCoded.FpML.Util.Version version = HandCoded.FpML.Util.Version.Parse(this.specification.GetReleaseForDocument(ownerDocument).Version);
            bool flag = (this.lower != null) ? (version.CompareTo(this.lower) >= 0) : true;
            bool flag2 = (this.upper != null) ? (version.CompareTo(this.upper) <= 0) : true;
            return (flag & flag2);
        }

        private readonly HandCoded.FpML.Util.Version lower;

        private readonly HandCoded.FpML.Util.Version upper;

        private readonly Specification specification;
    }
}