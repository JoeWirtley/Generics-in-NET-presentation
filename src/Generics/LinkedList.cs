using System.Collections;
using System.Collections.Generic;

namespace Generics {
   public class LinkedList<T>: IEnumerable<T> {
      private int _size;
      private Node<T> _head;
      private Node<T> _tail;

      public LinkedList() {
         _size = 0;
         _head = null;
      }

      public void Insert( T data ) {
         var node = CreateNode( data );
         node.Next = _head;
         _head = node;
      }

      public void Add( T data ) {
         var node = CreateNode( data );

         if ( _head == null ) {
            _head = node;
         } else {
            _tail.Next = node;
         }

         _tail = node;
      }

      private Node<T> CreateNode( T data ) {
         _size++;
         return new Node<T> {
            Data = data
         };
      }

      public int Count {
         get { return _size; }
      }

      public T Last {
         get {
            T result = default( T );
            if ( _tail != null ) {
               result = _tail.Data;
            }
            return result;
         }
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