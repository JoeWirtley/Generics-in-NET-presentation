using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public class Statboard: ChartBase<Statboard, StatboardDefinition> {
      public Statboard(): base( null ) {
      }

      public Statboard( StatboardDefinition chartDef ): base( chartDef ) {
      }

      public override string Serialize( IChartSerializer chartSerializer ) {
         return chartSerializer.Serialize( ChartDefinition );
      }
   }
}