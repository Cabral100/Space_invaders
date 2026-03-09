using UnityEngine;

public class Shot : MonoBehaviour
{
    public KeyCode shot = KeyCode.Space;
    private float speed = 5f;
    private Rigidbody2D rb2d; 
    public GameObject player;
    public GameObject morte;
    bool isShot = false;
    public float pontos = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void shotFunction()
    {
        rb2d.linearVelocity = new Vector2(0f, speed);
    }

    void OnCollisionEnter2D (Collision2D coll){
        var pos = transform.position;
        var posPlayer = player.transform.position;
        if (coll.gameObject.tag == "topWall"){
            isShot = false;
        }

        if (coll.gameObject.tag == "enemy"){
            pontos+= 10;
            FindObjectOfType<Display>().score += 10;
            coll.gameObject.GetComponent<Invaders>().DestroyInvader();
            isShot = false;
        }
        if (coll.gameObject.tag == "naveMae"){
            pontos+= 50;
            FindObjectOfType<Display>().score += 50;
            coll.gameObject.GetComponent<BossEnemy>().DestroyNaveMae();
            isShot = false;
        }
        if (coll.gameObject.tag == "EnemyShot"){
            pontos+= 1;
            FindObjectOfType<Display>().score += 1;
            isShot = false;
        }

        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        if (pontos > 300){
            speed = 11f;
        }
        else if (pontos > 200){
            speed = 9f;
        }
        else if (pontos > 100){
            speed = 7f;
        }
        var posPlayer = player.transform.position;
        if (!isShot)
        {
            transform.position = new Vector2(posPlayer.x, posPlayer.y + 1f);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKeyDown(shot) && !isShot)
        {
            shotFunction();
            isShot = true;
        }
    }
}
