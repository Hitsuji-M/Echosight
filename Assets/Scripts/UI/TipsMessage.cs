using System;
using UnityEngine;
using TMPro;

public class TipsMessage : MonoBehaviour
{
    private float messagePersistance = 2.0f;

    private GameObject _msg;
    private TakeItem _takeItem;
    private MsgFollowPlayer _follower;
    private Camera _camera;
    private GameObject _rayGm;
    private cakeslice.Outline _outline;

    private string _text;
    private Color _color;

    private float _timeLeft;
    private bool _hasMoved;
    private bool _hasTakenItem;
    private bool _hasInteracted;
    private bool _hasThrown;

    /// <summary>
    /// This function is called when the script is first loaded. It finds the TipsMessage object and the main camera. It
    /// also sets the initial values of the variables
    /// </summary>
    void Awake()
    {
        _msg = GameObject.Find("TipsMessage");
        _camera = Camera.main;

        _timeLeft = 0.0f;
        _hasInteracted = false;
        _hasMoved = false;
        _hasTakenItem = false;
        _hasThrown = false;
    }

    /// <summary>
    /// This function finds the TakeItem script on the player and the MsgFollowPlayer script on the message object.
    /// </summary>
    private void Start()
    {
        _takeItem = GameObject.Find("Player").GetComponent<TakeItem>();
        _follower = _msg.GetComponent<MsgFollowPlayer>();
    }
    
    /// <summary>
    /// It checks if the player has moved, if he has, it checks if he has taken an item or thrown one, if he hasn't, it
    /// checks if the object the player is looking at is an item, if it is, it displays a message telling the player how to
    /// take an item. If the player has taken an item, it checks if he has thrown one, if he hasn't, it displays a message
    /// telling the player how to throw an item
    /// </summary>
    void LateUpdate()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 2.0f))
        {
            _rayGm = hit.collider.gameObject;
            
            if (_hasMoved && (!_hasTakenItem || !_hasThrown))
            {
                _outline = _rayGm.GetComponent<cakeslice.Outline>();

                if (_outline != null &&
                    _outline.GetOutlineStatus() &&
                    _rayGm.CompareTag("Item"))
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
                if (_rayGm.name == "Btn")
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

    /// <summary>
    /// It displays a message on the screen for a certain amount of time
    /// </summary>
    /// <param name="coeff">The multiplier to the time the message will be displayed</param>
    public void ShowMoveTip(int coeff = 4)
    {
        _follower.SetText(
            "\n\n\n\n\n\n Z,Q,S,D pour se déplacer\nEspace pour sauter",
            0.3f,
            new Color(0.5f, 0.5f, 0.5f, 1),
            TextAlignmentOptions.Bottom);

        _timeLeft = messagePersistance * coeff;
        _hasMoved = true;
    }
}
