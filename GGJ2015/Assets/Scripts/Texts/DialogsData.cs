using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class DialogsData : MonoBehaviour {

    private static Dictionary<string, string> dialogs = new Dictionary<string,string>()
    { 
        {"US", @"<dialogs>
                    <scene id='Cen01_Quarto'>
                        
                    </scene>
                    <scene id='Cen02_Cozinha'>
                        
                    </scene>
                </dialogs>"} 
    };

    public static StringReader getDialogs(string language)
    {
        if (dialogs.ContainsKey(language))
            return new StringReader(dialogs[language]);
        else 
        {
            print("Dialog language could not be loaded");
            return null;
        }
    }
}
