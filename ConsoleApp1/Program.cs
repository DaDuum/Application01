using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }

    

    class Program
    {
        static void Main(string[] args)
        {
            List<Person> _data = new List<Person>
            {
                new Person(){
                    ID = 1,
                    Name = "Name01",
                    Description = "Desc01"
                },
                new Person(){
                    ID = 2,
                    Name = "Name02",
                    Description = "Desc02"
                }
            };

            string json = JsonConvert.SerializeObject(_data.ToArray(), Formatting.Indented);

            //SaveToJSON(json);

            ReadFromJSON();
        }

        public static void SaveToJSON(string json)
        {


            //open file stream
            using (StreamWriter file = File.CreateText(@"C:\Users\Administrator\AppData\Local\Packages\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\LocalState\sample2.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, json);
            }
        }

        //public static void ReadFromJSON() {


        //    var json = System.IO.File.ReadAllText(@"C:\Users\Administrator\AppData\Local\Packages\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\LocalState\new.json");

        //    var objects = JArray.Parse(json); // parse as array  
        //    foreach (JObject root in objects)
        //    {
        //        foreach (KeyValuePair<String, JToken> app in root)
        //        {
        //            var appName = app.Key;
        //            var description = (String)app.Value["Description"];
        //            var value = (String)app.Value["Value"];

        //            Console.WriteLine(appName);
        //            Console.WriteLine(description);
        //            Console.WriteLine(value);
        //            Console.WriteLine("\n");
        //        }
        //    }

        //    Console.ReadKey();
        //}

        public static void ReadFromJSON()
        {
            //var json = System.IO.File.ReadAllText(@"C:\Users\Administrator\AppData\Local\Packages\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\LocalState\sample2.txt");
            //List<Person> deserializedJson = JsonConvert.DeserializeObject<List<Person>>(json);

            var json = System.IO.File.ReadAllText(@"C:\Users\Administrator\AppData\Local\Packages\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\LocalState\sample.json");
            json = json.Replace(System.Environment.NewLine, "" );

            JArray objects = JArray.Parse(json); // parse as array  

            foreach (var person in objects)
            {

                    var id = person["ID"];
                    var name = person["Name"];
                    var description = (String)person["Description"];

                    Console.WriteLine(id);
                    Console.WriteLine(name);
                    Console.WriteLine(description);
                    Console.WriteLine("\n");

               
            }



            Console.ReadKey();
            //return deserializedJson;
        }


    }
}
