using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public float levelInterval = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("DescerNivel", 1f, levelInterval);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject[] boss = GameObject.FindGameObjectsWithTag("naveMae");

        foreach(GameObject enemy in enemies)
        {
            if(enemy.transform.position.y <= -4f)
            {
                SceneManager.LoadScene("LostScene");
            }
        }
        if(enemies.Length == 0 && boss.Length == 0)
        {
            SceneManager.LoadScene("WinScene");
        }
        if(player.vidas < 1)
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
}
