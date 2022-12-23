using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    public float speed = 1;

    private CharacterController enemeyRb;

    private GameObject player;

    private float grav = 20f;
    
    public float fallSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        enemeyRb = GetComponent<CharacterController>();
        player = GameObject.Find("fpsPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        Vector3 LookPos = player.transform.position - enemeyRb.GetComponentInParent<Transform>().position;
        
        LookPos.y = 0;
        
        var rotation = Quaternion.LookRotation(LookPos);
        
        if (!enemeyRb.isGrounded )
        {
            lookDirection.y -= fallSpeed * Time.deltaTime;
        }
        
        enemeyRb.Move(lookDirection * speed * Time.deltaTime);

        enemeyRb.GetComponentInParent<Transform>().rotation = rotation;
        
    }
}
