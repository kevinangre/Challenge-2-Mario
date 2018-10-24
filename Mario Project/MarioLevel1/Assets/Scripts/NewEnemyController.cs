using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemyController : MonoBehaviour {
    private Animator anim;
    public float speed;
    public LayerMask isGround;
    public Transform wallHitBox;
    private bool wallHit;
    public float wallHitHeight;
    public float wallHitWidht;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidht, wallHitHeight), 0, isGround);
        if (wallHit == true){
            speed = speed * -1;
        }
    }
    private void OnCollisionEnter(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            anim.SetBool("isDead", true);
            Debug.Log("I love Living");
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidht, wallHitHeight, 1));
    }

}

	