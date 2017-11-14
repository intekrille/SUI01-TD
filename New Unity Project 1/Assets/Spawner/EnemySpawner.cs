using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    [SerializeField]
    float spawnrate = 2f;
    float spawnrateleft = 0;
    int enemyIndex = 10;

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
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnrateleft -= Time.deltaTime;

        if (spawnrateleft<0.2f)
        {

            WaveIndex();
            //Instantiate(prefab, myvector , rotation);
            
            //spawnrateleft = spawnrate;
        }

        /*for (int i = 0; i < enemyIndex; i++)
        {
            Instantiate(prefab, myvector, rotation);

        }*/
    }

    void WaveIndex()
    {
        for (int i = 0; i < enemyIndex; i++)
        {
            Instantiate(prefab, myvector, rotation);
            spawnrateleft = spawnrate;
            /*for (int i = 0; i < length; i++)
            {

            }*/
        }
    }

}
