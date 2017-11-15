using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    public float startHealth = 100f;
    private float health;
    public float speed = 5f;

    [Header("Unity stuff")]
    public Image healthBar;

	// Use this for initialization
	void Start () {

        health = startHealth;
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void TakeHit(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / startHealth;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyReachedTarget()
    {
        Destroy(gameObject);

    }
}
