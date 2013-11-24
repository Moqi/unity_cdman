using UnityEngine;
using System.Collections;

public class die_animation : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}

	public void CompleteAnimation(){
		Instantiate(player, transform.position,Quaternion.Euler(0,0,0));
		Destroy(gameObject);
		respounter.On=true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
