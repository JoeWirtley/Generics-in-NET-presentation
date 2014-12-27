using System.Collections.Generic;

namespace Generics.RealWorld.Filtering {
   public class PersonFilter {
      private readonly List<IntFilter> _ageFilters = new List<IntFilter>();
      private readonly List<StringFilter> _nameFilters = new List<StringFilter>();

      public PersonFilter( AndOr andOr = AndOr.And ) {
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