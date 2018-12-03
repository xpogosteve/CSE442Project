//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Destroys this object when it enters a trigger
//
//=============================================================================

using UnityEngine;
using System.Collections;


	//-------------------------------------------------------------------------
	public class BallDestroyer : MonoBehaviour
	{
		

		//-------------------------------------------------
		void Start()
		{
           
            
		}


		//-------------------------------------------------
		void OnTriggerEnter( Collider collider )
		{
           /* if (collider.gameObject.name.Contains("white"))
            {
                return;
            }*/

            if (collider.gameObject.name.Contains("ball")) 
			{
                //Debug.Log(collider.gameObject.tag);
                //Debug.Log(collider.gameObject.transform.root.gameObject);

                //Destroy( collider.gameObject.transform.root.gameObject );
                Destroy(collider.gameObject);
            }
		}
	}

