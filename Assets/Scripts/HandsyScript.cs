using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsyScript : MonoBehaviour
{

    private GameObject CollidedObject;                  // Reference to the GameObject that's being collided with.

    private bool hasEquipped;                           // Track whether we've equipped anything at all

    private Rigidbody rb;                               // Reference to rigidbody-component of the collided gameObject.

    private GameObject rEquipped;                       // Bool to track anything equipped in Right-hand
    private GameObject lEquipped;                       // Bool to track anything equipped in Left-hand

    private NewFPS PlayerRef;                           // Reference to Player Character Script - in order to access Public bools


    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = gameObject.transform.root.GetComponentInParent<NewFPS>();               // Get Player Script NewFPS
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E) && !hasEquipped)
        {
            Equip();
        }
     else if(Input.GetKeyDown(KeyCode.E) && hasEquipped)
        {
            UnEquip();
        }
    }

    void Equip()
    {
        hasEquipped = true;
        rEquipped = CollidedObject.gameObject;
        if(CollidedObject.tag == "Knife")
        {
            rb.isKinematic = true;
            CollidedObject.transform.parent = this.transform;
        }

        Debug.Log(PlayerRef.REngaged);
    }

    void UnEquip()
    {
        hasEquipped = false;
        rb.isKinematic = false;
        rEquipped.transform.parent = null;
    }

    void OnTriggerEnter(Collider other)
    {
        CollidedObject = other.gameObject;
        rb = other.GetComponent<Rigidbody>();
        Debug.Log("OnTriggerEnter has been entered");
        Debug.Log(other.gameObject.name);

    }

}
