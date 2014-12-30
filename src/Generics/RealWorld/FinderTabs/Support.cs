using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Generics.RealWorld.FinderTabs {
   public interface IFinderTabs {
      bool ActivateViewMeetingCondition<T>( Func<T, bool> condition, out T openChart ) where T:class;
      bool ActivateViewMeetingCondition<T>( Func<T, bool> condition ) where T:class;
      bool IsViewOpenMeetingCondition<T>( Func<T, bool> condition ) where T:class;
   }

   // These interfaces stand in for Prism so that the FinderTabs example will compile.
   public interface IRegion {
      void Activate( object view );
      IEnumerable<object> Views { get; }
      void Add( object view );
   }

   public interface IRegionManager {
      IRegionCollection Regions { get; set; }
   }

   public interface IRegionCollection: IEnumerable<IRegion>, IEnumerable, INotifyCollectionChanged {
      void Add( IRegion region );
      bool Remove( string regionName );
      bool ContainsRegionWithName( string regionName );
      IRegion this[ string regionName ] { get; }
   }
}