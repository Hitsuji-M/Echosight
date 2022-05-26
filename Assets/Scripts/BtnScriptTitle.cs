//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnScriptTitle : MonoBehaviour
{
    private Button _btn;
    public int btnType;

    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        switch (btnType)
        {
            case 0:
                _btn.onClick.AddListener(StartGame);
                break;
            case 1:
                _btn.onClick.AddListener(QuitGame);
                break;
            default:
                _btn.onClick.AddListener(ShowCreds);
                break;
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Scenes/game");
    }

    private void QuitGame()
    {
        Application.Quit();
    }

    private void ShowCreds()
    {
        SceneManager.LoadScene("Scenes/creds");
    }
}
