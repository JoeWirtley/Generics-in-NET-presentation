namespace Generics.Basic {
   // ReSharper disable UnusedTypeParameter
   // ReSharper disable EmptyConstructor
   // ReSharper disable UnusedVariable


   public class DemoDefault<T> {
      public T GetDefault() {
         return default( T );
      }
   }

   public class ReferenceTypeClass<T> where T: class {
   }

   public class ValueTypeClass<T> where T: struct {
   }


   public interface IFoo {
   }

   public class Foo: IFoo {
   }

   public class OperatesOnIFoo<T> where T: IFoo {
   }

   public class OperatesOnFoo<T> where T: Foo {
   }

   public class TwoGenericTypes<T1, T2> where T2: T1 {
   }




   public class Bar {
   }

   public class Factory<T> where T: Bar, new() {
      public T CreateOne() {
         return new T();
      }
   }

   public class TestBar {
      public void CreateBars() {
         Factory<Bar> factory = new Factory<Bar>();
         Bar[] bars = {factory.CreateOne(), factory.CreateOne()};
      }
   }
   // ReSharper restore UnusedVariable
   // ReSharper restore EmptyConstructor
   // ReSharper restore UnusedTypeParameter
}