using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTGate : MonoBehaviour {

    public GameObject nodeObject;
    private GameObject inputOne;
    private GameObject output;

    private GateNode[] nodeScripts;

    public bool inputOneStatus;
    public bool outputStatus;

    public void Start(){

        //spawn input nodes
        Vector2 pos = new Vector2(transform.position.x-2, transform.position.y);
        inputOne = Instantiate(nodeObject, pos, Quaternion.identity);
        inputOne.transform.parent = transform;
        inputOne.tag = "InputNode";

        //spawn output node
        pos = new Vector2(transform.position.x+2, transform.position.y);
        output = Instantiate(nodeObject, pos, Quaternion.identity);
        output.transform.parent = transform;
        output.tag = "OutputNode";

        nodeScripts = GetComponentsInChildren<GateNode>();

    }

    void Update(){

        inputOneStatus = nodeScripts[0].status;

        if (inputOneStatus){
            outputStatus = false;
            nodeScripts[1].status = false;
        } else {
            outputStatus = true;
            nodeScripts[1].status = true;
        }

        if (inputOneStatus){
            inputOne.GetComponent<Renderer>().material.color = new Color(5.0f, 5.0f, 0.0f);
        } else {
            inputOne.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
        }

        if (outputStatus){
            output.GetComponent<Renderer>().material.color = new Color(5.0f, 5.0f, 0.0f);
        } else {
            output.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
        }

    }
}
