using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    // Start is called before the first frame update
   
    public float bulletPower;
    void Start()
    { 
 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(1,0,0) * Time.deltaTime * bulletPower);
        if (transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
