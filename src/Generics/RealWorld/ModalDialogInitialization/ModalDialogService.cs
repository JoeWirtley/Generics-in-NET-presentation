using Generics.RealWorld.ModalDialogInitialization.Support;

namespace Generics.RealWorld.ModalDialogInitialization {
   public class ModalDialogService {
      private readonly RegionManager _regionManager;
      private readonly Container _container;

      public ModalDialogService( RegionManager regionManager, Container container ) {
         _regionManager = regionManager;
         _container = container;
      }

      public TView Show<TView, TArguments>( TArguments args ) where TView: IModalView<TArguments> {
         var view = _container.Resolve<TView>();
         view.Initialize( args );
         _regionManager.Regions[ "DialogRegion" ].Add( view );
         return view;
      }
   }
}