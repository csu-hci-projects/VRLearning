using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class SpawnObject : MonoBehaviour {

    public GameObject thisObject;
    public SteamVR_LaserPointer laserPointer;
    public Vector3 spawnPoint = Vector3.zero;

    public void OnMouseDown(){
        // spawnObject();
    }

    void spawnObject()
    {
        Debug.Log("Spawn Object");
        Instantiate(thisObject, new Vector3(spawnPoint.x, 0.2f, 0.05f), Quaternion.identity);
    }

    void Update()
    {
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any) && (spawnPoint != Vector3.zero))
        {
            spawnObject();
        }
    }
}
