using UnityEngine;

public class SpaceShipMovement : MonoBehaviour
{
    [SerializeField] private float thrustForce = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite thrustSprite;
    
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.right * thrustForce);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.rotation += rotationSpeed * Time.fixedDeltaTime;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            rb.rotation -= rotationSpeed * Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            spriteRenderer.sprite = thrustSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }
        
    }
}
