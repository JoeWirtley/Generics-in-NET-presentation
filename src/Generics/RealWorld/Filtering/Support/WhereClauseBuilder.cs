using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Generics.RealWorld.Filtering.Support {
   public delegate Expression CombineUsing( Expression left, Expression right );

   /// <summary>
   /// Builds a LINQ expression tree from a list of LINQ expression trees, combining them using the 
   /// delegate passed to the constructor; this delegate will combine using either And or Or.
   /// </summary>
   /// <remarks>
   /// This code is inspired by the predicate builder class from C# 5.0 in a Nutshell, which is a more
   /// general version of this algorithm.  http://www.albahari.com/nutshell/predicatebuilder.aspx
   /// </remarks>
   /// <typeparam name="T"></typeparam>
   public abstract class WhereClauseBuilder<T> {
      private Expression<Func<T, bool>> _whereExpression;
      private readonly CombineUsing _combineUsing;

      protected WhereClauseBuilder( IEnumerable<Expression<Func<T, bool>>> clauses, CombineUsing combineUsing ) {
         _combineUsing = combineUsing;
         var headAndTail = clauses.GetEnumerator().HeadAndTail();
         _whereExpression = headAndTail.Head;

         while ( headAndTail.Tail.MoveNext() ) {
            Add( headAndTail.Tail.Current );
         }
      }

      private void Add( Expression<Func<T, bool>> expression ) {
         var invokedExpr = Expression.Invoke( expression, _whereExpression.Parameters.Cast<Expression>() );
         _whereExpression = Expression.Lambda<Func<T, bool>>
            ( _combineUsing( _whereExpression.Body, invokedExpr ), _whereExpression.Parameters );
      }

      public Expression<Func<T, bool>> WhereExpression {
         get { return _whereExpression; }
      }
   }


   public class WhereClauseAndBuilder<T>: WhereClauseBuilder<T> {
      public WhereClauseAndBuilder( IEnumerable<Expression<Func<T, bool>>> clauses )
         : base( clauses, Expression.AndAlso ) {
      }
   }

   public class WhereClauseOrBuilder<T>:WhereClauseBuilder<T> {
      public WhereClauseOrBuilder( IEnumerable<Expression<Func<T, bool>>> clauses )
         : base( clauses, Expression.OrElse ) {
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