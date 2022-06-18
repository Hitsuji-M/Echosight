using System;
using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private GameObject _itemInHand;
    private GameObject _hand;
    private Events _events;
    private bool _isGrabbed;
    private bool _canGrab;
    
    /// <summary>
    /// This function finds the hand object and sets the initial values of the _isGrabbed and _canGrab variables
    /// </summary>
    void Awake()
    {
        _hand = GameObject.Find("Hand");
        _isGrabbed = false;
        _canGrab = false;
    }

    /// <summary>
    /// It finds the GameManager object and gets the Events component from it.
    /// </summary>
    private void Start()
    {
        _events = GameObject.Find("GameManager").GetComponent<Events>();
    }
    
    /// <summary>
    /// Pick up items on click if nothing in hand
    /// Drop item in hand on click if item in hand
    /// Throw item in hand on right click if item in hand
    /// </summary>
    /// <returns>
    /// the value of the variable _isGrabbed.
    /// </returns>
    void LateUpdate()
    {
        if (!_canGrab) return;
        
        if (_isGrabbed) {
            if (Input.GetMouseButtonDown(0)) {
                DropItem(_itemInHand);
                return;
            }

            if (Input.GetMouseButtonDown(1)) {
                ThrowItem(_itemInHand);
                return;
            }
            FloatingItem(_itemInHand);
        }
        else {
            if (!Input.GetMouseButtonDown(0)) return;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit, 2.0f)) {
                if (hit.collider.gameObject.CompareTag("Item")) {
                    _isGrabbed = !_isGrabbed;
                    _itemInHand = hit.collider.gameObject;

                    if (_isGrabbed) {_events.SetTake(_isGrabbed);}
                }
            }
        }
    }

    /// <summary>
    /// The function takes in a GameObject and sets its velocity to zero, then sets its position to the position of the
    /// hand, but with a y value of 0.5f higher
    /// </summary>
    /// <param name="item">The item you want to float.</param>
    void FloatingItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.transform.position = new Vector3(_hand.transform.position.x, _hand.transform.position.y + 0.5f, _hand.transform.position.z);
        item.GetComponent<cakeslice.Outline>().OnEnable();
    }

    /// <summary>
    /// The function takes in a GameObject, sets the position of the GameObject to the position of the hand, sets the
    /// isGrabbed boolean to false, sets the itemInHand to null, and sets the drop event to true
    /// </summary>
    /// <param name="item">The item you want to drop.</param>
    void DropItem(GameObject item)
    {
        item.transform.position = new Vector3(_hand.transform.position.x, _hand.transform.position.y + 0.6f, _hand.transform.position.z);
        _isGrabbed = !_isGrabbed;
        _itemInHand = null;
        _events.SetDrop(true);
    }

    /// <summary>
    /// The function takes a GameObject as a parameter, adds a force to the object's Rigidbody component in the direction of
    /// the mouse cursor, sets the _isGrabbed boolean to false, sets the _itemInHand variable to null, and calls the
    /// SetThrow() function in the Events class
    /// </summary>
    /// <param name="item">The item you want to throw.</param>
    void ThrowItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * 15 , ForceMode.Impulse);
        _isGrabbed = !_isGrabbed;
        _itemInHand = null;
        _events.SetThrow(true);
    }

    /// <summary>
    /// This function sets the _canGrab variable to the value of the status parameter
    /// </summary>
    /// <param name="status">true or false</param>
    public void SetGrabStatus(bool status)
    {
        _canGrab = status;
    }

    /// <summary>
    /// > Returns true if the player has an item in hand, false otherwise
    /// </summary>
    /// <returns>
    /// A boolean value.
    /// </returns>
    public bool HasItemInHand()
    {
        return _itemInHand != null;
    }
}
