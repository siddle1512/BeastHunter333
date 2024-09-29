using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bow : MonoBehaviour
{
    [System.Serializable]
    public class BowSettings
    {
        [Header("Arrow Settings")] //ten
        public float arrowCount;//so luong ten;
        public GameObject arrowPrefab; //doi tuong ten
        public Transform arrowPos; //vi tri ten
        public Transform arrowEquipParent;//vi tri cha me

        //cung
        [Header("Bow String Settings")]
        public Transform bowString; // day cung
        public Transform stringInitialPos;//vi tri ban dau
        public Transform stringHandPullos;//tay keo
        public Transform stringInitialParent;//vi tri cha me

    }
    [SerializeField]
    public BowSettings bowSettings;

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

    //ham hien thi ten
    public void PickArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(true);
    }

    //ham an ten
    public void DisableArrow()
    {
        bowSettings.arrowPos.gameObject.SetActive(false);
    }
    //keo day cung
    public void PullString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringHandPullos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringHandPullos;
    }

    //tha day cung de ban
    public void ReleaseString()
    {
        bowSettings.bowString.transform.position = bowSettings.stringInitialPos.position;
        bowSettings.bowString.transform.parent = bowSettings.stringInitialParent;
    }

}
