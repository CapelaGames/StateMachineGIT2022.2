using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    [SerializeField] float shrinkPercent = 0.75f;
    [SerializeField] float smallestSize = 0.1f;

    //Unity cannot see this public variable
    [System.NonSerialized] public Bullet spiltByBullet = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet =  collision.gameObject.GetComponent<Bullet>();

        if (bullet != null)
        { //we hit a bullet
            if (bullet == spiltByBullet) return;

            transform.localScale *= shrinkPercent;
            if(transform.localScale.x < smallestSize)
            {
                Destroy(gameObject);
                return;
            }
            GameObject newGO = Instantiate(gameObject,
                transform.position,
                transform.rotation);

            spiltByBullet = bullet;
            newGO.GetComponent<Split>().spiltByBullet = bullet;
        }
    }
}
