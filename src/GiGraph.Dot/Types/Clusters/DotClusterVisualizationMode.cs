﻿using GiGraph.Dot.Output.Metadata;

namespace GiGraph.Dot.Types.Clusters;

/// <summary>
///     The mode used for handling clusters.
/// </summary>
public enum DotClusterVisualizationMode
{
    /// <summary>
    ///     At present, the modes <see cref="Unbounded" /> and <see cref="None" /> appear to be identical, both turning off the special
    ///     cluster processing, specific to the <see cref="Bounded" /> mode.
    /// </summary>
    [DotAttributeValue("none")]
    None,

    /// <summary>
    ///     At present, the modes <see cref="Unbounded" /> and <see cref="None" /> appear to be identical, both turning off the special
    ///     cluster processing, specific to the <see cref="Bounded" /> mode.
    /// </summary>
    [DotAttributeValue("global")]
    Unbounded,

    /// <summary>
    ///     When set, a subgraph whose name begins with "cluster" is given special treatment (refers to clusters added to the clusters
    ///     collection of the root graph). The subgraph is laid out separately, and then integrated as a unit into its parent graph, with
    ///     a bounding rectangle drawn about it. If the cluster has a label parameter, this label is displayed within the rectangle. Note
    ///     also that there can be clusters within clusters.
    /// </summary>
    [DotAttributeValue("local")]
    Bounded
}