using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _bull;
    [SerializeField] GameObject _gun;
    [SerializeField] GameObject rocketFireParticle;
    Rigidbody2D p_rb;
    public float speed;
    private Vector2 currentDirection;

    void Start()
    {
        p_rb = GetComponent<Rigidbody2D>();
        currentDirection = new Vector2(0, 1);
    }

    void Update()
    {
        RotateRocket();
        checkPosInRange();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            currentDirection = GetMoveDirectionVector(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            RBMove(currentDirection);
            rocketFireParticle.GetComponent<ParticleSystem>().emissionRate = 250;
        }
        else
        {
            rocketFireParticle.GetComponent<ParticleSystem>().emissionRate = 0;
        }
    }
    private void checkPosInRange()
    {
        if (transform.position.x > 100) transform.position = new Vector2(-100, transform.position.y);
        if (transform.position.x < -100) transform.position = new Vector2(100, transform.position.y);
        if (transform.position.y > 100) transform.position = new Vector2(transform.position.x, -100);
        if (transform.position.y < -100) transform.position = new Vector2(transform.position.x, 100);
    }
    private Vector2 GetMoveDirectionVector(Vector2 direction)
    {
        Vector2 movePos = new Vector2(direction.x - transform.position.x, direction.y - transform.position.y);
        movePos.Normalize();
        return movePos;
    }
    private void RotateRocket()
    {
        var direction = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - p_rb.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        p_rb.rotation = angle - 90;
    }
    private void RBMove(Vector2 direction)
    {
        p_rb.AddForce(new Vector2(direction.x * speed, direction.y * speed));
    }
    void Shoot()
    {
        Instantiate(_bull, _gun.transform.position, _gun.transform.rotation);
    }
}
