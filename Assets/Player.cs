using UnityEngine;

public class Player : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;
    public void TakeDamge(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
}
