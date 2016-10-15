using System;
using System.Collections.Generic;

namespace Assets.MapStruktur
{
    public class OpenStreatMap
    {
		public IDictionary<ulong, Node> Nodes;
		public IDictionary<ulong, Shape> Ways;
		public IDictionary<ulong, Building> Buildings;
		public IDictionary<ulong, Shape> Parks;
		public IDictionary<ulong, Shape> Waters;

		public OpenStreatMap(osm osmSchema)
		{
			Nodes = new Dictionary<ulong, Node> ();
			Ways = new Dictionary<ulong, Shape> ();
			Buildings = new Dictionary<ulong, Building> ();
			Parks = new Dictionary<ulong, Shape> ();
			Waters = new Dictionary<ulong, Shape> ();
			foreach(osmNode dirtyNode in osmSchema.node)
			{
				Node node = new Node (dirtyNode);
				Nodes.Add (node.Id, node);
			}
			foreach(osmWay dirtyWay in osmSchema.way)
			{
				if(dirtyWay.tag != null)
				{
					foreach(tag dirtyTag in dirtyWay.tag)
					{
						if(dirtyTag.k.Equals("highway"))
						{
							Shape way = new Shape (dirtyWay, Nodes);
							Ways.Add (way.Id, way);
						}
						else if(dirtyTag.k.Equals("building") && dirtyTag.v.Equals("yes"))
						{
							Building building = new Building (dirtyWay, Nodes);
							Buildings.Add (building.Id, building);
						}
						else if(dirtyTag.k.Equals("leisure") && dirtyTag.v.Equals("park"))
						{
							Shape park = new Shape (dirtyWay, Nodes);
							Parks.Add (park.Id, park);
						}
						else if(dirtyTag.k.Equals("natural") && dirtyTag.v.Equals("water"))
						{
							Shape water = new Shape (dirtyWay, Nodes);
							Waters.Add (water.Id, water);
						}
					}
				}
			}
		}
    }
}