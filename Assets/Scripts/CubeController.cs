using UnityEngine;

public class CubeController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Debug.Log("Qualcosa è entrato nel trigger: " + other.gameObject); 
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Qualcosa è uscito dal trigger");

    }
}
