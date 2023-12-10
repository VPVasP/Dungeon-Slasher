using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private Vector3 gizmosPosition;
    [SerializeField] private Vector3 gizmosCubeSize = new Vector3(5f, 5f, 5f);
    [SerializeField] private GameObject coinsPrefab;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject[] roomStuffPrefab;
    private void Start()
    {
        gizmosPosition = this.transform.position + new Vector3(0, 10, 0);
        float randomEnemies = Random.Range(1, 4);
        float randomCoins = Random.Range(5, 20);
        float randomStuff = Random.Range(2, 5);
        EnemyAndCoinsSpawner(randomEnemies, randomCoins, randomStuff);
    }
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(gizmosPosition, gizmosCubeSize);
        }

        Vector3 GetRandomPointInCube(Vector3 offset)
        {
            Vector3 cubeCenter = gizmosPosition;
            Vector3 cubeExtents = gizmosCubeSize / 2f;

            float randomX = Random.Range(cubeCenter.x - cubeExtents.x, cubeCenter.x + cubeExtents.x);
            float randomY = Random.Range(cubeCenter.y - cubeExtents.y, cubeCenter.y + cubeExtents.y);
            float randomZ = Random.Range(cubeCenter.z - cubeExtents.z, cubeCenter.z + cubeExtents.z);


            return new Vector3(randomX, randomY, randomZ) + offset;
        }
        void EnemyAndCoinsSpawner(float numberOfEnemies, float numberOfCoins, float numberOfStuff)
        {
            float enemiesClones = numberOfEnemies;
            float coinsClones = numberOfCoins;
            float randomStuffClones = numberOfStuff;

            for (int i = 0; i < enemiesClones; i++)
            {
                GameObject Enemy = enemyPrefab;

                float offsetX = Random.Range(-4f, 4f);
                float offsetY = Random.Range(-0.5f, 0.5f);
                float offsetZ = Random.Range(-4f, 7f);

                Vector3 randomSpawnPoint = GetRandomPointInCube(new Vector3(offsetX, offsetY, offsetZ));
                Instantiate(enemyPrefab, randomSpawnPoint, Quaternion.identity, transform);
            }
            for (int i = 0; i < coinsClones; i++)
            {
                GameObject Coin = coinsPrefab;

                float offsetX = Random.Range(-4f, 4f);
                float offsetY = Random.Range(-0.5f, 0.5f);
                float offsetZ = Random.Range(-4f, 7f);

                Vector3 randomSpawnPoint = GetRandomPointInCube(new Vector3(offsetX, offsetY, offsetZ));
                Instantiate(coinsPrefab, randomSpawnPoint, Quaternion.identity, transform);
            }
            for (int i = 0; i < randomStuffClones; i++)
            {
                GameObject randomStuff = roomStuffPrefab[Random.Range(0, roomStuffPrefab.Length)];

                float offsetX = Random.Range(-6f, 6f);
                float offsetY = Random.Range(-0.5f, 0.5f);
                float offsetZ = Random.Range(-7f, 10f);

                Vector3 randomSpawnPoint = GetRandomPointInCube(new Vector3(offsetX, offsetY, offsetZ));
                Instantiate(randomStuff, randomSpawnPoint, Quaternion.identity, transform);
            }


        }

    }


