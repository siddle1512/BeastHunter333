using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class Movement : MonoBehaviour
{
    Animator anim;
    CharacterController cc;

    [System.Serializable]
    public class CharacterSetting
    {
        public string forward = "forward";
        public string strafe = "strafe";
        public string sprint = "sprint";
    }
    [SerializeField]

    CharacterSetting setting;


    void Start()
    {
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }

    public void CharacterMove(float strafe, float forward)
    {
        anim.SetFloat(setting.strafe, strafe);
        anim.SetFloat(setting.forward, forward);
    }

    public void CharacterSprint(bool isSprinting)
    {
        anim.SetBool(setting.sprint, isSprinting);
    }

}
