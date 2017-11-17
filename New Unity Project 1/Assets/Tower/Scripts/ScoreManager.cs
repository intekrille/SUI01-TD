using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int lives = 10;
    public static int money = 100;

    public Text moneyText;
    public Text livesText;

    public void LoseLife(int l = 1)
    {
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        // TODO: Send the player to a game-over screen instead!
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        // FIXME: This doesn't actually need to update the text every frame.
        //moneyText.text = "Money: $" + money.ToString();
        livesText.text = "Lives: " + lives.ToString();




    }

}