using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputSystem : MonoBehaviour
{
    Movement move;
    public bow bowScripts;

    [System.Serializable]
    public class InputSetting
    {
        public string horizontal = "Horizontal";
        public string vertical = "Vertical";
        public string sprint = "Sprint";
        public string aim = "Fire2";
        public string fire = "Fire1";
    }
    [SerializeField]

    InputSetting input;

    [Header("camera & character syncing")]
    public float lookDistace = 5;
    public float lookSpeed = 5;

    [Header("aim setting")]
    public RaycastHit hit;
    Ray ray;

    public LayerMask aimMask;

    //[Header("spine rotate settings")]
    //public Transform spine;
    //public Vector3 spineOffset;

    [Header("head settings")]
    public float lookAt = 2.8f;


    Transform maincam;
    Transform camCenter;

    void Start()
    {
        move = GetComponent<Movement>();
        camCenter = Camera.main.transform.parent;
        maincam = Camera.main.transform;
    }

    bool isAiming;
    void Update()
    {
        if (Input.GetAxis(input.horizontal) !=0 || Input.GetAxis(input.vertical) != 0)
                rotateToCamView();
        move.CharacterMove(Input.GetAxis(input.horizontal), Input.GetAxis(input.vertical));
        move.CharacterSprint(Input.GetButton(input.sprint));

        isAiming = Input.GetButton(input.aim);
        move.CharacterAim(isAiming);

        if (isAiming)
        {
            aim();
            move.CharacterPullString(Input.GetButton(input.fire));

            if (Input.GetButtonUp(input.fire))
            {
                move.CharacterFire();
            }
        }

    }

    //void LateUpdate()
    //{
    //    rotateCharacterSpine();
    //}

    void rotateToCamView()
    {
        Vector3 camCenterPos = camCenter.position;
        Vector3 lookPoint = camCenterPos + (camCenter.forward * lookDistace);
        Vector3 dir = lookPoint - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        lookRotation.x = 0;
        lookRotation.z = 0;
        Quaternion final = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * lookSpeed);
        transform.rotation = final;

    }

    void aim()
    {
        if (maincam == null)
        {
            Debug.LogError("Main Camera is not assigned.");
            return;
        }

        if (bowScripts == null)
        {
            Debug.LogError("Bow Scripts is not assigned.");
            return;
        }

        Vector3 camPos = maincam.position;
        Vector3 dir = maincam.forward;

        ray = new Ray(camPos, dir);
        if (Physics.Raycast(ray, out hit, 500f, aimMask))
        {
            bowScripts.ShowCrossHair(hit.point); // Ensure bowScripts is assigned properly
        }
        else
        {
            bowScripts.Remove(); // Ensure bowScripts is assigned properly
        }
    }



    //void rotateCharacterSpine()
    //{
    //    spine.LookAt(ray.GetPoint(50));
    //    spine.Rotate(spineOffset);
    //}
}
