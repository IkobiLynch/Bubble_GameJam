
using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour
{
    public TextMeshProUGUI waveCountText;
    int waveCount = 1;

    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;

    public int enemyCount;

    public GameObject enemy;

    bool waveIsDone = true;

    void Update()
    {
        waveCountText.text = "Wave: " + waveCount.ToString();

        if (waveIsDone == true)
        {
            StartCoroutine(waveSpawner());
        }
    }

    // IEnumerator waveSpawner()
    // {
    //     waveIsDone = false;

    //     for (int i = 0; i < enemyCount; i++)
    //     {
    //         GameObject enemyClone = Instantiate(enemy);

    //         yield return new WaitForSeconds(spawnRate);
    //     }

    //     spawnRate -= 0.1f;
    //     enemyCount += 3;
    //     waveCount += 1;

    //     yield return new WaitForSeconds(timeBetweenWaves);

    //     waveIsDone = true;
    // }


    IEnumerator waveSpawner()
{
    waveIsDone = false;

    for (int i = 0; i < enemyCount; i++)
    {
        // Generate random positions within a range
        float randomX = Random.Range(-30f, 30f); // Replace -10 and 10 with your desired range
        float randomZ = Random.Range(-30f, 30f); // Adjust as needed
        Vector3 randomPosition = new Vector3(randomX, 0, randomZ);

        // Spawn enemy at the random position
        GameObject enemyClone = Instantiate(enemy, randomPosition, Quaternion.identity);

        yield return new WaitForSeconds(spawnRate);
    }

    // Update wave variables
    spawnRate = Mathf.Max(0.2f, spawnRate - 0.1f); // Prevent spawnRate from going too low
    enemyCount += 3;
    waveCount += 1;

    yield return new WaitForSeconds(timeBetweenWaves);

    waveIsDone = true;
}
}