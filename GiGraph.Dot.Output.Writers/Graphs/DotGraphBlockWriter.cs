﻿namespace GiGraph.Dot.Output.Writers.Graphs
{
    public abstract class DotGraphBlockWriter : DotEntityWriter
    {
        protected DotGraphBlockWriter(DotTokenWriter tokenWriter, DotEntityWriterContext context)
            : base(tokenWriter, context, enforceBlockComment: false)
        {
        }

        public virtual IDotGraphBodyWriter BeginBody()
        {
            var tokenWriter = _tokenWriter.NextIndentationLevel();
            tokenWriter.BlockStart()
               .LineBreak()
               .Indentation(linger: true);

            return new DotGraphBodyWriter(tokenWriter, _context);
        }

        public virtual void EndBody()
        {
            _tokenWriter.ClearLingerBuffer();
            _tokenWriter.Indentation();

            _tokenWriter.BlockEnd();
        }
    }
}