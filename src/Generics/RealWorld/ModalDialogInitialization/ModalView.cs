using Generics.RealWorld.ModalDialogInitialization.Support;

namespace Generics.RealWorld.ModalDialogInitialization {
   public interface IModalView<TArguments>: IView {
      void Initialize( TArguments arguments );
   }

   public class ModalView: IModalView<ModalViewArguments> {
      public void Initialize( ModalViewArguments arguments ) {
         Title = arguments.Title;
         Count = arguments.Count;
      }

      public string Title { get; private set; }
      public int Count { get; private set; }
   }

   public class ModalViewArguments {
      public string Title { get; set; }
      public int Count { get; set; }
   }

   public class ShowModalView {
      private readonly ModalDialogService _modalDialogService;

      public ShowModalView( ModalDialogService modalDialogService ) {
         _modalDialogService = modalDialogService;
      }

      public void Show() {
         ModalViewArguments args = new ModalViewArguments {
            Title = "Modal Dialog Title",
            Count = 42
         };
         _modalDialogService.Show<ModalView, ModalViewArguments>( args );
      }
   }
}