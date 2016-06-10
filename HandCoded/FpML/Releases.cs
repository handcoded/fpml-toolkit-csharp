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

using log4net;

using HandCoded.FpML.Meta;

namespace HandCoded.FpML
{
	/// <summary>
	/// The <b>Releases</b> class contains a set of static objects describing
	/// the FpML specification and its various releases.
	/// </summary>
	public sealed class Releases
	{
		/// <summary>
		/// The <see cref="HandCoded.Meta.InstanceInitialiser"/> used to populate new documents.
		/// </summary>
		private static HandCoded.Meta.InstanceInitialiser	initialiser
			= new FpMLInstanceInitialiser ();
		
		/// <summary>
		/// The <see cref="HandCoded.Meta.SchemaRecogniser"/> used to detect schema based documents.
		/// </summary>
		private static HandCoded.Meta.SchemaRecogniser	recogniser
			= new FpMLSchemaRecogniser ();
		
		/// <summary>
		/// A <see cref="HandCoded.Meta.Specification"/> instance representing FpML as a whole.
		/// </summary>
		public static readonly HandCoded.Meta.Specification FPML
			= HandCoded.Meta.Specification.ForName ("FpML");

		/// <summary>
		/// A <see cref="DTDRelease"/> instance containing the details for the
		/// FpML 1-0 recommendation.
		/// </summary>
		public static readonly DTDRelease	R1_0
			= FPML.GetReleaseForVersion ("1-0") as DTDRelease;

		/// <summary>
		/// A <see cref="DTDRelease"/> instance containing the details for the
		///FpML 2-0 recommendation.
		/// </summary>
		public static readonly DTDRelease	R2_0
			= FPML.GetReleaseForVersion ("2-0") as DTDRelease;

