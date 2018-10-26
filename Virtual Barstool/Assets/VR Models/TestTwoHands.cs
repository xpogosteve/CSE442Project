using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class TestTwoHands : MonoBehaviour
    {
        // Use this for initialization
        public Hand backHand;
        //public SteamVR_Input_Sources handType;
        public SteamVR_Action_Boolean triggerPull;
        public Vector3 cuePosition;

        public GameObject cue;


        void Start()
        {
            //cue = this.gameObject.transform.GetChild(0).gameObject;
            
        }
        // Update is called once per frame
        void Update()
        {
            if (backHand != null)
            {
                
                if (triggerPull.GetState(backHand.handType))
                {
                    Debug.Log("Trigger Pull Detected");
                    //cue.transform.Translate(cuePosition);
                    transform.Translate(cuePosition);
                }
            }
        }

        private void OnEnable()
        {
            backHand = GetComponent<Interactable>().attachedToHand;
        }
        private void OnDisable()
        {
            backHand = null;
        }
    }
}
