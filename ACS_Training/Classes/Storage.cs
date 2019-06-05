using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Windows;

namespace ACS_Training.Classes
{
    internal class Storage
    {
        internal static void WriteJson<T>(T data, string fileName)
        {

            try
            {
                FileStream stream = new FileStream(fileName, FileMode.Create);
                string dataAsString = JsonConvert.SerializeObject(data);
                byte[] dataAsBytes = new UTF8Encoding(true).GetBytes(dataAsString);
                stream.Write(dataAsBytes, 0, dataAsBytes.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        internal static T ReadJson<T>(string fileName)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(fileName))
                {
                    string data = streamReader.ReadToEnd();
                    return (T)JsonConvert.DeserializeObject<T>(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex, "Caution . . ");
                return (T)default;
            }
        }
    }
}