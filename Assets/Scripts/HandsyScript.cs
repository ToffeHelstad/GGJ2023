using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsyScript : MonoBehaviour
{

    private GameObject CollidedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E))
        {
            Equip();
        }
    }

    void Equip()
    {
        CollidedObject.transform.parent = this.transform;
    }

    void OnTriggerEnter(Collider other)
    {
        CollidedObject = other.gameObject;
        Debug.Log("OnTriggerEnter has been entered");
        Debug.Log(other.gameObject.name);

    }

}
