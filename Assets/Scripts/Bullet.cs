using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    public bool isUsed = false;
    void Update()
    {
        Vector2 direction = transform.up;
        Vector2 position = transform.position;
        direction = direction.normalized * _speed * Time.deltaTime;

        transform.position = position + direction;
    }

    void Start()
    {
        StartCoroutine(DestroySelf(1f));
    }

    IEnumerator DestroySelf(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GameObject.Destroy(gameObject);
    }
}
