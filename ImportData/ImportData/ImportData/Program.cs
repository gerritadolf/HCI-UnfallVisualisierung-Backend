using Dapper;
using MySqlConnector;
using System;
using System.IO;
using System.Text;

namespace ImportData
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var dbContext = new DbContext();
            
            Console.WriteLine("Step 1: Check database and create table if not exist.");
            try
            {
                using (var con = await dbContext.GetConnection())
                {
                    int result = con.Execute(Strings.createTableString);
                    if(result == 1)
                    {
                        Console.WriteLine("Step 1: Db created.");
                    } else
                    {
                        Console.WriteLine("Step 1: Db already exists. Continue");
                    }


                }
            } catch (MySqlException e)
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
                    string[] dataArr = currentLine.Split(",");

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
                        } catch(MySqlException ex)
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
