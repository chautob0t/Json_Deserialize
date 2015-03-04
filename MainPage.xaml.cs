using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using JSON_Deserialize.Resources;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace JSON_Deserialize
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        public class Mydata
        {
            public int id { get; set; }
            public string name { get; set; }
            public string location { get; set; }
            public string date { get; set; }
            public string time { get; set; }
        }

        public class RootObject
        {
            public List<Mydata> mydata { get; set; }
        }

        // Reading content of file in a string
        public static string ReadFile(string filePath)
        {
            var ResrouceStream = Application.GetResourceStream(new Uri(filePath, UriKind.Relative));
            if (ResrouceStream != null)
            {
                Stream myFileStream = ResrouceStream.Stream;
                if (myFileStream.CanRead)
                {
                    StreamReader myStreamReader = new StreamReader(myFileStream);
                    return myStreamReader.ReadToEnd();
                }
            }
            return "";
        }

        private void Click_to_Deserialize_Click(object sender, RoutedEventArgs e)
        {
            var sample = ReadFile(@"Assets/samplejson.txt");
            
            // Deserialize JSON data into an "obj" of class RootObject
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(sample);

            // Set the dataContext of LongListSelector to the parse object
            test.DataContext = obj;

            MessageBox.Show("Deserialization Succesfull!");
        }
    }
}