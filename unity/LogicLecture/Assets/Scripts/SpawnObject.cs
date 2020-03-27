using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject meteor;

    public void OnMouseDown(){
        spawnObject();
    }

    void spawnObject(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(meteor, mousePosition, Quaternion.identity);
    }

    void Update(){

    }
}
