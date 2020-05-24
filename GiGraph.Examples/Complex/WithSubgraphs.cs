﻿using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Graphs;

namespace GiGraph.Examples.Complex
{
    public static class WithSubgraphs
    {
        public static DotGraph Generate()
        {
            var graph = new DotGraph(isDirected: false);

            graph.Attributes.LayoutDirection = DotRankDirection.LeftToRight;

            graph.Edges.Add("e", "h");
            graph.Edges.Add("g", "k");
            graph.Edges.Add("r", "t");
            graph.Edges.Add("s", "z");
            graph.Edges.Add("t", "z");

            graph.Edges.AddOneToMany("a", "b", "c", "d");
            graph.Edges.AddOneToMany("b", "c", "e");
            graph.Edges.AddOneToMany("c", "e", "f");
            graph.Edges.AddOneToMany("d", "f", "g");
            graph.Edges.AddOneToMany("f", "h", "i", "j", "g");
            graph.Edges.AddOneToMany("h", "o", "l");
            graph.Edges.AddOneToMany("i", "l", "m", "j");
            graph.Edges.AddOneToMany("j", "m", "n", "k");
            graph.Edges.AddOneToMany("k", "n", "r");
            graph.Edges.AddOneToMany("l", "o", "m");
            graph.Edges.AddOneToMany("m", "o", "p", "n");
            graph.Edges.AddOneToMany("n", "q", "r");
            graph.Edges.AddOneToMany("o", "s", "p");
            graph.Edges.AddOneToMany("p", "s", "t", "q");
            graph.Edges.AddOneToMany("q", "t", "r");


            // add subgraphs to control the layout of some node groups
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("b", "c", "d");
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("e", "f", "g");
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("h", "i", "j", "k");
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("l", "m", "n");
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("o", "p", "q", "r");
            graph.Subgraphs.AddSubgraph(rank: DotRank.Same).Nodes.Add("s", "t");

            return graph;
        }
    }
}