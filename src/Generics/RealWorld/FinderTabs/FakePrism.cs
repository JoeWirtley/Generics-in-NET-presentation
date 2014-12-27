// This file defines interfaces to stand in for Prism so that the FinderTabs examplw will compile.
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Generics.RealWorld.FinderTabs {
   public interface IRegion {
      void Activate( object view );
      void Add( object view, string toString, bool createRegionManagerScope );
      IEnumerable<object> Views { get; }
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