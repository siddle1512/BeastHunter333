using TMPro;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public int HP = 500;

    public Animator animator;
    public void TakeDamge(int damageAmount)
    {
        HP -= damageAmount;
        UsernameMenu.score += damageAmount;
        if (HP <= 0)
        {
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            Debug.LogWarning("Score: " + UsernameMenu.score);
        }
        else
        {
            animator.SetTrigger("damage");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamge(50);
            Debug.Log("Enter Trigger");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
}
