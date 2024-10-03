using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int enemiesPerRow = 5;
    [SerializeField] private float spacingX = 2f;
    [SerializeField] private float spacingY = 2f;
    
    public void SpawnEnemies(int amountToSpawn)
    {
        var rows = Mathf.CeilToInt((float)amountToSpawn / enemiesPerRow);
        var enemiesInLastRow = amountToSpawn % enemiesPerRow;
        if (enemiesInLastRow == 0) enemiesInLastRow = enemiesPerRow;

        for (var row = 0; row < rows; row++)
        {
            var enemiesInThisRow = row == rows - 1 ? enemiesInLastRow : enemiesPerRow;
            for (var col = 0; col < enemiesInThisRow; col++)
            {
                var spawnPosition = spawnPoint.position + new Vector3(col * spacingX, -row * spacingY, 0);
                var enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                EventManager.TriggerEnemySpawn(enemy);
            }
        }
    }
}