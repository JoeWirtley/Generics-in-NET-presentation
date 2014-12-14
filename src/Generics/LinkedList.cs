using System.Collections.Generic;

namespace Generics {
   public class LinkedList<T> {
      private int _size;
      private Node<T> _head;
      private Node<T> _current;

      public LinkedList() {
         _size = 0;
         _head = null;
      }

      public void Add( T content ) {
         _size++;

         var node = new Node<T> {
            Data = content
         };

         if ( _head == null ) {
            _head = node;
         } else {
            _current.Next = node;
         }

         _current = node;
      }


      public int Count {
         get { return _size; }
      }

      public IEnumerator<T> GetEnumerator() {
         Node<T> current = _head;

         while ( current != null ) {
            yield return current.Data;
            current = current.Next;
         }
      }

      private class Node<T> {
         public T Data;
         public Node<T> Next;
      }
   }
}