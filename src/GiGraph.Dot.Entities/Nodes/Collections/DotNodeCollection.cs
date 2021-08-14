﻿using System;
using System.Collections.Generic;
using System.Linq;
using GiGraph.Dot.Entities.Nodes.Attributes;
using GiGraph.Dot.Output;

namespace GiGraph.Dot.Entities.Nodes.Collections
{
    public partial class DotNodeCollection : List<DotNodeDefinition>, IDotEntity, IDotAnnotatable
    {
        protected DotNodeCollection(DotNodeAttributes attributes)
        {
            Attributes = attributes;
        }

        public DotNodeCollection()
            : this(new DotNodeAttributes())
        {
        }

        /// <summary>
        ///     Gets the attributes to apply by default to all nodes of the graph.
        /// </summary>
        public virtual DotNodeAttributes Attributes { get; }

        /// <inheritdoc cref="IDotAnnotatable.Annotation" />
        public virtual string Annotation { get; set; }

        /// <summary>
        ///     Adds a node to the collection and initializes its attributes.
        /// </summary>
        /// <typeparam name="T">
        ///     The type of node to add.
        /// </typeparam>
        /// <param name="node">
        ///     The node to add.
        /// </param>
        /// <param name="init">
        ///     An optional node initializer delegate.
        /// </param>
        public virtual T Add<T>(T node, Action<T> init)
            where T : DotNodeDefinition
        {
            Add(node);
            init?.Invoke(node);
            return node;
        }

        /// <summary>
        ///     Adds a node with the specified identifier to the collection, and returns it.
        /// </summary>
        /// <param name="id">
        ///     The identifier of the node to add.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created node.
        /// </param>
        public virtual DotNode Add(string id, Action<DotNode> init = null)
        {
            return Add(new DotNode(id), init);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNodeGroup AddGroup(params string[] ids)
        {
            return AddGroup(ids, init: null);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created group.
        /// </param>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNodeGroup AddGroup(Action<DotNodeGroup> init, params string[] ids)
        {
            return AddGroup(ids, init);
        }

        /// <summary>
        ///     Adds a group of nodes with the specified identifiers to the collection.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="init">
        ///     An optional initializer delegate to call for the created group.
        /// </param>
        public virtual DotNodeGroup AddGroup(IEnumerable<string> ids, Action<DotNodeGroup> init = null)
        {
            return Add(new DotNodeGroup(ids), init);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        public virtual DotNode[] AddRange(params string[] ids)
        {
            return AddRange(ids, initNode: null);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="initNode">
        ///     An optional initializer delegate to call for each created node.
        /// </param>
        public virtual DotNode[] AddRange(Action<DotNode> initNode, params string[] ids)
        {
            return AddRange(ids, initNode);
        }

        /// <summary>
        ///     Adds nodes with the specified identifiers to the collection, and returns them.
        /// </summary>
        /// <param name="ids">
        ///     The identifiers of the nodes to add.
        /// </param>
        /// <param name="initNode">
        ///     An optional initializer delegate to call for each created node.
        /// </param>
        public virtual DotNode[] AddRange(IEnumerable<string> ids, Action<DotNode> initNode = null)
        {
            return ids.Select
                (
                    id =>
                    {
                        var node = Add(id);
                        initNode?.Invoke(node);
                        return node;
                    }
                )
               .ToArray();
        }
    }
}