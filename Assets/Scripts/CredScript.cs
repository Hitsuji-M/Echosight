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
    private GameObject _am;
    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btnTxt = GetComponentInChildren<TextMeshProUGUI>();
        _btnImg = GetComponent<Image>();
        _am = GameObject.Find("AudioManager");
        _btn.onClick.AddListener(BackToGame);
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

    void BackToGame()
    {
        SceneManager.LoadScene("Scenes/title_screen");
    }
}
