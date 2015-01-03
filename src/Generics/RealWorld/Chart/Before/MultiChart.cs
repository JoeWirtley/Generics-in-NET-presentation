using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart.Before {
   public class MultiChart: ChartBase {
      private MultiChartDefinition _chartDef;

      public MultiChart() {
      }

      public MultiChart( MultiChartDefinition chartDef ) {
         _chartDef = chartDef;
      }

      public override IChartDefCommon ChartDefinition {
         get { return _chartDef; }
         set { _chartDef = ( MultiChartDefinition ) value; }
      }

      protected override ChartBase CreateNewInstance() {
         return new MultiChart();
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( _chartDef );
      }
   }
}