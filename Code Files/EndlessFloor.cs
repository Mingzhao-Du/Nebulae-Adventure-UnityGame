using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessFloor : MonoBehaviour
{
    public Transform player;
    public GameObject floorPrefab;
    public GameObject[] floors;

    public GameObject[] obstacles;
    public GameObject[] coins;
    public GameObject healthPackPrefab;
    public GameObject[] enemies;

    private float offset;
    private float scale;
    private int currentFloor = 1;
    private int totalFloors = 3;

    public float floorWidth = 15f;
    public float floorLength = 50f;

    void Start()
    {
        floors = new GameObject[totalFloors];
        scale = floorPrefab.transform.localScale.z;
        offset = 0;
    }

    void nextFloor()
    {
        offset += scale;
        Vector3 newPosition = new Vector3(0, 0, offset);

        floors[currentFloor] = Instantiate(floorPrefab, newPosition, Quaternion.identity);

        SpawnObstacles(newPosition);
        SpawnCoins(newPosition);
        SpawnHealthPack(newPosition);
        SpawnEnemies(newPosition);

        currentFloor = (currentFloor + 1) % totalFloors;
    }

    // Enemy generation quantity and distance control
    void SpawnEnemies(Vector3 floorPosition)
    {
        List<Vector3> enemyPositions = new List<Vector3>();
        int enemyCount = Random.Range(8, 10);
        float minDistance = 4f;

        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 enemyPosition = GetRandomPosition(floorPosition, enemyPositions, minDistance);
            if (enemyPosition != floorPosition)
            {
                enemyPositions.Add(enemyPosition);
                Instantiate(enemies[Random.Range(0, enemies.Length)], enemyPosition, Quaternion.identity);
            }
        }
    }

    void clearPrevious()
    {
        int lastFloor = (currentFloor + totalFloors) % totalFloors;
        if (floors[lastFloor] != null)
        {
            Destroy(floors[lastFloor], 0);
        }
    }

    // A certain number of obstacles are randomly generated near floorPosition and placed in the appropriate position
    void SpawnObstacles(Vector3 floorPosition)
    {
        List<Vector3> obstaclePositions = new List<Vector3>();

        int obstacleCount = Mathf.Min(obstacles.Length, Random.Range(15, 25));
        float minDistance = 3f;
        int maxAttempts = 25;
        int attemptCounter = 15;

        // cyclic obstacle generation   
        for (int i = 0; i < obstacleCount; i++)
        {
            if (obstacles.Length > 0 && attemptCounter < maxAttempts)
            {
                GameObject obstacle = obstacles[i];
                Vector3 obstaclePosition = GetRandomPosition(floorPosition, obstaclePositions, minDistance);
                // Avoid obstacles that overlap or are too close together
                if (obstaclePosition != floorPosition)
                {
                    obstaclePositions.Add(obstaclePosition);
                    Instantiate(obstacle, obstaclePosition, Quaternion.identity);
                }
                else
                {
                    attemptCounter++;
                }
            }
            else
            {
                break;
            }
        }
    }

    void SpawnCoins(Vector3 floorPosition)
    {
        List<Vector3> coinPositions = new List<Vector3>();  // Avoid overlap

        int coinCount = Random.Range(3, 5);  // Make the number of coins richer
        for (int i = 0; i < coinCount; i++)
        {
            if (coins.Length > 0)
            {
                int randomIndex = Random.Range(0, coins.Length);
                GameObject coin = coins[randomIndex];

                // Generate different types of coins from random numbers
                GameObject selectedCoin = SelectRandomCoin();

                // Generate random coordinates and limit them to the floor
                float randomX = Mathf.Clamp(Random.Range(-floorWidth / 2, floorWidth / 2), -floorWidth / 2, floorWidth / 2);
                float randomZ = Mathf.Clamp(Random.Range(-floorLength / 2, floorLength / 2), -floorLength / 2, floorLength / 2);

                Vector3 coinPosition = new Vector3(floorPosition.x + randomX, floorPosition.y + 1.3f, floorPosition.z + randomZ);
                coinPositions.Add(coinPosition);
                Instantiate(selectedCoin, coinPosition, Quaternion.identity);
            }
        }
    }

    // According to the income of the three coins, adjust the generation probability of the three coins
    GameObject SelectRandomCoin()
    {
        int randomChance = Random.Range(0, 100);

        if (randomChance < 60) 
        {
            return coins[0]; 
        }
        else if (randomChance < 90)
        {
            return coins[1];
        }
        else
        {
            return coins[2];
        }
    }

    // HealthPack Formation and Its Probability Adjustment
    void SpawnHealthPack(Vector3 floorPosition)
    {
        int randomChance = Random.Range(0, 100);
        // The probability is 30%
        if (randomChance < 30) 
        {
            float randomX = Mathf.Clamp(Random.Range(-floorWidth / 2, floorWidth / 2), -floorWidth / 2, floorWidth / 2);
            float randomZ = Mathf.Clamp(Random.Range(-floorLength / 2, floorLength / 2), -floorLength / 2, floorLength / 2);

            Vector3 healthPackPosition = new Vector3(floorPosition.x + randomX, floorPosition.y + 1.3f, floorPosition.z + randomZ);
            Instantiate(healthPackPrefab, healthPackPosition, Quaternion.identity);
        }
    }

    // Make sure there is a certain distance between each object to make the playing field more reasonable
    Vector3 GetRandomPosition(Vector3 floorPosition, List<Vector3> existingPositions, float minDistance)
    {
        int maxAttempts = 50;
        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            float randomX = Random.Range(-floorWidth / 2, floorWidth / 2);
            float randomZ = Random.Range(-floorLength / 2, floorLength / 2);
            Vector3 newPosition = new Vector3(floorPosition.x + randomX, 0.5f, floorPosition.z + randomZ);

            if (IsPositionValid(newPosition, existingPositions, minDistance))
            {
                return newPosition;
            }
        }
        return floorPosition;
    }

    bool IsPositionValid(Vector3 newPosition, List<Vector3> existingPositions, float minDistance)
    {
        foreach (Vector3 existingPosition in existingPositions)
        {
            if (Vector3.Distance(newPosition, existingPosition) < minDistance)
            {
                return false;
            }
        }
        return true;
    }

    void ShuffleArray(GameObject[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }

    void Update()
    {
        float threshold = offset + (scale / 2.0f) * 0.4f;
        if (player.position.z > threshold)
        {
            nextFloor();
            clearPrevious();
        }
    }
}