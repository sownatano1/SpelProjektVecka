using UnityEngine;

public class Artifactaking : MonoBehaviour
{
    private PlayerMovement playerScript;
    private CameraFollower cameraScript;
    public Camera cam;
    private bool moveCamera = false;
    public float moveSpeed = 2;
    public GameObject camPos;
    public GameObject playerPos;
    void Start()
    {
        cam = Camera.main;   
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollower>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveCamera == true)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 10, moveSpeed);
            cam.transform.position = camPos.transform.position;
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