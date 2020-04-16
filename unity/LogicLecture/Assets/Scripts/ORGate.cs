using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORGate : MonoBehaviour {

    public GameObject nodeObject;
    private GameObject inputOne;
    private GameObject inputTwo;
    private GameObject output;

    private GateNode[] nodeScripts;

    public bool inputOneStatus;
    public bool inputTwoStatus;
    public bool outputStatus;

    public void Start(){

        //spawn input nodes
        Vector2 pos = new Vector2(transform.position.x-2, transform.position.y+0.5f);
        inputOne = Instantiate(nodeObject, pos, Quaternion.identity);
        inputOne.transform.parent = transform;
        inputOne.tag = "InputNode";

        pos = new Vector2(transform.position.x-2, transform.position.y-0.5f);
        inputTwo = Instantiate(nodeObject, pos, Quaternion.identity);
        inputTwo.transform.parent = transform;
        inputTwo.tag = "InputNode";

        //spawn output node
        pos = new Vector2(transform.position.x+2, transform.position.y);
        output = Instantiate(nodeObject, pos, Quaternion.identity);
        output.transform.parent = transform;
        output.tag = "OutputNode";

        nodeScripts = GetComponentsInChildren<GateNode>();

    }

    void Update(){

        inputOneStatus = nodeScripts[0].status;
        inputTwoStatus = nodeScripts[1].status;

        if (inputOneStatus || inputTwoStatus){
            outputStatus = true;
            nodeScripts[2].status = true;
        } else {
            outputStatus = false;
            nodeScripts[2].status = false;
        }

        if (inputOneStatus){
            inputOne.GetComponent<Renderer>().material.color = new Color(5.0f, 5.0f, 0.0f);
        } else {
            inputOne.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
        }

        if (inputTwoStatus){
            inputTwo.GetComponent<Renderer>().material.color = new Color(5.0f, 5.0f, 0.0f);
        } else {
            inputTwo.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
        }

        if (outputStatus){
            output.GetComponent<Renderer>().material.color = new Color(5.0f, 5.0f, 0.0f);
        } else {
            output.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 1.0f);
        }

    }
}
