using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Asteroid asteroidPrefab;

    private int levelNumber;
    private float spawnVelocity;
    public int asteroidCount;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        asteroidCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsAllAsteroidDestroyed())
        {
            GoToNextLevel();
        }
    }

    private void OnGUI()
    {
        GUI.matrix = Matrix4x4.identity;
        GUILayout.Label("Level Number: " + levelNumber);
        GUILayout.Label("Asteroids: " + asteroidCount);
    }
    
    private void GoToNextLevel()
    {
        var camera = Camera.main;
        
        int asteroidsToSpawn = levelNumber + 3;
        for (int i = 0; i < asteroidsToSpawn; i++)
        {
            Vector2 position = Random.insideUnitCircle.normalized * camera.orthographicSize;
            var asteroid = Instantiate(asteroidPrefab, position, Quaternion.identity);

            asteroid.Initialize(this);
            
            var asteroidBody = asteroid.GetComponent<Rigidbody2D>();
            asteroidBody.linearVelocity = Random.insideUnitCircle.normalized * spawnVelocity;
            asteroidBody.angularVelocity = Random.Range(-860f, 860f);
        }
    }

    private bool IsAllAsteroidDestroyed()
    {
        return asteroidCount == 0;
    }

    public void OnAsteroidCreated()
    {
        asteroidCount += 1;
    }

    public void OnAsteroidDestroyed()
    {
        asteroidCount -= 1;
    }
}
