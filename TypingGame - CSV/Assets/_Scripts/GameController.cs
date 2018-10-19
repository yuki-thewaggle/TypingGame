using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.

    private bool EnemyIsDead;


    static public string[,] QuestionList { get; set; }

    private EnemyInputController enemyInputController;

    void Awake()
    {
        QuestionList = GetComponent<LoadText>().Load();
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        var enemy = enemies[Random.Range(0, enemies.Length)];
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        enemyInputController = GetComponent<EnemyInputController>();
    }
}
