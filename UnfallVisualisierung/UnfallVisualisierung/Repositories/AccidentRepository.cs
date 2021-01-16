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

        public async Task<FeatureCollection> GetGeoData(DateTime startTime, DateTime endTime, FilterOptions filter)
        {
            var query = @"  SELECT Start_Lat AS latitude, Start_Lng AS longitude, ID as Id, Serverity
                            FROM AccidentEvents
                            WHERE Start_Time BETWEEN @StartTime AND @EndTime AND
                            (NOT @Amenity OR Amenity) AND
                            (NOT @Bump OR Bump) AND
                            (NOT @Crossing OR Crossing) AND
                            (NOT @GiveWay OR Give_Way) AND
                            (NOT @Junction OR Junction) AND
                            (NOT @NoExit OR No_Exit) AND
                            (NOT @Railway OR Railway) AND
                            (NOT @Roundabout OR Roundabout) AND
                            (NOT @Station OR Station) AND
                            (NOT @Stop OR Stop) AND
                            (NOT @TrafficCalming OR Traffic_Calming) AND
                            (NOT @TrafficSignal OR Traffic_Signal) AND
                            (NOT @TurningLoop OR Turning_Stop);";
            var parameters = new DynamicParameters();
            parameters.Add("@StartTime", startTime);
            parameters.Add("@EndTime", endTime);
            parameters.Add("@Amenity", (filter & FilterOptions.Amenity) == FilterOptions.Amenity, System.Data.DbType.Binary);
            parameters.Add("@Bump", (filter & FilterOptions.Bump) == FilterOptions.Bump, System.Data.DbType.Binary);
            parameters.Add("@Crossing", (filter & FilterOptions.Crossing) == FilterOptions.Crossing, System.Data.DbType.Binary);
            parameters.Add("@GiveWay", (filter & FilterOptions.GiveWay) == FilterOptions.GiveWay, System.Data.DbType.Binary);
            parameters.Add("@Junction", (filter & FilterOptions.Junction) == FilterOptions.Junction, System.Data.DbType.Binary);
            parameters.Add("@NoExit", (filter & FilterOptions.NoExit) == FilterOptions.NoExit, System.Data.DbType.Binary);
            parameters.Add("@Railway", (filter & FilterOptions.Railway) == FilterOptions.Railway, System.Data.DbType.Binary);
            parameters.Add("@Roundabout", (filter & FilterOptions.Roundabout) == FilterOptions.Roundabout, System.Data.DbType.Binary);
            parameters.Add("@Station", (filter & FilterOptions.Station) == FilterOptions.Station, System.Data.DbType.Binary);
            parameters.Add("@Stop", (filter & FilterOptions.Stop) == FilterOptions.Stop, System.Data.DbType.Binary);
            parameters.Add("@TrafficCalming", (filter & FilterOptions.TrafficCalming) == FilterOptions.TrafficCalming, System.Data.DbType.Binary);
            parameters.Add("@TrafficSignal", (filter & FilterOptions.TrafficSignal) == FilterOptions.TrafficSignal, System.Data.DbType.Binary);
            parameters.Add("@TurningLoop", (filter & FilterOptions.TurningLoop) == FilterOptions.TurningLoop, System.Data.DbType.Binary);
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
                        f.Properties.Add("Serverity", pos.Serverity);
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
                            wG.Name as WeatherGroupName,
                            wDG.groupName as Wind_Direction
                            FROM AccidentEvents as aE 
                        INNER JOIN Weather_Condition as wC ON aE.WeatherId = wC.Id
                        INNER JOIN WeatherGroups as wG ON wG.Id = wC.groupId
                        LEFT JOIN Wind_Direction as wD on wD.Id = aE.Wind_DirectionId
                        LEFT JOIN Wind_Direction_Groups as wDG ON wD.GroupId = wDG.Id
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
