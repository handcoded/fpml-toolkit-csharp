// Copyright (C),2005-2013 HandCoded Software Ltd.
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

using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Text;

using HandCoded.Framework;
using HandCoded.Xml;
using HandCoded.Xml.Resolver;

using log4net;
using log4net.Config;

namespace Convert
{
    sealed class Convert : Application
    {
        /// <summary>
        /// Creates an application instance and invokes its <see cref="Run"/>
        /// method passing the command line arguments.
        /// </summary>
        /// <param name="arguments">The command line arguments.</param>
        static void Main (string [] arguments)
        {
            log4net.Config.DOMConfigurator.Configure ();

            new Convert ().Run (arguments);
        }
		/// <summary>
		/// Processes the command line options and gets ready to start file
		/// processing.
		/// </summary>
		protected override void StartUp ()
		{
			base.StartUp ();

		    // Initialise the default catalog
		    string		catalogPath = ConfigurationManager.AppSettings ["HandCoded.FpML Toolkit.XmlCatalog"];

		    if (catalogOption.Present) {
			    if (catalogOption.Value != null)
				    catalogPath = catalogOption.Value;
			    else
				    log.Error ("Missing argument for -catalog option");
		    }

            if (outputOption.Present) {
                try {
                    writer = new StreamWriter (outputOption.Value);
                }
                catch (Exception) {
                    log.Error ("Failed to create output file");
                    Environment.Exit (1);
                }
            }

            try {
                XmlUtility.DefaultCatalog = CatalogManager.Find (PathTo (catalogPath));
            }
            catch (Exception error) {
                log.Error ("Failed to parse XML catalog", error);
                Environment.Exit (1);
            }

            XmlUtility.DefaultSchemaSet.XmlSchemaSet.Compile ();
        }

		/// <summary>
		/// Perform the file processing while timing the operation.
		/// </summary>
		protected override void Execute ()
		{
			DirectoryInfo	directory = new DirectoryInfo (Environment.CurrentDirectory);
			ArrayList		files	= new ArrayList ();

			try {
				for (int index = 0; index < Arguments.Length; ++index) {
					String	        location = directory.ToString ();
					string			target	 = Arguments [index];

					while (target.StartsWith (@"..\")) {
                        location = location.Substring (0, location.LastIndexOf (Path.DirectorySeparatorChar));
						target = target.Substring (3);
					}
					FindFiles (files, Path.Combine (location, target));
				}
			}
			catch (Exception) {
				log.Fatal ("Invalid command line argument");

				Finished = true;
				return;
			}

			try {
                ;
			}
			catch (Exception error) {
				log.Fatal ("Unexpected exception during processing", error);
			}

			Finished = true;
		}

        /// <summary>
        /// Provides a text description of the expected arguments.
        /// </summary>
        /// <returns>A description of the expected application arguments.</returns>
        protected override string DescribeArguments ()
        {
            return (" files ...");
        }

        /// <summary>
        /// The <see cref="ILog"/> instance used to record problems.
        /// </summary>
        private static ILog log
            = LogManager.GetLogger (typeof (Convert));

        /// <summary>
        /// The <see cref="Option"/> instance used to detect <b>-catalog url</b>.
        /// </summary>
        private Option      catalogOption
            = new Option ("-catalog", "Use url to create an XML catalog for parsing", "url");

        /// <summary>
        /// The <see cref="Option"/> instance used to detect <b>-target version</b>
        /// </summary>
        private Option      targetOption
            = new Option ("-target", "The target version of FpML", "version");

        /// <summary>
        /// The <see cref="Option"/> instance used to detect <b>-output directory</b>
        /// </summary>
        private Option      outputOption
            = new Option ("-output", "Write output to file", "directory");

        /// <summary>
        /// The <see cref="TextWriter"/> to write output to.
        /// </summary>
        private TextWriter  writer = System.Console.Out;

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
                    FileInfo info = new FileInfo (file);

                    if ((info.Attributes & FileAttributes.Hidden) == 0)
                        files.Add (info);
                }
            }
            else {
                string directory = Path.GetDirectoryName (path);
                string pattern = Path.GetFileName (path);

                foreach (string file in Directory.GetFiles (directory, pattern)) {
                    FileInfo info = new FileInfo (file);

                    if ((info.Attributes & FileAttributes.Hidden) == 0)
                        files.Add (info);
                }
            }
        }

    }
}
