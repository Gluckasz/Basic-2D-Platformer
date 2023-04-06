using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack2 : MonoBehaviour
{
    private Animator anim;
    public GameObject player;
    private Rigidbody2D rb;
    public float speed = -30;
    public float yDistance = 6;
    private bool attack = false;
    public float disappearAnimDuration = 0.12f;
    public float appearAnimDuration = 0.12f;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    IEnumerator Attack()
    {
        anim.SetInteger("state", 5);
        yield return new WaitForSeconds(disappearAnimDuration);
        transform.position = new Vector2(player.transform.position.x, yDistance);
        anim.SetInteger("state", 6);
        yield return new WaitForSeconds(appearAnimDuration);
        anim.SetInteger("state", 3);
        attack = true;
    }
    void OnEnable()
    {
        StartCoroutine(Attack());
    }
    void Update()
    {
        if (attack)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && attack == true)
        {
            attack = false;
            this.enabled = false;
        }
    }
}
