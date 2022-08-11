using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//private                       - Unity Cannot, other classes cannot
//public                        - Unity can, other classes can
//[SerializeField] private      - Unity can, other classes cannot
public class AiAgent : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;

    [SerializeField] private Transform[] _waypoints; //delare an array
    [SerializeField] private int _waypointIndex = 0;

    //Array
    //Pros: They are fast, and simple
    //Cons: They cannot be resized

    public bool IsPlayerInRange()
    {
        if(Vector2.Distance(transform.position, _player.transform.position) < 5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChasePlayer()
    {
        MoveToPoint(_player.transform.position);
    }


    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MoveToPoint(waypointPosition);
        if(Vector2.Distance(transform.position, waypointPosition) < 0.1f )
        {
            //_waypointIndex = (_waypointIndex+1) % _waypoints.Length;
            _waypointIndex++;
        }
        if(_waypointIndex >= _waypoints.Length)
        {
            _waypointIndex = 0;
        }
    }

    public void MoveToPoint(Vector2 point)
    {
        Vector2 directionToPlayer = point - (Vector2) transform.position;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= _speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }

    //while       <--- loops until statement is false
    //do while X
    //for         <--- 
    //foreach X

    public void Search()
    {
        //stores closest waypoint
        int closestIndex = -1;
        float closestDistance = float.MaxValue;
        //    initializer      condition                 iterator
        for (int index = 0; index < _waypoints.Length; index++)
        {
            float currentDistance = Vector2.Distance(_waypoints[index].position, transform.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestIndex = index;
            }
        }
        _waypointIndex = closestIndex;
    }
}
