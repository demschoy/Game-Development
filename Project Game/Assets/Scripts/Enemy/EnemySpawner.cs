using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy = null;

    private int playerID = 0;

    private float spawnRate = 3.5f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            //TODO - fix location!

            spawnRate = Random.value * 5;
            yield return new WaitForSeconds(1f / spawnRate);
            Vector3 location = Vector3.zero;
            playerID = Random.Range(0, 2);
            if (playerID == 0)
            {
                location = new Vector3(Random.Range(-9.5f, -2.5f), Random.Range(5.5f, 5f), 1);
            }
            else
            {
                location = new Vector3(Random.Range(-1f, 6f), Random.Range(5.5f, 5f), 1);
            }

            Instantiate(enemy, location, Quaternion.identity);
        }
    }
}
