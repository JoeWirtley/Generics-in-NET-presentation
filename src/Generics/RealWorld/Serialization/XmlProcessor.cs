using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Generics.RealWorld.Serialization {
   public class XmlProcessor {
      public T Deserialize< T >( string xml ) {
         StringReader stringReader = new StringReader( xml );
         XmlTextReader xmlTextReader = new XmlTextReader( stringReader );
         XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
         return ( ( T ) ( xmlSerializer.Deserialize( xmlTextReader ) ) );
      }

      public string Serialize< T >( T toSerialize ) {
         string result = "";
         MemoryStream serializedStream = new MemoryStream();
         try {
            XmlSerializer serializer = new XmlSerializer( typeof( T ) );
            XmlTextWriter serializedTextWriter = new XmlTextWriter( serializedStream, new UTF8Encoding() );
            serializer.Serialize( serializedTextWriter, toSerialize );
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