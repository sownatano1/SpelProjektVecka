using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] KeyCode attackKey = KeyCode.Mouse0;
    public GameObject attackPrefab;
    public Transform firePos;
    private float attackTime = 0f;
    private float attackCooldown = 0.4f;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey) && attackTime >= Time.time)
        {
            Instantiate(attackPrefab, firePos.position, firePos.rotation);
            attackTime = Time.time + attackCooldown;
        }
    }
}
