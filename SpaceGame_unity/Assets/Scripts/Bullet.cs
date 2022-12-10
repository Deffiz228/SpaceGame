using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 1200f;
    private int lifeTime = 1500;
    private bool IsAlive = true;
    public int damage { get; } = 65;
    [SerializeField] private GameObject explosion;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed);
        lifeCounter();
    }

    private void Update()
    {
        if (!IsAlive)
        {
            Kill();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IsAlive = false;
    }
    private async void lifeCounter()
    {
        await Task.Delay(lifeTime);
        IsAlive = false;
    }
    private void Kill()
    {

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    //private Vector2 GetMoveDirectionVector(Vector2 direction)
    //{
    //    Vector2 movePos = new Vector2(direction.x - transform.position.x, direction.y - transform.position.y);
    //    movePos.Normalize();
    //    return movePos;
    //}
}
