using Dapper;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnfallVisualisierung.DBConnection;
using UnfallVisualisierung.Model;
using UnfallVisualisierung.Model.GeoJson;
using UnfallVisualisierung.Repositories.Interfaces;

namespace UnfallVisualisierung.Repositories
{
    public class AccidentRepository : IAccidentRepository
    {
        private readonly IDBContext _dbContext;
        private readonly ILogger<AccidentRepository> _logger;

        public AccidentRepository(IDBContext dbContext, ILogger<AccidentRepository> logger) {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<GeoJsonData> GetGeoData(DateTime startTime, DateTime endTime)
        {
            var query = @"  SELECT Start_Lat AS latitude, Start_Lng AS longitude, NULL as altitude
                            FROM AccidentEvents
                            WHERE Start_Time BETWEEN @StartTime AND @EndTime;";
            var parameters = new DynamicParameters();
            parameters.Add("@StartTime", startTime);
            parameters.Add("@EndTime", endTime);
            try
            {

                using (var conn = await _dbContext.GetConnection())
                {
                    if (conn == null) {
                        return null; 
                    }
                    List<Feature> points = conn.Query<PointWrapper>(query, parameters).Select(pos => {
                        return new Feature(pos.Point);
                    }).ToList();
                    return new GeoJsonData(new FeatureCollection(points));
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning("AHHHH: " + e);
                throw;
            }
        }
    }
}
