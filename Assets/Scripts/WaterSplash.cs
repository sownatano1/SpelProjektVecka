using UnityEngine;
//Made by Jonathan
public class WaterSplash : MonoBehaviour
{
    public AudioSource splashAudio;
    public AudioSource leavingWater;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            splashAudio.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            leavingWater.Play();
        }
    }
}
