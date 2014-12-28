using Generics.RealWorld.Filtering.Support;

namespace Generics.RealWorld.Filtering {
   public abstract class BaseFilter<T> {
      public T Value { get; set; }
      public Operator Operator { get; set; }
   }

   public class StringFilter: BaseFilter<string> {
   }

   public class IntFilter: BaseFilter<int> {
   }
}