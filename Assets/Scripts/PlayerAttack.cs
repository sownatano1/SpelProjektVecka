using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] KeyCode attackKey = KeyCode.Mouse0;
    public GameObject attackPrefab;
    public Transform firePos;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(attackKey))
        {
            Instantiate(attackPrefab, firePos.position, firePos.rotation);
        }
    }
}