		/// <summary>
		/// A <see cref="DTDRelease"/> instance containing the details for the
		/// FpML 3-0 trial recommendation.
		/// </summary>
		public static readonly DTDRelease	R3_0
			= FPML.GetReleaseForVersion ("3-0") as DTDRelease;
		
		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-0 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_0
			= FPML.GetReleaseForVersion ("4-0") as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-1 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_1
			= FPML.GetReleaseForVersion ("4-1") as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-2 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_2
			= FPML.GetReleaseForVersion ("4-2") as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-3 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_3
			= FPML.GetReleaseForVersion ("4-3") as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-4 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_4
			= FPML.GetReleaseForVersion ("4-4") as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-5 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_5
			= FPML.GetReleaseForVersion ("4-5") as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 4-6 recommendation.
		/// </summary>
		public static readonly SchemaRelease	R4_6
			= FPML.GetReleaseForVersion ("4-6") as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 4-7 recommendation.
        /// </summary>
        public static readonly SchemaRelease R4_7
            = FPML.GetReleaseForVersion ("4-7") as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 4-8 recommendation.
        /// </summary>
        public static readonly SchemaRelease R4_8
            = FPML.GetReleaseForVersion ("4-8") as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 4-9 recommendation.
        /// </summary>
        public static readonly SchemaRelease R4_9
            = FPML.GetReleaseForVersion ("4-9") as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 4-10 recommendation.
        /// </summary>
        public static readonly SchemaRelease R4_10
            = FPML.GetReleaseForVersion ("4-10") as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-0 confirmation view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_0_CONFIRMATION
			= FPML.GetReleaseForVersionAndNamespace ("5-0", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-0 reporting view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_0_REPORTING
			= FPML.GetReleaseForVersionAndNamespace ("5-0", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-1 confirmation view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_1_CONFIRMATION
			= FPML.GetReleaseForVersionAndNamespace ("5-1", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-1 reporting view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_1_REPORTING
			= FPML.GetReleaseForVersionAndNamespace ("5-1", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-2 confirmation view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_2_CONFIRMATION
			= FPML.GetReleaseForVersionAndNamespace ("5-2", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-2 reporting view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_2_REPORTING
			= FPML.GetReleaseForVersionAndNamespace ("5-2", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-3 confirmation view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_3_CONFIRMATION
			= FPML.GetReleaseForVersionAndNamespace ("5-3", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-3 record keeeping view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_3_RECORDKEEPING
			= FPML.GetReleaseForVersionAndNamespace ("5-3", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-3 reporting view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_3_REPORTING
			= FPML.GetReleaseForVersionAndNamespace ("5-3", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-3 transparency view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_3_TRANSPARENCY
			= FPML.GetReleaseForVersionAndNamespace ("5-3", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-4 confirmation view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_4_CONFIRMATION
			= FPML.GetReleaseForVersionAndNamespace ("5-4", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-4 record keeeping view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_4_RECORDKEEPING
			= FPML.GetReleaseForVersionAndNamespace ("5-4", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

		/// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-4 reporting view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_4_REPORTING
			= FPML.GetReleaseForVersionAndNamespace ("5-4", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
		/// A <see cref="SchemaRelease"/> instance containing the details for
		/// FpML 5-4 transparency view recommendation.
		/// </summary>
		public static readonly SchemaRelease	R5_4_TRANSPARENCY
			= FPML.GetReleaseForVersionAndNamespace ("5-4", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-5 confirmation view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_5_CONFIRMATION
            = FPML.GetReleaseForVersionAndNamespace ("5-5", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-5 record keeeping view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_5_RECORDKEEPING
            = FPML.GetReleaseForVersionAndNamespace ("5-5", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-5 reporting view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_5_REPORTING
            = FPML.GetReleaseForVersionAndNamespace ("5-5", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-5 transparency view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_5_TRANSPARENCY
            = FPML.GetReleaseForVersionAndNamespace ("5-5", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-5 pre-trade view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_5_PRETRADE
            = FPML.GetReleaseForVersionAndNamespace ("5-5", "http://www.fpml.org/FpML-5/pretrade")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-6 confirmation view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_6_CONFIRMATION
            = FPML.GetReleaseForVersionAndNamespace ("5-6", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-6 record keeeping view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_6_RECORDKEEPING
            = FPML.GetReleaseForVersionAndNamespace ("5-6", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-6 reporting view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_6_REPORTING
            = FPML.GetReleaseForVersionAndNamespace ("5-6", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-6 transparency view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_6_TRANSPARENCY
            = FPML.GetReleaseForVersionAndNamespace ("5-6", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-6 pre-trade view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_6_PRETRADE
            = FPML.GetReleaseForVersionAndNamespace ("5-6", "http://www.fpml.org/FpML-5/pretrade")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-7 confirmation view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_7_CONFIRMATION
            = FPML.GetReleaseForVersionAndNamespace("5-7", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-7 record keeeping view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_7_RECORDKEEPING
            = FPML.GetReleaseForVersionAndNamespace("5-7", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-7 reporting view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_7_REPORTING
            = FPML.GetReleaseForVersionAndNamespace("5-7", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-7 transparency view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_7_TRANSPARENCY
            = FPML.GetReleaseForVersionAndNamespace("5-7", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-7 pre-trade view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_7_PRETRADE
            = FPML.GetReleaseForVersionAndNamespace("5-7", "http://www.fpml.org/FpML-5/pretrade")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-8 confirmation view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_8_CONFIRMATION
            = FPML.GetReleaseForVersionAndNamespace ("5-8", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-8 record keeeping view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_8_RECORDKEEPING
            = FPML.GetReleaseForVersionAndNamespace ("5-8", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-8 reporting view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_8_REPORTING
            = FPML.GetReleaseForVersionAndNamespace ("5-8", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-8 transparency view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_8_TRANSPARENCY
            = FPML.GetReleaseForVersionAndNamespace ("5-8", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-8 pre-trade view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_8_PRETRADE
            = FPML.GetReleaseForVersionAndNamespace ("5-8", "http://www.fpml.org/FpML-5/pretrade")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-9 confirmation view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_9_CONFIRMATION
            = FPML.GetReleaseForVersionAndNamespace ("5-9", "http://www.fpml.org/FpML-5/confirmation")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-9 record keeeping view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_9_RECORDKEEPING
            = FPML.GetReleaseForVersionAndNamespace ("5-9", "http://www.fpml.org/FpML-5/recordkeeping")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-9 reporting view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_9_REPORTING
            = FPML.GetReleaseForVersionAndNamespace ("5-9", "http://www.fpml.org/FpML-5/reporting")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-9 transparency view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_9_TRANSPARENCY
            = FPML.GetReleaseForVersionAndNamespace ("5-9", "http://www.fpml.org/FpML-5/transparency")
                as SchemaRelease;

        /// <summary>
        /// A <see cref="SchemaRelease"/> instance containing the details for
        /// FpML 5-9 pre-trade view recommendation.
        /// </summary>
        public static readonly SchemaRelease R5_9_PRETRADE
            = FPML.GetReleaseForVersionAndNamespace ("5-9", "http://www.fpml.org/FpML-5/pretrade")
                as SchemaRelease;

        /// <summary>
		/// The FpML 1.0 to 2.0 <see cref="HandCoded.Meta.Conversion"/> instance.
		/// </summary>
		private static readonly HandCoded.Meta.Conversion R1_0__R2_0
			= new Conversions.R1_0__R2_0 ();

		/// <summary>
		/// The FpML 2.0 to 3.0 <see cref="HandCoded.Meta.Conversion"/> instance.
		/// </summary>
		private static readonly HandCoded.Meta.Conversion R2_0__R3_0
			= new Conversions.R2_0__R3_0 ();

		/// <summary>
		/// The FpML 3.0 to 4.0 <see cref="HandCoded.Meta.Conversion"/> instance.
		/// </summary>
		private static readonly HandCoded.Meta.Conversion R3_0__R4_0
			= new Conversions.R3_0__R4_0 ();

		/// <summary>
		/// The FpML 4.0 to 4.1 <see cref="HandCoded.Meta.Conversion"/> instance.
		/// </summary>
		private static readonly HandCoded.Meta.Conversion R4_0__R4_1
			= new Conversions.R4_0__R4_1 ();

		/// <summary>
		/// The FpML 4.1 to 4.2 <see cref="HandCoded.Meta.Conversion"/> instance.
		/// </summary>
		private static readonly HandCoded.Meta.Conversion R4_1__R4_2
			= new Conversions.R4_1__R4_2 ();

        /// <summary>
        /// The FpML 4.2 to 4.3 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_2__R4_3
            = new Conversions.R4_2__R4_3 ();

        /// <summary>
        /// The FpML 4.3 to 4.4 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_3__R4_4
            = new Conversions.R4_3__R4_4 ();

        /// <summary>
        /// The FpML 4.4 to 4.5 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_4__R4_5
            = new Conversions.R4_4__R4_5 ();

        /// <summary>
        /// The FpML 4.5 to 4.6 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_5__R4_6
            = new Conversions.R4_5__R4_6 ();

        /// <summary>
        /// The FpML 4.6 to 4.7 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_6__R4_7
            = new Conversions.R4_6__R4_7 ();

        /// <summary>
        /// The FpML 4.7 to 4.8 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_7__R4_8
            = new Conversions.R4_7__R4_8 ();

        /// <summary>
        /// The FpML 4.8 to 4.9 <see cref="HandCoded.Meta.Conversion"/> instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R4_8__R4_9
            = new Conversions.R4_8__R4_9 ();

        /// <summary>
        /// The FpML 5.0 to 5.1 confirmation view <see cref="HandCoded.Meta.Conversion"/>
        /// instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R5_0__R5_1_CONFIRMATION
            = new Conversions.R5_0__R5_1_CONFIRMATION ();

        /// <summary>
        /// The FpML 5.1 to 5.2 confirmation view <see cref="HandCoded.Meta.Conversion"/>
        /// instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R5_1__R5_2_CONFIRMATION
            = new Conversions.R5_1__R5_2_CONFIRMATION ();

        /// <summary>
        /// The FpML 5.2 to 5.3 confirmation view <see cref="HandCoded.Meta.Conversion"/>
        /// instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R5_2__R5_3_CONFIRMATION
            = new Conversions.R5_2__R5_3_CONFIRMATION ();

        /// <summary>
        /// The FpML 5.3 to 5.4 confirmation view <see cref="HandCoded.Meta.Conversion"/>
        /// instance.
        /// </summary>
        private static readonly HandCoded.Meta.Conversion R5_3__R5_4_CONFIRMATION
            = new Conversions.R5_3__R5_4_CONFIRMATION ();

        /// <summary>
		/// <see cref="ILog"/> instance used to record problems.
		/// </summary>
		private static ILog			log
			= LogManager.GetLogger (typeof (Releases));

		/// <summary>
		/// Ensures that no instances can be created.
		/// </summary>
		private Releases ()
		{ }
	}
}