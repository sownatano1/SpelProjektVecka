using UnityEngine;

public class Artifactaking : MonoBehaviour
{
    private PlayerMovement playerScript;
    private CameraFollower cameraScript;
    public Camera camera;
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
;
        }

        if (cameraScript.transform.position == transform.position)
        {
            playerScript.isCinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerScript.isCinematic = true;
            cameraScript.isCinematic = true;
            moveCamera = true;
        }
    }
}
