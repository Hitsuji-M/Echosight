using System;
using TMPro;
using UnityEngine;

public class MsgFollowPlayer : MonoBehaviour
{
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    /**
     * Each frame, rotate the text with camera rotation and place it just in front
     */
    void Update()
    {
        Transform cmTrsf = _camera.transform;
        transform.rotation = cmTrsf.rotation;
        transform.position = cmTrsf.position + cmTrsf.forward * 0.5f;
    }

    /**
     * Change the text and align it in the center with a little font size
     */
    public void SetText(String newText, float fontSize)
    {
        TextMeshPro txtField = GetComponent<TextMeshPro>();
        txtField.text = newText;
        txtField.alignment = TextAlignmentOptions.Center;
        txtField.fontSize = fontSize;
    }
}
