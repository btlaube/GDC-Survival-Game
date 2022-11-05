using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;

    [SerializeField] private float numObjects = 10f;
    [SerializeField] private int xRange = 5;
    [SerializeField] private int zRange = 5;
    [SerializeField] private float spawnRate = 5f;
    private float timer;

    void Start() {
        SpawnEnemies();
        timer = Time.deltaTime;  
    }

     void Update() {
        timer += Time.deltaTime;
        if (timer >= spawnRate) {
            SpawnEnemies();
            timer = Time.deltaTime;  
        }
    }

    public void SpawnEnemies() {        
        for (int i = 0; i <= numObjects; i++) {
            int rand = Random.Range(0, enemies.Length);
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
            Debug.Log(extremeAxis.ToString()  + " " + randX.ToString()  + " " + randZ.ToString());
            Vector3 spawnPosition = new Vector3(randX, transform.position.y, randZ);
            Instantiate(enemies[rand], spawnPosition, Quaternion.identity, transform);
        }
    }
}
