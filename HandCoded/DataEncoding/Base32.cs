// Copyright (C),2006-2012 HandCoded Software Ltd.
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

using System.Text;

namespace HandCoded.DataEncoding
{
    /// <summary>
    /// The <b>Base32</b> class provides a utility function for converting a
    /// <c>byte</c> array into a printable string.
    /// </summary>
    public sealed class Base32
    {
        /// <summary>
        /// Encodes an array of bytes as a BASE32 string using the lexicon defined
	    /// in RFC 4648.
        /// </summary>
        /// <param name="bytes">The array of bytes to be encoded.</param>
        /// <returns>The encode data as a <see cref="string"/>.</returns>
        public static string Encode (byte [] bytes)
        {
            int             bits    = 0;
            int             count   = 0;
            int             index   = 0;
            StringBuilder   buffer  = new StringBuilder ();

            // Encode bits until the byte array is exhausted
            while (index < bytes.Length) {
                if (count < 5) {
                    bits = (bits << 8) | bytes [index++];
                    count += 8;
                }
                buffer.Append (LEXICON [(bits >> (count - 5)) & 0x1f]);
                count -= 5;
            }

            // Encode any remaining buffered bits
            while (count >= 5) {
                buffer.Append (LEXICON [(bits >> (count - 5)) & 0x1f]);
                count -= 5;
            }
            if (count > 0) {
                buffer.Append (LEXICON [(bits << (5 - count)) & 0x1f]);
                count -= 5;
            }

            // And add padding to end of quantum
            while (count != 0) {
                if (count < 5) count += 8;
                buffer.Append ('=');
                count -= 5;
            }

            return (buffer.ToString ());
        }

        /// <summary>
        /// The lexicon of characters allowed in the encoded string.
        /// </summary>
        private static readonly string LEXICON
            = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";

        /// <summary>
        /// Prevents any instances from being constructed.
        /// </summary>
        private Base32 ()
        { }
    }
}