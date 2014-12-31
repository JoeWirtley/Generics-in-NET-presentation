namespace Generics.RealWorld.Chart.Support {
   public interface IChartSerializer {
      string Serialize( MultiChartDefinition chartDef );
      string Serialize( StatboardDefinition chart );
      // This method makes it possible to place the serialize method in the ChartBase class.  This
      // method does not exist in the code this sample is drawn from.
      //string Serialize( IChartDefCommon chart );
   }
}