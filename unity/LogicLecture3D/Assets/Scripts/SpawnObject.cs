using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class SpawnObject : MonoBehaviour {

    public GameObject thisObject;
    public SteamVR_LaserPointer laserPointer;

    public void OnMouseDown(){
        // spawnObject();
    }

    public void Awake()
    {
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        int cutOff = e.target.name.IndexOf(' ') >= 0 ? e.target.name.IndexOf(' ') : 0;
        if (e.target.name.Substring(0, cutOff) == thisObject.name) spawnObject(e);
    }

    void spawnObject(PointerEventArgs e)
    {
        GameObject camera = GameObject.Find("Camera");
        Instantiate(thisObject, new Vector3(e.target.position.x, 0.2f, 0.05f), Quaternion.identity);
    }

    void Update(){

    }
}
