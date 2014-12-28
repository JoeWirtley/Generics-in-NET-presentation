using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public class Statboard: ChartBase<Statboard, StatboardDefinition> {
      public Statboard() {
      }

      public Statboard( StatboardDefinition chartDef ) {
         ChartDefinition = chartDef;
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}