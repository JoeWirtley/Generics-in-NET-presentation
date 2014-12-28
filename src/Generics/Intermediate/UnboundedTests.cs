using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Generics.Intermediate {
   /// <summary>
   /// These tests demonstrate some properties of unbounded generic types (generic types without any constraints).
   /// It also illustrates potential issue with comparison using the == operator for constrained generic types.
   /// </summary>
   [TestFixture]
   public class UnboundedTests {
      [Test]
      public void CanUseEqualOperatorWithClassConstraint() {
         // You can only use == to compare generics with a class constraint
         object value = new object();
         AreEqualReferenceTypes( value, new object() ).Should().BeFalse();
         AreEqualReferenceTypes( value, value ).Should().BeTrue();
      }

      // If you comment out the class constraint, this will no longer compile, since you cannot
      // use the == operator without the class constraint
      private bool AreEqualReferenceTypes< T >( T first, T second ) where T : class {
         return first == second;
      }

      [Test]
      public void EqualsMayNotWorkAsYouExpect() {
         // Note that ths first comparison succeeds and the second does not.  When comparing generic values using
         // == (or !=), it will always do a reference comparison, not a value comparison, even if the == operator is 
         // overloaded.  See http://msdn.microsoft.com/en-us/library/d5x73970.aspx 
         AreEqualReferenceTypes( "foo", "foo" ).Should().BeTrue();

         const string targetString = "target";
         string target = new StringBuilder( targetString ).ToString();
         target.Should().Be( targetString );
         AreEqualReferenceTypes( targetString, target ).Should().BeFalse();
      }

      [Test]
      public void CanUseEqualMethodWithoutConstraint() {
         // Generics without constraints can be compared with the .Equal method
         object value = new object();
         AreEqual( value, new object() ).Should().BeFalse();
         AreEqual( value, value ).Should().BeTrue();
         AreEqual( "foo", "foo" ).Should().BeTrue();

         AreEqual( 3, 3 ).Should().BeTrue();
         AreEqual( 4.5m, 4.5m ).Should().BeTrue();
      }

      private bool AreEqual< T >( T first, T second ) {
         return first.Equals( second );
      }

      [Test]
      public void IsNullReturnsFalseForValueTypes() {
         // Generics without constraints can be compred to null
         IsNull<object>( new object() ).Should().BeFalse();
         IsNull<object>( null ).Should().BeTrue();
         IsNull( 2 ).Should().BeFalse();
      }

      private bool IsNull< T >( T value ) {
         return value == null;
      }

      [Test]
      public void CanConvertToInterface() {
         // Generics without constraint can be converted to an interface
         AsITest( new object() ).Should().BeNull();
         AsITest( new Test() ).Should().NotBeNull();

         AsITest( 3 ).Should().BeNull();
      }

      private ITest AsITest<T>( T value ) {
         return value as ITest;
      }

      [Test]
      public void CanConvertToClass() {
         // Generics without constraint can be converted to a class
         AsTest( new object() ).Should().BeNull();
         AsTest( new Test() ).Should().NotBeNull();

         AsTest( 3 ).Should().BeNull();
      }

      private Test AsTest<T>( T value ) {
         return value as Test;
      }

      private interface ITest {}

      private class Test: ITest {}
   }
}