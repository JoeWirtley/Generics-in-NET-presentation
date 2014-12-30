using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Generics.RealWorld.Filtering.Support;

namespace Generics.RealWorld.Filtering {
   internal class PersonRepository {
      private readonly IEnumerable<Person> _people;

      public PersonRepository( IEnumerable<Person> people ) {
         _people = people;
      }

      public Person[] GetFilteredPeople( PersonFilter filter ) {
         IEnumerable<Expression<Func<Person, bool>>> clauses = CreateWhereClausesFromFilter( filter );

         Expression<Func<Person, bool>> whereClause;
         if ( filter.AndOr == AndOr.Or ) {
            whereClause = new WhereClauseOrBuilder<Person>( clauses ).WhereExpression;
         } else {
            whereClause = new WhereClauseAndBuilder<Person>( clauses ).WhereExpression;
         }

         return _people.AsQueryable().Where( whereClause ).ToArray();
      }

      private IEnumerable<Expression<Func<Person, bool>>> CreateWhereClausesFromFilter( PersonFilter filter ) {
         var clauses = new List<Expression<Func<Person, bool>>>();

         if ( filter.NameFilters.Any() ) {
            foreach ( StringFilter nameFilter in filter.NameFilters ) {
               StringFilter localFilter = nameFilter;
               if ( nameFilter.Operator == Operator.Equals ) {
                  clauses.Add( person => person.Name.ToLowerInvariant() == localFilter.Value.ToLowerInvariant() );
               } else if ( nameFilter.Operator == Operator.Contains ) {
                  clauses.Add( person => person.Name.ToLowerInvariant().Contains( localFilter.Value.ToLowerInvariant() ) );
               }
            }
         }
         if ( filter.AgeFilters.Any() ) {
            foreach ( IntFilter ageFilter in filter.AgeFilters ) {
               IntFilter localFilter = ageFilter;
               if ( ageFilter.Operator == Operator.Equals ) {
                  clauses.Add( person => person.Age == localFilter.Value );
               } else if ( ageFilter.Operator == Operator.GreaterThan ) {
                  clauses.Add( person => person.Age > localFilter.Value );
               } else if ( ageFilter.Operator == Operator.LessThan ) {
                  clauses.Add( person => person.Age < localFilter.Value );
               }
            }
         }
         return clauses;
      }
   }
}