using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//Made by Jonathan & Montaser
public class enime : MonoBehaviour
{
    Animator enemyAnim;
    private PlayerMovement playerScript;
    public float chaseRadius = 10f;
    public float obstacleCheckDistance = 1f;
    public LayerMask obstacleLayerMask;
    private Transform target;
    private bool isChasing = false;
    public float moveSpeed = 3f;
    public float attackTimer = 1.5f;
    public AudioSource playerDamage;

    [Header("Enemy Health")]
    public float enemyHealth = 1;
    public Image enemyHealthBar;
    public float enemyCurrentHealth = 1;
    public void Start()
    {
        enemyCurrentHealth = enemyHealth;
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        enemyHealthBar.fillAmount = enemyCurrentHealth;

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            isChasing = true;
            FlipSprite(target.position.x > transform.position.x);
        }
        else
        {
            isChasing = false;
            enemyAnim.SetBool("isWalking", false);
        }

        if (isChasing)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            Vector2 boxSize = new Vector2(1f, 1f); // storleken på boxen som fienden ska kolla i
            RaycastHit2D hit = Physics2D.BoxCast(transform.position, boxSize, 0f, direction, obstacleCheckDistance, obstacleLayerMask);
            if (hit.collider == null)
            {
                Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            }
            enemyAnim.SetBool("isWalking", true);
        }

        //If the health is lower or equal to 0 the enemy is destroyed (dead)
        if (enemyCurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void FlipSprite(bool shouldFlipRight)
    {
        if (shouldFlipRight)
        {
            transform.localScale = new Vector3(-3f, 3f, 1f); // Ingen ändring av skalning för att titta åt höger
        }
        else
        {
            transform.localScale = new Vector3(3f, 3f, 1f); // Ändra skalningen för att titta åt vänster
        }
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Enemy attack cooldown if the player stays in the enemy collider
            attackTimer += Time.deltaTime;
            if (attackTimer >= 1.5f)
            {
                DamageSound();
                playerScript.currentHealth = playerScript.currentHealth - 1 / 3f;
                collision.GetComponent<DamageFlash>().Flash();
                attackTimer = 0f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            enemyCurrentHealth = enemyCurrentHealth - 0.125f;
        }
    }

    //Reset cooldown when player exit enemy collider
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            attackTimer = 1.5f;
        }
    }
    
    void DamageSound()
    {
        Debug.Log("PlaySound");
        playerDamage.Play();
    }
}
