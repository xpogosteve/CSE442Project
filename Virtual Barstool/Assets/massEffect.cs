using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class massEffect : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = this.transform.parent.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION");
        if (collision.gameObject.tag == "Balls")
        {
            rb.mass = 3;
        }
    }
}
