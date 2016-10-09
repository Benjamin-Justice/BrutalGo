using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.Rendering;

public class MapParser : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    osm mapObject = loadMapFromXML();
	    Debug.Log(mapObject.note);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private osm loadMapFromXML()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(osm));
        return (osm) serializer.Deserialize(new XmlTextReader("Assets/XML/hh-small-response.xml"));
    }
}
