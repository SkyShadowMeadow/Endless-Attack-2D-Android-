using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private int damage = 1;

    void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
