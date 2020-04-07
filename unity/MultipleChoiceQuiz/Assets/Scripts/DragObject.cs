using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour {

    private bool dragging;

    public void OnMouseDown(){
        dragging = true;
    }

    public void OnMouseUp(){
        dragging = false;
    }

    void Update(){
        if (dragging) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
    }
}
