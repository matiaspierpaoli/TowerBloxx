using UnityEngine;
using System.Collections;

public class InstnciateScript : MonoBehaviour
{
    public Transform spawPoint;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab; 

    // This script will simply instantiate the Prefab when the game starts.
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
           
    }

    private void Spawn()
    {       
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(myPrefab, spawPoint.position , Quaternion.identity);
            
        myPrefab.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        

    }

}
