using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D asteroidPrefab;

    private int levelNumber;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAllAsteroidDestroyed())
        {
            GoToNextLevel
        }
    }

    private void IsAllAsteroidDestroyed()
    {
        bool 
    }
}
