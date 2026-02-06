using UnityEngine;

public class MarioController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 1.0f;
    public float jumpForce = 1.0f;
    public KeyCode jumpKey = KeyCode.Space;

    public ForceMode forceMode;

    bool _isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;
        
        float hMove = Input.GetAxis("Horizontal") * speed;
        rb.AddForce(hMove, 0, 0, forceMode);

        if(Input.GetKeyDown(jumpKey) && !_isJumping)
        {
            _isJumping = true;
            rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
        }

        Debug.Log(rb.linearVelocity.y);
    }

    void OnCollisionEnter(Collision collision)
    {
        _isJumping = false;
        if(collision.gameObject.CompareTag("Distruggibile"))
        {
            Destroy(collision.gameObject);
        }
    }
}
