using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Class which contains the informations of the keys
/// </summary>
public class Keys{
    [XmlAttribute("name")] public string keyName;
    [XmlAttribute("value")] public KeyCode keyValue;
}
