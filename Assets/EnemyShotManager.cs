using UnityEngine;
using System.Collections.Generic;

public class EnemyShootManager : MonoBehaviour
{
    public float shootInterval = 0.5f;

    void Start()
    {
        InvokeRepeating("RandomFrontShoot", 1f, shootInterval);
    }

    void RandomFrontShoot()
    {
        Invaders[] enemies = FindObjectsOfType<Invaders>();

        if (enemies.Length == 0) return;

        Dictionary<int, Invaders> frontEnemies = new Dictionary<int, Invaders>();

        foreach (Invaders enemy in enemies)
        {
            int column = Mathf.RoundToInt(enemy.transform.position.x);

            if (!frontEnemies.ContainsKey(column))
            {
                frontEnemies[column] = enemy;
            }
            else
            {
                if (enemy.transform.position.y < frontEnemies[column].transform.position.y)
                {
                    frontEnemies[column] = enemy;
                }
            }
        }

        List<Invaders> frontList = new List<Invaders>(frontEnemies.Values);

        int randomIndex = Random.Range(0, frontList.Count);

        frontList[randomIndex].Shoot();
    }
}