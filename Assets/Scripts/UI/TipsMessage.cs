using UnityEngine;
using TMPro;

public class TipsMessage : MonoBehaviour
{
    public float messagePersistance;
    private GameObject _msg;
    private float timeLeft;
    private bool _hasMoved;
    private bool _hasTakenItem;
    private bool _hasInteracted;
    private bool _hasThrown;
    private TextMeshPro textmesh;

    void Start()
    {
        _msg = GameObject.Find("TipsMessage");
        _msg.SetActive(false);
        textmesh = _msg.GetComponent<TextMeshPro>();
        textmesh.alignment = TextAlignmentOptions.Bottom;
        textmesh.fontSize = 0.3f;        
        timeLeft = 0;
        _hasInteracted = false;
        _hasMoved = false;
        _hasTakenItem = false;
        _hasThrown = false;
    }
    
    // Update is called once per frame
    void LateUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        timeLeft -= Time.deltaTime;
        if (Physics.Raycast(ray, out hit))
        {
            try 
            {
                if (!_hasMoved)
                {
                    textmesh.color = new Color (0.5f, 0.5f, 0.5f, 1);
                    textmesh.text = "\n\n\n\n\n\n Z,Q,S,D pour se déplacer\nEspace pour sauter";
                    timeLeft = messagePersistance * 4;
                    SetStatusTrue("move");
                }

                else if (!_hasTakenItem || !_hasThrown)
                {
                    if (hit.collider.gameObject.GetComponent<cakeslice.Outline>().GetOutlineStatus() &&  
                        hit.collider.gameObject.CompareTag("Item") )
                    {
                        textmesh.color = new Color (0.5f, 0, 0, 1);
                        textmesh.text = "\n\n\n\n\n\n Clic gauche pour prendre un objet";
                        timeLeft = messagePersistance;

                        if ( GameObject.Find("Player").GetComponent<TakeItem>().HasItemInHand() && !_hasThrown)
                        {
                            textmesh.color = new Color (0.5f, 0.5f, 0, 1);
                            textmesh.text = "\n\n\n\n\n\n Clic droit pour lancer un objet";
                            timeLeft = messagePersistance;

                        }
                    }
                }

                else if (!_hasInteracted)
                {
                    if (hit.collider.gameObject.TryGetComponent( typeof(InteractWithB), out Component component) )
                    {
                        textmesh.color = new Color (0, 0.5f, 0, 1);
                        textmesh.text = "\n\n\n\n\n\n E pour interagir";
                        timeLeft = messagePersistance;                
                    }
                }
            }
            catch 
            {

            }

            if (timeLeft < 0)
            {
                _msg.SetActive(false);
            }
            else
            {
                _msg.SetActive(true);
            }
        }
        
    }

    public void SetStatusTrue(string action)
    {
        switch(action) 
        {
            case "move" :
                _hasMoved = true;
                return;

            case "take" :
                _hasTakenItem = true;
                return;

            case "interact" :
                _hasInteracted = true;
                return;

            case "throw" :
                _hasThrown = true;
                return;
        }
    }
}
