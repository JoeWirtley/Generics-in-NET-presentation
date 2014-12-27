using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Generics.RealWorld.Filtering {
   public class WhereAndBuilder<T> {
      private Expression<Func<T, bool>> _whereExpression;

      public WhereAndBuilder( IEnumerable<Expression<Func<T, bool>>> clauses ) {
         var headAndTail = clauses.GetEnumerator().HeadAndTail();
         _whereExpression = headAndTail.Head;

         while ( headAndTail.Tail.MoveNext() ) {
            Add( headAndTail.Tail.Current );
         }
      }

      private void Add( Expression<Func<T, bool>> expression ) {
         var invokedExpr = Expression.Invoke( expression, _whereExpression.Parameters.Cast<Expression>() );
         _whereExpression = Expression.Lambda<Func<T, bool>>
            ( Expression.AndAlso( _whereExpression.Body, invokedExpr ), _whereExpression.Parameters );
      }

      public Expression<Func<T, bool>> WhereExpression {
         get { return _whereExpression; }
      }
   }


   internal class HeadAndTail<T> {
      public readonly T Head;
      public readonly IEnumerator<T> Tail;

      public HeadAndTail( T head, IEnumerator<T> tail ) {
         Head = head;
         Tail = tail;
      }
   }

   internal static class HeadAndTailExtensions {
      public static HeadAndTail<T> HeadAndTail<T>( this IEnumerator<T> enumerator ) {
         if ( !enumerator.MoveNext() ) {
            return null;
         }
         return new HeadAndTail<T>( enumerator.Current, enumerator );
      }
   }
}