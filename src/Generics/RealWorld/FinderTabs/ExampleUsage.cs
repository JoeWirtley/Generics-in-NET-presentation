using System;

namespace Generics.RealWorld.FinderTabs {
   internal static class ExampleUsage {
      public static bool ActivateView( IFinderTabs finderTabs, Guid idToActivate ) {
         IChartDisplayView openChart;
         if ( !finderTabs.ActivateViewMeetingCondition( chart => chart.ChartId == idToActivate, out openChart ) ) {
            return false;
         }
         return true;
      }
   }

   internal interface IChartDisplayView {
      Guid ChartId { get; set; }
   }
}