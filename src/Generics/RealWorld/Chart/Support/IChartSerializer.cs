namespace Generics.RealWorld.Chart.Support {
   public interface IChartSerializer {
      string Serialize( MultiChartDefinition chartDef );
      string Serialize( StatboardDefinition chart );
   }
}