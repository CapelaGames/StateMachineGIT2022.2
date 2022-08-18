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
    //Cons: cannot be resized

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

    //while loop,        keeps looping until the statement is false
    //do while <-- later
    //for                loops for when you have a set ammount of times you want to loop
    //foreach <-- later


    //if the player is not in range -> then search
    public void Search()
    {
        int closestIndex = -1;
        float closestDistance = float.MaxValue;

        //   initializer        condition             iterator 
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

    public void ChasePlayer()
    {

        MoveToPoint(_player.transform.position);
    }

    public void Patrol()
    {
        Vector2 waypointPosition = _waypoints[_waypointIndex].position;
        MoveToPoint(waypointPosition);
        if(Vector2.Distance(transform.position, waypointPosition) < 0.1f)
        {
            _waypointIndex++; // increase waypointIndex by 1

            //_waypointIndex = _waypointIndex % _waypoints.Length;
        }

        if(_waypointIndex >= _waypoints.Length)
        {
            _waypointIndex = 0;
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
