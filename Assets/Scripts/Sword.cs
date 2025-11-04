using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private enime enemyScript;
    public int attackDamage = 25;
    void Start()
    {
        Invoke("StopAttack", 0.2f);

        if (GameObject.FindWithTag("Enemy") == null)
        {
            Debug.Log("No enemies detected in the scene");
        }

        if (GameObject.FindWithTag("Enemy") != null)
        {
            enemyScript = GameObject.FindWithTag("Enemy").GetComponent<enime>();
        }
    }

    void Update()
    {
       
    }

    void StopAttack()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            enemyScript.enemyHealth = enemyScript.enemyHealth - attackDamage;
        }
    }
}
