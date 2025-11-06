using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 2;
    private PlayerMovement playerMovement;
    public AudioSource bossAudio;
    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (playerMovement.currentHealth == 0)
        {
            bossAudio.Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerMovement.currentHealth = playerMovement.currentHealth - playerMovement.maxHealth;
        }
    }
}
