using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public bool spawnInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return true;
        }
        else return false;
    }
}
