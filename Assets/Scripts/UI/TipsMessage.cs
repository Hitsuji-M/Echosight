using UnityEngine;
using TMPro;

public class TipsMessage : MonoBehaviour
{
    private float messagePersistance = 2.0f;

    private GameObject _msg;
    private TakeItem _takeItem;
    private MsgFollowPlayer _follower;
    private Camera _camera;
    private GameObject rayGm;
    private cakeslice.Outline outline;

    private string _text;
    private Color _color;

    private float _timeLeft;
    private bool _hasMoved;
    private bool _hasTakenItem;
    private bool _hasInteracted;
    private bool _hasThrown;

    void Start()
    {
        _msg = GameObject.Find("TipsMessage");
        _takeItem = GameObject.Find("Player").GetComponent<TakeItem>();
        _follower = _msg.GetComponent<MsgFollowPlayer>();
        _camera = Camera.main;

        _timeLeft = 0.0f;
        _hasInteracted = false;
        _hasMoved = false;
        _hasTakenItem = false;
        _hasThrown = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 2.0f))
        {
            rayGm = hit.collider.gameObject;
            
            if (_hasMoved && (!_hasTakenItem || !_hasThrown))
            {
                outline = rayGm.GetComponent<cakeslice.Outline>();

                if (outline != null &&
                    outline.GetOutlineStatus() &&
                    rayGm.CompareTag("Item"))
                {
                    _follower.SetText(
                        "\n\n\n\n\n\n Clic gauche pour prendre un objet",
                        0.3f,
                        new Color(0.5f, 0, 0, 1),
                        TextAlignmentOptions.Bottom);
                    
                    _timeLeft = messagePersistance;
                    _hasTakenItem = true;

                    if (_takeItem.HasItemInHand() && !_hasThrown)
                    {
                        _follower.SetText(
                            "\n\n\n\n\n\n Clic droit pour lancer un objet",
                            0.3f,
                            new Color(0.5f, 0.5f, 0, 1),
                            TextAlignmentOptions.Bottom);
                        
                        _timeLeft = messagePersistance;
                        _hasThrown = true;
                    }
                }
            }
            else if (!_hasInteracted) {
                if (rayGm.name == "Btn")
                {
                    _follower.SetText(
                        "\n\n\n\n\n\n E pour interagir",
                        0.3f,
                        new Color(0, 0.5f, 0, 1),
                        TextAlignmentOptions.Bottom);
                    
                    _timeLeft = messagePersistance;
                    _hasInteracted = true;
                }
            }
        }

        if (_timeLeft <= 0) {
            _msg.SetActive(false);
        } else {
            _timeLeft -= Time.deltaTime;
            _msg.SetActive(true);
        }
    }

    public void ShowMoveTip()
    {
        _follower.SetText(
            "\n\n\n\n\n\n Z,Q,S,D pour se déplacer\nEspace pour sauter",
            0.3f,
            new Color(0.5f, 0.5f, 0.5f, 1),
            TextAlignmentOptions.Bottom);

        _timeLeft = messagePersistance * 4;
        _hasMoved = true;
    }
}
