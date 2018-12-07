//======= Copyright (c) Valve Corporation, All rights reserved. ===============
//
// Purpose: Demonstrates how to create a simple interactable object
//
//=============================================================================

using UnityEngine;
using System.Collections;

namespace Valve.VR.InteractionSystem.Sample
{
    //-------------------------------------------------------------------------
    [RequireComponent(typeof(Interactable))]
    public class TwoHands : MonoBehaviour
    {
        public Hand backHand; //attached
        private Hand frontHand;

        private Vector3 backPosition;
        private Vector3 frontPosition;



        public SteamVR_Action_Boolean FrontHandGrip;
        public SteamVR_Action_Boolean RotationTrigger; //Grab Pinch is the trigger, select from inspecter
        public SteamVR_Input_Sources frontHandController = SteamVR_Input_Sources.Any;//which controller

        private TextMesh textMesh;
        private Vector3 oldPosition;
        private Quaternion oldRotation;

        private float attachTime;


        private Hand.AttachmentFlags attachmentFlags = Hand.defaultAttachmentFlags & (~Hand.AttachmentFlags.DetachFromOtherHand) & (~Hand.AttachmentFlags.SnapOnAttach) & (~Hand.AttachmentFlags.DetachOthers) & (~Hand.AttachmentFlags.VelocityMovement);

        private Interactable interactable;
        private LinearDrive linearDrive;

        private Vector3 attachmentpoint;

        public Vector3 centeredVect;
        public Vector3 rotationVect;

        //-------------------------------------------------
        void Awake()
        {
            linearDrive = this.GetComponent<LinearDrive>();

            interactable = this.GetComponent<Interactable>();
        }


        //-------------------------------------------------
        // Called when a Hand starts hovering over this object
        //-------------------------------------------------
        private void OnHandHoverBegin(Hand hand)
        {
            //Debug.Log("Hovering hand: " + hand.name);
        }


        //-------------------------------------------------
        // Called when a Hand stops hovering over this object
        //-------------------------------------------------
        private void OnHandHoverEnd(Hand hand)
        {
            //Debug.Log("No Hand Hovering");
        }


        //-------------------------------------------------
        // Called every Update() while a Hand is hovering over this object
        //-------------------------------------------------
        private void HandHoverUpdate(Hand hand)
        {

        }


        //-------------------------------------------------
        // Called when this GameObject becomes attached to the hand
        //-------------------------------------------------
        private void OnAttachedToHand(Hand hand)
        {
            backHand = hand;
            frontHand = backHand.otherHand;
            frontHandController = hand.otherHand.handType;

            Quaternion tRot = Quaternion.Euler(174.252F, -5.822998F, 62.587F);
            transform.localRotation = tRot;
            transform.localPosition = new Vector3(-0.028F, 0.015F, 0.178F);
            //transform.position = Vector3.Lerp(backHand.transform.position, backHand.transform.position, 1.0F);
        }


        //-------------------------------------------------
        // Called when this GameObject is detached from the hand
        //-------------------------------------------------
        private void OnDetachedFromHand(Hand hand)
        {
            transform.GetChild(0).GetComponent<BoxCollider>().enabled = true;
            backHand = null;
            frontHand = null;
            //Debug.Log("Detached from hand: " + hand.name);
            frontHandController = 0;
            linearDrive.enabled = false;

            if (RotationTrigger != null)
            {
                RotationTrigger.RemoveOnChangeListener(onRotationTriggerChange, frontHandController);
                FrontHandGrip.RemoveOnChangeListener(onFrontHandGripChange, frontHandController);

            }
        }


        //-------------------------------------------------
        // Called every Update() while this GameObject is attached to the hand
        //-------------------------------------------------
        private void HandAttachedUpdate(Hand hand)
        {
            //Debug.Log("Attached to hand: " + hand.name + "\nAttached time: " + ( Time.time - attachTime ).ToString( "F2" ));
            //if (RotationTrigger.GetStateDown(frontHandController))
            Debug.Log(RotationTrigger.GetState(frontHandController));
            //frontHand.transform.getChild(5).transform.getChild(1).transform.getChild(0)
            
            if (RotationTrigger.GetState(frontHandController))
            {
                Vector3 temp = transform.position;
                //transform.position = (backHand.transform.position + frontHand.transform.position) / 2.0F;
                transform.rotation = Quaternion.LookRotation(backHand.transform.localPosition - frontHand.transform.localPosition, Vector3.forward);
                transform.localPosition = hand.objectAttachmentPoint.localPosition;
            }

        }


        //-------------------------------------------------
        // Called when this attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusAcquired(Hand hand)
        {
        }


        //-------------------------------------------------
        // Called when another attached GameObject becomes the primary attached object
        //-------------------------------------------------
        private void OnHandFocusLost(Hand hand)
        {
        }

        // called when front Hand Trigger is pulled
        private void onRotationTriggerChange(SteamVR_Action_In action_In)
        {
            if (RotationTrigger.GetStateDown(frontHandController))
            {
                attachmentpoint = frontHand.transform.position;

                Debug.Log("pressed");
                oldRotation = transform.localRotation;
                oldPosition = transform.localPosition;

                //transform.GetChild(0).transform.rotation = Quaternion.Euler(0, -90, 0);
            }


            if (RotationTrigger.GetStateUp(frontHandController))
            {

                Debug.Log("released");
                //transform.GetChild(0).transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.localRotation = oldRotation;
                transform.localPosition = oldPosition;

            }

        }

        private void onFrontHandGripChange(SteamVR_Action_In action_In)
        {
            if (FrontHandGrip.GetStateDown(frontHandController))
            {
                

                
            }


            if (FrontHandGrip.GetStateUp(frontHandController))
            {
               // linearDrive.enabled = true;
            }
        }
    }
}
