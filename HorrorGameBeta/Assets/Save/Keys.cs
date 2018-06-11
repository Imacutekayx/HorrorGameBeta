using System.Xml.Serialization;
using UnityEngine;

public class Keys{
    [XmlAttribute("name")] public string keyName;
    [XmlAttribute("value")] public KeyCode keyValue;
}
