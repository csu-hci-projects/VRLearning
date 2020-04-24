using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class PointerController : SteamVR_LaserPointer
{
    public override void OnPointerIn(PointerEventArgs e)
    {
        base.OnPointerIn(e);
        if (e.target.gameObject.tag == "Draggable")
        {
            e.target.GetComponent<DragObject>().draggable = true;
            e.target.GetComponent<DragObject>().raycastPoint = e.hit.point;
        }
        if (e.target.gameObject.tag == "Spawner")
        {
            e.target.GetComponent<SpawnObject>().spawnPoint = new Vector3(e.target.position.x, 0.2f, 0.05f);
        }
    }
    public override void OnPointerOut(PointerEventArgs e)
    {
        base.OnPointerOut(e);
        if (e.target.gameObject.tag == "Draggable")
        {
            e.target.GetComponent<DragObject>().draggable = false;
        }
        if (e.target.gameObject.tag == "Spawner")
        {
            e.target.GetComponent<SpawnObject>().spawnPoint = Vector3.zero;
        }
    }
}
