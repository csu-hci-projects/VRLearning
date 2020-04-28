using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {

    public GameObject[] cameras;
    public CanvasGroup Quiz;
    public CanvasGroup Answer;
    private static bool canPress = true;
    private int index = 0;

    void Start() {
        if (canPress == true) {
            Quiz.alpha = 0;
            Quiz.interactable = false;
        }
        Answer.alpha = 0;
    }

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

        int lastIndex = index;
        index = index + change;

        if (index == cameras.Length) {
            Quiz.alpha = 1;
            Quiz.interactable = true;
            canPress = false;
        }

        if (index > cameras.Length-1){
            index = 0;
        }
        if (index < 0){
            index = cameras.Length-1;
        }

        cameras[lastIndex].SetActive(false);
        cameras[index].SetActive(true);

    }
}
