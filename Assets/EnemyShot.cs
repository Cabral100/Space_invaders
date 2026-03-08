using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            coll.gameObject.GetComponent<player>().TomarTiro();
        }

        if (coll.gameObject.CompareTag("bottomWall") || coll.gameObject.CompareTag("shot"))
        {
            Destroy(gameObject);
        }
    }
}