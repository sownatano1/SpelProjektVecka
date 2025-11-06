using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0,0,-10);
    public bool isCinematic = false;
    void Start()
    {
        isCinematic = false;
    }

    void LateUpdate()
    {
        if (isCinematic == false)
        {
            transform.position = player.transform.position + offset;
        }
    }
}
