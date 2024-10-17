using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int enemiesRemaining = 20;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(WinAfterTime(15f));
    }

    IEnumerator WinAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        WinGame();
    }

    public void LoseGame()
    {
        Debug.Log("Game Over! You lose.");
        SceneManager.LoadScene("LoseScene");
    }

    public void WinGame()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("WinScene");
    }

    public void EnemyDefeated()
    {
        enemiesRemaining--;
        if (enemiesRemaining <= 0)
        {
            WinGame();
        }
    }
}
