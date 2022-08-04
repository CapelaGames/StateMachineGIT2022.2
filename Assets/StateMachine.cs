using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    //comma separated list of identifier
   public enum State
   {
        Patrol, 
        Chase,
        Search,
        BerryPicking
   }

    //The AI's current state
    [SerializeField] private State _state;

    private void Start()
    {
        NextState();
    }
    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
            default:
                Debug.LogWarning("State does not exsit in NextState function, stopping statemachine");
                break;
        }
    
 /*       if(_state == State.Patrol)
        {
            StartCoroutine(PatrolState());
        }
        else if(_state == State.BerryPicking)
        {
            StartCoroutine(BerryPickingState());
        }*/
        
    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        while (_state == State.Patrol)
        {
            //Our code runs here
            yield return null; //wait a single frame
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }

    private IEnumerator BerryPickingState()
    {
        Debug.Log("BerryPicking: Enter");
        while (_state == State.BerryPicking)
        {
            //Our code runs here
            yield return null; //wait a single frame
        }
        Debug.Log("BerryPicking: Exit");
        NextState();
    }
}
