using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InstnciateScript : MonoBehaviour
{
    public Transform spawnPoint;
    //public GameObject cyllinder;
    GameObject cube;
    InputManager inputManager;

    List<GameObject> cubeList = new List<GameObject>();

    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject myPrefab;

    private void Start()
    {
        cube = GameObject.Find("cubePrefab");
        inputManager = cube.GetComponent<InputManager>();

        cubeList.Add(myPrefab);
    }

    private void Update()
    {
        if(inputManager.spawnInput())
        {
            Spawn();
        }                 
    }

    private void Spawn()
    {
        GameObject instatiated = Instantiate(myPrefab, spawnPoint.position, Quaternion.identity);
        cubeList.Add(instatiated);
        instatiated.GetComponent<MeshRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);        

    }

}
