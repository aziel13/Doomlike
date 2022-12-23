using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollisionDetection : MonoBehaviour
{

    public float despawnRangexz = 30;
    public float despawnRangey = -2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x >= despawnRangexz || transform.position.z >= despawnRangexz 
                                                   || transform.position.y < despawnRangey )
        {
            Destroy(gameObject);
        }

    }
    
     
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy hit");
            
            Destroy(collision.gameObject);
        }
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }
    
}
