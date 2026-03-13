using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene_ORIG");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene_ORIG");
    }
}