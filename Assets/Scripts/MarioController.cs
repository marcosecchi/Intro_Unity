using UnityEngine;

public class MarioController : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 1.0f;
    public float jumpForce = 1.0f;
    public float longPressLimit = 1.0f;
    public KeyCode jumpKey = KeyCode.Space;

    public ForceMode forceMode;

    bool _isJumping;

    float _duration = 0;

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
            _duration = 0;
        }
        else if (Input.GetKeyUp(jumpKey) && !_isJumping)
        {
            _isJumping = true;

            _duration = Mathf.Clamp(_duration, 0, longPressLimit);
            // E' uguale a
            //if (_duration > longPressLimit)
            //{
              //  _duration = longPressLimit;
            //}
            
            float jumpIntensity = _duration * jumpForce;
            rb.AddForce(0, jumpIntensity, 0, ForceMode.Impulse);
        }
        _duration += Time.deltaTime;

           Debug.Log(_duration);
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
