using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamemaster : MonoBehaviour {
    [SerializeField]
    static int health = 10;
    public Text healthtext;

    void Start()
    {
        healthtext.text = health.ToString();
    }

    // Update is called once per frame
    void Update ()
    {
        healthtext.text = "Health: " + health.ToString();
        if (health <= 0)
        {
            Debug.Log("You lost!");
            Time.timeScale = 0;
        }
	}
    public void Takedamage()
    {
        health--;
        healthtext.text = "Health " + health.ToString();
    }
}
