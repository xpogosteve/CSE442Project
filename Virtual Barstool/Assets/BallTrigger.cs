using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    public bool enter = true;
    public bool stay = true;
    public bool exit = true;

    // Use this for initialization
    void Awake() {
        



        // create a sphere for this cube to interact with



    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (enter)
        {
            Debug.Log("entered");
            Debug.Log(other);
        }
    }

    // stayCount allows the OnTriggerStay to be displayed less often
    // than it actually occurs.
    private float stayCount = 0.0f;
    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            if (stayCount > 0.25f)
            {
                Debug.Log("staying");
                stayCount = stayCount - 0.25f;
            }
            else
            {
                stayCount = stayCount + Time.deltaTime;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (exit)
        {
            Debug.Log("exit");
        }
    }
    }
    
 


