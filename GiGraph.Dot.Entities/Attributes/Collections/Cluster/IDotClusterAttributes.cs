﻿using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Types.Colors;
using GiGraph.Dot.Entities.Types.Labels;
using GiGraph.Dot.Entities.Types.Points;
using GiGraph.Dot.Entities.Types.Strings;

namespace GiGraph.Dot.Entities.Attributes.Collections.Cluster
{
    public interface IDotClusterAttributes
    {
        /// <summary>
        ///     Font properties.
        /// </summary>
        IDotEntityFontAttributes Font { get; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the label to display on the cluster. It may be plain text (<see cref="string" />) or HTML (
        ///         <see cref="DotHtmlLabel" />). See also <see cref="DotTextFormatter" /> for plain text label formatting if needed.
        ///     </para>
        ///     <para>
        ///         Examples:
        ///         <list type="bullet">
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = "My label";
        ///                 </description>
        ///             </item>
        ///             <item>
        ///                 <description>
        ///                     <see cref="Label" /> = new <see cref="DotHtmlLabel" />("&lt;TABLE&gt;...&lt;/TABLE&gt;");
        ///                 </description>
        ///             </item>
        ///         </list>
        ///     </para>
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     Justification for the label. Note that a subgraph inherits attributes from its parent. Thus, if the root graph sets this
        ///     attribute to <see cref="DotHorizontalAlignment.Left" />, the subgraph inherits this value. Default:
        ///     <see cref="DotHorizontalAlignment.Center" />.
        /// </summary>
        DotHorizontalAlignment? HorizontalLabelAlignment { get; set; }

        /// <summary>
        ///     Vertical placement of the label (default: <see cref="DotVerticalAlignment.Top" />; only
        ///     <see cref="DotVerticalAlignment.Top" /> and <see cref="DotVerticalAlignment.Bottom" /> are allowed). Note that a subgraph
        ///     inherits attributes from its parent. Thus, if the root graph sets this attribute to
        ///     <see cref="DotVerticalAlignment.Bottom" />, the subgraph inherits this value.
        /// </summary>
        DotVerticalAlignment? VerticalLabelAlignment { get; set; }

        /// <summary>
        ///     Tooltip annotation attached to the cluster. If unset, Graphviz will use the <see cref="Label" /> attribute if defined.
        /// </summary>
        DotEscapeString Tooltip { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color to use for the cluster (default: <see cref="System.Drawing.Color.Black" />).
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used, with no weighted colors in its parameters (<see cref="DotColor" /> items
        ///         only), and the <see cref="Style" /> contains <see cref="DotStyles.Filled" />, a linear gradient fill is done.
        ///     </para>
        ///     <para>
        ///         If <see cref="DotGradientColor" /> is used with weighted colors (see <see cref="DotWeightedColor" />), a degenerate
        ///         linear gradient fill is done. This essentially does a fill using two colors, with the
        ///         <see cref="DotWeightedColor.Weight" /> specifying how much of region is filled with each color.
        ///     </para>
        ///     <para>
        ///         If the <see cref="Style" /> attribute contains the value <see cref="DotStyles.Radial" />, then a radial gradient fill is
        ///         done. See also the <see cref="GradientAngle" /> attribute for setting a gradient angle.
        ///     </para>
        ///     <para>
        ///         These fills work with any shape. For certain shapes, the <see cref="Style" /> attribute can be set to do fills using more
        ///         than 2 colors (set the <see cref="DotStyles.Striped" /> shape, and use <see cref="DotMultiColor" /> as a color list
        ///         definition).
        ///     </para>
        /// </summary>
        DotColorDefinition Color { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the background color of the cluster (default: none). Used as the initial background for the cluster. If the
        ///         <see cref="Style" /> attribute of the cluster contains the <see cref="DotStyles.Filled" /> style, the cluster's
        ///         <see cref="FillColor" /> will overlay the background color.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the <see cref="GradientAngle" />
        ///         attribute for setting a gradient angle.
        ///     </para>
        /// </summary>
        DotColorDefinition BackgroundColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the color used to fill the background of the cluster, assuming that <see cref="Style" /> is
        ///         <see cref="DotStyles.Filled" />. If <see cref="FillColor" /> is not defined, <see cref="Color" /> is used. If
        ///         <see cref="Color" /> is not defined, <see cref="BackgroundColor" /> is used. If it is not defined too, the default is
        ///         used, except when the output format is MIF, which use black by default.
        ///     </para>
        ///     <para>
        ///         When <see cref="DotGradientColor" /> is used, a gradient fill is generated. By default, this is a linear fill; setting
        ///         <see cref="Style" /> to <see cref="DotStyles.Radial" /> will cause a radial fill. If the second color is
        ///         <see cref="System.Drawing.Color.Empty" />, the default color is used for it. See also the <see cref="GradientAngle" />
        ///         attribute for setting a gradient angle.
        ///     </para>
        ///     <para>
        ///         Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a
        ///         <see cref="IDotGraphClusterAttributes.FillColor" /> for clusters, this will override a <see cref="Color" /> or
        ///         <see cref="BackgroundColor" /> attribute set for the cluster.
        ///     </para>
        /// </summary>
        DotColorDefinition FillColor { get; set; }

        /// <summary>
        ///     Specifies a color scheme namespace to use. If defined, specifies the context for interpreting color names. If no color scheme
        ///     is set, the standard <see cref="DotColorSchemes.X11" /> naming is used. For example, if
        ///     <see cref="DotColorSchemes.DotBrewerColorSchemes.BuGn9" /> Brewer color scheme is used, then a color named "7", e.g.
        ///     Color.FromName("7"), will be evaluated in the context of that specific color scheme. See <see cref="DotColorSchemes" /> for
        ///     supported scheme names.
        /// </summary>
        string ColorScheme { get; set; }

        /// <summary>
        ///     If a gradient fill is being used, this determines the angle of the fill. For linear fills, the colors transform along a line
        ///     specified by the angle and the center of the object. For radial fills, a value of zero causes the colors to transform
        ///     radially from the center; for non-zero values, the colors transform from a point near the object's periphery as specified by
        ///     the value. If unset, the default angle is 0.
        /// </summary>
        int? GradientAngle { get; set; }

        /// <summary>
        ///     Specifies the width of the pen, in points, used to draw lines and curves, including the boundaries of edges and clusters. The
        ///     value is inherited by subclusters. It has no effect on text. Default: 1.0, minimum: 0.0.
        /// </summary>
        double? PenWidth { get; set; }

        /// <summary>
        ///     Color used to draw the bounding box around the cluster (default: <see cref="System.Drawing.Color.Black" />). If
        ///     <see cref="BoundingBoxColor" /> is not defined, <see cref="Color" /> is used. If this is not defined, the default is used.
        ///     Note that a cluster inherits the root graph's attributes if defined. Thus, if the root graph has defined a
        ///     <see cref="IDotGraphClusterAttributes.BoundingBoxColor" /> for clusters, this will override a <see cref="Color" /> or
        ///     <see cref="BackgroundColor" /> attribute set for the cluster.
        /// </summary>
        DotColor BoundingBoxColor { get; set; }

        /// <summary>
        ///     <para>
        ///         Sets the style of the cluster (default: unset). See the descriptions of individual <see cref="DotStyles" /> values to
        ///         learn which styles are applicable to this element type.
        ///     </para>
        ///     <para>
        ///         Multiple styles can be used at once, for example: <see cref="Style" /> = <see cref="DotStyles.Rounded" /> |
        ///         <see cref="DotStyles.Bold" />;
        ///     </para>
        /// </summary>
        DotStyles? Style { get; set; }

        /// <summary>
        ///     Sets the number of peripheries used in cluster boundaries (default: 1, minimum: 0, maximum: 1). Setting peripheries to 0 will
        ///     remove the boundaries.
        /// </summary>
        int? Peripheries { get; set; }

        /// <summary>
        ///     <para>
        ///         Hyperlinks incorporated into device-dependent output. At present, used in PS2, CMAP, I*MAP and SVG formats. For all these
        ///         formats, URLs can be attached to nodes, edges and clusters. URL attributes can also be attached to the root graph in PS2,
        ///         CMAP and I*MAP formats. This serves as the base URL for relative URLs in the former, and as the default image map file in
        ///         the latter.
        ///     </para>
        ///     <para>
        ///         The active area for a cluster is its bounding box.
        ///     </para>
        /// </summary>
        DotEscapeString Url { get; set; }

        /// <summary>
        ///     Synonym for <see cref="Url" />.
        /// </summary>
        DotEscapeString Href { get; set; }

        /// <summary>
        ///     If the object has a <see cref="Url" /> specified, this attribute determines which window of the browser is used for the URL.
        ///     See
        ///     <see href="http://www.w3.org/TR/html401/present/frames.html#adef-target">
        ///         W3C documentation
        ///     </see>
        ///     .
        /// </summary>
        DotEscapeString UrlTarget { get; set; }

        /// <summary>
        ///     Specifies the space between the nodes in the cluster and the cluster bounding box. By default, this is 8 points.
        /// </summary>
        DotPoint Margin { get; set; }

        /// <summary>
        ///     Gets or sets the sorting index of the cluster (default: 0). If <see cref="IDotGraphAttributes.PackingMode" /> indicates an
        ///     array packing, this attribute specifies an insertion order among the components, with smaller values inserted first.
        /// </summary>
        int? SortIndex { get; set; }
    }
}