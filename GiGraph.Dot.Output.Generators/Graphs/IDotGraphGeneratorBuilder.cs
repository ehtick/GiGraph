﻿using GiGraph.Dot.Output.Options;
using GiGraph.Dot.Output.Writers.Graphs;

namespace GiGraph.Dot.Output.Generators.Graphs
{
    public interface IDotGraphGeneratorBuilder
    {
        IDotEntityGenerator<IDotGraphWriterRoot> Build(DotSyntaxRules syntaxRules, DotSyntaxOptions options);
    }
}