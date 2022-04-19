using UnityEngine;
using System.Collections;

public class InstnciateScript : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject cyllinder;

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;
  
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn();
        }
           
    }

    private void Spawn()
    {
        GameObject instatiated = Instantiate(myPrefab, spawnPoint.position, Quaternion.identity); ;
        instatiated.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);        

    }

}
