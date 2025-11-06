using UnityEngine;

public class BreakingPlank : MonoBehaviour
{
    private PlayerMovement playerScript;
    public GameObject breakParticle;
    public AudioSource breakingSound;
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
            Invoke("Break", 0.4f);
        }
    }

    void Break()
    {
        breakingSound.Play();
        Instantiate(breakParticle);
        Destroy(gameObject);
    }
}
