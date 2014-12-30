using System;

namespace Generics.RealWorld.FinderTabs {
   public class ExampleUsage {
      private readonly IFinderTabs _finderTabs;

      public ExampleUsage( IFinderTabs finderTabs) {
         _finderTabs = finderTabs;
      }

      public bool ActivateViewWithInitialization( Guid idToActivate ) {
         IChartDisplayView openChartView;
         if ( !_finderTabs.ActivateViewMeetingCondition( chart => chart.ChartId == idToActivate, out openChartView ) ) {
            return false;
         }
         // Initialize view here
         return true;
      }

      public bool ActivateView( Guid idToActivate ) {
         return _finderTabs.ActivateViewMeetingCondition<IChartDisplayView>( chart => chart.ChartId == idToActivate );
      }
   }

   internal interface IChartDisplayView {
      Guid ChartId { get; set; }
   }
}