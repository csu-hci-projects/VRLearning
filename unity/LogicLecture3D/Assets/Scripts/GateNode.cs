using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class GateNode : MonoBehaviour {

    public static GameObject down;
    public static GameObject up;
    public GateNode node;
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
        if (line && node){
            line.SetPosition(0, gameObject.transform.position);
            line.SetPosition(1, node.transform.position);
        }
        if (node) {
            status = node.status;
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateDown(SteamVR_Input_Sources.Any) && e.bHit)
        {
            down = e.target.gameObject;
        }
        if (SteamVR_Actions.default_GrabPinch.GetStateUp(SteamVR_Input_Sources.Any) && e.bHit)
        {
            up = e.target.gameObject;
            if (up && down)
            {
                if (down.GetInstanceID() == up.GetInstanceID()) status = !status;
                else if (down.tag != "InputNode")
                {
                    node = down.GetComponent<GateNode>();
                    if (line == null)
                    {
                        line = this.gameObject.AddComponent<LineRenderer>();
                        line.SetWidth(0.1F, .1F);
                        line.SetVertexCount(2);
                        line.material.color = Color.white;
                    }
                    else
                    {
                        Destroy(gameObject.GetComponent<LineRenderer>());
                        node = null;
                    }
                    down = null;
                    up = null;
                }
            }
        }
    }
}