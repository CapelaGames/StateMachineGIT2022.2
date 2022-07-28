using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//private                       - Unity Cannot, other classes cannot
//public                        - Unity can, other classes can
//[SerializeField] private      - Unity can, other classes cannot
public class AiAgent : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    void Update()
    {
        //
        //                                                this.transform.position;
        Vector2 directionToPlayer = player.transform.position - transform.position;
        //If you want to know the direction from A to B
        // A ----> B
        // DirAToB = B - A;
        if (directionToPlayer.magnitude > 0.1f)
        {
            directionToPlayer.Normalize();
            directionToPlayer *= speed * Time.deltaTime;
            transform.position += (Vector3)directionToPlayer;
        }
    }
}
