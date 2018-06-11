using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

[XmlRoot("Controls")]
public class Controls{
    [XmlArray("Control"), XmlArrayItem("Key")]
    public List<Keys> lstKeys;

    [XmlArray("Sliding"), XmlArrayItem("Slider")]
    public List<CtrlSlider> lstSliders;

    private Controls() { }

    public static Controls LoadFromFile(string filepath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Controls));
        using(FileStream stream = new FileStream(filepath, FileMode.Open))
        {
            return serializer.Deserialize(stream) as Controls;
        }
    }

    public void Save(string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Controls));
        using(FileStream stream = new FileStream(path, FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
