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

    /**
     * Set a listener to the button depending of his type attribute
     */
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

    /**
     * Change the button's color when the mouse hover it
     */
    public void OnPointerEnter (PointerEventData eventData)
    {
        _btnImg.color = Color.white;
        _btnTxt.color = Color.black;
    }
 
    /**
     * Change the button's color when the mouse exit it
     */
    public void OnPointerExit (PointerEventData eventData)
    {
        _btnImg.color = Color.black;
        _btnTxt.color = Color.white;
    }
    
    /**
     * Stops the playing music then load the scene of the tutorial
     */
    private void StartGame()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("audio_menu")) {Destroy(obj);}
        SceneManager.LoadScene("Scenes/Levels/lvl0");
    }

    /**
     * Stop the game
     */
    private void QuitGame()
    {
        Application.Quit();
    }

    /**
     * Load the controls scene
     */
    private void ShowControls()
    {
        SceneManager.LoadScene("Scenes/controls");
    }

    /**
     * Load the credits scene 
     */
    private void ShowCreds()
    {
        SceneManager.LoadScene("Scenes/creds");
    }
}
