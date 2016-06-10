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

using System.Collections.Generic;
using System.Xml;

using HandCoded.Meta;
using HandCoded.Validation;
using HandCoded.Xml;

namespace HandCoded.FpML.Validation
{
    /// <summary>
    /// A <b>VersionRangePrecondition</b> instance tests if the FpML version
    /// of a documents lies between two limits. Either of the minimum or maximum
    /// values can be omitted to make the range open ended.
    /// </summary>
    public class VersionRangePrecondition : Precondition
    {
        /// <summary>
        /// Constructs a <b>VersionRangePrecondition</b> using the two
        /// bounding release versions.
        /// </summary>
        /// <param name="minimum">The minimum version accepted.</param>
        /// <param name="maximum">The maximum version accepted.</param>
        public VersionRangePrecondition (Release minimum, Release maximum)
            : this ((minimum != null) ? minimum.Version : null,
                    (maximum != null) ? maximum.Version : null)
        { }

        /// <summary>
        /// Constructs a <b>VersionRangePrecondition</b> using the two
        /// bounding release versions.
        /// </summary>
        /// <param name="minimum">The minimum version accepted.</param>
        /// <param name="maximum">The maximum version accepted.</param>
        public VersionRangePrecondition (string minimum, string maximum)
        {
            this.minimum = (minimum != null) ? HandCoded.FpML.Util.Version.Parse (minimum) : null;
            this.maximum = (maximum != null) ? HandCoded.FpML.Util.Version.Parse (maximum) : null;
        }
        
        /// <summary>
		/// Evaluates this <see cref="Precondition"/> against the contents of the
		/// indicated <see cref="NodeIndex"/>.
		/// </summary>
		/// <param name="nodeIndex">The <see cref="NodeIndex"/> of a <see cref="XmlDocument"/></param>
        /// <param name="cache">A cache of previously evaluated precondition results.</param>
		/// <returns>A <see cref="bool"/> value indicating the applicability of this
		/// <see cref="Precondition"/> to the <see cref="XmlDocument"/>.</returns>
 	    public override bool Evaluate (NodeIndex nodeIndex, Dictionary<Precondition, bool> cache)
	    {
		    HandCoded.FpML.Util.Version version;
    		
		    // Find the document version
		    XmlNodeList list = nodeIndex.GetElementsByName ("FpML");
		    if (list.Count > 0)
			    version = FpML.Util.Version.Parse (((XmlElement) list [0]).GetAttribute ("version"));
		    else {
			    list = nodeIndex.GetAttributesByName ("fpmlVersion");
			    if (list.Count > 0)
				    version = FpML.Util.Version.Parse (((XmlAttribute) list [0]).Value);
			    else
				    return (false);
		    }
    		
//		    System.Console.Write ("Range (Doc=" + version
//				+ " Min=" + ((minimum != null) ? minimum.ToString () : "*")
//				+ " Max=" + ((maximum != null) ? maximum.ToString () : "*"));

		    bool validMin = (minimum != null) ? (version.CompareTo (minimum) >= 0) : true;
		    bool validMax = (maximum != null) ? (version.CompareTo (maximum) <= 0) : true;
    		
//		    System.Console.WriteLine (") => " + (validMin & validMax));

		    return (validMin & validMax);
	    }

		/// <summary>
		/// Creates debugging string describing the precondition rule.
		/// </summary>
		/// <returns>A debugging string.</returns>
        public override string  ToString()
        {
		    return ("minimum=" + ((minimum != null) ? minimum.ToString () : "any") +
				    " maximum=" + ((maximum != null) ? maximum.ToString () : "any"));	
        }
    	
        /// <summary>
        /// The minimum FpML version number.
        /// </summary>
	    private readonly HandCoded.FpML.Util.Version	minimum;
    	
        /// <summary>
        /// The maximum FpML version number.
        /// </summary>
	    private readonly HandCoded.FpML.Util.Version	maximum;
    }
}