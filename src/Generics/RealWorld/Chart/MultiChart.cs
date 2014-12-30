using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public class MultiChart: ChartBase<MultiChart, MultiChartDefinition> {
      public MultiChart(): base( null ) {
      }

      public MultiChart( MultiChartDefinition chartDef ): base( chartDef ) {
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}