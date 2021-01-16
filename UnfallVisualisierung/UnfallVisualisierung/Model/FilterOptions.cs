using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;

namespace UnfallVisualisierung.Model
{
	[Flags]
	public enum FilterOptions
	{
		None = 0,
		Amenity = 1,
		Bump = 2,
		Crossing = 4,
		GiveWay = 8,
		Junction = 16,
		NoExit = 32,
		Railway = 64,
		Roundabout = 128,
		Station = 256,
		Stop = 512,
		TrafficCalming = 1024,
		TrafficSignal = 2048,
		TurningLoop = 4096
	}
}
