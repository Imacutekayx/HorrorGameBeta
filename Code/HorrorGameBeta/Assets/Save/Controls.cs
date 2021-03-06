﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

/// <summary>
/// Class Controls which will be the link between the XML and the game
/// </summary>
[XmlRoot("Controls")]
public class Controls{

    //Lists of XML informations
    [XmlArray("Control"), XmlArrayItem("Key")]
    public List<Keys> lstKeys;
    [XmlArray("Sliding"), XmlArrayItem("Slider")]
    public List<CtrlSlider> lstSliders;
    [XmlArray("Gamepad"), XmlArrayItem("Button")]
    public List<Button> lstButtons;

    /// <summary>
    /// Method which will load the informations from the XML file
    /// </summary>
    /// <param name="filepath">Path to the XML file</param>
    /// <returns>Controls</returns>
    public static Controls LoadFromFile()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Controls));
        using(FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/controls.xml", FileMode.Open))
        {
            return serializer.Deserialize(stream) as Controls;
        }
    }

    /// <summary>
    /// Method which will save the informations of the game in the XML file
    /// </summary>
    /// <param name="path">Path to the XML file</param>
    public void Save()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Controls));
        using(FileStream stream = new FileStream(Application.dataPath + "/StreamingAssets/controls.xml", FileMode.Create))
        {
            serializer.Serialize(stream, this);
        }
    }
}
