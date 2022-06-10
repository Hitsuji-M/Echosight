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

    // Start is called before the first frame update
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
    
    public void OnPointerEnter (PointerEventData eventData)
    {
        _btnImg.color = Color.white;
        _btnTxt.color = Color.black;
    }
 
    public void OnPointerExit (PointerEventData eventData)
    {
        Debug.Log("Passage");
        _btnImg.color = Color.black;
        _btnTxt.color = Color.white;
    }

    private void ResumeGame()
    {
        _gm.UpdateUI();
    }

    private void ResetRoom()
    {
        _gm.UpdateUI();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitRoom()
    {
        _gm.SetCursorMvmt(false);
        _gm.SetTimeScale(true);
        SceneManager.LoadScene("Scenes/title_screen");
    }
}