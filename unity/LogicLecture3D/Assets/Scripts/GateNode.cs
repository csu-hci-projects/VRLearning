using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class GateNode : MonoBehaviour {

    public GateNode node;
    private GameObject clickedObject;
    public bool status;
    private LineRenderer line;
    public PointerEventArgs e = default(PointerEventArgs);

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update(){
        if (line){
            line.SetPosition(0, this.gameObject.transform.position);
            line.SetPosition(1, clickedObject.transform.position);
        }
        if (node){
            node.status = status;
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any) && e.bHit)
        {
            clickedObject = e.target.gameObject;
            node = clickedObject.GetComponent<GateNode>();
            if (line == null)
            {
                line = this.gameObject.AddComponent<LineRenderer>();
                line.SetWidth(0.1F, .1F);
                line.SetVertexCount(2);
                line.material.color = Color.white;
            }
            status = !status;
        }
    }
}
