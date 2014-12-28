using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public class MultiChart: ChartBase<MultiChart, MultichartDefinition> {
      public MultiChart() {
      }

      public MultiChart( MultichartDefinition chartDef ) {
         ChartDefinition = chartDef;
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}