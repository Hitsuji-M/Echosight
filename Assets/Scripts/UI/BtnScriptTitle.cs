//using System.Collections;
//using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BtnScriptTitle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button _btn;
    private TextMeshProUGUI _btnTxt;
    private Image _btnImg;
    public int btnType;
    
    /// <summary>
    /// Add a listener to a button depending of it's type
    /// </summary>
    void Start()
    {
        _btn = GetComponent<Button>();
        _btnTxt = GetComponentInChildren<TextMeshProUGUI>();
        _btnImg = GetComponent<Image>();
        switch (btnType)
        {
            case 0:
                _btn.onClick.AddListener(StartGame);
                break;
            case 1:
                _btn.onClick.AddListener(QuitGame);
                break;
            case 2:
                _btn.onClick.AddListener(ShowControls);
                break;
            default:
                _btn.onClick.AddListener(ShowCreds);
                break;
        }
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
    /// It finds all the audio objects in the menu scene and destroys them, then it checks if the toggle is on or off and
    /// saves the value to the player prefs, then it loads the first level
    /// </summary>
    private void StartGame()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("audio_menu")) {Destroy(obj);}
        
        bool playText = GameObject.Find("Pass").GetComponent<Toggle>().isOn;
        PlayerPrefs.SetInt("play_text", playText ? 1 : 0);
        
         SceneManager.LoadScene("Scenes/Levels/lvl0");
    }
    
    /// <summary>
    /// QuitGame() is a function that quits the game
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
    }
    
    /// <summary>
    /// This function loads the controls scene
    /// </summary>
    private void ShowControls()
    {
        SceneManager.LoadScene("Scenes/controls");
    }
    
    /// <summary>
    /// This function loads the scene called credits when the button is clicked
    /// </summary>
    private void ShowCreds()
    {
        SceneManager.LoadScene("Scenes/creds");
    }
}
