
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ball_Log : MonoBehaviour {
    public GameObject Menu;
    public GameObject balls;
    public GameObject cueball;
    string s1 = "ball";
    string str = "stripe";
    string sol = "solid";
    string eb = "ball_8";
    int stripecount = 7;
    int solidcount = 8;
    string winner="No body";


    // Use this for initialization
    void Start () {
        
		
	}
	
	// Update is called once per frame

    void OnTriggerEnter(Collider collider)
        {
       
        string t = collider.gameObject.name;
        //Debug.Log(collider.gameObject.name);
        if (t.Contains(s1)) //if the object that passed through is a ball
            {
                //Debug.Log(collider.gameObject.name);
               // Debug.Log("working");
                //Debug.Log(collider.gameObject.transform.root.gameObject);
                //Destroy(collider.gameObject.transform.root.gameObject); //deletes ball
                if (t.Contains(str))//if the ball that passed is a stripe
                {
                    stripecount -= 1;
                    

                }
                if (t.Contains(sol))//if ball is solid
                {
                    solidcount -= 1;
                    

                }
                if (t.Contains(eb)) //if ball is 8ball
                {
                    if (solidcount == 1)
                    {
                    //gamewin
                    Menu.GetComponent<Text>().text = "You Win!";
                    winner = "solid";
                    Gameover(winner);

                }
                    else if (stripecount == 0)
                    {
                    //gamewin
                    Menu.GetComponent<Text>().text = "You Win!";
                    winner = "stripe";
                    Gameover(winner);
                }
                    else
                    {
                    //gamelose
                    Menu.GetComponent<Text>().text = "You Loose!";
                    Gameover(winner);
                }

                }
                else//if cueball
                {
               Instantiate(cueball, Vector3.zero, transform.rotation);
                }
            //Debug.Log(Menu.GetComponent<Text>());
            Menu.GetComponent<Text>().text = "Solids: " + solidcount + "\n Stripes: " + stripecount;


            }
        }

    void Gameover(string winner)
    {


    }
    
}
