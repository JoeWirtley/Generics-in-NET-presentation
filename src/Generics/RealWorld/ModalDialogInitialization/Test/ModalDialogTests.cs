using FluentAssertions;
using Generics.RealWorld.ModalDialogInitialization.Before;
using Generics.RealWorld.ModalDialogInitialization.Support;
using NUnit.Framework;

namespace Generics.RealWorld.ModalDialogInitialization.Test {
   [TestFixture]
   public class ModalDialogTests {
      [Test]
      public void TestBeforeDialog() {
         BeforeModalDialogService modalDialogService = new BeforeModalDialogService( new RegionManager(), new Container() );

         BeforeModalView view = modalDialogService.Show<BeforeModalView>( "Modal Dialog Title", 25 );
         view.Should().NotBeNull();
         view.Title.Should().Be( "Modal Dialog Title" );
         view.Count.Should().Be( 25 );
      }

      [Test]
      public void TestAfterDialog() {
         ModalDialogService modalDialogService = new ModalDialogService( new RegionManager(), new Container() );

         ModalViewArguments args = new ModalViewArguments {
            Title = "Modal Dialog Title", 
            Count = 25
         };

         ModalView view = modalDialogService.Show<ModalView,ModalViewArguments>( args );
         view.Should().NotBeNull();
         view.Title.Should().Be( "Modal Dialog Title" );
         view.Count.Should().Be( 25 );
      }
   }
}