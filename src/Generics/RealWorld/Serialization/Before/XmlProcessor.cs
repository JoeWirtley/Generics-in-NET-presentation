using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Generics.RealWorld.Serialization.Support;

namespace Generics.RealWorld.Serialization.Before {
   public class XmlProcessor {

      public PurchaseOrder DeserializePurchaseOrder( string xml ) {
         StringReader stringReader = new StringReader( xml );
         XmlTextReader xmlTextReader = new XmlTextReader( stringReader );
         XmlSerializer xmlSerializer = new XmlSerializer( typeof( PurchaseOrder ) );
         return ( ( PurchaseOrder ) ( xmlSerializer.Deserialize( xmlTextReader ) ) );
      }

      public Invoice DeserializeInvoice( string xml ) {
         StringReader stringReader = new StringReader( xml );
         XmlTextReader xmlTextReader = new XmlTextReader( stringReader );
         XmlSerializer xmlSerializer = new XmlSerializer( typeof( Invoice ) );
         return ( ( Invoice ) ( xmlSerializer.Deserialize( xmlTextReader ) ) );
      }

      public string SerializePurchaseOrder( PurchaseOrder po ) {
         string result = "";
         MemoryStream serializedStream = new MemoryStream();
         try {
            XmlSerializer serializer = new XmlSerializer( typeof( PurchaseOrder ) );
            XmlTextWriter serializedTextWriter = new XmlTextWriter( serializedStream, new UTF8Encoding() );
            serializer.Serialize( serializedTextWriter, po );
            result = UTF8ByteArrayToString( serializedStream.ToArray() );
         } finally {
            serializedStream.Close();
         }
         return result;
      }

      public string SerializeInvoice( Invoice invoice ) {
         string result = "";
         MemoryStream serializedStream = new MemoryStream();
         try {
            XmlSerializer serializer = new XmlSerializer( typeof( Invoice ) );
            XmlTextWriter serializedTextWriter = new XmlTextWriter( serializedStream, new UTF8Encoding() );
            serializer.Serialize( serializedTextWriter, invoice );
            result = UTF8ByteArrayToString( serializedStream.ToArray() );
         } finally {
            serializedStream.Close();
         }
         return result;
      }

      private string UTF8ByteArrayToString( Byte[] characters ) {
         UTF8Encoding encoding = new UTF8Encoding();
         string constructedString = encoding.GetString( characters );
         return ( constructedString );
      }
   }
}