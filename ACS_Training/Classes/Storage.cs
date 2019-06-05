using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace ACS_Training.Classes
{
    internal class Storage
    {
        internal static void WriteJson<T>(T data, string fileName)
        {

            try
            {
                
                FileStream stream = new FileStream(fileName, FileMode.Create);
                string a = JsonConvert.SerializeObject(data);
                byte[] info = new UTF8Encoding(true).GetBytes(a);
                stream.Write(info, 0, info.Length);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}