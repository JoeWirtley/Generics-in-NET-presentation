using System.Collections.Generic;

namespace Generics.RealWorld.Filtering.Support {
   public class PersonFilter {
      private readonly List<IntFilter> _ageFilters = new List<IntFilter>();
      private readonly List<StringFilter> _nameFilters = new List<StringFilter>();

      public static PersonFilter And() {
         return new PersonFilter( AndOr.And );
      }

      public static PersonFilter Or() {
         return new PersonFilter( AndOr.Or );
      }

      private PersonFilter( AndOr andOr) {
         AndOr = andOr;
      }

      public AndOr AndOr { get; private set; }

      public IEnumerable<StringFilter> NameFilters {
         get { return _nameFilters; }
      }

      public IEnumerable<IntFilter> AgeFilters {
         get { return _ageFilters; }
      }

      public PersonFilter ForNameEquals( string name ) {
         _nameFilters.Add( new StringFilter {Value = name, Operator = Operator.Equals} );
         return this;
      }

      public PersonFilter ForNameContains( string partialName ) {
         _nameFilters.Add( new StringFilter {Value = partialName, Operator = Operator.Contains} );
         return this;
      }

      public PersonFilter ForAgeGreaterThan( int age ) {
         _ageFilters.Add( new IntFilter { Value = age, Operator = Operator.GreaterThan}  );
         return this;
      }

      public PersonFilter ForAgeLessThan( int age ) {
         _ageFilters.Add( new IntFilter { Value = age, Operator = Operator.LessThan } );
         return this;
      }
   }
}