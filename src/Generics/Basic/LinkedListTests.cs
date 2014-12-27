using FluentAssertions;
using Generics.Basic;
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
      public void TestLastOnIntList() {
         LinkedList<int> list = new LinkedList<int>();
         list.Last.Should().Be( 0 );

         list.Add( 42 );
         list.Last.Should().Be( 42 );
      }

      [Test]
      public void TestLastOnObjectList() {
         LinkedList<object> list = new LinkedList<object>();
         list.Last.Should().BeNull();

         var data = new object();
         list.Add( data );
         list.Last.Should().Be( data );
      }

      [Test]
      public void TestFirstOnIntList() {
         LinkedList<int> list = new LinkedList<int>();
         list.First.Should().Be( 0 );

         list.Add( 42 );
         list.First.Should().Be( 42 );
      }

      [Test]
      public void TestFirstOnObjectList() {
         LinkedList<object> list = new LinkedList<object>();
         list.First.Should().BeNull();

         var data = new object();
         list.Add( data );
         list.First.Should().Be( data );
      }

      [Test]
      public void TestIndexOfData() {
         LinkedList<int> list = new LinkedList<int>( 1, 2, 3, 4, 5, 6 );

         list.DataWhere( value => value < 4 ).Should()
            .NotBeEmpty().And
            .HaveCount( 3 ).And
            .Equal( 1, 2, 3 );

         list.DataWhere( value => value > 6 ).Should().BeEmpty();
      }
   }
}