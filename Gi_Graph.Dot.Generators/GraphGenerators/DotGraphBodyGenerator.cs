﻿using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Nodes;
using GiGraph.Dot.Entities.Subgraphs;
using GiGraph.Dot.Generators.CommonEntityGenerators;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.AttributeWriters;
using GiGraph.Dot.Writers.EdgeWriters;
using GiGraph.Dot.Writers.EntityDefaultsWriter;
using GiGraph.Dot.Writers.GraphWriters;
using GiGraph.Dot.Writers.NodeWriters;
using GiGraph.Dot.Writers.SubgraphWriters;
using System.Linq;

namespace GiGraph.Dot.Generators.GraphGenerators
{
    public class DotGraphBodyGenerator : DotEntityGenerator<DotCommonGraph, IDotGraphBodyWriter>
    {
        public DotGraphBodyGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotCommonGraph graphBody, IDotGraphBodyWriter writer)
        {
            WriteAttributes(graphBody.Attributes, writer);

            WriteDefaults(graphBody.NodeDefaults, graphBody.EdgeDefaults, writer);

            WriteNodes(graphBody.Nodes, writer);
            WriteEdges(graphBody.Edges, writer);

            WriteSubgraphs(graphBody.Subgraphs, writer);
        }

        protected virtual void WriteAttributes(DotAttributeCollection attributes, IDotGraphBodyWriter writer)
        {
            if (attributes.Any())
            {
                var attributesWriter = writer.BeginAttributesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotAttributeStatementWriter>(attributes).Generate(attributes, attributesWriter);
                writer.EndAttributesSection();
            }
        }

        private void WriteDefaults(DotNodeAttributeCollection nodeDefaults, DotEdgeAttributeCollection edgeDefaults, IDotGraphBodyWriter writer)
        {
            if (!nodeDefaults.Any() && !edgeDefaults.Any())
            {
                return;
            }

            var defaultsWriter = writer.BeginDefaultsSection(_options.PreferStatementDelimiter);

            WriteNodeDefaults(nodeDefaults, defaultsWriter);
            WriteEdgeDefaults(edgeDefaults, defaultsWriter);

            writer.EndDefaultsSection();
        }

        protected virtual void WriteNodeDefaults(DotNodeAttributeCollection nodeDefaults, IDotEntityDefaultsStatementWriter writer)
        {
            if (nodeDefaults.Any())
            {
                var nodeDefaultsWriter = writer.BeginNodeDefaults();
                _entityGenerators.GetForEntity<IDotNodeDefaultsWriter>(nodeDefaults).Generate(nodeDefaults, nodeDefaultsWriter);
                writer.EndNodeDefaults();
            }
        }

        protected virtual void WriteEdgeDefaults(DotEdgeAttributeCollection edgeDefaults, IDotEntityDefaultsStatementWriter writer)
        {
            if (edgeDefaults.Any())
            {
                var edgeDefaultsWriter = writer.BeginEdgeDefaults();
                _entityGenerators.GetForEntity<IDotEdgeDefaultsWriter>(edgeDefaults).Generate(edgeDefaults, edgeDefaultsWriter);
                writer.EndEdgeDefaults();
            }
        }

        protected virtual void WriteNodes(DotNodeCollection nodes, IDotGraphBodyWriter writer)
        {
            if (nodes.Any())
            {
                var nodeStatementWriter = writer.BeginNodesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotNodeStatementWriter>(nodes).Generate(nodes, nodeStatementWriter);
                writer.EndNodesSection();
            }
        }

        protected virtual void WriteEdges(DotEdgeCollection edges, IDotGraphBodyWriter writer)
        {
            if (edges.Any())
            {
                var edgeStatementWriter = writer.BeginEdgesSection(_options.PreferStatementDelimiter);
                _entityGenerators.GetForEntity<IDotEdgeStatementWriter>(edges).Generate(edges, edgeStatementWriter);
                writer.EndEdgesSection();
            }
        }

        protected virtual void WriteSubgraphs(DotCommonSubgraphCollection subgraphs, IDotGraphBodyWriter writer)
        {
            if (subgraphs.Any())
            {
                var subgraphWriterRoot = writer.BeginSubgraphsSection();
                _entityGenerators.GetForEntity<IDotSubgraphWriterRoot>(subgraphs).Generate(subgraphs, subgraphWriterRoot);
                writer.EndSubgraphsSection();
            }
        }
    }
}