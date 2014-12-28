using System;

namespace Generics.RealWorld.Chart.Support {
   public class MultichartDefinition: IChartDefCommon {
      public Guid Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public static string ChartTypeKey { get; set; }
   }
}