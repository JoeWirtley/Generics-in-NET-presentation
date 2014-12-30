using FluentAssertions;
using Generics.RealWorld.Chart.Support;
using NUnit.Framework;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace Generics.RealWorld.Chart.Test {
   [TestFixture]
   public class ChartTests {
      [Test]
      public void MultiChartShouldConstructProperly() {
         MultiChartDefinition chartDefinition = new MultiChartDefinition {
            Name = "MultiChart"
         };

         MultiChart chart = new MultiChart( chartDefinition );
         chart.Should().BeOfType<MultiChart>();
         chart.ChartDefinition.Should().BeOfType<MultiChartDefinition>();
         chart.Name.Should().Be( "MultiChart" );
      }

      [Test]
      public void MultiChartShouldCopyProperly() {
         MultiChartDefinition chartDefinition = new MultiChartDefinition {
            Name = "MultiChart"
         };

         MultiChart chart = new MultiChart( chartDefinition );

         VisualObject copy = chart.Copy( "Copied MultiChart" );
         copy.Should().BeOfType<MultiChart>();
         MultiChart copiedChart = ( MultiChart ) copy;
         copiedChart.ChartDefinition.Should().BeOfType<MultiChartDefinition>();
         copiedChart.Name.Should().Be( "Copied MultiChart" );
      }

      [Test]
      public void MultiChartShouldSerializeProperly() {
         MultiChartDefinition chartDefinition = new MultiChartDefinition {
            Name = "MultiChart"
         };

         MultiChart chart = new MultiChart( chartDefinition );

         IChartSerializer serializer = Mock.Create<IChartSerializer>( Behavior.Strict );
         serializer.Arrange( x => x.Serialize( Arg.IsAny<MultiChartDefinition>() ) ).Returns( "" ).OccursOnce();

         chart.Serialize( serializer );

         serializer.AssertAll();
      }

      [Test]
      public void StatboardShouldConstructProperly() {
         StatboardDefinition chartDefinition = new StatboardDefinition {
            Name = "Statboard"
         };

         Statboard chart = new Statboard( chartDefinition );
         chart.Should().BeOfType<Statboard>();
         chart.ChartDefinition.Should().BeOfType<StatboardDefinition>();
         chart.Name.Should().Be( "Statboard" );
      }

      [Test]
      public void StatboardShouldCopyProperly() {
         StatboardDefinition chartDefinition = new StatboardDefinition {
            Name = "Statboard"
         };

         Statboard chart = new Statboard( chartDefinition );

         VisualObject copy = chart.Copy( "Copied Statboard" );
         copy.Should().BeOfType<Statboard>();
         Statboard copiedChart = ( Statboard ) copy;
         copiedChart.ChartDefinition.Should().BeOfType<StatboardDefinition>();
         copiedChart.Name.Should().Be( "Copied Statboard" );
      }

      [Test]
      public void StatboardShouldSerializeProperly() {
         StatboardDefinition chartDefinition = new StatboardDefinition {
            Name = "Statboard"
         };

         Statboard chart = new Statboard( chartDefinition );

         IChartSerializer serializer = Mock.Create<IChartSerializer>( Behavior.Strict );
         serializer.Arrange( x => x.Serialize( Arg.IsAny<StatboardDefinition>() ) ).Returns( "" ).OccursOnce();

         chart.Serialize( serializer );

         serializer.AssertAll();
      }
   }
}