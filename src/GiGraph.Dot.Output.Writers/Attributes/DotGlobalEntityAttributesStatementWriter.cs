﻿using GiGraph.Dot.Output.Writers.Edges.Attributes;
using GiGraph.Dot.Output.Writers.Graphs.Attributes;
using GiGraph.Dot.Output.Writers.Nodes.Attributes;
using GiGraph.Dot.Output.Writers.TokenWriter;

namespace GiGraph.Dot.Output.Writers.Attributes
{
    public class DotGlobalEntityAttributesStatementWriter : DotEntityStatementWriter, IDotGlobalEntityAttributesStatementWriter
    {
        public DotGlobalEntityAttributesStatementWriter(DotTokenWriter tokenWriter, DotEntityWriterConfiguration configuration, bool useStatementDelimiter)
            : base(tokenWriter, configuration, useStatementDelimiter)
        {
        }

        public virtual IDotGlobalGraphAttributesWriter BeginGraphAttributesStatement()
        {
            return new DotGlobalGraphAttributesWriter(
                BeginSeparateEntity(_configuration.Formatting.GlobalAttributes.SingleLineGraphAttributeList),
                _configuration
            );
        }

        public virtual void EndGraphAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalNodeAttributesWriter BeginNodeAttributesStatement()
        {
            return new DotGlobalNodeAttributesWriter(
                BeginSeparateEntity(_configuration.Formatting.GlobalAttributes.SingleLineNodeAttributeList),
                _configuration
            );
        }

        public virtual void EndNodeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        public virtual IDotGlobalEdgeAttributesWriter BeginEdgeAttributesStatement()
        {
            return new DotGlobalEdgeAttributesWriter(
                BeginSeparateEntity(_configuration.Formatting.GlobalAttributes.SingleLineEdgeAttributeList),
                _configuration
            );
        }

        public virtual void EndEdgeAttributesStatement()
        {
            EndEntityAttributesStatement();
        }

        protected virtual void EndEntityAttributesStatement()
        {
            EndStatement();
        }

        protected virtual DotTokenWriter BeginSeparateEntity(bool isCurrentEntitySingleLine)
        {
            return _tokenWriter.Options.SingleLine
                ? _tokenWriter
                : _paddedEntityWriter.BeginEntity(enforcePadding: !isCurrentEntitySingleLine);
        }

        public override void EndComment()
        {
            EmptyLine();
        }
    }
}