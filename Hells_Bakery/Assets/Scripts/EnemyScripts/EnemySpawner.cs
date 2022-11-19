using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public EnemyObject[] enemies;
    public GameObject enemy;

    [SerializeField] private float waveSize = 10f;
    [SerializeField] private int xRange = 5;
    [SerializeField] private int zRange = 5;
    [SerializeField] private float waveRate = 5f;
    private float timer;

    void Start() {
        SpawnEnemies();
        timer = Time.deltaTime;  
    }

     void Update() {
        timer += Time.deltaTime;
        if (timer >= waveRate) {
            SpawnEnemies();
            timer = Time.deltaTime;  
        }
    }

    public void SpawnEnemies() {        
        for (int i = 0; i <= waveSize; i++) {
            //Pick which enemy to spawn with varying probability
            int whichEnemy = Random.Range(0, 100);
            if(whichEnemy <= 70) {
                whichEnemy = 0;
            }
            else if(whichEnemy <= 90) {
                whichEnemy = 1;
            }
            else {
                whichEnemy = 2;
            }

            int randX;
            int randZ;
            bool extremeAxis = Random.value > 0.5;
            bool whichExtreme = Random.value > 0.5;
            if(extremeAxis) {
                if(whichExtreme) {
                    randX = xRange;
                }
                else {
                    randX = -xRange;
                }
                randZ = Random.Range(-zRange, zRange + 1);
            }
            else {
                if(whichExtreme) {
                    randZ = zRange;
                }
                else {
                    randZ = -zRange;
                }
                randX = Random.Range(-xRange, xRange + 1);
            }
            Vector3 spawnPosition = new Vector3(randX, transform.position.y, randZ);
            GameObject newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity, transform);
            newEnemy.GetComponent<EnemyBehavior>().enemyObject = enemies[whichEnemy];
        }
    }
}
