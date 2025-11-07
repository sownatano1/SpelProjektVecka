using UnityEngine;

public class ArtifactCinematic : MonoBehaviour
{
    private PlayerMovement playerScript;
    private CameraFollower cameraScript;
    private bool moveCamera = false;
    public float moveSpeed = 2;
    void Start()
    {
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollower>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveCamera == true)
        {
            cameraScript.transform.position = Vector3.MoveTowards(cameraScript.transform.position,
            transform.position, moveSpeed * Time.deltaTime);
        }

        if (cameraScript.transform.position == transform.position)
        {
            playerScript.isCinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerScript.isCinematic = true;
            cameraScript.isCinematic = true;
            moveCamera = true;
        }
    }
}
