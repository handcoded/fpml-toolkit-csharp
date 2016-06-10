// Copyright (C),2005-2015 HandCoded Software Ltd.
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

namespace HandCoded.FpML.Validation
{
	/// <summary>
	/// The <b>Preconditions</b> class contains a set of <see cref="Precondition"/>
	/// instances used by the rules to define thier applicability.
	/// </summary>
	public sealed class Preconditions
	{
		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 1-0 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R1_0
			= new VersionPrecondition ("1-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 2-0 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R2_0
			= new VersionPrecondition ("2-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 3-0 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R3_0
			= new VersionPrecondition ("3-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-0 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_0
			= new VersionPrecondition ("4-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-1 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_1
			= new VersionPrecondition ("4-1");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-2 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_2
			= new VersionPrecondition ("4-2");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-3 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_3
			= new VersionPrecondition ("4-3");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-4 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_4
			= new VersionPrecondition ("4-4");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-5 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_5
			= new VersionPrecondition ("4-5");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 4-6 compatible
		/// documents.
		/// </summary>
		public static readonly Precondition	R4_6
			= new VersionPrecondition ("4-6");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 4-7 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R4_7
            = new VersionPrecondition ("4-7");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 4-8 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R4_8
            = new VersionPrecondition ("4-8");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 4-9 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R4_9
            = new VersionPrecondition ("4-9");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-0 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_0
            = new VersionPrecondition ("5-0");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-1 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_1
            = new VersionPrecondition ("5-1");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-2 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_2
            = new VersionPrecondition ("5-2");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-3 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_3
            = new VersionPrecondition ("5-3");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-4 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_4
            = new VersionPrecondition ("5-4");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-5 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_5
            = new VersionPrecondition("5-5");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-6 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_6
            = new VersionPrecondition("5-6");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-7 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_7
            = new VersionPrecondition("5-7");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML 5-8 compatible
        /// documents.
        /// </summary>
        public static readonly Precondition R5_8
            = new VersionPrecondition ("5-8");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects any FpML 4-x compatible
	    /// document.
        /// </summary>
	    public static readonly Precondition R4_X
		    = new VersionRangePrecondition (Releases.R4_0, Releases.R4_9);

       /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 5-0 confirmation
		/// compatible documents.
		/// </summary>
		public static readonly Precondition	R5_0__LATER_CONFIRMATION
			= new NamespacePrecondition (Releases.R5_0_CONFIRMATION);

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 5-0 reporting
		/// compatible documents.
		/// </summary>
		public static readonly Precondition	R5_0__LATER_REPORTING
			= new NamespacePrecondition (Releases.R5_0_REPORTING);

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 5-2 transparency
		/// compatible documents.
		/// </summary>
		public static readonly Precondition	R5_3__LATER_TRANSPARENCY
			= new NamespacePrecondition (Releases.R5_3_TRANSPARENCY);

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML 5-3 record keeping
		/// compatible documents.
		/// </summary>
		public static readonly Precondition	R5_3__LATER_RECORDKEEPING
			= new NamespacePrecondition (Releases.R5_3_RECORDKEEPING);

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML versions that use
		/// XPointer syntax for intra-document links.
		/// </summary>
		public static readonly Precondition	R1_0__R2_0
			= new VersionRangePrecondition ("1-0", "2-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects either FpML 1-0,
		/// 2-0 or 3-0 compatible documents.
		/// </summary>
		public static readonly Precondition	R1_0__R3_0
			= new VersionRangePrecondition ("1-0", "3-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects either FpML 1-0 thru
        /// 4-6 compatible documents.
		/// </summary>
		public static readonly Precondition	R1_0__R4_6
			= new VersionRangePrecondition ("1-0", "4-6");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects either FpML 1-0 thru
        /// 4-9 compatible documents.
        /// </summary>
        public static readonly Precondition R1_0__R4_9
            = new VersionRangePrecondition ("1-0", "4-9");

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 2-0 and
		/// 3-0.
		/// </summary>
		public static readonly Precondition	R2_0__R3_0
			= new VersionRangePrecondition ("2-0", "3-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 3-0 and
		/// 4-0.
		/// </summary>
		public static readonly Precondition	R3_0__R4_0
			= new VersionRangePrecondition ("3-0", "4-0");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 3-0 or
		/// 4-*.
		/// </summary>
		public static readonly Precondition	R3_0__R4_X
			= new VersionRangePrecondition ("3-0", "4-9999");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 4-0
        /// or 4-1.
		/// </summary>
		public static readonly Precondition	R4_0__R4_1
			= new VersionRangePrecondition ("4-0", "4-1");

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 4-*.
		/// </summary>
		public static readonly Precondition	R4_0__R4_X
			= new VersionRangePrecondition ("4-0", "4-9999");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 4-1
        /// or later 4-* compatible document.
        /// </summary>
        public static readonly Precondition R4_1__R4_X
            = new VersionRangePrecondition ("4-1", "4-9999");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 4-2
        /// thru 4-4 document.
        /// </summary>
        public static readonly Precondition R4_2__R4_4
            = new VersionRangePrecondition ("4-2", "4-4");

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 4-*
        /// document from 4-2 onwards.
		/// </summary>
		public static readonly Precondition	R4_2__R4_X
			= new VersionRangePrecondition ("4-2", "4-9999");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 4-*
        /// document from 4-3 onwards.
        /// </summary>
        public static readonly Precondition R4_3__R4_X
            = new VersionRangePrecondition ("4-3", "4-9999");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 4-*
        /// document from 4-4 onwards.
        /// </summary>
        public static readonly Precondition R4_4__R4_X
            = new VersionRangePrecondition ("4-4", "4-9999");

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML version 5-0
        /// up to 5-3.
		/// </summary>
		public static readonly Precondition	R5_0__R5_3
            = new VersionRangePrecondition ("5-0", "5-3");

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 2-0 and
        /// later.
        /// </summary>
        public static readonly Precondition R1_0__LATER
            = new VersionRangePrecondition ("1-0", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 2-0 and
        /// later.
        /// </summary>
        public static readonly Precondition R2_0__LATER
            = new VersionRangePrecondition ("2-0", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML version 3-0 and
        /// later.
        /// </summary>
        public static readonly Precondition R3_0__LATER
            = new VersionRangePrecondition ("3-0", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-0 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_0__LATER
            = new VersionRangePrecondition ("4-0", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-1 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_1__LATER
            = new VersionRangePrecondition ("4-1", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-2 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_2__LATER
            = new VersionRangePrecondition ("4-2", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-3 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_3__LATER
            = new VersionRangePrecondition ("4-3", null);

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML versions 4-4 and
		/// later.
		/// </summary>
		public static readonly Precondition	R4_4__LATER
			= new VersionRangePrecondition ("4-4", null);

		/// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML versions 4-5 and
		/// later.
		/// </summary>
		public static readonly Precondition	R4_5__LATER
			= new VersionRangePrecondition ("4-5", null);

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects FpML versions 4-6 and
		/// later.
		/// </summary>
		public static readonly Precondition	R4_6__LATER
			= new VersionRangePrecondition ("4-6", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-7 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_7__LATER
            = new VersionRangePrecondition ("4-7", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-8 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_8__LATER
            = new VersionRangePrecondition ("4-8", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 4-9 and
        /// later.
        /// </summary>
        public static readonly Precondition R4_9__LATER
            = new VersionRangePrecondition ("4-9", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-0 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_0__LATER
            = new VersionRangePrecondition ("5-0", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-1 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_1__LATER
            = new VersionRangePrecondition ("5-1", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-2 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_2__LATER
            = new VersionRangePrecondition ("5-2", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-3 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_3__LATER
            = new VersionRangePrecondition ("5-3", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-4 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_4__LATER
            = new VersionRangePrecondition ("5-4", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-5 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_5__LATER
            = new VersionRangePrecondition ("5-5", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-6 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_6__LATER
            = new VersionRangePrecondition ("5-6", null);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects FpML versions 5-7 and
        /// later.
        /// </summary>
        public static readonly Precondition R5_7__LATER
            = new VersionRangePrecondition("5-7", null);

        /// <summary>
		/// A <see cref="Precondition"/> instance that detects all FpML versions 
		/// except 4-0.
		/// </summary>
		public static readonly Precondition	NOT_R4_0
			= Precondition.Not (R4_0);

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects all confirmation
        /// view documents.
        /// </summary>
	    public static readonly Precondition	CONFIRMATION
		    = Precondition.Or (new Precondition []
		   	    {
				    R1_0__R3_0,
				    R4_0__R4_X,
				    R5_0__LATER_CONFIRMATION
		   	    });

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects all reporting
        /// view documents.
        /// </summary>
        public static readonly Precondition REPORTING
		    = Precondition.Or (new Precondition []
		   	    {
				    R4_1__R4_X,
				    R5_0__LATER_REPORTING
		   	    });

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects all record keeping
        /// view documents.
        /// </summary>
        public static readonly Precondition RECORDKEEPING
		    = R5_3__LATER_RECORDKEEPING;

        /// <summary>
        /// A <see cref="Precondition"/> instance that detects all transparency
        /// view documents.
        /// </summary>
        public static readonly Precondition TRANSPARENCY
		    = R5_3__LATER_TRANSPARENCY;

		/// <summary>
		/// Ensures that no instances can be created.
		/// </summary>
		private Preconditions()
		{ }
    }
}