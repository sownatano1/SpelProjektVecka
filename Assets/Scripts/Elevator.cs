using UnityEngine;
//Made by Jonathan
public class Elevator : MonoBehaviour
{
    public float elevatorSpeed;
    bool start = false;
    public AudioSource elevatorSound;
    void Start()
    {
        
    }

    void Update()
    {
        if (start == true)
        {
            transform.Translate(Vector3.down * elevatorSpeed * Time.deltaTime);
        }

        if (transform.position.y == -25)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
            Invoke("GoDown", 2f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

    void GoDown()
    {
        elevatorSound.Play();
        start = true;
    }
}
