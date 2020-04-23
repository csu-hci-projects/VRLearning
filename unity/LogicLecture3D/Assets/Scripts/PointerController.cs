using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class PointerController : SteamVR_LaserPointer
{
    public SteamVR_Action_Single squeezeAction = SteamVR_Input.GetAction<SteamVR_Action_Single>("Squeeze");

    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);

        if (e.target.gameObject.tag == "Draggable")
        {
            float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.Any);
            if (triggerValue > 0.0f)
            {
                e.target.position = new Vector3(e.target.position.x + 10, e.target.position.y, e.target.position.z);
            }
        }
    }
}
