using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    [SerializeField] KeyCode right = KeyCode.D;
    [SerializeField] KeyCode left = KeyCode.A;
    [SerializeField] KeyCode jumpKey = KeyCode.Space;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(right))
        {
            transform.position += new Vector3(1, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(left))
        {
            transform.position += new Vector3(-1, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKey(jumpKey))
        {
            transform.position += new Vector3(0, 1) * speed * Time.deltaTime;
        }
    }
}
