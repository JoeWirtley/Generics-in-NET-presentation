using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Generics.RealWorld.Filtering.Support;
using NUnit.Framework;

namespace Generics.RealWorld.Filtering.Test {
   [TestFixture]
   public class FilteringTests {
      private PersonRepository _repository;

      [SetUp]
      public void BeforeEachTest() {
         List<Person> people = new List<Person> {
            new Person {Name = "Susie", Age = 27},
            new Person {Name = "John", Age = 42},
            new Person {Name = "Jake", Age = 35},
            new Person {Name = "Sarah", Age = 30},
            new Person {Name = "Cheryl", Age = 44},
            new Person {Name = "Lindsey", Age = 24},
         };
         _repository = new PersonRepository( people );
      }


      [Test]
      public void NameContainsSShouldReturnThree() {
         PersonFilter filter = new PersonFilter().ForNameContains( "s" );

         IEnumerable<Person> people = _repository.GetFilteredPeople( filter );

         people.Should().NotBeEmpty().And.HaveCount( 3 );
         people.Select( person => person.Name ).Should().Equal( "Susie", "Sarah", "Lindsey" );
      }

      [Test]
      public void AgeGreaterThan30ShouldReturnThree() {
         PersonFilter filter = new PersonFilter().ForAgeGreaterThan( 30 );

         IEnumerable<Person> people = _repository.GetFilteredPeople( filter );

         people.Should().NotBeEmpty().And.HaveCount( 3 );
         people.Select( person => person.Name ).Should().Equal( "John", "Jake", "Cheryl" );
      }

      [Test]
      public void AgeGreaterThan26AndLessThan32ShouldReturnTwo() {
         PersonFilter filter = new PersonFilter().ForAgeGreaterThan( 26 ).ForAgeLessThan( 32 );

         IEnumerable<Person> people = _repository.GetFilteredPeople( filter );

         people.Should().NotBeEmpty().And.HaveCount( 2 );
         people.Select( person => person.Name ).Should().Equal( "Susie", "Sarah" );
      }

      [Test]
      public void AgeGreaterThan26AndLessThan32AndNameContainsUShouldReturnOne() {
         PersonFilter filter = new PersonFilter().ForAgeGreaterThan( 26 ).ForAgeLessThan( 32 ).ForNameContains( "u" );

         IEnumerable<Person> people = _repository.GetFilteredPeople( filter );

         people.Should().NotBeEmpty().And.HaveCount( 1 );
         people.Select( person => person.Name ).Should().Equal( "Susie" );
      }
   }
}