using FluentAssertions;
using NUnit.Framework;

namespace Generics.Test {
   [TestFixture]
   public class LinkedListTests {
      [Test]
      public void TestConstruction() {
         LinkedList<int> list = new LinkedList<int>();

         list.Should().BeEmpty();
      }

      [Test]
      public void TestOneMember() {
         LinkedList<int> list = new LinkedList<int> {42};

         list.Should().NotBeEmpty().And.HaveCount( 1 );
         list.Should().Equal( 42 );
      }

      [Test]
      public void TestTwoMembers() {
         LinkedList<int> list = new LinkedList<int> {42, 54};

         list.Should().NotBeEmpty().And.HaveCount( 2 );
         list.Should().Equal( 42, 54 );
      }

      [Test]
      public void TestInsertMember() {
         LinkedList<int> list = new LinkedList<int> {42, 54};
         list.Insert( 21 );

         list.Should().NotBeEmpty().And.HaveCount( 3 );
         list.Should().Equal( 21, 42, 54 );
      }

      [Test]
      public void TestLastOnEmptyIntList() {
         LinkedList<int> list = new LinkedList<int>();
         list.Last.Should().Be( 0 );
      }

      [Test]
      public void TestLastOnEmptyObjectList() {
         LinkedList<object> list = new LinkedList<object>();
         list.Last.Should().BeNull();
      }
   }
}