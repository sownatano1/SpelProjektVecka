using UnityEngine;

public class Healthpotion : MonoBehaviour
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
            if (playerScript.currentHealth < 1)
            {
                playerScript.currentHealth = playerScript.currentHealth + playerScript.maxHealth / 3;
            }

            Destroy(gameObject);
        }
    }
}
