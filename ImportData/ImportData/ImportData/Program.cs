using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace ImportData
{
    class Program
    {
        private enum Corona
        {
            Province_State = 0,
            Contry_region,
            Last_Update,
            Lat,
            Long_,
            Confirmed,
            Deaths,
            Recovered,
            Active,
            FIPS,
            Incident_Rate,
            Total_Tests_Results,
            People_Hospitalized,
            Case_Fatality_Ratio,
            UID,
            ISO3,
            Testing_Rate,
            Hospitalization_Rate
        }
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //var dbContext = new DbContext();
            //Console.WriteLine("Step 1: Create Table if not exists");
            //try
            //{
            //    using (var con = await dbContext.GetConnection())
            //    {
            //        con.Execute(Strings.coronaTable);
            //    }
            //}
            //catch (MySqlException e)
            //{
            //    Console.WriteLine(e.ToString());
            //}
            //Console.WriteLine("Step 2: CSV einlesen.");

            //using (StreamReader sr = new StreamReader("C:/dev/Studium/HCI/Backend/ImportData/ImportData/ImportData/Corona/01-25-2021.csv"))
            //{
            //    string currentLine;
            //    string query = Strings.coronaInsert;
            //    var param = new DynamicParameters();

            //    bool isHeaderLine = true;
            //    bool notFirstDataLine = false;
            //    int counter = 0;
            //    Console.WriteLine("Step 3: Query formen.");
            //    while ((currentLine = sr.ReadLine()) != null)
            //    {
            //        if (!isHeaderLine)
            //        {
            //            string[] dataArr = currentLine.Split(",");


            //            if (notFirstDataLine)
            //            {
            //                query += ", ";
            //            }
            //            query += $@"(@{counter}_0, 
            //                        @{counter}_1,
            //                        @{counter}_2,
            //                        @{counter}_3,
            //                        @{counter}_4,
            //                        @{counter}_5,
            //                        @{counter}_6,
            //                        @{counter}_7)";

            //            param.Add($"@{counter}_0", dataArr[(int) Corona.Province_State]);
            //            param.Add($"@{counter}_1", dataArr[(int)Corona.Last_Update]);
            //            param.Add($"@{counter}_2", dataArr[(int)Corona.Confirmed]);
            //            param.Add($"@{counter}_3", dataArr[(int)Corona.Deaths]);
            //            param.Add($"@{counter}_4", string.IsNullOrEmpty(dataArr[(int)Corona.Recovered]) ? null : dataArr[(int)Corona.Recovered]);
            //            param.Add($"@{counter}_5", dataArr[(int)Corona.FIPS]);
            //            param.Add($"@{counter}_6", string.IsNullOrEmpty(dataArr[(int)Corona.Incident_Rate]) ? null : dataArr[(int)Corona.Incident_Rate]);
            //            param.Add($"@{counter}_7", string.IsNullOrEmpty(dataArr[(int)Corona.Total_Tests_Results]) ? null : dataArr[(int)Corona.Total_Tests_Results]);

            //            notFirstDataLine = true;
            //        }
            //        isHeaderLine = false;
            //        counter++;
            //    }
            //    Console.WriteLine("Step 4: In Db Eintragen");
            //    try
            //    {
            //        using (var con = await dbContext.GetConnection())
            //        {
            //           con.Execute(query, param);
            //            Console.WriteLine("Eintragung erfolgreich");
            //        }
            //    }
            //    catch (MySqlException e)
            //    {
            //        Console.WriteLine(e.ToString());
            //    }
            //    Console.ReadLine();
            //}

            var replaceString = @"ALABAMA,AL|ALASKA,AK|AMERICAN SAMOA,AS|ARIZONA,AZ|ARKANSAS,AR|CALIFORNIA,CA|COLORADO,CO|CONNECTICUT,CT|DELAWARE,DE|DISTRICT OF COLUMBIA,DC|FLORIDA,FL|GEORGIA,GA|GUAM,GU|HAWAII,HI|IDAHO,ID|ILLINOIS,IL|INDIANA,IN|IOWA,IA|KANSAS,KS|KENTUCKY,KY|LOUISIANA,LA|MAINE,ME|MARYLAND,MD|MASSACHUSETTS,MA|MICHIGAN,MI|MINNESOTA,MN|MISSISSIPPI,MS|MISSOURI,MO|MONTANA,MT|NEBRASKA,NE|NEVADA,NV|NEW HAMPSHIRE,NH|NEW JERSEY,NJ|NEW MEXICO,NM|NEW YORK,NY|NORTH CAROLINA,NC|NORTH DAKOTA,ND|NORTHERN MARIANA IS,MP|OHIO,OH|OKLAHOMA,OK|OREGON,OR|PENNSYLVANIA,PA|PUERTO RICO,PR|RHODE ISLAND,RI|SOUTH CAROLINA,SC|SOUTH DAKOTA,SD|TENNESSEE,TN|TEXAS,TX|UTAH,UT|VERMONT,VT|VIRGINIA,VA|VIRGIN ISLANDS,VI|WASHINGTON,WA|WEST VIRGINIA,WV|WISCONSIN,WI|WYOMING,WY";

            string baseQuery = "Update CoronaStatistic SET Province_State = '#SHORT#' WHERE UPPER(Province_State) = '#PROV#';\n";

            string query = "";
            string[] states = replaceString.Split("|");

            foreach(string state in states)
            {
                string[] splitState = state.Split(",");
                query += baseQuery.Replace("#SHORT#", splitState[1]).Replace("#PROV#", splitState[0]);
            }
            Console.WriteLine(query);
        }
    }
}
