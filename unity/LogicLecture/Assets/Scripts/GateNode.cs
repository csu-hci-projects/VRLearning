using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateNode : MonoBehaviour {
    
    public bool status;
    // Start is called before the first frame update
    void Start()
    {
        status = false;
    }

    public void OnMouseUp(){
        if (status) {
            status = false;
        } else {
            status = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
