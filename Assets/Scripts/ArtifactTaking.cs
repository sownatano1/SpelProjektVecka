using UnityEngine;
using UnityEngine.SceneManagement;
//Made by Jonathan
public class Artifactaking : MonoBehaviour
{
    private PlayerMovement playerScript;
    private CameraFollower cameraScript;
    public Camera cam;
    private bool moveCamera = false;
    public float moveSpeed = 2;
    public GameObject camPos;
    public GameObject playerPos;
    public GameObject playerPos2;
    public SpriteRenderer artifactSprite;
    public AudioSource victorySound;
    private CheckPoint checkPoint;
    void Start()
    {
        cam = Camera.main;   
        playerScript = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        cameraScript = GameObject.FindWithTag("MainCamera").GetComponent<CameraFollower>();
        checkPoint = GameObject.FindWithTag("CheckPointManager").GetComponent<CheckPoint>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveCamera == true)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 10, moveSpeed);
            cam.transform.position = camPos.transform.position;
            playerScript.transform.position = playerPos.transform.position;
            Invoke("StartAnimation", 1);
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

    void StartAnimation()
    {
        playerScript.VictoryAnimation();
        playerScript.transform.position = playerPos2.transform.position;
        Destroy(artifactSprite);
        Destroy(checkPoint);
        Invoke("EndScene", 0.5f);
    }

    void EndScene()
    {
        SceneManager.LoadScene("Ending");
    }
}