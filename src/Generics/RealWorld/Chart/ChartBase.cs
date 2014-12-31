using Generics.RealWorld.Chart.Support;

namespace Generics.RealWorld.Chart {
   public abstract class ChartBase<TChart, TChartDefinition>: VisualObject
      where TChart: ChartBase<TChart, TChartDefinition>, new()
      where TChartDefinition: IChartDefCommon {

      protected ChartBase( TChartDefinition chartDefinition ) {
         ChartDefinition = chartDefinition;
      }

      public abstract string Serialize( IChartSerializer chartSerializer );

      // This doesn't work although I'd like it to
      //public string Serialize( IChartSerializer chartSerializer ) {
      //   return chartSerializer.Serialize( ChartDefinition );
      //}

      public TChartDefinition ChartDefinition { get; private set; }

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