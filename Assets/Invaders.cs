using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;

    public Sprite destroyedSprite;

    private float timer = 0.0f;
    private float waitTime = 1.0f;
    private float speed = 2.0f;

    public GameObject enemyBullet;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        var vel = rb2d.linearVelocity;
        vel.x = speed;
        rb2d.linearVelocity = vel;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            ChangeState();
            timer = 0.0f;
        }
    }

    void ChangeState()
    {
        var vel = rb2d.linearVelocity;
        vel.x *= -1;
        rb2d.linearVelocity = vel;
    }

    public void Shoot()
    {
        Instantiate(enemyBullet, transform.position + Vector3.down * 0.5f, Quaternion.identity);
    }

    public void DestroyInvader()
    {
        StartCoroutine(DestroyAnimation());
    }

    System.Collections.IEnumerator DestroyAnimation()
    {
        GetComponent<Animator>().enabled = false;
        sr.sprite = destroyedSprite;
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}