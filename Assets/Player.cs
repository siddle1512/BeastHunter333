using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
            Task.Delay(4000);
            SceneManager.LoadScene("MenuScore");
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }
    public int GetHP()
    {
        return HP;
    }
}
