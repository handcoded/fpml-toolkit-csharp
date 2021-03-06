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

using System;
using System.Collections;
using System.IO;
using System.Xml;

using HandCoded.Classification;
using HandCoded.FpML;
using HandCoded.FpML.Classification;
using HandCoded.FpML.Identification;
using HandCoded.FpML.Infoset;
using HandCoded.Framework;
using HandCoded.Meta;
using HandCoded.Xml;

using log4net;
using log4net.Config;

namespace Classify
{
	/// <summary>
	/// This application demonstrates the classification components being used to
	/// identify the type of product within an FpML document based on its structure.
	/// </summary>
	sealed class Classify : Application
	{
		/// <summary>
		/// Creates an application instance and invokes its <see cref="Run"/>
		/// method passing the command line arguments.
		/// </summary>
		/// <param name="arguments">The command line arguments.</param>
		[STAThread]
		static void Main (string [] arguments)
		{
			log4net.Config.DOMConfigurator.Configure ();

			new Classify ().Run (arguments);
		}

		/// <summary>
		/// Processes the command line options and gets ready to start file
		/// processing.
		/// </summary>
		protected override void StartUp ()
		{
			base.StartUp ();

		    if (Arguments.Length == 0) {
			    log.Fatal ("No files are present on the command line");
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
			catch (Exception error) {
				log.Fatal ("Invalid command line argument", error);

				Finished = true;
				return;
			}

			XmlDocument		document;
			NodeIndex		nodeIndex;

			try {
				for (int index = 0; index < files.Count; ++index) {
					string filename = (files [index] as FileInfo).FullName;
					FileStream	stream	= File.OpenRead (filename);

					document = XmlUtility.NonValidatingParse (stream);

					System.Console.WriteLine (">> " + filename);

				    Release release = Specification.ReleaseForDocument (document);
				
				    if (release != null) {
                        if (release is DTDRelease)
                            System.Console.WriteLine ("= " + release
                                + " {" + (release as DTDRelease).PublicId + "}");
                        else if (release is SchemaRelease)
                            System.Console.WriteLine ("= " + release
                                + " {" + (release as SchemaRelease).NamespaceUri + "}");
                        else
                            System.Console.WriteLine ("= " + release);
                    }

                    if (isdaOption.Present) {
                        if (release != Releases.R5_3_CONFIRMATION) {
                            Conversion conversion = Conversion.ConversionFor (release, Releases.R5_3_CONFIRMATION);

                            if (conversion == null) {
                                Console.WriteLine ("!! The contents of the file can not be converted to FpML 5.3 (Confirmation)");
                                continue;
                            }
                            document = conversion.Convert (document, new DefaultHelper ());

                            if (document == null) {
                                Console.WriteLine ("!! Automatic conversion to FpML 5.3 (Confirmation) failed");
                                continue;
                            }
                        }

					    nodeIndex = new NodeIndex (document);

					    DoIsdaClassify (nodeIndex.GetElementsByName ("trade"));
                    }
                    else {
					    nodeIndex = new NodeIndex (document);

					    DoClassify (nodeIndex.GetElementsByName ("trade"), "Trade");
					    DoClassify (nodeIndex.GetElementsByName ("contract"), "Contract");
                    }			
					stream.Close ();
				}
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
		private static ILog		log
			= LogManager.GetLogger (typeof (Classify));

		/// <summary>
		/// A command line option that allows the default taxonomy to be overridden.
		/// </summary>
		private Option				isdaOption
			= new Option ("-isda", "Use the ISDA taxonomy");

        /// <summary>
		/// Constructs a <b>Classify</b> instance.
		/// </summary>
		private Classify ()
		{ }

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
				foreach (string file in Directory.GetFiles (path)) {
					FileInfo	info = new FileInfo (file);

					if ((info.Attributes & FileAttributes.Hidden) == 0)
						files.Add (info);
				}
			}
		}

		/// <summary>
		/// Uses the predefined FpML product types to attempt to classify a
		/// product within the document.
		/// </summary>
		/// <param name="list">A set of context elements to analyze.</param>
		/// <param name="container">The type of product container for display.</param>
		private void DoClassify (XmlNodeList list, string container)
		{
			foreach (XmlElement element in list) {
			    Category	category = FpMLTaxonomy.FPML.Classify (element);

			    System.Console.Write (": " + container + "(");
			    System.Console.Write ((category != null) ? category.ToString () : "UNKNOWN");
			    System.Console.WriteLine (")");
			}
		}

        /// <summary>
        /// Attempts to classify the trades within the document using the ISDA
	    /// taxonomy defined for regulatory reporting and generate an example
	    /// UPI.
        /// </summary>
        /// <param name="list">A set of context elements to analyse.</param>
        private void DoIsdaClassify (XmlNodeList list)
        {
			foreach (XmlElement element in list) {
			    XmlDocument	infoset		= ProductInfoset.CreateInfoset (element);
			    XmlElement	infosetRoot	= infoset.DocumentElement;
							
			    Category	assetClass  = ISDATaxonomy.AssetClassForInfoset (infosetRoot);
			    Category	productType = ISDATaxonomy.ProductTypeForInfoset (infosetRoot);
			    UPI			upi = UPI.ForProductInfoset (infosetRoot, productType);

			    System.Console.Write (": Trade (");
			    System.Console.Write ((assetClass != null) ? assetClass.ToString () : "UNKNOWN");
                System.Console.Write (" / ");
			    System.Console.Write ((productType != null) ? productType.ToString () : "UNKNOWN");
                System.Console.Write (" / ");
			    System.Console.Write ((upi != null) ? upi.ToString () : "UNKNOWN");
			    System.Console.WriteLine (")");
            }
       }
	}
}