using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiAgent))]
public class StateMachine : MonoBehaviour
{
    //comma separated list of identifier
   public enum State
   {
        Patrol, 
        Chase,
        Search,
        Orbit,
        BerryPicking
   }
    //The AI's current state
    [SerializeField] private State _state;
    private AiAgent _aiAgent;
    private void Start()
    {
        //Grabs the first AiAgent it finds (or whatever is in the <>)
        //and stores it in the variable
        _aiAgent = GetComponent<AiAgent>();

        NextState();
    }
    private void NextState()
    {
        switch (_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Chase:
                StartCoroutine(ChaseState());
                break;
            case State.Orbit:
                StartCoroutine(OrbitState());
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
            default:
                Debug.LogWarning("State does not exist in NextState function, stopping statemachine");
                break;
        }
    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.Search();
        while (_state == State.Patrol)
        {
            _aiAgent.Patrol();
            if(_aiAgent.IsPlayerInRange())
            {
                _state = State.Chase;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }

    private IEnumerator OrbitState()
    {
        Debug.Log("Orbit: Enter");
        while (_state == State.Orbit)
        {
            _aiAgent.OrbitPlayer();
            yield return null; //wait a single frame
        }
        Debug.Log("Orbit: Exit");
        NextState();
    }
    private IEnumerator ChaseState()
    {
        Debug.Log("Chase: Enter");
        while (_state == State.Chase)
        {

            _aiAgent.ChasePlayer();
            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Chase: Exit");
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
