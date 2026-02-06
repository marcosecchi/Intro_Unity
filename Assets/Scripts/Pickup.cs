using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Pickup : MonoBehaviour
{
    BoxCollider boxCollider;

    public Light lightRef;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        MarioController mc = other.gameObject.GetComponent<MarioController>();
        if(mc != null)
        {
            mc.jumpForce *= 10;

            if (lightRef != null)
            {
                lightRef.intensity = 10;
            }
        }
//        Destroy(gameObject);

     //   gameObject.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        MarioController mc = other.gameObject.GetComponent<MarioController>();
        if (mc != null)
        {
            mc.jumpForce /= 10;

            if (lightRef != null)
            {
                lightRef.intensity = 0;
            }
        }

    }
}
