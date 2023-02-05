using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsyScript : MonoBehaviour
{

    private GameObject CollidedObject;                  // Reference to the GameObject that's being collided with.

    private bool RhasEquipped;                          // Track whether we've equipped anything in Right-hand
    private bool LhasEquipped;                          // Track whether we've equipped anything in Left-hand

    private Rigidbody rb;                               // Reference to rigidbody-component of the collided gameObject.

    private GameObject rEquipped;                       // Track the GameObject in our right-hand
    private GameObject lEquipped;                       // Track the GameObject in our left-hand

    private NewFPS PlayerRef;                           // Reference to Player Character Script - in order to access Public bools


    // Start is called before the first frame update
    void Start()
    {
        PlayerRef = gameObject.transform.root.GetComponentInParent<NewFPS>();               // Get Player Script NewFPS
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.E))
        {
            if(PlayerRef.REngaged == true && !RhasEquipped)
            {
                //RhasEquipped = true;
                rEquipped = CollidedObject.gameObject;
                Equip();
            }
            else if(PlayerRef.LEngaged == true && !LhasEquipped)
            {
                //LhasEquipped = true;
                lEquipped = CollidedObject.gameObject;
                Equip();
            }
            else if (PlayerRef.REngaged == true && RhasEquipped)
            {
                //RhasEquipped = false;
                UnEquip();
            }
            else if (PlayerRef.LEngaged == true && LhasEquipped)
            {
                //LhasEquipped = false;
                UnEquip();
            }
        }
    }

    void Equip()
    {
        if(CollidedObject.tag == "Utensil")
        {
            rb.isKinematic = true;
            CollidedObject.transform.parent = this.transform;

            if (PlayerRef.REngaged == true)
            {
                RhasEquipped = true;
            }
            else if(PlayerRef.LEngaged == true)
            {
                LhasEquipped = true;
            }
        }
    }

    void UnEquip()
    {
        Rigidbody rbObj;
        //rb.isKinematic = false;

        if (PlayerRef.REngaged == true)
        {
            rbObj = rEquipped.GetComponent<Rigidbody>();
            rEquipped.transform.parent = null;
            rbObj.isKinematic = false;
            RhasEquipped = false;
        }
        else if(PlayerRef.LEngaged == true)
        {
            rbObj = lEquipped.GetComponent<Rigidbody>();
            lEquipped.transform.parent = null;
            rbObj.isKinematic = false;
            LhasEquipped = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        CollidedObject = other.gameObject;
        rb = other.GetComponent<Rigidbody>();
    }

}
