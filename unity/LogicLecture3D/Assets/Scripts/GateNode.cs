using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNode : MonoBehaviour {

    public GateNode node;
    private GameObject clickedObject;
    public bool status;
    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    public void OnMouseUp(){
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
        if (hit){
            clickedObject = hitInfo.transform.gameObject;
            node = clickedObject.GetComponent<GateNode>();
            if(line == null){
                line = this.gameObject.AddComponent<LineRenderer>();
                line.SetWidth(0.1F, .1F);
                line.SetVertexCount(2);
                line.material.color = Color.white;
            }
        }

        if (status){
            status = false;
        } else{
            status = true;
        }
    }

    // Update is called once per frame
    void Update(){
        if(line){
            line.SetPosition(0, this.gameObject.transform.position);
            line.SetPosition(1, clickedObject.transform.position);
        }
        if(node){
            node.status = status;
        }
    }
}
