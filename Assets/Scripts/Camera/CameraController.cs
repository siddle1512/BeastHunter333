using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CamSetting
    {
        public float moveSpeed = 5;
    }
    [SerializeField]
    CamSetting camsettings;

    Camera maincam;
    Transform center;
    Transform target;
    void Start()
    {
        maincam = Camera.main;
        center = transform.GetChild(0);
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (target)
        {
            FollowPlayer();
        }
        else
        {
            findPlayer();
        }
    }
    void FollowPlayer()
    {
        Vector3 MoveVector = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * camsettings.moveSpeed);
        transform.position = MoveVector;
    }

    void findPlayer()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}
