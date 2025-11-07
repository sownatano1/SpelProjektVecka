using Unity.VisualScripting;
using UnityEngine;
//Made by Jonathan
public class Sword : MonoBehaviour
{
    private enime enemyScript;
    public float attackDamage = 0.25f;
    private DamageFlash damageflash;
    void Start()
    {
        Invoke("StopAttack", 0.1f);
        damageflash = GetComponent<DamageFlash>();

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
            collision.GetComponent<DamageFlash>().Flash();
        }
    }
}
