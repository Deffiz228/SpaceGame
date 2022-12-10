using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    public float _timeLive;

    void Update()
    {
        transform.position += transform.up * _speed * Time.deltaTime;
        Destroy(gameObject, _timeLive);
    }
}
