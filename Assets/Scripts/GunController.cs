using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectile;

    public Transform projectileSpawnPoint;

    private Transform camercaTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        projectileSpawnPoint = gameObject.GetComponentInChildren<Transform>();

        camercaTransform = gameObject.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void fire()
   {
       // gameObject.transform.forward();
        
        Instantiate(projectile, projectileSpawnPoint.position, projectile.transform.rotation);
    }
}
