using UnityEngine;
using UnityEngine.EventSystems;

public class enime : MonoBehaviour
{
    private bool takeDamege;
    int health = 100;
    public float chaseRadius = 10f;
    public float obstacleCheckDistance = 1f;
    public LayerMask obstacleLayerMask;
    private Transform target;
    private bool isChasing = false;
    public float moveSpeed = 3f;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
        {
            isChasing = true;
            FlipSprite(target.position.x > transform.position.x);
        }
        else
        {
            isChasing = false;
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
        }
    }
    private void FlipSprite(bool shouldFlipRight)
    {
        if (shouldFlipRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Ingen ändring av skalning för att titta åt höger
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Ändra skalningen för att titta åt vänster
        }
    }
     





    private void death()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

  
}
