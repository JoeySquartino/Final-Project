using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup1 : MonoBehaviour
{
    

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
     
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Done_Player")
        {
            other.gameObject.GetComponent<Done_PlayerController>().fireRate -= 1;
            Destroy(this.gameObject);
        }
    }
}

