using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
namespace App1
{

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


    }


    
    public sealed partial class MainPage : Page
    {
   //     private static string JsonFile =
   //"C:\\Users\\Administrator\\AppData\\Local\\Packages\\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\\LocalState\\sample.txt";

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = ReadFromJSON();

            //System.IO.File.WriteAllText(@"C:\temp\personaldata1.txt", json);

        }

        public async static void SaveToJSON(string json)
        {

            // Create sample file; replace if exists.
            Windows.Storage.StorageFolder storageFolder =
                    Windows.Storage.ApplicationData.Current.LocalFolder;

            Windows.Storage.StorageFile sampleFile =
                    await storageFolder.CreateFileAsync("sample.txt",
                        Windows.Storage.CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteTextAsync(sampleFile, json);
        }
        
        public static JArray ReadFromJSON() {
            var json = System.IO.File.ReadAllText(@"C:\Users\Administrator\AppData\Local\Packages\3cb18cff-163c-452c-840c-f8bcc5eda7a9_75cr2b68sm664\LocalState\sample.json");

            json = json.Replace(System.Environment.NewLine, "");

            JArray objects = JArray.Parse(json); 

            //foreach (var person in objects)
            //{

            //    var id = person["ID"];
            //    var name = person["Name"];
            //    var description = (String)person["Description"];
                
            //}


            return objects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            SaveToJSON(json);

        }

        private void Read_Button(object sender, RoutedEventArgs e)
        {

            ReadFromJSON();

        }
    }
}
