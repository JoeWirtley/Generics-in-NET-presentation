namespace Generics.RealWorld.Serialization {
   public static class SerializeExtensions {
      public static string Serialize<T>( this T toSerialize ) {
         return new XmlProcessor().Serialize( toSerialize );
      }

      public static T Deserialize<T>( this string xml ) {
         return new XmlProcessor().Deserialize<T>( xml );
      }
   }
}