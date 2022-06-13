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
    // Pick up items on E
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
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
                if (Physics.Raycast(ray, out hit, 3.0f))
                {
                    if (hit.collider.gameObject.CompareTag("Item"))
                    {
                        isGrabbed = !isGrabbed;
                        itemInHand = hit.collider.gameObject;
                    }
                }
            }
        }

        if (isGrabbed){FloatingItem(itemInHand);}

    }
    void FloatingItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.5f, hand.transform.position.z);
    }

    void DropItem(GameObject item)
    {
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.6f, hand.transform.position.z);
    }
}
