using System;

namespace Generics.RealWorld.FinderTabs {
   public interface IFinderTabs {
      bool ActivateViewMeetingCondition<T>( Func<T, bool> condition, out T openChart ) where T:class;
      bool ActivateViewMeetingCondition<T>( Func<T, bool> condition ) where T:class;
      bool IsViewOpenMeetingCondition<T>( Func<T, bool> condition ) where T: class;
   }
}