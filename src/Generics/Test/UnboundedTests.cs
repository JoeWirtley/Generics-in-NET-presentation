using FluentAssertions;
using NUnit.Framework;

namespace Generics.Test {
   [TestFixture]
   public class UnboundedTests {
      [Test]
      public void CanUseEqualOperatorWithClassConstraint() {
         object value = new object();
         AreEqualReferenceTypes( value, new object() ).Should().BeFalse();
         AreEqualReferenceTypes( value, value ).Should().BeTrue();
      }

      private bool AreEqualReferenceTypes< T >( T first, T second ) where T : class {
         return first == second;
      }

      [Test]
      public void CanUseEqualMethodWithoutConstraint() {
         object value = new object();
         AreEqual( value, new object() ).Should().BeFalse();
         AreEqual( value, value ).Should().BeTrue();

         AreEqual( 3, 3 ).Should().BeTrue();
      }

      private bool AreEqual< T >( T first, T second ) {
         return first.Equals( second );
      }

      [Test]
      public void IsNullReturnsFalseForValueTypes() {
         IsNull<object>( null ).Should().BeTrue();
         IsNull( 2 ).Should().BeFalse();
      }

      private bool IsNull< T >( T value ) {
         return value == null;
      }

      [Test]
      public void CanConvertToInterface() {
         AsTest( new object() ).Should().BeNull();
         AsTest( new Test() ).Should().NotBeNull();


         AsTest( 3 ).Should().BeNull();
      }

      private ITest AsTest< T >( T value ) {
         return value as ITest;
      }

      private interface ITest {}

      private class Test: ITest {}
   }
}