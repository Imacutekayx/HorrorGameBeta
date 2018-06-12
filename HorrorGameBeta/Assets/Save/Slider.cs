using System.Xml.Serialization;

/// <summary>
/// Class which contains the informations of the sliders
/// </summary>
public class CtrlSlider{
    [XmlAttribute("name")] public string sliderName;
    [XmlAttribute("value")] public float sliderValue;
}
