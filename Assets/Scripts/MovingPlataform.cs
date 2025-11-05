using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    public float speed = 2;
    public Vector3 EndPos;
    public Vector3 StartPos;
    void Start()
    {
        transform.position = StartPos;
    }

    void Update()
    {
        if (transform.position == EndPos)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }

        if (transform.position == StartPos)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
    }
}
