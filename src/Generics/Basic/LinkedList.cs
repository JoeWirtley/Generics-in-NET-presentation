using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Generics.Basic {
   public class LinkedList<T>: IEnumerable<T> {
      private int _size;
      private Node<T> _head;
      private Node<T> _tail;

      public LinkedList() {
         _size = 0;
         _head = null;
      }

      public LinkedList( params T[] values): this() {
         foreach ( var value in values ) {
            Add( value  );
         }
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

      public T First {
         get { return DataFromNode( _head ); }
      }

      public T Last {
         get { return DataFromNode( _tail ); }
      }

      private T DataFromNode( Node<T> node ) {
         T result = default( T );
         if ( node != null ) {
            result = node.Data;
         }
         return result;
      }

      public IEnumerable<T> DataWhere( Func<T, bool> criteria ) {
         return this.Where( criteria );
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

      private class Node<TData> {
         public TData Data;
         public Node<TData> Next;
      }
   }
}