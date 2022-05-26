using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CredScript : MonoBehaviour
{
    private Button _btn;
    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponent<Button>();
        _btn.onClick.AddListener(BackToGame);
    }

    void BackToGame()
    {
        SceneManager.LoadScene("Scenes/title_screen");
    }
}
