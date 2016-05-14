using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Diagrams
{
    [Serializable]
    public class SerializableObject //: ISerializable
    {

        public List<string> OneFigure { get; set; }
        public List<List<string>> Figures { get; set; }
        //   public List<string> TextInFigure { get; set; }

        public SerializableObject()
        {
            OneFigure = new List<string>();
            Figures = new List<List<string>>();
        }

        //public SerializableObject(SerializationInfo sInfo, StreamingContext contextArg)
        //{
        //    this.figures = (List<string>)sInfo.GetValue("Figures", typeof(List<string>));
        //}

        //public void GetObjectData(SerializationInfo sInfo, StreamingContext contextArg)
        //{
        //    sInfo.AddValue("Figures", this.figures);
        //}
    }
}
