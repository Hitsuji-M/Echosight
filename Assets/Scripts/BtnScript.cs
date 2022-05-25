using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BtnScript : MonoBehaviour
{
    private Button btn;
    public int btnType;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        switch (btnType)
        {
            case 0:
                btn.onClick.AddListener(StartGame);
                Debug.Log(btnType);
                break;
            case 1:
                btn.onClick.AddListener(QuitGame);
                Debug.Log(btnType);
                break;
            default:
                btn.onClick.AddListener(ShowCreds);
                Debug.Log(btnType);
                break;
        }
    }

    // Update is called once per frame
    void Update() {}

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/game");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCreds()
    {
        SceneManager.LoadScene("Scenes/creds");
    }
}
