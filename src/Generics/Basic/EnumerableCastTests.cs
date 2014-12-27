using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Generics.Basic {
   [TestFixture]
   public class EnumerableCastTests {
      [Test]
      public void TestCastToString() {
         ArrayList values = new ArrayList {"Apple", "Orange", "Kumquat"};

         string result = values.Cast<string>().JoinWithPlus();

         // values.JoinWithPlus(); // This line will not compile

         result.Should().Be( "Apple+Orange+Kumquat" );
      }
   }

   public static class StringExtensions {
      public static string JoinWithPlus( this IEnumerable<string> values ) {
         return string.Join( "+", values );
      }
   }
}