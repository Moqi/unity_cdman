using UnityEngine;
using System.Collections;

public class score : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = cdman_control.Score.ToString();
		while (guiText.text.Length<8) {
			guiText.text="0"+guiText.text;
		}
	}
}
