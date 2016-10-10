using System;
using System.Collections.Generic;

namespace Assets.MapStruktur
{
    public class Way
    {
		public ulong Id { get; private set;}
		public List<Node> Edges { get; private set;}

		public Way(osmWay dirtyWay, IDictionary<ulong, Node> nodes)
		{
			Id = Id = UInt64.Parse(dirtyWay.id);
			Edges = new List<Node>();
			foreach(osmWayND dirtyNode in dirtyWay.nd)
			{
				ulong nodeId = UInt64.Parse(dirtyNode.@ref);
				Edges.Add (nodes[nodeId]);
			}
			//TODO Tags
		}
    }
}