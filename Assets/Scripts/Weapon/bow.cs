using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    [Header("crosshair setting")]
    public GameObject crosshairPrefabs;
    GameObject currentCrossHair;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ShowCrossHair(Vector3 crossHair)
    {
        if (!currentCrossHair)
            currentCrossHair = Instantiate(crosshairPrefabs) as GameObject;

        currentCrossHair.transform.position = crossHair;
        currentCrossHair.transform.LookAt(Camera.main.transform);
    }

    public void Remove ()
    {
        if (currentCrossHair)
            Destroy(currentCrossHair);
    }
}
