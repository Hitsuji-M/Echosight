using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipsMessage : MonoBehaviour
{

    private GameObject _msg;



    void Start()
    {
        _msg = GameObject.Find("TipsMessage");
        _msg.SetActive(false);
    }
    // Update is called once per frame
    void LateUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            try 
            {
                if ( hit.collider.gameObject.GetComponent<cakeslice.Outline>().GetOutlineStatus() &&  hit.collider.gameObject.CompareTag("Item"))
                {
                    _msg.SetActive(true);
                    _msg.GetComponent<MsgFollowPlayer>().SetText("\n \n \n Appuyez sur clic gauche pour prendre un objet");
                }
                else 
                {
                    _msg.SetActive(false);
                }
            }
            catch 
            {

            }

        }
        
    }
}
