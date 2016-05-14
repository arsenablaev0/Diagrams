using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;

namespace Diagrams
{
    public class MySerializer
    {

        public MySerializer()
        {

        }

        public void SerializeObject(string fileName, SerializableObject objToSerialize)
        {
            FileStream fstream = File.Open(fileName, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fstream, objToSerialize);
            fstream.Close();
        }
        public SerializableObject DeserializeObject(string fileName)
        {
            try
            {
                SerializableObject objToSerialize = null;
                FileStream fstream = null;
                fstream = File.Open(fileName, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                objToSerialize = (SerializableObject)binaryFormatter.Deserialize(fstream);
                fstream.Close();
                return objToSerialize;
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Файл не найден или пустой");
            }

        }
    }
}
