using System;

namespace Assets.MapStruktur
{
    public class Node
    {
        public ulong Id { get; private set;}
        public decimal Latitude { get; private set;}
        public decimal Longitude { get; private set;}

        public Node(osmNode dirtyNote)
        {
            Id = UInt64.Parse(dirtyNote.id);
            Latitude = Decimal.Parse(dirtyNote.lat);
            Longitude = Decimal.Parse(dirtyNote.lon);
        }
    }
}