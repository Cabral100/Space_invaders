using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float levelInterval = 5f;
    public Display player;

    void Start()
    {
        InvokeRepeating("DescerNivel", 1f, levelInterval);
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] boss = GameObject.FindGameObjectsWithTag("naveMae");

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.y <= -4f)
            {
                SceneManager.LoadScene("LostScene");
            }
        }

        if (enemies.Length == 0 && boss.Length == 0)
        {
            SceneManager.LoadScene("WinScene");
        }

        if (player.vidas < 1)
        {
            SceneManager.LoadScene("LostScene");
        }
    }

    void DescerNivel()
    {
        Invaders[] enemies = FindObjectsOfType<Invaders>();
        foreach (Invaders enemy in enemies)
        {
            enemy.transform.position += Vector3.down * 0.5f;
        }
    }

    public void AddScore(int pontos)
    {
        player.score += pontos;
    }

    public void PerderVida()
    {
        player.vidas -= 1;
    }
}