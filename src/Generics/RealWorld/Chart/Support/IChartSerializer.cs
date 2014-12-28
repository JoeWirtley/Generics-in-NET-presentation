namespace Generics.RealWorld.Chart.Support {
   public interface IChartSerializer {
      string Serialize( MultichartDefinition chartDef );
      string Serialize( StatboardDefinition chart );
   }
}