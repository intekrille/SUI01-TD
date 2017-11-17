using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButtonScript : MonoBehaviour
{
    EnemySpawner enemy;

    void Start()
    {
        enemy = FindObjectOfType<EnemySpawner>();
    }


    public void Nextwave()
    {
        enemy.wavecountdown = 0.3f;
    }
}
