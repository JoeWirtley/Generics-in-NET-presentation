using Generics.RealWorld.ModalDialogInitialization.Support;

namespace Generics.RealWorld.ModalDialogInitialization.Before {
   public class BeforeModalView: IView {
      public void Initialize( object[] args ) {
         Title = args[ 0 ].ToString();
         Count = ( int ) args[ 1 ];
      }

      public string Title { get; private set; }
      public int Count { get; private set; }
   }

   public class ShowModalView {
      private readonly BeforeModalDialogService _modalDialogService;

      public ShowModalView( BeforeModalDialogService modalDialogService ) {
         _modalDialogService = modalDialogService;
      }

      public void Show() {
         _modalDialogService.Show<BeforeModalView>( "Modal Dialog Title", 42 );
      }
   }
}