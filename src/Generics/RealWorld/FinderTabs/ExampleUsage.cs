using System;

namespace Generics.RealWorld.FinderTabs {
   internal static class ExampleUsage {
      public static bool ActivateView( IFinderTabs finderTabs, Guid idToActivate ) {
         IChartDisplayView openChart;
         if ( !finderTabs.ActivateViewMeetingCondition( chart => chart.ChartId == idToActivate, out openChart ) ) {
            return false;
         }
         // Do something with View here
         return true;
      }
   }

   internal interface IChartDisplayView {
      Guid ChartId { get; set; }
   }
}