using UnityEngine;

public class SpaceShipFiring : MonoBehaviour
{
    [SerializeField] private Rigidbody2D bulletPrefab;
    [SerializeField] private float bulletVelocity;
    
    private Rigidbody2D body;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet= Instantiate(bulletPrefab, body.position, transform.rotation);
            bullet.linearVelocity = body.GetRelativeVector(Vector2.right) * bulletVelocity;
        } 
    }
}
