using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class CredScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _btn;
    private Image _btnImg;
    private TextMeshProUGUI _btnTxt;
    
    /// <summary>
    /// > This function gets the button, text, and image components of the pause menu button and adds a listener to the
    /// button's onClick event
    /// </summary>
    void Start()
    {
        _btn = GetComponent<Button>();
        _btnTxt = GetComponentInChildren<TextMeshProUGUI>();
        _btnImg = GetComponent<Image>();
        _btn.onClick.AddListener(BackToGame);
    }
    
    /// <summary>
    /// When the mouse pointer enters the button, change the button's image color to white and the button's text color to
    /// black
    /// </summary>
    /// <param name="eventData">This is the data that is passed to the event.</param>
    public void OnPointerEnter (PointerEventData eventData)
    {
        _btnImg.color = Color.white;
        _btnTxt.color = Color.black;
    }
    
    /// <summary>
    /// When the mouse pointer exits the button, change the button's image color to black and the button's text color to
    /// white
    /// </summary>
    /// <param name="eventData">This is the data that is passed to the event.</param>
    public void OnPointerExit (PointerEventData eventData)
    {
        _btnImg.color = Color.black;
        _btnTxt.color = Color.white;
    }
    
    /// <summary>
    /// This function loads the title screen scene
    /// </summary>
    void BackToGame()
    {
        SceneManager.LoadScene("Scenes/title_screen");
    }
}
