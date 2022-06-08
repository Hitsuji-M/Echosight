using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    GameObject itemInHand;
    GameObject hand;

    bool isGrabbed;

    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;   
        hand = GameObject.Find("Hand");

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if ( Input.GetKeyDown("e") )
        {
            if (isGrabbed)
            {
                isGrabbed = !isGrabbed;
                DropItem(itemInHand);
            }
            else 
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider != null && hit.collider.gameObject.CompareTag("Item"))
                {
                    if ( Vector3.Distance( hit.point, transform.position ) < 3 )
                    {
                        isGrabbed = !isGrabbed;
                        itemInHand = hit.collider.gameObject;
                    }

                }
            }
            //Debug.Log(itemInHand);
            
        }

        if (isGrabbed)
        {
            FloatingItem(itemInHand);
        }

    }

    float angle;
    void FloatingItem(GameObject item)
    {
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.5f, hand.transform.position.z);
    }

    void DropItem(GameObject item)
    {
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.6f, hand.transform.position.z);
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
