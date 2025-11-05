using UnityEngine;
using UnityEngine.UIElements;

public class CheckPointsArea : MonoBehaviour
{
    private CheckPoint checkPoint;
    private Vector3 pos;
    void Start()
    {
        pos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("New Spawn");
            GetComponent<CheckPoint>();
            CheckPoint.instance.checkpointPosition = pos;
        }
    }
}
