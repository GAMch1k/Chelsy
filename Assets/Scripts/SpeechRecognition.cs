using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour {
    void Start() {
    }

    void Update() {
        float seconds = System.DateTime.Now.Second;
        if (seconds % 2f != 0f) {
            string text = System.IO.File.ReadAllText(@"D:\Unity\Projects\Chelsy\Assets\Scripts\text.txt").ToLower();
            if (text != string.Empty) {
                Debug.Log(text);
                System.IO.File.WriteAllText(@"D:\Unity\Projects\Chelsy\Assets\Scripts\text.txt", string.Empty);
                
                if (text.Contains("вверх")) {
                    Up();
                }
                if (text.Contains("вниз")) {
                    Down();
                }
                if (text.Contains("влево")) {
                    Left();
                }
                if (text.Contains("вправо")) {
                    Right();
                }
            }
        }
    }

    private void Right() {
        transform.Translate(1, 0, 0);
    }
    private void Left() {
        transform.Translate(-1, 0, 0);
    }
    private void Up() {
        transform.Translate(0, 1, 0);
    }
    private void Down() {
        transform.Translate(0, -1, 0);
    }
}
