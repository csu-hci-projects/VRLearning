using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;
using Valve.VR.Extras;

public class DragObject : MonoBehaviour {

    public bool draggable = false;
    public bool dragging = false;
    public Vector3 raycastPoint;

    public void OnMouseDown(){
        dragging = true;
    }

    public void OnMouseUp(){
        dragging = false;
    }

    void Update(){
        if (draggable && dragging) {
            transform.position = new Vector3(raycastPoint.x, raycastPoint.y, 0.05f);
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            dragging = true;
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any))
        {
            dragging = false;
        }
    }
}
