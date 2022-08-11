using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;

    Camera _camera;
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 clickLocation = _camera.ScreenToWorldPoint(Input.mousePosition);

            Vector2 clickDirection = clickLocation - transform.position;

            //Spawn a projectile
            GameObject.Instantiate(_bulletPrefab,
                transform.position,
                Quaternion.FromToRotation(Vector2.up, clickDirection)
                );

            //Send bullet move direction
        }
    }
}
