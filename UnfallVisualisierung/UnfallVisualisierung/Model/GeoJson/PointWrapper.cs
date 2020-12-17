using GeoJSON.Net.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model.GeoJson
{
    public class PointWrapper
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Id { get; set; }
        public int Serverity { get; set; }
        public Point Point { get => new Point(new Position(this.Latitude, this.Longitude)); }
    }
}
