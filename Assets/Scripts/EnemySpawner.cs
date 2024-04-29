using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    private float[] arrPosX = { -2.2f, -1.1f, 0f, 1.1f, 2.2f };

    [SerializeField]
    private float SpawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartEnemyRoutine();
    }

    void StartEnemyRoutine()
    {
        StartCoroutine("EnemyRoutine");
    }

    IEnumerator EnemyRoutine()
    {
        yield return new WaitForSeconds(3f);

        float moveSpeed = 5f;
        int spawnCount = 0;

        while (true)
        {
            foreach (float posX in arrPosX)
            {
                int index = Random.Range(0, enemies.Length);
                SpawnEnemy(posX, index, moveSpeed);
            }
            spawnCount += 1;
            if (spawnCount % 10 == 0)
            {
                moveSpeed += 1f;
            }

            yield return new WaitForSeconds(SpawnInterval);
        }
    }
    void SpawnEnemy(float posX, int index, float moveSpeed)
    {
        Vector3 spawnPos = new Vector3(posX, transform.position.y, transform.position.z);
        GameObject enemyObject = Instantiate(enemies[index], spawnPos, Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>(); // Enemy 클래스 가져와서 객체로 만들기
        enemy.SetMoveSpeed(moveSpeed);

    }

}
