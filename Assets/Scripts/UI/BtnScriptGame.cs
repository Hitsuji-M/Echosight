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

    /**
     * Set a listener to the button depending of his type attribute
     */
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
     * Resume the game by updating the UI status
     */
    private void ResumeGame()
    {
        _gm.UpdateUI();
    }

    /**
     * Load the scene to reset it
     */
    private void ResetRoom()
    {
        _gm.UpdateUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /**
     * Go back to the title_screen scene
     */
    private void QuitRoom()
    {
        _gm.SetCursorMvmt(false);
        _gm.SetTimeScale(true);
        SceneManager.LoadScene("Scenes/title_screen");
    }
}