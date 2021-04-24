using System;
using System.Collections.Generic;

namespace KMolenda.Aisd.Graph 
{
    public class Program {
        public static void Main(string[] args) 
        {

            string[] lines = new string[]
            {
                "..###.....#####.....#####",
                "..###.....#####.....#####",
                "..###.....#####.....#####",
                "...........###......#####",
                "......###...........#####",
                "...#..###..###......#####",
                "###############.#######..",
                "###############.#######.#",
                "###############.#######..",
                "................########.",
                "................#######..",
                "...#######..##.......##.#",
                "...#######..##.......##..",
                "...##...........########.",
                "#####...........#######..",
                "#####...##..##..#...#...#",
                "#####...##..##....#...#.."
            };

            List<Tuple<int, int>> mapVerticies = new List<Tuple<int, int>>();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (lines[i][j] == '.')
                        mapVerticies.Add(Tuple.Create(i, j));
                }
            }

            List<Tuple<Tuple<int, int>, Tuple<int, int>>> mapEdges = new List<Tuple<Tuple<int, int>, Tuple<int, int>>>();

            foreach (var item in mapVerticies)
            {
                Tuple<Tuple<int, int>, Tuple<int, int>> newEdge;

                if (item.Item2 + 1 < lines[0].Length)
                    if (lines[item.Item1][item.Item2 + 1] == '.')
                    {
                        newEdge = Tuple.Create(item, Tuple.Create(item.Item1, item.Item2 + 1));
                        if (!mapEdges.Contains(Tuple.Create(Tuple.Create(item.Item1, item.Item2 + 1), item)))
                            mapEdges.Add(newEdge);        
                    }

                if (item.Item1 + 1 < lines.Length)
                    if (lines[item.Item1 + 1][item.Item2] == '.')
                    {
                        newEdge = Tuple.Create(item, Tuple.Create(item.Item1 + 1, item.Item2));
                        if (!mapEdges.Contains(Tuple.Create(Tuple.Create(item.Item1 + 1, item.Item2), item)))
                            mapEdges.Add(newEdge);
                    }
            }

            var mapGraph = new Graph<Tuple<int, int>>(mapVerticies, mapEdges);

            Tuple<int,int> start = Tuple.Create(0,0), end = Tuple.Create(16, 24);
            var mapPath = mapGraph.ShortestPath(start: start, end: end);

            var pathVertices = new List<Tuple<int,int>>(mapPath);

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    ConsoleColor color = ConsoleColor.White;
                    if (lines[i][j] == '#')
                        color = ConsoleColor.Red;
                    else
                    {
                        color = ConsoleColor.White;
                        if (pathVertices.Contains(Tuple.Create(i, j)))
                            color = ConsoleColor.Green;

                    }
                    Console.BackgroundColor = color;
                    Console.Write(" ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }

}
