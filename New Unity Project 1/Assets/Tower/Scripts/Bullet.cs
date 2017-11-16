using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    public float speed = 10f;
    public float damage = 1f;
    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        while(Tower.ammo > 0)
        {
            Vector3 direction = target.position - this.transform.localPosition;
            float directionSpeed = speed * Time.deltaTime;

            if (direction.magnitude <= directionSpeed)
            {
                BulletHit();
            }
            transform.Translate(direction.normalized * directionSpeed, Space.World);
            Tower.ammo -= 1;
        }

        //while()
	}

    public void BulletHit()
    {
        target.GetComponent<Enemy>().TakeHit(damage);
        Destroy(gameObject);
    }
}