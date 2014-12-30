using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public class MultiChart: ChartBase<MultiChart, MultichartDefinition> {
      public MultiChart(): base( null ) {
      }

      public MultiChart( MultichartDefinition chartDef ): base( chartDef ) {
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}