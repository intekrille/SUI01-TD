using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    float waverate = 5f;
    [SerializeField]
    float spawnrate = 2f;
    float spawnrateleft = 0f;
    int enemyIndex = 10;

    public int[] waves = { 5, 10, 15, 20, 25 };

    [SerializeField]
    GameObject spawnTarget;
    [SerializeField]
    GameObject prefab;
    Quaternion rotation;
    Vector3 myvector;
    // Use this for initialization
    void Start ()
    {
        myvector = new Vector3(spawnTarget.transform.position.x, spawnTarget.transform.position.y, spawnTarget.transform.position.z);
        //spawnrateleft -= Time.deltaTime;
        //Update();
        //WaveIndex();
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnrateleft -= Time.deltaTime;

        if (spawnrateleft<0.2f)
        {

            //WaveIndex();
            Instantiate(prefab, myvector , rotation);          
            spawnrateleft = spawnrate;
        }
    }

    /*void WaveIndex()
    {
        spawnrateleft = waverate;
        if(spawnrateleft < 0.2f)
        {
            for (int i = 0; i < waves.Length; i++)
            {
                spawnrateleft = spawnrate;
                if (spawnrateleft < 0.2f)
                {
                    for (int j = 0; j < waves[i]; j++)
                    {
                        Instantiate(prefab, myvector, rotation);
                        spawnrateleft = spawnrate;
                    }
                }
            }
        }
    }*/
}
