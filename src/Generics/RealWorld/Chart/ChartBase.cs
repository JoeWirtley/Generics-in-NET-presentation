using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public abstract class ChartBase< TChart, TChartDefinition >
      where TChart : ChartBase<TChart, TChartDefinition>, new() 
      where TChartDefinition : IChartDefCommon {

      public abstract string Serialize( IChartSerializer chartSerializer );

      public TChartDefinition ChartDefinition { get; set; }

      public string Name {
         get { return ChartDefinition.Name; }
         set { ChartDefinition.Name = value; }
      }

      public ChartBase<TChart, TChartDefinition> Copy( string newChartName ) {
         var newChart = new TChart {
            ChartDefinition = ChartDefinition,
         };
         newChart.ChartDefinition.Name = newChartName;
         return newChart;
      }
   }
}
