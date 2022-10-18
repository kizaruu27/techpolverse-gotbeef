using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform normalPos;
    [SerializeField] Transform cookingPos;

    private void Start()
    {
       SetCameraToNormal();
    }

    public void SetCameraToNormal()
    {
        cam.position = normalPos.position;
        cam.rotation = normalPos.rotation;
    }

    public void SetCameraToCookingMode()
    {
        cam.position = cookingPos.position;
        cam.rotation = cookingPos.rotation;
    }
}
