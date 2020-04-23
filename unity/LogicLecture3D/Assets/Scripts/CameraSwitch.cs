/* SceneHandler.cs*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR;

public class CameraSwitch : MonoBehaviour
{
    public GameObject cameraRig;
    public int numberOfSlides = 0;
    private int index = 0;

    void Update()
    {
        
        if (SteamVR_Actions.default_SlideRight.GetStateDown(SteamVR_Input_Sources.Any))
        {
            updateCameraPosition(1);
        }
        if (SteamVR_Actions.default_SlideLeft.GetStateDown(SteamVR_Input_Sources.Any))
        {
            updateCameraPosition(-1);
        }
    }

    void updateCameraPosition(int direction)
    {
        int slideIndex = numberOfSlides - 1;
        index += direction;

        float xPos = cameraRig.transform.position.x;

        if (index > slideIndex) 
        { 
            index = 0; 
            cameraRig.transform.position = new Vector3(0, 0, -10); 
        }
        else if (index < 0) 
        { 
            index = numberOfSlides - 1; 
            cameraRig.transform.position = new Vector3((slideIndex * 20), 0, -10); 
        }
        else
        {
            cameraRig.transform.position = new Vector3(xPos + (20 * direction), 0, -10);
        }
    }

}
