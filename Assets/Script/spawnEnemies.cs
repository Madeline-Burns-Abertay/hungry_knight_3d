using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    int enemyCount = 0;
    [SerializeField] int MAX_ENEMY_COUNT = 500;
    [SerializeField] float spawnRadius = 50f;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        while (enemyCount < MAX_ENEMY_COUNT)
        {
            Vector3 playerPos = transform.parent.transform.position;
            Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;
            Vector3 position = new Vector3(playerPos.x + randomPoint.x, 0, playerPos.z + randomPoint.y);
            Instantiate(enemy, position, Quaternion.identity);
            enemyCount++;
        }
    }

    public void KillEnemy()
    {
        enemyCount--;
    }
}
