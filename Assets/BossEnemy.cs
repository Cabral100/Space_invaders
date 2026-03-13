using UnityEngine;
using System.Collections;

public class BossEnemy : MonoBehaviour
{

    private SpriteRenderer sr;
    public Sprite destroyedSprite;
    public float minTime = 10f;
    public float maxTime = 15f;

    public float speed = 3f;

    public float startX = -10f;
    public float endX = 15f;
    public float posY = 4.5f;

    bool active = false;



    void Start()
    {
        StartCoroutine(SpawnBoss());
        sr = GetComponent<SpriteRenderer>();

    }

    IEnumerator SpawnBoss()
    {
        while (true)
        {
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);

            Spawn();

            while (active)
            {
                yield return null;
            }
        }
    }

    void Spawn()
    {
        transform.position = new Vector2(startX, posY);
        active = true;
    }

    void Update()
    {
        if (!active) return;

        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x >= endX)
        {
            active = false;
        }
    }

    public void DestroyNaveMae()
    {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.AddScore(50);
        StartCoroutine(DestroyAnimation());
    }

    System.Collections.IEnumerator DestroyAnimation()
    {
        sr.sprite = destroyedSprite;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
