using Unity.VisualScripting;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    public AudioSource snapSound;
    public Collider2D colliderDestroy;
    private PlayerMovement playerScript;
    public Camera playerCamera;
    public GameObject pointToHere;
    public float moveSpeed = 2;
    private CameraFollower cameraScript;
    private bool moveCamera = false;
    private BossEyesAnimation bossEyesAnimation;
    private bool oneTime = true;
    void Start()
    {
        oneTime = true;
        bossEyesAnimation = GameObject.FindWithTag("Eyes").GetComponent<BossEyesAnimation>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollower>();
    }

    void FixedUpdate()
    {
        if (moveCamera == true)
        {
            playerCamera.transform.position = Vector3.MoveTowards(playerCamera.transform.position,
            pointToHere.transform.position, moveSpeed * Time.deltaTime);
        }

        if (playerCamera.transform.position == pointToHere.transform.position)
        {
            if (oneTime == true)
            {
                bossEyesAnimation.StartAnimation();
                oneTime = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            snapSound.Play();
            playerScript.isCinematic = true;
            Destroy(colliderDestroy);
            Invoke("CinematicCamera", 1);
        }
    }
    void CinematicCamera()
    {
        cameraScript.isCinematic = true;
        moveCamera = true;
    }
    public void OffCinematic()
    {
        Debug.Log("Off Cinematic");
        playerScript.isCinematic = false;
        cameraScript.isCinematic = false;
    }
}
