using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public int speed = 5;
    public GameObject deathFX;

    Rigidbody2D _rigidbody;
    Collider2D collision;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            enemyDie();
        }
    }

    private void enemyDie()
    {
        Destroy(gameObject);
        Instantiate(deathFX, transform.position, Quaternion.identity);
    }


    void Update()
    {
        if (isFacingRight())
        {
            _rigidbody.velocity = new Vector2(speed, 0);
        }

        else
        {
            _rigidbody.velocity = new Vector2(-speed, 0);
        }

        if (collision.IsTouchingLayers(LayerMask.GetMask("Player")))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            AddToScore.score = 0;
        }
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall2")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(_rigidbody.velocity.x)), 4.5f);
        }
    }
}
