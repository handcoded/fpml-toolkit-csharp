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
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;

using HandCoded.Framework;
using HandCoded.Xml;
using HandCoded.Xml.Writer;

using log4net;
using log4net.Config;

namespace ViewCompiler
{
    public class ViewCompiler : Application
    {
		/// <summary>
		/// Creates an application instance and invokes its <see cref="Run"/>
		/// method passing the command line arguments.
		/// </summary>
		/// <param name="arguments">The command line arguments.</param>
		[STAThread]
		static void Main (string[] arguments)
		{
			log4net.Config.DOMConfigurator.Configure ();

			new ViewCompiler ().Run (arguments);
		}

        /// <summary>
		/// Processes the command line options and gets ready to start file
		/// processing.
		/// </summary>
		protected override void StartUp ()
		{
			base.StartUp ();

            if (!viewOption.Present) {
                log.Fatal ("No view name specified on the command line");
                Environment.Exit (1);
            }

            if (!outputOption.Present) {
                log.Fatal ("No output directory path specified on the command line");
                Environment.Exit (1);
            }
            if (!Directory.Exists (outputOption.Value))
                Directory.CreateDirectory (outputOption.Value);

            if (Arguments.Length == 0) {
                log.Fatal ("No master schema files have been provided");
                Environment.Exit (1);
            }
        }

