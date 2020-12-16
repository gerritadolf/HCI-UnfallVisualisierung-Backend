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

        public async Task<FeatureCollection> GetGeoData(DateTime startTime, DateTime endTime)
        {
            var query = @"  SELECT Start_Lat AS latitude, Start_Lng AS longitude, ID as Id
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
                        var f = new Feature(pos.Point);
                        f.Properties.Add("Id", pos.Id);
                        return f;
                    }).ToList();
                    return new FeatureCollection(points);
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning("AHHHH: " + e);
                throw;
            }
        }

        public async Task<AccidentEvent> GetEventById(string eventId)
        {
            var query = @"SELECT 
                            aE.ID,
                            Source,
                            TMC ,
                            Serverity ,
                            Start_Time ,
                            End_Time ,
                            Start_Lat ,
                            Start_Lng ,
                            End_Lat ,
                            End_Lng ,
                            Distance ,
                            Description,
                            Number,
                            Street,
                            Side,
                            City,
                            County,
                            State,
                            Zipcode,
                            Country,
                            Timezone,
                            Airport_Code,
                            Weather_Timestamp ,
                            Temperature ,
                            Wind_Chill ,
                            Humidity,
                            Pressure ,
                            Visibility,
                            Wind_Direction,
                            Wind_Speed,
                            Precipitation,
                            Amenity,
                            Bump ,
                            Crossing,
                            Give_Way,
                            Junction,
                            No_Exit,
                            Railway ,
                            Roundabout,
                            Station,
                            Stop,
                            Traffic_Calming,
                            Traffic_Signal,
                            Turning_Stop,
                            Sunrise_Sunset,
                            Civil_Twilight,
                            Nautical_Twilight ,
                            Astromonical_Twilight,
                            wC.weather as Weather_Condition, 
                            wG.Name as WeatherGroupName 
                            FROM AccidentEvents as aE 
                        INNER JOIN Weather_Condition as wC ON aE.WeatherId = wC.Id
                        INNER JOIN WeatherGroups as wG ON wG.Id = wC.groupId
                        WHERE aE.ID = @id;";
            var param = new DynamicParameters();
            param.Add("@id", eventId);

            try
            {
                using(var conn = await _dbContext.GetConnection())
                {
                    if (conn == null)
                    {
                        _logger.LogError("DB Connection failed!");
                        return null;
                    }
                    var result = conn.QueryFirstOrDefault<AccidentEvent>(query, param);
                    if(result == null)
                    {
                        _logger.LogInformation("No content found for id: " + eventId);
                    } else
                    {
                        _logger.LogInformation("Get event by id successful. EventId" + eventId);
                    }
                    return result;
                }
            } catch(Exception e)
            {
                _logger.LogWarning("AHHHH: " + e);
                throw;
            }
        }
    }
}
