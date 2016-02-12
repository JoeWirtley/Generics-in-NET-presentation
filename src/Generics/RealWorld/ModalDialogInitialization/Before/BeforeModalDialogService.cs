using System;
using Generics.RealWorld.ModalDialogInitialization.Support;

namespace Generics.RealWorld.ModalDialogInitialization.Before {

   public class BeforeModalDialogService {
      private readonly RegionManager _regionManager;
      private readonly Container _container;

      public BeforeModalDialogService( RegionManager regionManager, Container container ) {
         _regionManager = regionManager;
         _container = container;
      }

      public TView Show<TView>( params object[] args ) where TView: IView {
         var view = _container.Resolve<TView>();
         InvokeInitialize( view, args );
         _regionManager.Regions[ "DialogRegion" ].Add( view );
         return view;
      }

      private void InvokeInitialize<T>( T view, params object[] args ) {
         var initializeMethod = view.GetType().GetMethod( "Initialize" );
         if ( initializeMethod != null ) {
            initializeMethod.Invoke( view, new Object[] { args } );
         }
      }
   }
}