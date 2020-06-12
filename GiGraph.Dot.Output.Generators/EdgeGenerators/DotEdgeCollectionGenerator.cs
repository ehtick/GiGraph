﻿using GiGraph.Dot.Entities;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Collections;
using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.EdgeWriters;
using System.Linq;
using GiGraph.Dot.Output.Generators.CommonEntityGenerators;
using GiGraph.Dot.Output.Generators.Providers;
using GiGraph.Dot.Output.TextEscaping;

namespace GiGraph.Dot.Output.Generators.EdgeGenerators
{
    public class DotEdgeCollectionGenerator : DotEntityGenerator<DotEdgeCollection, IDotEdgeStatementWriter>
    {
        protected DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators, IDotTextEscaper identifierEscaper)
            : base(syntaxRules, options, entityGenerators, identifierEscaper)
        {
        }

        public DotEdgeCollectionGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        public override void Generate(DotEdgeCollection edges, IDotEdgeStatementWriter writer)
        {
            var orderedEdges = _options.OrderElements
                ? edges.Cast<IDotOrderableEntity>()
                       .OrderBy(edge => edge.OrderingKey)
                       .Cast<DotEdgeDefinition>()
                : edges;

            foreach (var edge in orderedEdges.Where(edge => edge.Endpoints.Any()))
            {
                WriteEdge(edge, writer);
            }
        }

        protected virtual void WriteEdge(DotEdgeDefinition edge, IDotEdgeStatementWriter writer)
        {
            var edgeWriter = writer.BeginSequence();
            _entityGenerators.GetForEntity<IDotEdgeWriter>(edge).Generate(edge, edgeWriter);
            writer.EndSequence();
        }
    }
}