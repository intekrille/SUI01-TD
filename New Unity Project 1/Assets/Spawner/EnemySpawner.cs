using UnityEngine.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float spawnrate = 2f;
    float spawnrateleft = 0;
    [SerializeField]
    float wavespawnrate = 50f;
    public float wavecountdown;
    bool spawneractive = true;
    bool wavecountdownrunning = false;
    int enemyindex = 0;
    int waveindex = 0;
    public Text waveCountdownText;
    [SerializeField]
    GameObject target;
    [SerializeField]
    GameObject prefab;
    Quaternion rotation;
    Vector3 myvector;
    [SerializeField]
    int[] waves = new int[] { 3, 5, 7, 9, 11, 13, 15 };
    // Use this for initialization
    void Start()
    {
        myvector = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        wavecountdown = wavespawnrate;
    }

    // Update is called once per frame
    void Update()
    {

        if (spawneractive)
        {

            spawnrateleft -= Time.deltaTime;
            if (spawnrateleft < 0.3f)
            {

                Instantiate(prefab, myvector, rotation);

                spawnrateleft = spawnrate;
                enemyindex++;
            }
            if (enemyindex == waves[waveindex])
            {
                spawneractive = false;
                waveindex++;
                enemyindex = 0;
                wavecountdownrunning = true;
            }



        }
        if (wavecountdownrunning)
        {


            wavecountdown -= Time.deltaTime;
            waveCountdownText.text = "Call next wave: " + Mathf.Floor(wavecountdown).ToString();
            if (wavecountdown < 0.3f)
            {
                spawneractive = true;
                wavecountdown = wavespawnrate;
                wavecountdownrunning = false;
            }
        }
    }

}
