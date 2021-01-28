﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ImportData
{
    public static class Strings
    {
        public static string getIds = "SELECT Id FROM AccidentEvents";
        public static string createTableString = @"
CREATE TABLE IF NOT EXISTS AccidentEvents (
      ID varchar(50) not null primary key,
      Source varchar(128),
      TMC float,
      Serverity int,
      Start_Time Datetime,
      End_Time Datetime,
      Start_Lat float,
      End_Lat float,
      Start_Lng float,
      End_Lng float,
      Distance float,
      Description varchar(256) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
      Number varchar(128),
      Street varchar(256),
      Side varchar(128),
      City varchar(128),
      County varchar(128),
      State varchar(128),
      Zipcode varchar(128),
      Country varchar(128),
      Timezone varchar(128),
      Airport_Code varchar(128),
      Weather_Timestamp datetime,
      Temperature double,
      Wind_Chill double,
      Humidity double,
      Pressure double,
      Visibility double,
      Wind_Direction varchar(128),
      Wind_Speed varchar(128),
      Precipitation double,
      Weather_Condition varchar(128),
      WeatherId int,
      Amenity bool,
      Bump bool,
      Crossing bool,
      Give_Way bool,
      Junction bool,
      Railway bool,
      No_Exit bool,
      Roundabout bool,
      Station bool,
      Stop bool,
      Traffic_Calming bool,
      Traffic_Signal bool, 
      Turning_Stop bool,
      Sunrise_Sunset varchar(128),
      Civil_Twilight varchar(128),
      Nautical_Twilight varchar(128),
      Astromonical_Twilight varchar(128)
);
";
        public static string insertQuery = @"INSERT INTO
  AccidentEvents (
      ID,
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
      Weather_Condition,
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
      Astromonical_Twilight
  )
VALUES ";

        public static string coronaTable = @"CREATE TABLE IF NOT EXISTS CoronaStatistic (
            Province_State VARCHAR(128) NOT NULL PRIMARY KEY,
            Last_Update DATETIME NOT NULL,
            Confirmed INT NOT NULL,
            Deaths INT NOT NULL,
            Recovered DOUBLE,
            FIPS INT NOT NULL,
            Incident_Rate FLOAT,
            Total_Test_Results FLOAT);";
        public static string coronaInsert = @"INSERT INTO CoronaStatistic ( 
            Province_State ,
            Last_Update ,
            Confirmed,
            Deaths,
            Recovered,
            FIPS,
            Incident_Rate,
            Total_Test_Results) VALUES ";

    }

    
}
