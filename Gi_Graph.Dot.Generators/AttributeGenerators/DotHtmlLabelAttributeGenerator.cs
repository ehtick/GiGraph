﻿using GiGraph.Dot.Core;
using GiGraph.Dot.Entities.Attributes.LabelAttributes;
using GiGraph.Dot.Generators.Options;
using GiGraph.Dot.Generators.Providers;
using GiGraph.Dot.Writers.AttributeWriters;

namespace GiGraph.Dot.Generators.AttributeGenerators
{
    public class DotHtmlLabelAttributeGenerator : DotAttributeGenerator<DotHtmlLabelAttribute>
    {
        public DotHtmlLabelAttributeGenerator(DotSyntaxRules syntaxRules, DotGenerationOptions options, IDotEntityGeneratorsProvider entityGenerators)
            : base(syntaxRules, options, entityGenerators)
        {
        }

        protected override void WriteAttribute(string key, string value, IDotAttributeWriter writer)
        {
            key = EscapeKey(key);

            writer.WriteHtmlAttribute
            (
                key,
                quoteKey: KeyRequiresQuoting(key),
                value, // don't escape the HTML value
                braceValue: true
            );
        }
    }
}