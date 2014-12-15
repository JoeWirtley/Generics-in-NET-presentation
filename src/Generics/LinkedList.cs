using System.Collections;
using System.Collections.Generic;

namespace Generics {
   public class LinkedList<T>: IEnumerable<T> {
      private int _size;
      private Node<T> _head;
      private Node<T> _current;

      public LinkedList() {
         _size = 0;
         _head = null;
      }

      public void Insert( T content ) {
         var node = CreateNode( content );
         node.Next = _head;
         _head = node;
      }

      public void Add( T content ) {
         var node = CreateNode( content );

         if ( _head == null ) {
            _head = node;
         } else {
            _current.Next = node;
         }

         _current = node;
      }

      private Node<T> CreateNode( T content ) {
         _size++;
         return new Node<T> {
            Data = content
         };
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

      IEnumerator IEnumerable.GetEnumerator() {
         return GetEnumerator();
      }

      private class Node<T> {
         public T Data;
         public Node<T> Next;
      }

   }
}