using Unity.VisualScripting;
using UnityEngine;
//Made by Jonathan
public class MovingPlataform : MonoBehaviour
{
    public float speed = 2;
    public Transform EndPos, StartPos;
    public bool turn = true;
    void Start()
    {
        transform.position = StartPos.position;
    }

    void FixedUpdate()
    {
        if (turn == true)
        { 
            Invoke("GoEndPos", 2);
        }

        if (turn == false)
        {
            Invoke("GoStartPos", 2);
        }

        if (transform.position.y == StartPos.position.y)
        {
            turn = true;
        }
        if (transform.position.y == EndPos.position.y)
        {
            turn = false;
        }
    }

    void GoEndPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, EndPos.position, speed * Time.deltaTime);
    }

    void GoStartPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, StartPos.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
