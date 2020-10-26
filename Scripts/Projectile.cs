using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D _rigidbody;
    public int Speed = 5; 
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody.velocity = transform.right * Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(50);
        }
        Destroy(gameObject);
    }

}
