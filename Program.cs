using System;
using System.Collections.Generic;

namespace KMolenda.Aisd.Graph 
{
    public class Program {
        public static void Main(string[] args) 
        {
            var vertices = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var edges = new[] {Tuple.Create(1,2), Tuple.Create(1,3),
                Tuple.Create(2,4), Tuple.Create(3,5), Tuple.Create(3,6),
                Tuple.Create(4,7), Tuple.Create(5,7), Tuple.Create(5,8),
                Tuple.Create(5,6), Tuple.Create(8,9), Tuple.Create(9,10)};

            var graph = new Graph<int>(vertices, edges);
            Console.WriteLine( graph );

            foreach( var vertex in graph.TraverseDeepFirst(start: 1) )
                System.Console.Write( vertex + " ");
            
            Console.WriteLine();
            foreach( var vertex in graph.TraverseBreadthFirst(start: 1) )
                System.Console.Write( vertex + " ");
            
            Console.WriteLine();
            int a = 1, b = 4;
            var path = graph.ShortestPath(start: a, end: b);
            Console.WriteLine( $"Shortest path from {a} to {b}: {string.Join(", ", path)}" );

            foreach( var vertex in graph.Vertices )
            {
                var fun = graph.ShortestPathFunc(start: a);
                Console.WriteLine( $"Shortest path from {a} to {vertex}: {string.Join(", ", fun(vertex))}" );
            }
        }
    }

}
