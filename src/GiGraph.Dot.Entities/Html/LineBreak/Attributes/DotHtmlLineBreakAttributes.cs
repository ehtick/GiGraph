﻿using System;
using System.Reflection;
using GiGraph.Dot.Entities.Attributes.Collections;
using GiGraph.Dot.Entities.Attributes.Properties.KeyLookup;
using GiGraph.Dot.Entities.Html.Attributes.Collections;
using GiGraph.Dot.Entities.Html.Attributes.Factories;
using GiGraph.Dot.Entities.Html.Attributes.Properties;
using GiGraph.Dot.Output.Metadata;
using GiGraph.Dot.Types.Alignment;

namespace GiGraph.Dot.Entities.Html.LineBreak.Attributes
{
    public class DotHtmlLineBreakAttributes : DotHtmlElementRootAttributes<IDotHtmlLineBreakAttributes>, IDotHtmlLineBreakAttributes
    {
        protected static readonly Lazy<DotMemberAttributeKeyLookup> HtmlLineBreakAttributesKeyLookup = new DotMemberAttributeKeyLookupBuilder<DotHtmlLineBreakAttributes, IDotHtmlLineBreakAttributes>().BuildLazy();

        protected DotHtmlLineBreakAttributes(DotHtmlAttributeCollection attributes, Lazy<DotMemberAttributeKeyLookup> attributeKeyLookup)
            : base(attributes, attributeKeyLookup)
        {
        }

        public DotHtmlLineBreakAttributes()
            : this(new DotHtmlAttributeCollection(), HtmlLineBreakAttributesKeyLookup)
        {
        }

        [DotAttributeKey("align")]
        DotHorizontalAlignment? IDotHtmlLineBreakAttributes.LineAlignment
        {
            get => GetValueAs<DotHorizontalAlignment>(MethodBase.GetCurrentMethod(), out var result) ? result : null;
            set => SetOrRemove(MethodBase.GetCurrentMethod(), value.HasValue, () => value!.Value);
        }
    }
}