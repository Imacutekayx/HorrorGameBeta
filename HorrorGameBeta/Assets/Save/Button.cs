using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Class which contains the informations of the buttons
/// </summary>
public class Button{
    [XmlAttribute("name")] public string btnName;
    [XmlAttribute("value")] public KeyCode btnValue;
}
