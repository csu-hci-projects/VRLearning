using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject[] cameras;
    public Canvas QuizUI;
    private bool canPress = true;

    void Start() {
        QuizUI.enabled = false;
    }

    void Update(){
        checkForKeyPress();
    }

    void checkForKeyPress(){
        if (Input.GetKeyDown(KeyCode.RightArrow) && canPress){
            changeCamera(1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canPress){
            changeCamera(-1);
        }
    }

    void changeCamera(int change){
        int currentCamera = PlayerPrefs.GetInt("CameraPosition");

        int lastCamera = currentCamera;

        currentCamera = currentCamera + change;

        if (currentCamera == cameras.Length) {
            QuizUI.enabled = true;
            canPress = false;
        }
        if (currentCamera > cameras.Length - 1) {
            currentCamera = 0;
        }
        if (currentCamera < 0) {
            currentCamera = cameras.Length - 1;
        }

        PlayerPrefs.SetInt("CameraPosition", currentCamera);

        cameras[lastCamera].SetActive(false);
        cameras[currentCamera].SetActive(true);

    }
}
