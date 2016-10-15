using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.Rendering;
using Assets.MapStruktur;

public class MapParser : MonoBehaviour {

	public OpenStreatMap MapData { get; private set;}

	// Use this for initialization
	void Start ()
	{
	    osm mapObject = loadMapFromXML();
	    Debug.Log(mapObject.note);
		MapData = new OpenStreatMap (mapObject);
		Debug.Log (MapData.Nodes.Count);
		Debug.Log (MapData.Ways.Count);
		Debug.Log (MapData.Buildings.Count);
		Debug.Log (MapData.Parks.Count);
		Debug.Log (MapData.Waters.Count);
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
