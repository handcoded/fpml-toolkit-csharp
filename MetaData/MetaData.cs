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

using System;
using System.Collections;
using System.Configuration;
using System.Text;

using HandCoded.Framework;
using HandCoded.Meta;
using HandCoded.Xml;
using HandCoded.Xml.Resolver;

using log4net;
using log4net.Config;
 
namespace MetaData
{
    /// <summary>
    /// 
    /// </summary>
    class MetaData : Application
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

			new MetaData ().Run (arguments);
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

            try {
			    XmlUtility.DefaultCatalog = CatalogManager.Find (PathTo (catalogPath));
            }
            catch (Exception error) {
                log.Error ("Failed to parse XML catalog", error);
				Environment.Exit (1);
            }
	    }

		/// <summary>
		/// Perform the file processing while timing the operation.
		/// </summary>
		protected override void Execute ()
		{
            foreach (Specification specification in Specification.Specifications) {
                Console.WriteLine (">> " + specification.Name);

                foreach (Release release in specification.Releases) {
                    if (release is DTDRelease)
                        Console.WriteLine ("DTD " + release.Version
                            + " " + ((DTDRelease) release).PublicId);
                    else if (release is SchemaRelease)
                        Console.WriteLine ("XSD " + release.Version
                            + " " + ((SchemaRelease) release).NamespaceUri);
                    else
                        Console.WriteLine ("??? " + release.Version);
                }
            }
            Finished = true;
        }

		/// <summary>
		/// The <see cref="ILog"/> instance used to record problems.
		/// </summary>
		private static ILog		log
			= LogManager.GetLogger (typeof (MetaData));
    }
}