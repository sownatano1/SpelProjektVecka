using UnityEngine;
//Made by Jonathan
public class BossEyesAnimation : MonoBehaviour
{
    Animator animator;
    public AudioSource screamAudio;
    public GameObject enemies1;
    public GameObject enemies2;
    //public GameObject enemies3;
    private BossTrigger bossTrigger;
    public GameObject spawn;
    public GameObject spawn2;
    void Start()
    {
        animator = GetComponent<Animator>();
        bossTrigger = FindAnyObjectByType<BossTrigger>().GetComponent<BossTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAnimation()
    {
        Invoke("WakingUp", 2);
    }
    public void WakingUp()
    {
        animator.SetBool("isWakingUp", true);
        Invoke("Scream", 5);
    }

    void Scream()
    {
        screamAudio.Play();
        SpawnEnemies();
        bossTrigger.OffCinematic();
    }

    void SpawnEnemies()
    {
        Instantiate(enemies1, spawn.transform);
        Invoke("SpawnEnemies1", 6);
    }
    void SpawnEnemies1()
    {
        Instantiate(enemies2, spawn.transform);
        Invoke("SpawnEnemies2", 6);
    }

    void SpawnEnemies2()
    {
        Instantiate(enemies1, spawn2.transform);
        Invoke("SpawnEnemies3", 6);
    }
    void SpawnEnemies3()
    {
        Instantiate(enemies2, spawn.transform);
    }
}
