// Copyright (C),2005-2013 HandCoded Software Ltd.
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace CodeCompiler
{
	class CodeComplier
	{
		static void Main (string [] args)
		{
			foreach (string arg in args) {
				if (arg.IndexOfAny ("*?".ToCharArray ()) != -1) {
					FileInfo [] infos = new DirectoryInfo (Environment.CurrentDirectory).GetFiles (arg);

					foreach (FileInfo info in infos) {
						XmlDocument doc = new XmlDocument ();

						doc.Load (info.FullName);
						string name = doc.SelectSingleNode ("//Identification/ShortName").InnerText;
                        string version = doc.SelectSingleNode ("//Identification/Version").InnerText;

						if (!name.Equals ("FpML Set of Coding Schemes"))
							codeLists [name+ "-" + version] = doc;
					}
				}
				else {
					XmlDocument doc = new XmlDocument ();

					doc.Load (arg);
					string name = doc.SelectSingleNode ("//Identification/ShortName").InnerText;

					if (!name.Equals ("FpML Set of Coding Schemes"))
						codeLists [name] = doc;
				}
			}

            Console.OutputEncoding = Encoding.UTF8;
			Console.Out.WriteLine ("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			Console.Out.WriteLine ("<schemeDefinitions>");
			foreach (string name in codeLists.Keys) {
				XmlDocument doc = codeLists [name];
				string uri = doc.SelectSingleNode ("//Identification/CanonicalVersionUri").InnerText;
				string canonicalUri = doc.SelectSingleNode ("//Identification/CanonicalUri").InnerText;

				Console.Out.WriteLine ("\t<scheme uri=\"" + uri
					+ "\" canonicalUri=\"" + canonicalUri
					+ "\" name=\"" + name + "\">");
				Console.Out.WriteLine ("\t\t<schemeValues>");

				int codeIndex = -1;
				int sourceIndex = -1;
				int descIndex = -1;

				int count = 1;
				foreach (XmlNode node in doc.SelectNodes ("//ColumnSet/Column")) {
					string text = node ["ShortName"].InnerText;

					if (text.Equals ("Code")) codeIndex = count;
					if (text.Equals ("Source")) sourceIndex = count;
					if (text.Equals ("Description")) descIndex = count;

					++count;
				}

				if ((codeIndex == -1) || (sourceIndex == -1) || (descIndex == -1)) {
					Console.Error.WriteLine ("A required column is not present in code list for " + name);
					continue;
				}

				foreach (XmlNode node in doc.SelectNodes ("//SimpleCodeList/Row")) {
					string code = Escape (node.SelectSingleNode ("Value[" + codeIndex + "]/SimpleValue").InnerText);
					string source = Escape (node.SelectSingleNode ("Value[" + sourceIndex + "]/SimpleValue").InnerText);
					string desc = Escape (node.SelectSingleNode ("Value[" + descIndex + "]/SimpleValue").InnerText.Trim ());

					Console.Out.WriteLine ("\t\t\t<schemeValue schemeValueSource=\"" + source + "\" name=\"" + code + "\">");
					if (desc.Length > 0)
						Console.Out.WriteLine ("\t\t\t\t<paragraph>" + desc + "</paragraph>");
					Console.Out.WriteLine ("\t\t\t</schemeValue>");
				}

				Console.Out.WriteLine ("\t\t</schemeValues>");
				Console.Out.WriteLine ("\t</scheme>");
			}
			Console.Out.WriteLine ("</schemeDefinitions>");
		}

        /// <summary>
        /// The set of codelists to be processed into a single file.
        /// </summary>
		private static SortedDictionary<string, XmlDocument>	codeLists
		 = new SortedDictionary<string,XmlDocument> ();

        /// <summary>
        /// Replace characters in the argument string that must be escaped in
        /// XML with thier equivalent control sequence.
        /// </summary>
        /// <param name="str">The string to be processed</param>
        /// <returns>The string with special XML characters escaped.</returns>
		private static string Escape (string str)
		{
			StringBuilder	buffer	= new StringBuilder ();

			foreach (char ch in str) {
				if (ch == '<')
					buffer.Append ("&lt;");
				else if (ch == '&')
					buffer.Append ("&amp;");
				else if (ch == '\'')
					buffer.Append ("&apos;");
				else
					buffer.Append (ch);
			}
			return (buffer.ToString ());
		}
	}
}