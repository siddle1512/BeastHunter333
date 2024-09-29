using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable]
    public class CamSetting
    {
        public float moveSpeed = 5;
        public float mouseX_Sensivity = 5;
        public float mouseY_Sensivity = 5;
        public float minClamp = -30;
        public float maxClamp = 90;
        public float rotateSpeed = 5;
        public float zoomFileOfView = 30;
        public float originalzoomFileOfView = 60;
        public float zoomSpeed = 5;

    }
    [SerializeField]
    CamSetting camsettings;

    [System.Serializable]
    public class camInputSettings
    {
        public string mouseXAxis = "Mouse X";
        public string mouseYAxis = "Mouse Y";
        public string aimInput = "Fire2";
    }
    [SerializeField]

    camInputSettings cis;

    Camera maincam;
    Camera UICam;
    Transform center;
    Transform target;

    float camXRotate = 0;
    float camYRotate = 0;
    void Start()
    {
        maincam = Camera.main;
        center = transform.GetChild(0);
        UICam = maincam.GetComponentInChildren<Camera>();
    }

    void Update()
    {
        if (!target)
            return;

        rotateCam();
        zoomCam();
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

    void rotateCam()
    {
        camXRotate -= Input.GetAxis(cis.mouseYAxis) * camsettings.mouseY_Sensivity;
        camYRotate += Input.GetAxis(cis.mouseXAxis) * camsettings.mouseX_Sensivity;

        camXRotate = Mathf.Clamp(camXRotate, camsettings.minClamp, camsettings.maxClamp);
        camYRotate = Mathf.Repeat(camYRotate, 360);

        Vector3 rotatingAngle = new Vector3(camXRotate, camYRotate, 0);
        Quaternion rotate = Quaternion.Slerp(center.transform.localRotation, Quaternion.Euler(rotatingAngle), camsettings.rotateSpeed * Time.deltaTime);
        center.transform.localRotation = rotate;
    }

    void zoomCam()
    {
        if (Input.GetButton(cis.aimInput))
        {
            maincam.fieldOfView = Mathf.Lerp(maincam.fieldOfView, camsettings.zoomFileOfView, camsettings.zoomSpeed * Time.deltaTime);
            UICam.fieldOfView = Mathf.Lerp(maincam.fieldOfView, camsettings.zoomFileOfView, camsettings.zoomSpeed * Time.deltaTime);
        }
        else
        {
            maincam.fieldOfView = Mathf.Lerp(maincam.fieldOfView, camsettings.originalzoomFileOfView, camsettings.zoomSpeed * Time.deltaTime);
            UICam.fieldOfView = Mathf.Lerp(maincam.fieldOfView, camsettings.originalzoomFileOfView, camsettings.zoomSpeed * Time.deltaTime);
        }
    }

}
