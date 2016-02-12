using System;

namespace Generics.RealWorld.ModalDialogInitialization.Support {
   public class Container {
      public T Resolve<T>() {
         return Activator.CreateInstance<T>();
      }
   }
}