using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;

    private CharacterController enemeyRb;

    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        enemeyRb = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized; 
        enemeyRb.Move(lookDirection * speed * Time.deltaTime);
    }
}
