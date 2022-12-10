using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D p_rb;
    public float _impulse;
    [SerializeField] GameObject _bull;
    [SerializeField] GameObject _gun;

    void Impulse()
    {
        p_rb.AddForce(transform.up * _impulse);
        if (p_rb.velocity.magnitude > 10f)
        {
            p_rb.velocity = p_rb.velocity.normalized * 10;
        }
    }
    void Shoot()
    {
        Instantiate(_bull, _gun.transform.position, _gun.transform.rotation);
    }

    void Start()
    {
        p_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (transform.position.x > 100) transform.position = new Vector2(-100, transform.position.y);
        if (transform.position.x < -100) transform.position = new Vector2(100, transform.position.y);
        if (transform.position.y > 100) transform.position = new Vector2(transform.position.x, -100);
        if (transform.position.y < -100) transform.position = new Vector2(transform.position.x, 100);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0, 0, 1f));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -1f));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Impulse();
        }
    }
}
