using UnityEngine;

public class MovingPlataform : MonoBehaviour
{
    public float speed = 2;
    public Transform EndPos;
    public Transform StartPos;
    void Start()
    {
        transform.position = StartPos.position;
    }

    void Update()
    {
        Vector2 start = StartPos.position;
        Vector2 end = EndPos.position;

        if (transform.position.y <= StartPos.position.y)
        {
            transform.position = Vector2.Lerp(start, end, 1);
        }

        if (transform.position.y >= EndPos.position.y)
        {
            transform.position = Vector2.Lerp(start, end, 1);
        }
    }
}
