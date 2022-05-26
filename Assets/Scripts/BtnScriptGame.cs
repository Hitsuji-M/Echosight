//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnScriptGame : MonoBehaviour
{
    private Button _btn;
    private GameManager _gm;
    public int btnType;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
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

    private void ResumeGame()
    {
        _gm.UpdateUI();
    }

    private void ResetRoom()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void QuitRoom()
    {
        SceneManager.LoadScene("Scenes/title_screen");
    }
}