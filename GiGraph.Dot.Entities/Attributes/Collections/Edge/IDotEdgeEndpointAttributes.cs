﻿using GiGraph.Dot.Entities.Attributes.Collections.Graph;
using GiGraph.Dot.Entities.Attributes.Enums;
using GiGraph.Dot.Entities.Edges;
using GiGraph.Dot.Entities.Edges.Endpoints;
using GiGraph.Dot.Entities.Graphs;
using GiGraph.Dot.Entities.Types.Arrows;
using GiGraph.Dot.Entities.Types.Edges;
using GiGraph.Dot.Entities.Types.Labels;

namespace GiGraph.Dot.Entities.Attributes.Collections.Edge
{
    public interface IDotEdgeEndpointAttributes
    {
        /// <summary>
        ///     The text label to be placed near the endpoint of the edge.
        /// </summary>
        DotLabel Label { get; set; }

        /// <summary>
        ///     Indicates where on the node to attach the end of the edge. In the default case, the edge is aimed towards the center of the
        ///     node, and then clipped at the node boundary. See also the <see cref="DotEndpoint.Port" /> property of the edge's
        ///     <see cref="DotEdge{TTail,THead}.Head" /> or <see cref="DotEdge{TTail,THead}.Tail" />.
        /// </summary>
        DotEndpointPort Port { get; set; }

        /// <summary>
        ///     Logical endpoint of the edge (dot only). When <see cref="DotGraphClusterAttributes.AllowEdgeClipping" /> is true (see
        ///     attributes on the graph's <see cref="DotCommonGraphSection.Clusters" /> collection), if the current property is defined, and
        ///     is the identifier of a cluster containing the real endpoint node, the edge is clipped to the boundary of the cluster.
        /// </summary>
        string ClusterId { get; set; }

        /// <summary>
        ///     If true (default), the end of the edge is clipped to node boundary; otherwise, it goes to the center of the node, or the
        ///     center of a port, if applicable.
        /// </summary>
        bool? ClipToNodeBoundary { get; set; }

        /// <summary>
        ///     When specified, edges with the same endpoint and the same group name are aimed at the same point on that endpoint (dot only).
        ///     This has no effect on loops. Each node may have at most 5 unique group names specified.
        /// </summary>
        string GroupName { get; set; }

        /// <summary>
        ///     <para>
        ///         Gets or sets the style of arrowhead at the end of the edge (default: <see cref="DotArrowheadShape.Normal" />). Appears
        ///         only if the <see cref="DotEdgeAttributes.Directions" /> attribute on the edge is <see cref="DotEdgeDirections.Forward" />
        ///         (when specifying an arrowhead for the head endpoint), <see cref="DotEdgeDirections.Backward" /> (when specifying an
        ///         arrowhead for the tail endpoint), or <see cref="DotEdgeDirections.Both" />.
        ///     </para>
        ///     <para>
        ///         For basic shapes, assign a value of the <see cref="DotArrowheadShape" /> enumeration to this property (it will be
        ///         converted implicitly). For variants of the basic shapes (filled/empty, normal/clipped) use <see cref="DotArrowhead" />.
        ///         To generate an arrow composed of multiple arrowheads use <see cref="DotCompositeArrowhead" />.
        ///     </para>
        /// </summary>
        DotArrowheadDefinition Arrowhead { get; set; }
    }
}