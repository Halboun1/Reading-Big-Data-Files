using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;

namespace WritingCsvToDatabase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int[]> arrayList = new List<int[]>();
            int[] array = new int[5];
            var lineNumber = 0;
            string connectionString = @"Data Source=LAPTOP-TFQT1SVB; Integrated Security=true";
            StringBuilder errorMessages = new StringBuilder();
            string skipLine;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (StreamReader reader = new StreamReader(@"c:\BigData\newData.csv"))
                {
                    while(!reader.EndOfStream)
                    {
                        reader.ReadLine();
                        var line = reader.ReadLine();

                        var values = line.Split(',');



                        /*array[0] = int.Parse(values[0]);    //GEO
                        array[1] = int.Parse(values[1]);    //SEX
                        array[2] = int.Parse(values[2]);    //AGEGR5
                        array[3] = int.Parse(values[3]);    //NOC2011
                        array[4] = int.Parse(values[4]);    //COWD
                        arrayList.Add(array);
                        //Console.WriteLine(arrayList.Count);
                        Console.WriteLine(line);
                        Console.ReadKey();*/


                        var sql = "INSERT INTO newSample.dbo.newdata VALUES ('" + values[0] + "','" + values[1] + "','" + values[2] + "','" + values[3] + "','" + values[4] +")";

                        var cmd = new SqlCommand();
                        cmd.CommandText = sql;

                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = conn;

                        cmd.ExecuteNonQuery();


                    }

                }
                
            }

        }
    }
}
