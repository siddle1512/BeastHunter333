using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 100;

    public Animator animator;
    Transform agent;
    Transform player;
    public void TakeDamge(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
