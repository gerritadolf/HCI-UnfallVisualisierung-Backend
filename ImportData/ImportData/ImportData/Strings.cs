using System;
using System.Collections.Generic;
using System.Text;

namespace ImportData
{
    public static class Strings
    {
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
CREATE TABLE IF NOT EXISTS Weather_Condition (
	Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
	GroupId INT NOT NULL,
	Weather VARCHAR(256) NOT NULL
);
CREATE TABLE IF NOT EXISTS WeatherGroups (
Id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
'Name' VARCHAR(128) NOT NULL
);
ALTER TABLE Weather_Condition AUTO_INCREMENT=1;
ALTER TABLE WeatherGroups AUTO_INCREMENT=1;
INSERT INTO `WeatherGroups` VALUES ('1', 'Windy');
INSERT INTO `WeatherGroups` VALUES ('2', 'Volcano Ash');
INSERT INTO `WeatherGroups` VALUES ('3', 'Tornado');
INSERT INTO `WeatherGroups` VALUES ('4', 'Thunderstorm');
INSERT INTO `WeatherGroups` VALUES ('5', 'Snow');
INSERT INTO `WeatherGroups` VALUES ('6', 'Fog');
INSERT INTO `WeatherGroups` VALUES ('7', 'Sand');
INSERT INTO `WeatherGroups` VALUES ('8', 'Rain');
INSERT INTO `WeatherGroups` VALUES ('9', 'Cloudy');
INSERT INTO `WeatherGroups` VALUES ('10', 'Hail');
INSERT INTO `WeatherGroups` VALUES ('11', 'Clear');
INSERT INTO `WeatherGroups` VALUES ('12', 'Unspezified');
INSERT INTO `WeatherGroups` VALUES ('13', 'Smoke');
INSERT INTO `WeatherGroups` VALUES ('14', 'Dust');

INSERT INTO `Weather_Condition` VALUES ('1', '1', 'Wintry Mix / Windy');
INSERT INTO `Weather_Condition` VALUES ('2', '1', 'Wintry Mix');
INSERT INTO `Weather_Condition` VALUES ('3', '14', 'Widespread Dust / Windy');
INSERT INTO `Weather_Condition` VALUES ('4', '14', 'Widespread Dust');
INSERT INTO `Weather_Condition` VALUES ('5', '2', 'Volcanic Ash');
INSERT INTO `Weather_Condition` VALUES ('6', '3', 'Tornado');
INSERT INTO `Weather_Condition` VALUES ('7', '4', 'Thunderstorms and Snow');
INSERT INTO `Weather_Condition` VALUES ('8', '4', 'Thunderstorms and Rain');
INSERT INTO `Weather_Condition` VALUES ('9', '4', 'Thunderstorm');
INSERT INTO `Weather_Condition` VALUES ('10', '4', 'Thunder in the Vicinity');
INSERT INTO `Weather_Condition` VALUES ('11', '4', 'Thunder and Hail');
INSERT INTO `Weather_Condition` VALUES ('12', '4', 'Thunder / Wintry Mix / Windy');
INSERT INTO `Weather_Condition` VALUES ('13', '4', 'Thunder / Windy');
INSERT INTO `Weather_Condition` VALUES ('14', '4', 'Thunder');
INSERT INTO `Weather_Condition` VALUES ('15', '4', 'T-Storm / Windy');
INSERT INTO `Weather_Condition` VALUES ('16', '4', 'T-Storm');
INSERT INTO `Weather_Condition` VALUES ('17', '1', 'Squalls / Windy');
INSERT INTO `Weather_Condition` VALUES ('18', '1', 'Squalls');
INSERT INTO `Weather_Condition` VALUES ('19', '5', 'Snow Showers');
INSERT INTO `Weather_Condition` VALUES ('20', '5', 'Snow Grains');
INSERT INTO `Weather_Condition` VALUES ('21', '5', 'Snow and Thunder');
INSERT INTO `Weather_Condition` VALUES ('22', '5', 'Snow and Sleet / Windy');
INSERT INTO `Weather_Condition` VALUES ('23', '5', 'Snow and Sleet');
INSERT INTO `Weather_Condition` VALUES ('24', '5', 'Snow / Windy');
INSERT INTO `Weather_Condition` VALUES ('25', '5', 'Snow');
INSERT INTO `Weather_Condition` VALUES ('26', '13', 'Smoke / Windy');
INSERT INTO `Weather_Condition` VALUES ('27', '13', 'Smoke');
INSERT INTO `Weather_Condition` VALUES ('28', '10', 'Small Hail');
INSERT INTO `Weather_Condition` VALUES ('29', '5', 'Sleet');
INSERT INTO `Weather_Condition` VALUES ('30', '1', 'Showers in the Vicinity');
INSERT INTO `Weather_Condition` VALUES ('31', '6', 'Shallow Fog');
INSERT INTO `Weather_Condition` VALUES ('32', '9', 'Scattered Clouds');
INSERT INTO `Weather_Condition` VALUES ('33', '7', 'Sand / Dust Whirlwinds / Windy');
INSERT INTO `Weather_Condition` VALUES ('34', '7', 'Sand / Dust Whirlwinds');
INSERT INTO `Weather_Condition` VALUES ('35', '7', 'Sand / Dust Whirls Nearby');
INSERT INTO `Weather_Condition` VALUES ('36', '7', 'Sand');
INSERT INTO `Weather_Condition` VALUES ('37', '8', 'Rain Showers');
INSERT INTO `Weather_Condition` VALUES ('38', '8', 'Rain Shower');
INSERT INTO `Weather_Condition` VALUES ('39', '8', 'Rain and Sleet');
INSERT INTO `Weather_Condition` VALUES ('40', '8', 'Rain / Windy');
INSERT INTO `Weather_Condition` VALUES ('41', '8', 'Rain');
INSERT INTO `Weather_Condition` VALUES ('42', '6', 'Patches of Fog / Windy');
INSERT INTO `Weather_Condition` VALUES ('43', '6', 'Patches of Fog');
INSERT INTO `Weather_Condition` VALUES ('44', '9', 'Partly Cloudy / Windy');
INSERT INTO `Weather_Condition` VALUES ('45', '9', 'Partly Cloudy');
INSERT INTO `Weather_Condition` VALUES ('46', '9', 'Partial Fog / Windy');
INSERT INTO `Weather_Condition` VALUES ('47', '9', 'Partial Fog');
INSERT INTO `Weather_Condition` VALUES ('48', '9', 'Overcast');
INSERT INTO `Weather_Condition` VALUES ('49', '12', 'N/A Precipitation');
INSERT INTO `Weather_Condition` VALUES ('50', '9', 'Mostly Cloudy / Windy');
INSERT INTO `Weather_Condition` VALUES ('51', '9', 'Mostly Cloudy');
INSERT INTO `Weather_Condition` VALUES ('52', '6', 'Mist');
INSERT INTO `Weather_Condition` VALUES ('53', '5', 'Low Drifting Snow');
INSERT INTO `Weather_Condition` VALUES ('54', '4', 'Light Thunderstorms and Snow');
INSERT INTO `Weather_Condition` VALUES ('55', '4', 'Light Thunderstorms and Rain');
INSERT INTO `Weather_Condition` VALUES ('56', '4', 'Light Thunderstorm');
INSERT INTO `Weather_Condition` VALUES ('57', '5', 'Light Snow with Thunder');
INSERT INTO `Weather_Condition` VALUES ('58', '5', 'Light Snow Showers');
INSERT INTO `Weather_Condition` VALUES ('59', '5', 'Light Snow Shower');
INSERT INTO `Weather_Condition` VALUES ('60', '5', 'Light Snow Grains');
INSERT INTO `Weather_Condition` VALUES ('61', '5', 'Light Snow and Sleet / Windy');
INSERT INTO `Weather_Condition` VALUES ('62', '5', 'Light Snow and Sleet');
INSERT INTO `Weather_Condition` VALUES ('63', '5', 'Light Snow / Windy');
INSERT INTO `Weather_Condition` VALUES ('64', '5', 'Light Snow');
INSERT INTO `Weather_Condition` VALUES ('65', '5', 'Light Sleet');
INSERT INTO `Weather_Condition` VALUES ('66', '8', 'Light Rain with Thunder');
INSERT INTO `Weather_Condition` VALUES ('67', '8', 'Light Rain Showers');
INSERT INTO `Weather_Condition` VALUES ('68', '8', 'Light Rain Shower / Windy');
INSERT INTO `Weather_Condition` VALUES ('69', '8', 'Light Rain Shower');
INSERT INTO `Weather_Condition` VALUES ('70', '8', 'Light Rain / Windy');
INSERT INTO `Weather_Condition` VALUES ('71', '8', 'Light Rain');
INSERT INTO `Weather_Condition` VALUES ('72', '5', 'Light Ice Pellets');
INSERT INTO `Weather_Condition` VALUES ('73', '9', 'Light Haze');
INSERT INTO `Weather_Condition` VALUES ('74', '10', 'Light Hail');
INSERT INTO `Weather_Condition` VALUES ('75', '8', 'Light Freezing Rain / Windy');
INSERT INTO `Weather_Condition` VALUES ('76', '8', 'Light Freezing Rain');
INSERT INTO `Weather_Condition` VALUES ('77', '6', 'Light Freezing Fog');
INSERT INTO `Weather_Condition` VALUES ('78', '8', 'Light Freezing Drizzle');
INSERT INTO `Weather_Condition` VALUES ('79', '6', 'Light Fog');
INSERT INTO `Weather_Condition` VALUES ('80', '8', 'Light Drizzle / Windy');
INSERT INTO `Weather_Condition` VALUES ('81', '8', 'Light Drizzle');
INSERT INTO `Weather_Condition` VALUES ('82', '5', 'Light Blowing Snow');
INSERT INTO `Weather_Condition` VALUES ('83', '5', 'Ice Pellets');
INSERT INTO `Weather_Condition` VALUES ('84', '4', 'Heavy Thunderstorms with Small Hail');
INSERT INTO `Weather_Condition` VALUES ('85', '4', 'Heavy Thunderstorms and Snow');
INSERT INTO `Weather_Condition` VALUES ('86', '4', 'Heavy Thunderstorms and Rain');
INSERT INTO `Weather_Condition` VALUES ('87', '4', 'Heavy T-Storm / Windy');
INSERT INTO `Weather_Condition` VALUES ('88', '4', 'Heavy T-Storm');
INSERT INTO `Weather_Condition` VALUES ('89', '5', 'Heavy Snow with Thunder');
INSERT INTO `Weather_Condition` VALUES ('90', '5', 'Heavy Snow / Windy');
INSERT INTO `Weather_Condition` VALUES ('91', '5', 'Heavy Snow');
INSERT INTO `Weather_Condition` VALUES ('92', '13', 'Heavy Smoke');
INSERT INTO `Weather_Condition` VALUES ('93', '4', 'Heavy Sleet');
INSERT INTO `Weather_Condition` VALUES ('94', '8', 'Heavy Rain Showers');
INSERT INTO `Weather_Condition` VALUES ('95', '8', 'Heavy Rain Shower');
INSERT INTO `Weather_Condition` VALUES ('96', '8', 'Heavy Rain / Windy');
INSERT INTO `Weather_Condition` VALUES ('97', '8', 'Heavy Rain');
INSERT INTO `Weather_Condition` VALUES ('98', '5', 'Heavy Ice Pellets');
INSERT INTO `Weather_Condition` VALUES ('99', '8', 'Heavy Freezing Rain');
INSERT INTO `Weather_Condition` VALUES ('100', '8', 'Heavy Freezing Drizzle');
INSERT INTO `Weather_Condition` VALUES ('101', '8', 'Heavy Drizzle');
INSERT INTO `Weather_Condition` VALUES ('102', '5', 'Heavy Blowing Snow');
INSERT INTO `Weather_Condition` VALUES ('103', '1', 'Haze / Windy');
INSERT INTO `Weather_Condition` VALUES ('104', '1', 'Haze');
INSERT INTO `Weather_Condition` VALUES ('105', '10', 'Hail');
INSERT INTO `Weather_Condition` VALUES ('106', '9', 'Funnel Cloud');
INSERT INTO `Weather_Condition` VALUES ('107', '8', 'Freezing Rain / Windy');
INSERT INTO `Weather_Condition` VALUES ('108', '8', 'Freezing Rain');
INSERT INTO `Weather_Condition` VALUES ('109', '8', 'Freezing Drizzle');
INSERT INTO `Weather_Condition` VALUES ('110', '6', 'Fog / Windy');
INSERT INTO `Weather_Condition` VALUES ('111', '6', 'Fog');
INSERT INTO `Weather_Condition` VALUES ('112', '11', 'Fair / Windy');
INSERT INTO `Weather_Condition` VALUES ('113', '11', 'Fair');
INSERT INTO `Weather_Condition` VALUES ('114', '1', 'Dust Whirls');
INSERT INTO `Weather_Condition` VALUES ('115', '6', 'Drizzle and Fog');
INSERT INTO `Weather_Condition` VALUES ('116', '8', 'Drizzle / Windy');
INSERT INTO `Weather_Condition` VALUES ('117', '8', 'Drizzle');
INSERT INTO `Weather_Condition` VALUES ('118', '5', 'Drifting Snow');
INSERT INTO `Weather_Condition` VALUES ('119', '9', 'Cloudy / Windy');
INSERT INTO `Weather_Condition` VALUES ('120', '9', 'Cloudy');
INSERT INTO `Weather_Condition` VALUES ('121', '11', 'Clear');
INSERT INTO `Weather_Condition` VALUES ('122', '5', 'Blowing Snow / Windy');
INSERT INTO `Weather_Condition` VALUES ('123', '5', 'Blowing Snow');
INSERT INTO `Weather_Condition` VALUES ('124', '7', 'Blowing Sand');
INSERT INTO `Weather_Condition` VALUES ('125', '14', 'Blowing Dust / Windy');
INSERT INTO `Weather_Condition` VALUES ('126', '14', 'Blowing Dust');
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
    }
}
