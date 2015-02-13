using UnityEngine;
using System.Collections;
using System.Xml;

public class Dialogs : MonoBehaviour {

	// Use this for initialization
	void Start () {
        getSceneDialogs();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void getSceneDialogs(string language = "US")
    {
        XmlDocument xmlDoc = new XmlDocument();

        xmlDoc.Load(DialogsData.getDialogs(language));

        XmlNodeList sceneTag = xmlDoc.GetElementsByTagName("scene");

        foreach (XmlNode e in sceneTag)
        {
            print(e.Attributes.Item(0).InnerText);
            
        }
        
    }
}
