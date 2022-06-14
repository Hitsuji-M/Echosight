using UnityEngine;

public class TakeItem : MonoBehaviour
{
    private GameObject _itemInHand;
    private GameObject _hand;
    private bool _isGrabbed;
    private bool _canGrab;

    // Start is called before the first frame update
    void Start()
    {
        _hand = GameObject.Find("Hand");
        _isGrabbed = false;
        _canGrab = false;
    }

    // Update is called once per frame
    // Pick up items on click if nothing in hand
    // Drop item in hand on click if item in hand
    // Throw item in hand on right click if item in hand
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
            
            if (Physics.Raycast(ray, out hit, 3.0f)) {
                if (hit.collider.gameObject.CompareTag("Item")) {
                    _isGrabbed = !_isGrabbed;
                    _itemInHand = hit.collider.gameObject;
                }
            }
        }
    }

    void FloatingItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().velocity = Vector3.zero;
        item.transform.position = new Vector3(_hand.transform.position.x, _hand.transform.position.y + 0.5f, _hand.transform.position.z);
        item.GetComponent<cakeslice.Outline>().OnEnable();
    }

    void DropItem(GameObject item)
    {
        item.transform.position = new Vector3(_hand.transform.position.x, _hand.transform.position.y + 0.6f, _hand.transform.position.z);
        _isGrabbed = !_isGrabbed;
        _itemInHand = null;
    }

    void ThrowItem(GameObject item)
    {
        item.GetComponent<Rigidbody>().AddForce(Camera.main.ScreenPointToRay(Input.mousePosition).direction * 15 , ForceMode.Impulse);
        _isGrabbed = !_isGrabbed;
        _itemInHand = null;
    }

    public void SetGrabStatus(bool status)
    {
        _canGrab = status;
    }
}