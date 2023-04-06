using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack1 : MonoBehaviour
{
    public GameObject player;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private int direction = 0;
    public float speed = 10;
    public float speedIncrease = 2;
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void OnEnable()
    {
        if (player.transform.position.x > gameObject.transform.position.x)
        {
            direction = 1;
            sprite.flipX = false;
        }
        else if (player.transform.position.x < gameObject.transform.position.x)
        {
            direction = -1;
            sprite.flipX = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (direction != 0)
        {
            rb.velocity = new Vector2(speed * direction, rb.velocity.y);
            speed += Time.deltaTime * speedIncrease;
        }
    }
    void OnDisable()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);
    }
}
