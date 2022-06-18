//using System.Collections;
//using System.Collections.Generic;

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BtnScriptGame : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _btn;
    private TextMeshProUGUI _btnTxt;
    private Image _btnImg;
    private GameManager _gm;
    public int btnType;
    
    /// <summary>
    /// Add a listener to a button depending of it's type
    /// </summary>
    void Start()
    {
        _btn = GetComponent<Button>();
        _btnTxt = GetComponentInChildren<TextMeshProUGUI>();
        _btnImg = GetComponent<Image>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        switch (btnType)
        {
            case 0:
                _btn.onClick.AddListener(ResumeGame);
                break;
            case 1:
                _btn.onClick.AddListener(ResetRoom);
                break;
            default:
                _btn.onClick.AddListener(QuitRoom);
                break;
        }
    }
    
    /// <summary>
    /// When the mouse pointer enters the button, change the button's image color to white and the button's text color to
    /// black
    /// </summary>
    /// <param name="eventData">This is the data that is passed to the event.</param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        _btnImg.color = Color.white;
        _btnTxt.color = Color.black;
    }
    
    /// <summary>
    /// When the mouse pointer exits the button, change the button's image color to black and the button's text color to
    /// white
    /// </summary>
    /// <param name="eventData">This is the data that is passed to the event.</param>
    public void OnPointerExit(PointerEventData eventData)
    {
        _btnImg.color = Color.black;
        _btnTxt.color = Color.white;
    }
    
    /// <summary>
    /// This function is called when the player clicks the resume button in the pause menu
    /// </summary>
    private void ResumeGame()
    {
        _gm.UpdateUI();
    }
    
    /// <summary>
    /// ResetRoom() resets the room by reloading the current scene
    /// </summary>
    private void ResetRoom()
    {
        _gm.UpdateUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    /// <summary>
    /// This function is called when the player clicks the "Quit" button in the pause menu. It sets the cursor movement to
    /// false, sets the time scale to true, and loads the title screen scene
    /// </summary>
    private void QuitRoom()
    {
        _gm.SetCursorMvmt(false);
        _gm.SetTimeScale(true);
        SceneManager.LoadScene("Scenes/title_screen");
    }
}