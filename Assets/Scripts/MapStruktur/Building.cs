using System;
using System.Collections.Generic;

namespace Assets.MapStruktur
{
	public class Building : Shape
	{
		public string Street { get; private set;}
		public string Housenumber { get; private set;}
		public string City { get; private set;}
		public string Country { get; private set;}
		public string Postcode { get; private set;}

		public Building (osmWay dirtyWay, IDictionary<ulong, Node> nodes) : base(dirtyWay, nodes)
		{
			foreach(tag dirtyTag in dirtyWay.tag)
			{
				if(dirtyTag.k.Equals("addr:street"))
				{
					Street = dirtyTag.v;
				}
				else if(dirtyTag.k.Equals("addr:housenumber"))
				{
					Housenumber = dirtyTag.v;
				}
				else if(dirtyTag.k.Equals("addr:city"))
				{
					City = dirtyTag.v;
				}
				else if(dirtyTag.k.Equals("addr:country"))
				{
					Country = dirtyTag.v;
				}
				else if(dirtyTag.k.Equals("addr:postcode"))
				{
					Postcode = dirtyTag.v;
				}
			}
		}
	}
}
