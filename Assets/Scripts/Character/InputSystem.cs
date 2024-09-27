using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class InputSystem : MonoBehaviour
{
    Movement move;
    [System.Serializable]
    public class InputSetting
    {
        public string horizontal = "Horizontal";
        public string vertical = "Vertical";
        public string sprint = "Sprint";
    }
    [SerializeField]

    InputSetting input;

    void Start()
    {
        move = GetComponent<Movement>();
    }

    void Update()
    {
        move.CharacterMove(Input.GetAxis(input.horizontal), Input.GetAxis(input.vertical));
        move.CharacterSprint(Input.GetButton(input.sprint));
    }
}
