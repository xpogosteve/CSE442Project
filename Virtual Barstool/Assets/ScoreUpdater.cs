using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

  

	// Use this for initialization
	void Start () {
        // Set the text of the attached Text mesh
        GetComponent<Text>().text = "Hello World";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
