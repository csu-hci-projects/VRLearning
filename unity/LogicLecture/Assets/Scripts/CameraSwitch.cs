using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject[] cameras;

    void Update(){
        checkForKeyPress();
    }

    void checkForKeyPress(){
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            changeCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            changeCamera(-1);
        }
    }

    void changeCamera(int change){
        int currentCamera = PlayerPrefs.GetInt("CameraPosition");

        int lastCamera = currentCamera;

        currentCamera = currentCamera + change;

        if (currentCamera > cameras.Length-1){
            currentCamera = 0;
        }
        if (currentCamera < 0){
            currentCamera = cameras.Length-1;
        }

        PlayerPrefs.SetInt("CameraPosition", currentCamera);

        cameras[lastCamera].SetActive(false);
        cameras[currentCamera].SetActive(true);

    }
}
