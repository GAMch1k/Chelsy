using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeechRecognition : MonoBehaviour {
    
    string[] _open = new string[] { "открой", "включи", "запусти", "включай" };
    string[] _opera = new string[] { "opera", "опера", "оперу", "браузер" };
    string[] _telegram = new string[] { "telegram", "телеграм", "телегу" };

    string[] _apps = new string[] {
        @"C:\\Users\GAMch1k\AppData\Local\Programs\Opera GX\launcher.exe",
        @"C:\\Users\GAMch1k\AppData\Roaming\Telegram Desktop\Telegram.exe"
    };

    string text_file = @"D:\Unity\Projects\Chelsy\Assets\Scripts\text.txt"; 

    void Update() {
        float seconds = System.DateTime.Now.Second;
        if (seconds % 2f != 0f) {
            string text = System.IO.File.ReadAllText(text_file).ToLower();
            if (text != string.Empty) {
                Debug.Log(text);
                checkCommand(text);
                System.IO.File.WriteAllText(text_file, string.Empty);
            }
        }
    }

    private void checkCommand(string text) {        
        foreach (var elem in _open) {   // Check if text contains OPEN words
            if (text.Contains(elem)) {
                foreach (var elem2 in _opera) {     // Check if it's OPERA
                    if (text.Contains(elem2)) {
                        Debug.Log(elem + " " + elem2);
                        Debug.Log(elem2 + " will be started now...");
                        System.Diagnostics.Process.Start(_apps[0]);
                        return;
                    }
                }

                foreach (var elem2 in _telegram) {     // Check if it's TELEGRAM
                    if (text.Contains(elem2)) {
                        Debug.Log(elem + " " + elem2);
                        Debug.Log(elem2 + " will be started now...");
                        System.Diagnostics.Process.Start(_apps[1]);
                        return;
                    }
                }
            }
        }
    }
}
