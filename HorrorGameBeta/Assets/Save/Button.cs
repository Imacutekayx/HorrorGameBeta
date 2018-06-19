using System.Xml.Serialization;

/// <summary>
/// Class which contains the informations of the buttons
/// </summary>
public class Button{
    [XmlAttribute("name")] public string btnName;
    [XmlAttribute("value")] public string btnValue;
}
