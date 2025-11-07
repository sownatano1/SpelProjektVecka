using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    float dirX;
    Animator anim;
    [Header("Player Movement")]
    public float speed = 8f;
    public float jumpForce = 8f;
    public Rigidbody2D rb;
    public Collider2D col;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    public bool isCinematic = false;
   
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

    [Header("Player Attack")]
    [SerializeField] KeyCode attackKey = KeyCode.Mouse0;
    public GameObject attackPrefab;
    public Transform firePos;
    float attackTime = 0;
    float attackCooldown = 0.5f;
  
    [Header("Sounds")]
    public AudioSource attackAudio;
    public AudioSource jumpAudio;
    public AudioSource damageAudio;
    //[Header("Sounds")]
    //public AudioSource walkingAudio;
    //public AudioClip[] stepsSounds;
    void Start()
    {
        isCinematic = false;
        currentHealth = maxHealth;
        restartGame.onClick.AddListener(RestartGame);
        enemyScript = GameObject.FindWithTag("Enemy").GetComponent<enime>();

        if (CheckPoint.instance != null)
        {
            transform.position = CheckPoint.instance.checkpointPosition;
        }
        
        anim = GetComponent<Animator>();
        speed = 8f; 
    }


     void Update()
     {
        canJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKey(right) && isGameOver == false)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKey(left) && isGameOver == false)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (Input.GetKeyDown(jumpKey) && canJump && isGameOver == false && isCinematic == false)
        {
            rb.AddForce(new Vector3(0f, jumpForce), ForceMode2D.Impulse);
            jumpAudio.Play();
            
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
        dirX = Input.GetAxisRaw ("Horizontal") * speed * Time.deltaTime; 
        transform.position = new Vector2 (transform.position.x + dirX, transform.position.y);
        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (isGameOver == true || isCinematic == true)
        {
            speed = 0f;
        }

        else
        {
            speed = 8f;
        }

        if (Input.GetKeyDown(attackKey) && attackTime <= Time.time && isGameOver == false && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Invoke("Attack", 0.3f);
            attackTime = Time.time + attackCooldown;
            attackAudio.Play();
            anim.SetBool("isWalking", false);
            anim.SetTrigger("hit");
        }
    }

    void Attack()
    {
        Instantiate(attackPrefab, firePos.position, firePos.rotation);
    }
    void RestartGame()
    {
        Debug.Log("Clicked");
        SceneManager.LoadScene("Main Level");
    }
    public void DamageSound()
    {
        damageAudio.Play();
    }
}
