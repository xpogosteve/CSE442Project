
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    Vector3 ct = new Vector3(0, 0, 0);


    // Use this for initialization
    void Start () {
        ct = cueball.transform.position;


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
                else if(t.Contains("white")) //if cueball
                {
                 Instantiate(cueball, ct, transform.rotation);
                }
            //Debug.Log(Menu.GetComponent<Text>());
            Menu.GetComponent<Text>().text = "Solids: " + solidcount + "\n Stripes: " + stripecount;


            }
        }

    void Gameover(string winner)
    {
        Menu.GetComponent<Text>().text = winner;
        new WaitForSeconds(5);
        Menu.GetComponent<Text>().text = "Resetting in: ";
        for(int x=5; x>0; x--)
        {
            Menu.GetComponent<Text>().text = "Resetting in: " + x;
            new WaitForSeconds(1);

        }


        SceneManager.LoadScene("Pirate Bar");



    }
    
}
