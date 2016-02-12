namespace Generics.RealWorld.ModalDialogInitialization.Support {
   // These interfaces stand in for Prism so that the ModalDialogService example will compile and 
   // the tests will run.
   public interface IRegion {
      void Add( IView view );
   }

   public class Region: IRegion {
      public void Add( IView view ) {
      }
   }

   public class RegionManager {
      public RegionManager() {
         Regions = new RegionCollection();
      }

      public RegionCollection Regions { get; private set; }
   }

   public class RegionCollection {
      public void Add( IRegion region ) {
      }

      public IRegion this[ string regionName ] {
         get { return new Region(); }
      }
   }
}