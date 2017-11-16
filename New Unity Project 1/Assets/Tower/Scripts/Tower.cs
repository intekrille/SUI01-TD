using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    //TODO: Lägg till ammosystem senare.
    [SerializeField]
    public static int ammo = 11;
    [SerializeField]
    float bulletSpeed = 50f;
    [SerializeField]
    float damage = 1f;
    [SerializeField]
    float range = 10f;
    [SerializeField]
    float shootCooldown = 1f;
    float shootCooldownLeft = 0f;
    public GameObject BulletPrefab;

	// Use this for initialization
	void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        Enemy[] enemies = FindObjectsOfType<Enemy>();

        Enemy closestEnemy = null;
        float distanceToEnemy = Mathf.Infinity;

        foreach (Enemy e in enemies)
        {
            float distance = Vector3.Distance(this.transform.position, e.transform.position); //distance to goal här.
            if(closestEnemy == null || distance < distanceToEnemy)
            {
                closestEnemy = e;
                distanceToEnemy = distance;
            }
        }


        if (closestEnemy != null)
        {
            Vector3 direction = closestEnemy.transform.position - this.transform.position;
            if (direction.magnitude < range)
            {
                Quaternion towerRotation = Quaternion.LookRotation(direction);
                this.transform.rotation = Quaternion.Euler(0, towerRotation.eulerAngles.y, 0);

                shootCooldownLeft -= Time.deltaTime;
                Vector3 enemyPosition = closestEnemy.transform.position;

                if (shootCooldownLeft <= 0f)
                {
                    Shoot(closestEnemy);
                    shootCooldownLeft = shootCooldown;
                }
            }
        }
        //If enemy innanför range Shoot(enemyTarget);
		
	}

    public void Shoot(Enemy target)
    {
        //Skapa en bullet med startposition vid objektet som skapade den.
        GameObject createBullet = Instantiate(BulletPrefab, this.transform.position, this.transform.rotation);

        //Hittar komponenten med namn Bullet i objektet (bulletscriptet)
        Bullet bullet = createBullet.GetComponent<Bullet>();
        //Sätt bullets damage till tornets damage.
        bullet.damage = damage;
        //Sätt bullets target till tornets target.
        bullet.target = target.transform;
        //Sätt bullets speed till tornets bulletspeed.
        bullet.speed = bulletSpeed;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void UpgradeTower()
    {
        //if()
    }
}