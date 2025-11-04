using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] KeyCode attackKey = KeyCode.Mouse0;
    public GameObject attackPrefab;
    public Transform firePos;
    float attackTime = 0;
    float attackCooldown = 0.5f;
    public AudioSource attackAudio;
    private PlayerMovement playerMovement;
    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && attackTime <= Time.time && playerMovement.isGameOver == false)
        {
            Instantiate(attackPrefab, firePos.position, firePos.rotation);
            attackTime = Time.time + attackCooldown;
            attackAudio.Play();
        }
    }
}
