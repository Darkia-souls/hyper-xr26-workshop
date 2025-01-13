using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnOnBreak;

    [SerializeField] private float spawnVelocity;
    
    
    private Rigidbody2D rb;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Break();
    }

    private void Break()
    {
        foreach (GameObject prefab in spawnOnBreak)
        {
            var rotation = Quaternion.Euler(0f,0f, Random.Range(0f, 360f));
            var newObject = Instantiate(prefab, rb.position, transform.rotation);
            
            var newBody = newObject.GetComponent<Rigidbody2D>();
            if (newBody != null)
            {
                newBody.linearVelocity = Random.insideUnitCircle.normalized * spawnVelocity;
                newBody.angularVelocity = Random.Range(-360f, 360f);
            }
        }
        Destroy(gameObject);
    }
}
