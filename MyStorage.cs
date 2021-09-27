using System;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace animal_care
{
    internal class MyStorage
    {
        internal static void WriteXml<T>(T data, string fileName)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                FileStream stream;
                stream = new FileStream(fileName, FileMode.Create);
                xmlSerializer.Serialize(stream, data);
                stream.Close();
            }
            catch(Exception)
            {
                throw;
            }
        }

        internal static T ReadXML<T>(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    return (T)xmlSerializer.Deserialize(sr);
                }
            }
            catch(Exception x)
            {
                MessageBox.Show(x.ToString(), "ERROR");
                return default(T);
            }
        }
    }
}