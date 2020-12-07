using System;
using System.Threading.Tasks;
using UnfallVisualisierung.Model;

namespace UnfallVisualisierung.Repositories.Interfaces
{
    /// <summary>
    /// Interface describing accident repository
    /// </summary>
    public interface IAccidentRepository
    {
        /// <summary>
        /// Getter method for accident geo data in specific time frame
        /// </summary>
        /// <param name="startTime">start of timeframe</param>
        /// <param name="endTime">end of timeframe</param>
        /// <returns>Data object with feature collection of coordinates for accidents in timeframe</returns>
        public Task<GeoJsonData> GetGeoData(DateTime startTime, DateTime endTime);
    }
}
