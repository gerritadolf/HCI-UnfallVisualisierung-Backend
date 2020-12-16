using GeoJSON.Net.Feature;
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
        public Task<FeatureCollection> GetGeoData(DateTime startTime, DateTime endTime);

        /// <summary>
        /// Getter method for a specific accident event with id.
        /// </summary>
        /// <param name="eventId">eventId of the accident</param>
        /// <returns>Full data object for the accident.</returns>
        public Task<AccidentEvent> GetEventById(string eventId);
    }
}
