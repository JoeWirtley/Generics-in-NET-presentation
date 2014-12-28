﻿using System;

namespace Generics.RealWorld.FinderTabs {
   internal static class ExampleUsage {
      public static bool ActivateView( IFinderTabs finderTabs, Guid idToActivate ) {
         IChartDisplayView openChartView;
         if ( !finderTabs.ActivateViewMeetingCondition( chart => chart.ChartId == idToActivate, out openChartView ) ) {
            return false;
         }
         // Do something with view here
         return true;
      }
   }

   internal interface IChartDisplayView {
      Guid ChartId { get; set; }
   }
}