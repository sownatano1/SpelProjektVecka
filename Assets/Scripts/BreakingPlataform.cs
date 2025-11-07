using UnityEngine;
//Made by Jonathan
public class BreakingPlataform : MonoBehaviour
{
    private PlayerMovement playerScript;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
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
            Invoke("Shatter", 0.3f);
        }
    }

    void Shatter()
    {
        spriteRenderer.sprite = sprite1;
        Invoke("StartShattering", 0.3f);
    }
    

    void StartShattering()
    {
        spriteRenderer.sprite = sprite2;
        Invoke("BreakPlataform", 0.3f);
    }

    void BreakPlataform()
    {
        spriteRenderer.sprite = sprite3;
        Invoke("DestroyPlataform", 0.3f);
    }

    void DestroyPlataform()
    {
        gameObject.SetActive(false);
        Invoke("RestartPlataform", 5);
    }
    void RestartPlataform()
    {
        gameObject.SetActive(true);
    }
}
