using UnityEngine;
using UnityEngine.UI;

public class Display : MonoBehaviour
{
    public Text hudText;

    public int score = 0;
    public int vidas = 3;

    void Update()
    {
        hudText.text = "Score: " + score + "   Lives: " + vidas;
    }
}