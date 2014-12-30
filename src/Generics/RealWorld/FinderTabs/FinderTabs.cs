using System;
using System.Collections.Generic;
using System.Linq;

namespace Generics.RealWorld.FinderTabs {
   public class FinderTabs: IFinderTabs {
      private readonly IRegionManager _regionManager;

      public FinderTabs( IRegionManager regionManager ) {
         _regionManager = regionManager;
      }

      private IRegion TabsRegion {
         get { return _regionManager.Regions[ "TabRegion" ]; }
      }

      private IEnumerable<T> GetViewsOfType<T>() {
         return TabsRegion.Views.Where( o => o is T ).Cast<T>();
      }

      public void AddView( object view ) {
         TabsRegion.Add( view );
         TabsRegion.Activate( view );
      }

      public bool ActivateViewMeetingCondition<T>( Func<T, bool> condition, out T openChart ) where T:class {
         T view = GetViewsOfType<T>().FirstOrDefault( condition );
         if ( view != null ) {
            TabsRegion.Activate( view );
         }
         openChart = view;
         return view != null;
      }

      public bool ActivateViewMeetingCondition<T>( Func<T, bool> condition ) where T:class {
         T view;
         return ActivateViewMeetingCondition( condition, out view );
      }

      public bool IsViewOpenMeetingCondition<T>( Func<T, bool> condition ) where T: class {
         return GetViewsOfType<T>().Any( condition );
      }
   }
}