		/// <summary>
		/// Perform the file processing while timing the operation.
		/// </summary>
		protected override void Execute ()
		{
			DirectoryInfo	directory = new DirectoryInfo (Environment.CurrentDirectory);

			try {
				for (int index = 0; index < Arguments.Length; ++index) {
					DirectoryInfo	location = directory;
					string			target	 = Arguments [index];

					while (target.StartsWith (@"..\")) {
						location = location.Parent;
						target = target.Substring (3);
					}
					FindFiles (files, Path.Combine (location.ToString (), target));
				}
			}
			catch (Exception) {
				log.Fatal ("Invalid command line argument");

				Finished = true;
				return;
			}

            foreach (FileInfo info in files)
                ProcessSchema (info.FullName);

            Finished = true;
        }

		/// <summary>
		/// Provides a text description of the expected arguments.
		/// </summary>
		/// <returns>A description of the expected application arguments.</returns>
		protected override string DescribeArguments ()
		{
			return (" schemas");
		}

		/// <summary>
		/// The <see cref="ILog"/> instance used to record problems.
		/// </summary>
		private static ILog		log
			= LogManager.GetLogger (typeof (ViewCompiler));
       
		/// <summary>
		/// The <see cref="Option"/> instance used obtain the view name.
		/// </summary>
		private Option			viewOption
			= new Option ("-view", "The target view name", "name");
		
		/// <summary>
		/// The <see cref="Option"/> instance used define a suffix added to
        /// generated files.
		/// </summary>
		private Option			suffixOption
			= new Option ("-suffix", "Optional file suffix (e.g. -version)", "string");
		
		/// <summary>
		/// The <see cref="Option"/> instance used define the output directory.
		/// </summary>
		private Option			outputOption
			= new Option ("-output", "The output directory)", "path");
		
        /// <summary>
        /// A list of all the schema files to process
        /// </summary>
 		private ArrayList		files	= new ArrayList ();

        /// <summary>
        /// Constructs a <b>ViewCompiler</b> instance.
        /// </summary>
        private ViewCompiler ()
        { }

        /// <summary>
        /// Determine if a text string contains a decimal value.
        /// </summary>
        /// <param name="text">The text string to test.</param>
        /// <returns>A <c>bool</c> value indicating the result.</returns>
        private static bool IsNumber (string text)
        {
            if (text.Length > 0) {
                foreach (char ch in text) {
                    if ((ch < '0') || (ch > '9'))
                        return (false);
                }
                return (true);
            }
            return (false);
        }

        /// <summary>
        /// Reads in a schema file, updates its contents to match the target view
        /// and write out the result if the schema is not empty afterwards.
        /// </summary>
        /// <param name="filename">The filename of the schema to be processed.</param>
        private void ProcessSchema (string filename)
        {
            FileStream  stream = new FileStream (filename, FileMode.Open);
            XmlDocument document = XmlUtility.NonValidatingParse (stream);
            stream.Close ();

            WalkSchema (document.DocumentElement);
            if (document.DocumentElement != null) {
                string suffix = suffixOption.Value;

                if (suffix == null) suffix = "";

                string target
                    = Path.Combine (
                        Path.Combine (Path.GetDirectoryName (filename), outputOption.Value),
                        Path.GetFileNameWithoutExtension (filename) + suffix + Path.GetExtension (filename));
                    
                Stream output = new FileStream (target, FileMode.Create);
                new TidyWriter (output, Encoding.UTF8).Write (document);
                output.Close ();
            }
        }

        /// <summary>
        /// Recursively walks through an XML Schema making the changed indicated
        /// by the override definitions.
        /// </summary>
        /// <param name="element">The <see cref="XmlElement"/> to process.</param>
        private void WalkSchema (XmlElement element)
        {
            // Does this element have a child annotation?
            XmlElement annotation = XPath.Path (element, "annotation");
            if (annotation != null) {
                XmlElement appInfo = XPath.Path (annotation, "appinfo");
                if (appInfo != null) {
                    bool        skipped   = false;
                    bool        exclusive = false;
                    bool        included  = false;

                    foreach (XmlElement command in DOM.GetChildElements (appInfo)) {
                        if (command.LocalName.Equals ("exclusive")) {
                            exclusive = true;
                            if (command.GetAttribute ("view").Equals (viewOption.Value))
                                included = true;

                            appInfo.RemoveChild (command);
                        }
                        else if (command.LocalName.Equals ("skip")) {
                            if (command.GetAttribute ("view").Equals (viewOption.Value))
                                skipped = true;

                            appInfo.RemoveChild (command);
                        }
                        else if (command.LocalName.Equals ("override")) {
                            if (command.GetAttribute ("view").Equals (viewOption.Value)) {
                                // Do the actual attribute overriding
                                foreach (XmlAttribute attribute in command.Attributes) {
                                    if (!attribute.LocalName.Equals ("view")) {
                                        string oldValue = element.GetAttribute (attribute.LocalName, attribute.NamespaceURI);
                                        string newValue = attribute.Value;

                                        element.SetAttribute (attribute.LocalName, attribute.NamespaceURI, attribute.Value);

                                        if (attribute.LocalName.Equals ("minOccurs")) {
                                            if (IsNumber (oldValue) && IsNumber (newValue)) {
                                                if (Int32.Parse (oldValue) > Int32.Parse (newValue)) {
                                                    Console.Out.WriteLine ("Invalid minOccurs override on "
                                                        + element.LocalName + " @" + attribute.LocalName);
                                                }
                                            }
                                        }
                                        else if (attribute.LocalName.Equals ("maxOccurs")) {
                                            if (IsNumber (oldValue) && IsNumber (newValue)) {
                                                if (Int32.Parse (oldValue) < Int32.Parse (newValue)) {
                                                    Console.Out.WriteLine ("Invalid maxOccurs override on "
                                                        + element.LocalName + " @" + attribute.LocalName);
                                                }
                                            }
                                        }
                                    }
                                }

                                XmlNodeList newDocs = XPath.Paths (command, "documentation");

                                // If we have new documentation the replace the old stuff
                                if (newDocs.Count > 0) {
                                    XmlNodeList oldDocs = XPath.Paths (annotation, "documentation");

                                    foreach (XmlNode node in oldDocs)
                                        annotation.RemoveChild (node);

                                    foreach (XmlNode node in newDocs)
                                        annotation.AppendChild (node);
                                }
                            }
                            appInfo.RemoveChild (command);
                        }
                    }

                    // Remove elements that are skipped or excluded
                    if (skipped || (exclusive && !included))
                        element.ParentNode.RemoveChild (element);

                    // Remove empty appInfo elements
                    if (DOM.GetChildElements (appInfo).Count == 0)
                        annotation.RemoveChild (appInfo);
                }

                // Remove empty annotation elements
                if (DOM.GetChildElements (annotation).Count == 0)
                    element.RemoveChild (annotation);
            }

            // Handle view renaming in namespace attributes
            foreach (XmlAttribute attribute in element.Attributes) {
                if (attribute.LocalName.StartsWith ("xmlns") ||
                    attribute.LocalName.Equals ("namespace") ||
                    attribute.LocalName.Equals ("targetNamespace"))
                    attribute.Value = attribute.Value.Replace ("master", viewOption.Value);
            }

            // Handle file renaming in schemaLocation attributes
            if (suffixOption.Present) {
                XmlAttribute attribute = element.GetAttributeNode ("schemaLocation");
                if (attribute != null) {
                    string      location = attribute.Value;

                    foreach (FileInfo info in files) {
                        string filename = info.FullName;
                        string oldname 
                            = Path.GetFileName (filename);
                        string newname
                            = Path.GetFileNameWithoutExtension (filename)
                            + suffixOption.Value
                            + Path.GetExtension (filename);

                        location = location.Replace (oldname, newname);
                    }

                    attribute.Value = location;
                }
            }
                       
            // Recurse over any child elements
            foreach (XmlElement child in DOM.GetChildElements (element))
                WalkSchema (child);
        }

 		/// <summary>
		/// Creates a list of files to be processed by expanding a path and handling
		/// wildcards.
		/// </summary>
		/// <param name="files">The set of files to be processed.</param>
		/// <param name="path">The path to be processed.</param>
		private void FindFiles (ArrayList files, string path)
		{
			if (Directory.Exists (path)) {
				foreach (string subdir in Directory.GetDirectories (path)) {
					if ((new DirectoryInfo (subdir).Attributes & FileAttributes.Hidden) == 0)
						FindFiles (files, subdir);
				}

				foreach (string file in Directory.GetFiles (path, "*.xml")) {
					FileInfo	info = new FileInfo (file);

					if ((info.Attributes & FileAttributes.Hidden) == 0)
						files.Add (info);
				}
			}
			else {
                string directory = Path.GetDirectoryName (path);
                string pattern = Path.GetFileName (path);

				foreach (string file in Directory.GetFiles (directory, pattern)) {
					FileInfo	info = new FileInfo (file);

					if ((info.Attributes & FileAttributes.Hidden) == 0)
						files.Add (info);
				}
			}
		}
    }
}