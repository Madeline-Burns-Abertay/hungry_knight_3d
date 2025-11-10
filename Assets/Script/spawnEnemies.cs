using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    int enemyCount = 0;
    [SerializeField] const int MAX_ENEMY_COUNT = 5000;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        while (enemyCount < MAX_ENEMY_COUNT)
        {
            Vector3 position = new Vector3(Random.Range(0, 1000), 0, Random.Range(0, 1000));
            Instantiate(enemy, position, Quaternion.identity);
            enemyCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
