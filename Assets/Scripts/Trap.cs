using UnityEngine;
//Made by Jonathan
public class Trap : MonoBehaviour
{
    private PlayerMovement playerScript;
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.currentHealth = playerScript.currentHealth - playerScript.maxHealth;
        }
    }
}
