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

        if (
            Input.GetKeyDown(jumpKey) && // E' stato premuto il tasto jump
            Mathf.Abs(rb.linearVelocity.y) <= Mathf.Epsilon // Non sto saltando (velocità verticale pari a zero)
            )
        {
            _duration = 0;
        }
        else if (
            Input.GetKeyUp(jumpKey) && // E' stato rilasciato il tasto jump
            Mathf.Abs(rb.linearVelocity.y) <= Mathf.Epsilon // Non sto saltando (velocità verticale pari a zero)
            )
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

        
    }

}
