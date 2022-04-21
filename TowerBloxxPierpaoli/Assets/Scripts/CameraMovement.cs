using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform mainCamera;
    public MeshRenderer mr;
    private InputManager inputManager;

    // Update is called once per frame
    void Update()
    {        
        if (inputManager.spawnInput())
        {
            MoveCameraUp();
        }
    }

    private void MoveCameraUp()
    {
        mainCamera.position += mr.bounds.size;
    }

   
}
