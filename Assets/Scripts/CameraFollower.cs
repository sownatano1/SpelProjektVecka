using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0,0,-10);
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
