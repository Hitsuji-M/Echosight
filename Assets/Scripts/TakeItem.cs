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
        if (isGrabbed){
            if (Input.GetMouseButtonDown(0)) 
            {
                DropItem(itemInHand);
                return;
            }

            if (Input.GetMouseButtonDown(1))
            {
                ThrowItem(itemInHand);
                return;
            }

            FloatingItem(itemInHand);
        }
        else 
        {
            if (!Input.GetMouseButtonDown(0)) return;

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

    void FloatingItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.5f, hand.transform.position.z);
        item.GetComponent<cakeslice.Outline>().OnEnable();
    }

    void DropItem(GameObject item)
    {
        item.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y + 0.6f, hand.transform.position.z);
        isGrabbed = !isGrabbed;
        itemInHand = null;
    }

    void ThrowItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * 15 , ForceMode.Impulse);
        isGrabbed = !isGrabbed;
        itemInHand = null;

    }
}
