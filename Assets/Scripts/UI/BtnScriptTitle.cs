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
    private GameObject _am;
    public int btnType;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btnTxt = GetComponentInChildren<TextMeshProUGUI>();
        _btnImg = GetComponent<Image>();
        _am = GameObject.Find("AudioManager");
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

    public void OnPointerEnter (PointerEventData eventData)
    {
        _btnImg.color = Color.white;
        _btnTxt.color = Color.black;
    }
 
    public void OnPointerExit (PointerEventData eventData)
    {
        _btnImg.color = Color.black;
        _btnTxt.color = Color.white;
    }
    
    private void StartGame()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("audio_menu")) {Destroy(obj);}
        SceneManager.LoadScene("Scenes/Levels/lvl0");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ShowControls()
    {
        SceneManager.LoadScene("Scenes/controls");
    }

    private void ShowCreds()
    {
        SceneManager.LoadScene("Scenes/creds");
    }
}
