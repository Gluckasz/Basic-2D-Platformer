using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FrogController : MonoBehaviour
{
    private Animator anim;
    private Attack2 attack2Script;
    private Attack1 attack1Script;
    private FacePlayer facePlayerScript;
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    public float attack1Duration = 2;
    public float attackAnimDuration = 1.33f;
    private int attackCounter = 0;
    private enum MovementState { idle, running, jumping, falling, attacking, disappearing};
    // Start is called before the first frame update
    void Start()
    {
        attack1Script = GetComponent<Attack1>();
        attack2Script = GetComponent<Attack2>();
        facePlayerScript = GetComponent<FacePlayer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Attack1());
    }
    IEnumerator Attack1()
    {
        Debug.Log("Attack1 started");
        MovementState state;
        state = MovementState.attacking;
        anim.SetInteger("state", (int)state);
        yield return new WaitForSeconds(attackAnimDuration);
        state = MovementState.running;
        anim.SetInteger("state", (int)state);
        facePlayerScript.enabled = false;
        attack1Script.enabled = true;
        yield return new WaitForSeconds(attack1Duration);
        state = MovementState.idle;
        anim.SetInteger("state", (int)state);
        attack1Script.enabled = false;
        facePlayerScript.enabled = true;
        StartCoroutine(Attack2());
    }

    IEnumerator Attack2()
    {
        MovementState state;
        Debug.Log("Attack2 started");
        attack2Script.enabled = true;
        yield return new WaitUntil(() => !attack2Script.enabled);
        state = MovementState.idle;
        anim.SetInteger("state", (int)state);
        yield return new WaitForSecondsRealtime(2);
        attackCounter += 1;
        if (attackCounter < 3)
        {
            StartCoroutine(Attack1());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
