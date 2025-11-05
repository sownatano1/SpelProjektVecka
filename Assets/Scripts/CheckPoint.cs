using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public static CheckPoint instance;
    public Vector3 checkpointPosition;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetCheckpoint(Vector3 position)
    {
        checkpointPosition = position;
    }
}