﻿// This file demonstrates a number of generic class, method, and constraint declarations
// and serves no purpose other than that.  The code in this file is displayed on presentation slides.

using System;
using System.Collections.Generic;

namespace Generics.Intermediate {
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



   public class Test {
      public Test() {
      }

      public void SomeGenericMethod<T>( T someParameter ) {
      }

      public void TypeInferred() {
         SomeGenericMethod( "Some String" );
      }

      public T AnotherGenericMethod<T>() where T: new() {
         return new T();
      }

      public void NotInferred() {
         Test value = AnotherGenericMethod<Test>();
      }
  }


   public class CoContra {

      public void Covariance() {
         IEnumerable<String> strings = new List<String>();
         IEnumerable<Object> objects = strings;
      }

   }

   public class Reflection {
      public void CreateGenericViaReflection() {
         var stringList = typeof( List<> ).MakeGenericType( typeof( string ) );
         
      }
   }

   // ReSharper restore UnusedVariable
   // ReSharper restore EmptyConstructor
   // ReSharper restore UnusedTypeParameter
}