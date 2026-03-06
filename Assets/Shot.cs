using UnityEngine;

public class Shot : MonoBehaviour
{
    public KeyCode shot = KeyCode.Space;
    public float speed = 0f; 
    public float inicioX = 0f;
    public float inicioY = -3.39f;
    private Rigidbody2D rb2d; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void shotFunction()
    {
        rb2d.linearVelocity = new Vector2(0f, 5.0f);
    }

    void OnCollisionEnter2D (Collision2D coll){
        var pos = transform.position;

        if (coll.gameObject.tag == "topWall"){
            pos.x = inicioX;
            pos.y = inicioY;
            speed = 0f;
        }

        if (coll.gameObject.tag == "enemy"){
            Destroy(coll.gameObject); 
            pos.x = inicioX;
            pos.y = inicioY;
            speed = 0f;
        }

        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(shot)){
            shotFunction();
        }
    }
}
