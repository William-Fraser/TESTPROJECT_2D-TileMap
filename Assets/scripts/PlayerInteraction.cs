using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject currentInterObj = null;
    public InteractionObject currentInterObjScript = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentInterObj)
        {
            if (currentInterObjScript.pickup)
            {
                currentInterObjScript.Pickup();
            }
            if (currentInterObjScript.info)
            {
                currentInterObjScript.Info();
            }
            if (currentInterObjScript.talks)
            {
                currentInterObjScript.Talks();
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("InterObject"))
        {
            currentInterObj = collision.gameObject;
            currentInterObjScript = currentInterObj.GetComponent<InteractionObject>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("InterObject"))
        {
            currentInterObj = null;
        }
    }
}
