using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ImportData
{
    class OldImporter
    {
        async System.Threading.Tasks.Task importAsync()
        {
            var dbContext = new DbContext();
            var list = new List<string>();
            int totalCount = 0;
            Console.WriteLine("Step 1: Get existing ids.");
            try
            {
                using (var con = await dbContext.GetConnection())
                {
                    list = con.Query<string>(Strings.getIds).ToList();
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Step 2: CSV einlesen.");

            using (StreamReader sr = new StreamReader("C:/dev/Studium/HCI/Backend/ImportData/ImportData/ImportData/US_Accidents_June20.csv"))
            {
                Console.WriteLine("Step 2: CSV gefunden. Beginne Übertragung in DB.");
                string currentLine;
                int counter = 0, totalResetted = 0;
                var config = new DynamicParameters();
                // currentLine will be null when the StreamReader reaches the end of file
                var valuesString = "";
                while ((currentLine = sr.ReadLine()) != null)
                {
                    totalCount++;
                    string[] dataArr = currentLine.Split(",");

                    if (list.FindIndex(x => x == dataArr[0]) == -1)
                    {
                        list.Remove(dataArr[0]);
                        if (counter == 0 && totalResetted == 0)
                        {
                            counter++;
                            continue;
                        }
                        if (counter > 1)
                        {
                            valuesString += ", ";
                        }

                        valuesString += "(";
                        for (int j = 0; j < 49; j++)
                        {
                            byte[] bytes = Encoding.Default.GetBytes(dataArr[j]);
                            dataArr[j] = Encoding.UTF8.GetString(bytes);

                            if (j > 0) valuesString += ", ";
                            valuesString += $"@{j}_{counter}";

                            if (dataArr[j] == "False") dataArr[j] = "0";
                            if (dataArr[j] == "True") dataArr[j] = "1";
                            config.Add($"@{j}_{counter}", String.IsNullOrEmpty(dataArr[j]) ? null : dataArr[j]);
                        }

                        valuesString += ")";
                        if (counter == 1000)
                        {
                            valuesString += ";";
                            try
                            {
                                using (var con = await dbContext.GetConnection())
                                {
                                    var result = con.Execute(Strings.insertQuery + valuesString, config);
                                    Console.WriteLine("Step 2: Zwischenergebnis: 1000 weitere Zeilen eingetragen");

                                }
                            }
                            catch (MySqlException ex)
                            {
                                Console.WriteLine(ex.ToString());
                                Console.WriteLine(currentLine);
                            }
                            finally
                            {
                                counter = 0;
                                valuesString = "";
                                config = new DynamicParameters();
                            }
                        }

                        counter++;
                    }
                    else
                    {
                        if ((totalCount % 1000) == 0)
                        {
                            Console.WriteLine(totalCount + ": Found duplicate");
                        }
                    }
                }
                valuesString += ";";
                try
                {
                    using (var con = await dbContext.GetConnection())
                    {
                        var result = con.Execute(Strings.insertQuery + valuesString, config);
                        Console.WriteLine("Step 2: Letzte Eintragung.");
                        counter = 0;
                        valuesString = "";
                        config = new DynamicParameters();
                    }
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            Console.WriteLine("Step 2: Alle Eintrage übernommen!");

            Console.WriteLine("Die Anwendung führt keine Aufgaben mehr aus uns kann geschlossen werden");
            Console.ReadLine();
        }
        }
}
