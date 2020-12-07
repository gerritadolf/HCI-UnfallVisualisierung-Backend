using GeoJSON.Net.Feature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnfallVisualisierung.Model
{
    /// <summary>
    /// Defines GeoJsonData object. Used to send position data to frontend
    /// </summary>
    public class GeoJsonData
    {
        public GeoJsonData(FeatureCollection data) { 
            Data = data;
        }
        /// <summary>
        /// Predefined type property for data. 'geojson' in this case
        /// </summary>
        public string Type { get => "geojson"; }

        /// <summary>
        /// GeoJSON data payload. Contains FeatureCollection.
        /// </summary>
        public FeatureCollection Data { get; set; }
    }
}
