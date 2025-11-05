using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed = 5f;
    public float jumpForce = 20f;
    public Rigidbody2D rb;
    public Collider2D col;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
   
    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.2f;
    public bool canJump = false;

    [Header("Health")]
    public float maxHealth = 1f;
    public float currentHealth = 1f;
    public Image healthBarImage;

    [Header("Game Over")]
    public GameObject gameOverUI;
    public bool isGameOver = false;
    public Button restartGame;
    private enime enemyScript;
    private CheckPoint checkPoint;

    //[Header("Sounds")]
    //public AudioSource walkingAudio;
    //public AudioClip[] stepsSounds;
    void Start()
    {
        currentHealth = maxHealth;
        restartGame.onClick.AddListener(RestartGame);
        enemyScript = GameObject.FindWithTag("Enemy").GetComponent<enime>();

        if (CheckPoint.instance != null)
        {
            transform.position = CheckPoint.instance.checkpointPosition;
        }
    }


     void Update()
     {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKey(right) && isGameOver == false)
        {
            transform.position += new Vector3(1f, 0f) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKey(left) && isGameOver == false)
        {
            transform.position += new Vector3(-1f, 0f) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetKeyDown(jumpKey) && canJump && isGameOver == false)
        {
            rb.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
        }

        //Health bar has the same filled amount of the current health
        healthBarImage.fillAmount = currentHealth;

        //If the health is lower or equal to 0 the player die (Game Over)
        if (currentHealth <= 0.01)
        {
            gameOverUI.gameObject.SetActive(true);
            isGameOver = true;
            enemyScript.moveSpeed = 0f;
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene("J Scene");
    }
}
