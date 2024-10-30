using UnityEngine;

public class Dragon : MonoBehaviour
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().TakeDamge(40);
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
