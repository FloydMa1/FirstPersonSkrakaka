using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    [SerializeField] private Texture text;

	// Use this for initialization
	void Start () {
		
	}

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(Screen.width/2-text.width/2, Screen.height/2-text.height/2, text.width, text.height), text);
    }
}
