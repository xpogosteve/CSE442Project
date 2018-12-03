using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceOffWalls : MonoBehaviour
{


    private Rigidbody rb;
    private int currentIndex;
    public int frameSaves = 10;
    //lower number slows down ball on wall collision
    public float speedLoss = 1.0F;
    public Vector3[] preHitVel;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentIndex = 0;
    }


    // Update is called once per frame
    void Update()
    {
        preHitVel[currentIndex++] = rb.velocity;
        if (currentIndex >= frameSaves)
        {
            currentIndex = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        int temp = currentIndex + 1;
        if (temp >= frameSaves)
        {
            temp = 0;
        }

        if (other.GetComponent<whichwall>().LongWall)
        {
            rb.velocity = new Vector3(-speedLoss * preHitVel[temp].x, 0, rb.velocity.z);
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, -speedLoss * preHitVel[temp].z);
        }
    }
}
