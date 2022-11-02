using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform normalPos;
    [SerializeField] Transform cookingPos;
    [SerializeField] Transform cookingTarget;

    private bool isCooking;

    private void Start()
    {
       SetCameraToNormal();
    }

    private void FixedUpdate()
    {
        if (isCooking)
        {
            cam.position = Vector3.Lerp(cam.position, cookingPos.position, .5f);
            cam.LookAt(cookingTarget);
        }
        else
        {
            cam.position = Vector3.Lerp(cam.position, normalPos.position, .5f);
            cam.rotation = normalPos.rotation;
        }
    }

    public void SetCameraToNormal()
    {
        isCooking = false;
    }

    public void SetCameraToCookingMode()
    {
        isCooking = true;
    }
}
