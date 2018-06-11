using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;

public class CtrlSlider{
    [XmlAttribute("name")] public string sliderName;
    [XmlAttribute("value")] public float sliderValue;
}
