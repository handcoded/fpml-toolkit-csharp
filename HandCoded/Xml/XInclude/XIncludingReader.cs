// Copyright (C),2015 HandCoded Software Ltd.
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

using log4net;

namespace HandCoded.Xml.XInclude
{
    /// <summary>
    /// The <b>XIncludingReader</b> class implements an <see cref="XmlReader">XmlReader</see>
    /// that understands enough of the W3C XInclude 1.0 specification to allow
    /// XML files to include content from other files.
    /// </summary>
    public sealed class XIncludingReader : XmlReader
    {
        /// <summary>
        /// The namespace URL for the W3C XInclude feature 
        /// </summary>
        public static readonly string NS = "http://www.w3.org/2001/XInclude";

        /// <summary>
        /// Gets the number of attributes on the current node.
        /// </summary>
        public override int AttributeCount
        {
            get { 
                return (readers.Peek ().AttributeCount);
            }
        }

        /// <summary>
        /// Gets the base URI of the current node.
        /// </summary>
        public override string BaseURI
        {
	        get { 
                return (readers.Peek ().BaseURI);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the XmlReader implements the
        /// ReadValueChunk method.
        /// </summary>
        public override bool CanReadBinaryContent
        {
	        get { 
		        return (readers.Peek ().CanReadBinaryContent);
	        }
        }

        /// <summary>
        /// Gets the depth of the current node in the XML document.
        /// </summary>
        public override int Depth
        {
            get {
                return (readers.Peek ().Depth);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the reader is positioned at the end
        /// of the stream.
        /// </summary>
        public override bool EOF
        {
            get {
                return (readers.Peek ().EOF && (readers.Count == 1));
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current node has any attributes.
        /// </summary>
        public override bool HasAttributes
        {
            get {
                return (readers.Peek ().HasAttributes);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current node can have a Value.
        /// </summary>
        public override bool HasValue
        {
            get {
                return (readers.Peek ().HasValue);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current node is an attribute
        /// that was generated from the default value defined in the DTD or
        /// schema.
        /// </summary>
        public override bool IsDefault
        {
            get {
                return (readers.Peek ().IsDefault);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current node is an empty
        /// element (for example, <MyElement/>).
        /// </summary>
        public override bool IsEmptyElement
        {
            get {
                return (readers.Peek ().IsEmptyElement);
            }
        }

        /// <summary>
        /// Gets the local name of the current node.
        /// </summary>
        public override string LocalName
        {
            get {
                return (readers.Peek ().LocalName);
            }
        }

        /// <summary>
        /// Gets the namespace URI (as defined in the W3C Namespace
        /// specification) of the node on which the reader is positioned.
        /// </summary>
        public override string NamespaceURI
        {
            get {
                return (readers.Peek ().NamespaceURI);
            }
        }

        /// <summary>
        /// Gets the XmlNameTable associated with this implementation.
        /// </summary>
        public override XmlNameTable NameTable
        {
            get {
                return (readers.Peek ().NameTable);
            }
        }

        /// <summary>
        /// Gets the type of the current node.
        /// </summary>
        public override XmlNodeType NodeType
        {
            get {
                return (readers.Peek ().NodeType);
            }
        }

        /// <summary>
        /// Gets the namespace prefix associated with the current node.
        /// </summary>
        public override string Prefix
        {
            get {
                return (readers.Peek ().Prefix);
            }
        }

        /// <summary>
        /// Gets the state of the reader.
        /// </summary>
        public override ReadState ReadState
        {
            get {
                return (readers.Peek ().ReadState);
            }
        }

        /// <summary>
        /// Gets the text value of the current node.
        /// </summary>
        public override string Value
        {
            get {
                return (readers.Peek ().Value);
            }
        }

        /// <summary>
        /// Constructs a <b>XmlIncludingReader</b> attached to the specified
        /// <see cref="XmlReader">XmlReader</see> instance.
        /// </summary>
        /// <param name="reader">The source <see cref="XmlReader">XmlReader</see>.</param>
        public XIncludingReader (XmlReader reader)
        {
            readers.Push (reader);
        }

        /// <summary>
        /// Constructs a <b>XmlIncludingReader</b> attached to the specified
        /// <see cref="Stream">Stream</see> instance.
        /// </summary>
        /// <param name="stream">The input stream.</param>
        public XIncludingReader (Stream stream)
        {
            if (stream is FileStream) {
                string      path = (stream as FileStream).Name;
                readers.Push (XmlReader.Create (stream, null, "file://" + path.Replace ("\\", "/")));
            }
            else
                readers.Push (XmlReader.Create (stream));
        }

        /// <summary>
        /// Cchanges the ReadState to Closed.
        /// </summary>
        public override void Close ()
        {
            while (readers.Count > 0)
                readers.Pop ().Close ();
        }

        /// <summary>
        /// Gets the value of the attribute with the specified index.
        /// </summary>
        /// <param name="i">The attribute index.</param>
        /// <returns>The value of the specified attribute. If the attribute is
        /// not found or the value is <b>String.Empty</b>, <b>null</b> is
        /// returned.</returns>
        public override string GetAttribute (int i)
        {
            return (readers.Peek ().GetAttribute (i));
        }

        /// <summary>
        /// Gets the value of the attribute with the specified Name.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns>The value of the specified attribute. If the attribute is
        /// not found or the value is <b>String.Empty</b>, <b>null</b> is
        /// returned.</returns>
        public override string GetAttribute (string name)
        {
            return (readers.Peek ().GetAttribute (name));
        }

        /// <summary>
        /// Gets the value of the attribute with the specified LocalName and
        /// NamespaceURI.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="namespaceURI">The attribute namespace URI.</param>
        /// <returns>The value of the specified attribute. If the attribute is
        /// not found or the value is <b>String.Empty</b>, <b>null</b> is
        /// returned.</returns>
        public override string GetAttribute (string name, string namespaceURI)
        {
            return (readers.Peek ().GetAttribute (name, namespaceURI));
        }

        /// <summary>
        /// Resolves a namespace prefix in the current element's scope.
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns>The namespace URI to which the prefix maps or <b>null</b>
        /// if no matching prefix is found.</returns>
        public override string LookupNamespace (string prefix)
        {
            return (readers.Peek ().LookupNamespace (prefix));
        }

        /// <summary>
        /// Moves to the attribute with the specified index.
        /// </summary>
        /// <param name="i">The attribute index.</param>
        public override void MoveToAttribute (int i)
        {
            readers.Peek ().MoveToAttribute (i);
        }

        /// <summary>
        /// Moves to the attribute with the specified Name.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <returns><b>true</b> if the attribute is found; otherwise, <b>false</b>.
        /// If <b>false</b>, the reader's position does not change.</returns>
        public override bool MoveToAttribute (string name)
        {
            return (readers.Peek ().MoveToAttribute (name));
        }

        /// <summary>
        /// Moves to the attribute with the specified LocalName and NamespaceURI.
        /// </summary>
        /// <param name="name">The attribute name.</param>
        /// <param name="ns">The attribute namespace URI.</param>
        /// <returns><b>true</b> if the attribute is found; otherwise, <b>false</b>.
        /// If <b>false</b>, the reader's position does not change.</returns>
        public override bool MoveToAttribute (string name, string ns)
        {
            return (readers.Peek ().MoveToAttribute (name, ns));
        }

        /// <summary>
        /// Checks whether the current node is a content (non-white space text,
        /// CDATA, Element, EndElement, EntityReference, or EndEntity) node. If
        /// the node is not a content node, the reader skips ahead to the next
        /// content node or end of file. It skips over nodes of the following
        /// type: ProcessingInstruction, DocumentType, Comment, Whitespace, or
        /// SignificantWhitespace.
        /// </summary>
        /// <returns>The <see cref="NodeType">NodeType</see> of the current
        /// node found by the method or <b>XmlNodeType.None</b> if the reader
        /// has reached the end of the input stream.</returns>
        public override XmlNodeType MoveToContent ()
        {
            return (readers.Peek ().MoveToContent ());
        }

        /// <summary>
        /// Moves to the element that contains the current attribute node.
        /// </summary>
        /// <returns><b>true</b> if the reader is positioned on an attribute
        /// (the reader moves to the element that owns the attribute); <b>false</b>
        /// if the reader is not positioned on an attribute (the position of
        /// the reader does not change).</returns>
        public override bool MoveToElement ()
        {
            return (readers.Peek ().MoveToElement ());
        }

        /// <summary>
        /// Moves to the first attribute.
        /// </summary>
        /// <returns><b>true</b> if an attribute exists (the reader moves to
        /// the first attribute); otherwise, <b>false</b> (the position of
        /// the reader does not change).</returns>
        public override bool MoveToFirstAttribute ()
        {
            return (readers.Peek ().MoveToFirstAttribute ());
        }

        /// <summary>
        /// Moves to the next attribute.
        /// </summary>
        /// <returns><b>true</b> if there is a next attribute; <b>false</b> if
        /// there are no more attributes.</returns>
        public override bool MoveToNextAttribute ()
        {
            return (readers.Peek ().MoveToNextAttribute ());
        }

        /// <summary>
        /// Reads the next node from the stream.
        /// </summary>
        /// <returns><b>true</b> if the next node was read successfully;
        /// otherwise, <b>false</b>.</returns>
        public override bool Read ()
        {
            XmlReader reader = readers.Peek ();
            bool result = false;

            try {
                result = reader.Read ();
            }
            catch (Exception error) {
                log.Error ("Error reading XML", error);
            }

            //Console.Error.WriteLine (
            //    "Result = " + result
            //    + " NodeType = " + reader.NodeType
            //    + " NS = " + reader.NamespaceURI
            //    + " Name = " + reader.Name
            //    + " Value = " + reader.Value);

            if (result) {
                switch (reader.NodeType) {

                case XmlNodeType.Element:
                    if (reader.NamespaceURI.Equals (NS) && reader.LocalName.Equals ("include"))
                        ProcessXInclude ();
                    break;

                case XmlNodeType.EndElement:
                    if (reader.NamespaceURI.Equals (NS))
                        return (Read ());
                    break;
                }
            }
            else {
                // If EOF then try to unwind a level
                if (reader.EOF && (readers.Count > 1)) {
                    readers.Pop ().Close ();
                    return (Read ());
                }
            }

            return (result);
        }

        /// <summary>
        /// Parses the attribute value into one or more Text, EntityReference,
        /// or EndEntity nodes.
        /// </summary>
        /// <returns><b>true</b> if there are nodes to return. <b>false</b> if
        /// the reader is not positioned on an attribute node when the initial
        /// call is made or if all the attribute values have been read. An
        /// empty attribute, such as, <code>misc=""</code>, returns true with
        /// a single node with a value of <b>String.Empty</b>.</returns>
        public override bool ReadAttributeValue ()
        {
            return (readers.Peek ().ReadAttributeValue ());
        }

        /// <summary>
        /// Resolves the entity reference for EntityReference nodes.
        /// </summary>
        public override void ResolveEntity ()
        {
            readers.Peek ().ResolveEntity ();
        }

        /// <summary>
        /// <see cref="ILog"/> instance used to record problems.
        /// </summary>
        private static ILog log
            = LogManager.GetLogger (typeof (XIncludingReader));
        
        /// <summary>
        /// The stack of <see cref="XmlReader">XmlReader</see> instances being
        /// used to process content.
        /// </summary>
        private Stack<XmlReader> readers = new Stack<XmlReader> ();

        /// <summary>
        /// Handle the processing of an xinclude element and the use of
        /// fallback elements if the included content could not be accessed.
        /// </summary>
        private void ProcessXInclude ()
        {
            XmlReader source = readers.Peek ();

            string href = source.GetAttribute ("href");
            Uri baseUri = new Uri (source.BaseURI);

            Uri uri = new Uri (baseUri, href);

            try {
                XmlReader target = XmlReader.Create (uri.ToString ());

                // Search for the first element
                while (target.Read ()) {
                     if (target.NodeType == XmlNodeType.Element) {
                        source.Skip ();
                        readers.Push (target);
                        return;
                    }
                }
                target.Close ();
            }
            catch (Exception error) {
                log.Error ("Exception processing Xinclude", error);
            }

            // No content process fallback if any
            if (!source.IsEmptyElement) {
                while (source.Read ()) {
                    switch (source.NodeType) {

                    case XmlNodeType.Element:
                        if (source.NamespaceURI.Equals (NS) && source.LocalName.Equals ("fallback")) {
                            source.Read ();
                            return;
                        }
                        break;

                    case XmlNodeType.EndElement:
                        if (source.NamespaceURI.Equals (NS) && source.LocalName.Equals ("xinclude"))
                            return;
                        break;
                    }
                }
            }
        }
    }
}