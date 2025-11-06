using UnityEngine;

public class BreakingPlataform : MonoBehaviour
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
            transform.rotation = Quaternion.Euler(180, 0, 90);
            Invoke("StartShattering", 0.4f);
        }
    }

    void StartShattering()
    {
        transform.rotation = Quaternion.Euler(0, 0, 90);
        Invoke("BreakPlataform", 0.4f);
    }

    void BreakPlataform()
    {
        gameObject.SetActive(false);
        Invoke("RestartPlataform", 5);
    }
    void RestartPlataform()
    {
        gameObject.SetActive(true);
    }
}
