using UnityEngine;

public class BossFinalTrigger : MonoBehaviour
{
    public GameObject boss;
    public GameObject spawnPosition;
    private CameraFollower cameraScript;
    private BossMovement bossMovement;
    public GameObject destination;
    public GameObject darkWall;
    public GameObject barrier;
    private bool isNull = true;
    public GameObject destroyPlataform;
    void Start()
    {
        isNull = true;  
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollower>();
    }
    
    void Update()
    {
        if (isNull == false)
        {
            if (bossMovement.transform.position.y >= destination.transform.position.y)
            {
                darkWall.SetActive(true);
                Destroy(bossMovement.gameObject);
                Destroy(destroyPlataform);
                isNull = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Instantiate(boss, spawnPosition.transform);
            bossMovement = GameObject.FindWithTag("Monster").GetComponent<BossMovement>();
            cameraScript.offset = new Vector3(0, 0, -10);
            barrier.SetActive(true);
            isNull = false;
        }
    }
}
