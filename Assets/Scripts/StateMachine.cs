using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AiAgent))]
public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Patrol,
        Aware,
        Combat,
        Flee,
        Sleep,
        BerryPicking,
    }

    //The Ai's current state
    [SerializeField] private State _state;

    private AiAgent _aiAgent;//delare

    private void Start()
    {
        //Grabs the first AiAgent (or whatever is in the <>)
        // and puts it in the variable
        _aiAgent = GetComponent<AiAgent>();

        NextState();
    }

    private void NextState()
    {
        switch(_state)
        {
            case State.Patrol:
                StartCoroutine(PatrolState());
                break;
            case State.Combat:
                StartCoroutine(CombatState());
                break;
            default:
                Debug.LogWarning("_state doesnt exist withing NextState function, stopping statemachine");
                break;
        }
    }

    private IEnumerator PatrolState()
    {
        Debug.Log("Patrol: Enter");
        _aiAgent.Search();
        while(_state == State.Patrol)
        {
            _aiAgent.Patrol();
            if(_aiAgent.IsPlayerInRange())
            {
                _state = State.Combat;
            }

            yield return null; //wait a single frame
        }
        Debug.Log("Patrol: Exit");
        NextState();
    }

    private IEnumerator CombatState()
    {
        Debug.Log("Combat: Enter");
        while (_state == State.Combat)
        {
            _aiAgent.ChasePlayer();

            if (!_aiAgent.IsPlayerInRange())
            {
                _state = State.Patrol;
            }
            yield return null; //wait a single frame
        }
        Debug.Log("Combat: Exit");
        NextState();
    }
}
