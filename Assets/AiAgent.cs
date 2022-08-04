using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAgent : MonoBehaviour
{
    //private, Unity and no other classes can access player
    //public, Unity and all other classes can access player
    //[SerializeField] Unity has speical access to this variable
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _waypoints;//define
    [SerializeField] private int _waypointIndex = 0;
    //Array
    //Store many values as a single variable
    //Pros: fast
    //Cons: set size

    void Update()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MoveToPoint(waypointPosition);
        if(Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointIndex++;
        }

        //MoveToPoint(_player.transform.position);
    }
    void MoveToPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2) transform.position;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
