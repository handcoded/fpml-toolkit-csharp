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

using System.Text;
using System.Xml;

namespace HandCoded.FpML.Util
{
    /// <summary>
    /// Instances of the <b>Identifier</b> class are used to represent
    /// scheme based identifiers like those for parties, trades and messages.
    /// </summary>
    public sealed class Identifier
    {
        /// <summary>
        /// Contains the qualifying scheme URI.
        /// </summary>
        public string SchemeUri {
            get {
                return (schemeUri);
            }
        }

        /// <summary>
        /// Contains the actual identifier value.
        /// </summary>
        public string CodeValue {
            get {
                return (codeValue);
            }
        }

        /// <summary>
        /// Constructs an <b>Identifier</b> from the data contained in
	    /// the indicated DOM <see cref="XmlElement"/>.
        /// </summary>
        /// <param name="context">The DOM <see cref="XmlElement"/>.</param>
        /// <param name="attributeName">The name of the scheme attribute.</param>
        public Identifier (XmlElement context, string attributeName)
            : this (context.GetAttribute (attributeName), context.InnerText)
        { }

        /// <summary>
        /// Constructs an <b>Identifier</b> from the given data values.
        /// </summary>
        /// <param name="schemeUri">The qualifying scheme URI.</param>
        /// <param name="codeValue">The actual code value.</param>
        public Identifier (string schemeUri, string codeValue)
        {
            this.schemeUri = schemeUri;
            this.codeValue = codeValue;
        }

        /// <summary>
        /// Converts the data content of the instance into a printable string.
        /// </summary>
        /// <returns>A printable string.</returns>
        public override string ToString ()
        {
            lock (buffer) {
                buffer.Length = 0;

                if (schemeUri != null) buffer.Append (schemeUri);
                buffer.Append (':');
                if (codeValue != null) buffer.Append (codeValue);
          
                return (buffer.ToString ());
            }
        }
        
        /// <summary>
        /// Calculates the hash code value of the instance.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode ()
        {
            return (ToString ().GetHashCode ());
        }

        /// <summary>
        /// Compares the value of this <c>Identifier</c> with another
        /// <see cref="object"/>.
        /// </summary>
        /// <param name="other">The <see cref="object"/> to compare with.</param>
        /// <returns><c>true</c> if the two instances contain the same value.</returns>
        public override bool Equals (object other)
        {
 	         return ((other is Identifier) && Equals ((Identifier) other));
        }

        /// <summary>
        /// Determines if two <b>Identitier</b> instance represent the same
	    /// qualified value. 
        /// </summary>
        /// <param name="other">The instance to compare with.</param>
        /// <returns><c>true</c> if the two instances contain the same value.</returns>
        public bool Equals (Identifier other)
        {
            return (Equals (schemeUri, other.schemeUri) && Equals (codeValue, other.codeValue));
        }
        
        /// <summary>
        /// A static buffer used to format the string value.
        /// </summary>
        private static StringBuilder    buffer = new StringBuilder ();

        /// <summary>
        /// The qualifying scheme URI.
        /// </summary>
        private readonly string     schemeUri;

        /// <summary>
        /// The actual code value.
        /// </summary>
        private readonly string     codeValue;

	    /// <summary>
	    /// Compares to string or null values to determine if they have the same
	    /// value.
	    /// </summary>
	    /// <param name="lhs">The left hand string or <c>null</c>.</param>
	    /// <param name="rhs">The right hand string or <c>null</c>.</param>
	    /// <returns><c>true</c> if both strings are <c>null</c> or have
        /// the same value.</returns>
	    private static bool Equals (string lhs, string rhs)
	    {
		    return ((lhs == rhs) || ((lhs != null) && (rhs != null) && lhs.Equals (rhs)));
	    }
    }
}