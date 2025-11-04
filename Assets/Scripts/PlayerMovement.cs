using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 5f;
    public float jumpForce = 20f;
    public Rigidbody2D rb;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
   
    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public bool canJump = false;

    [Header("Health")]
    public float maxHealth = 0.99f;
    public float currentHealth = 0.99f;
    public Image healthBarImage;
    public GameObject gameOverUI;
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(1f, 0f) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1f, 0f) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetKeyDown(jumpKey) && canJump)
        {
            rb.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
        }

        healthBarImage.fillAmount = currentHealth;

        //If the health is lower or equal to 0 the player die (Game Over)
        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            gameOverUI.gameObject.SetActive(true);
        }
    }

    void GameOver()
    {
        
    }
}
