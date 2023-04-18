using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0.0f;
    [SerializeField] bool isLooping;
    private WaveConfigSO currentWave;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        // Todo -> for ve while döngülerinde koşul, döngü başlamadan önce kontrol edilir.
        // Todo -> do while döngüsünde ise, bu kontrol her döngüden sonra gerçekleştirilir.
        // Todo -> Operasyon mantığında do while döngüsü, koşul ne olursa olsun en az bir kere çalıştırılır.
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0),
                                currentWave.GetStartingWayPoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
            }

            yield return new WaitForSeconds(timeBetweenWaves);
        } while (isLooping);
    }
}
