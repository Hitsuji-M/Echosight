using System;
using TMPro;
using UnityEngine;

public class MsgFollowPlayer : MonoBehaviour
{
    private Camera _camera;
    
    /// <summary>
    /// > The Start function is called once when the script is enabled
    /// </summary>
    void Start()
    {
        _camera = Camera.main;
    }
    
    /// <summary>
    /// Update the position and rotation of the object to match the camera's position and rotation.
    /// </summary>
    void Update()
    {
        Transform cmTrsf = _camera.transform;
        transform.rotation = cmTrsf.rotation;
        transform.position = cmTrsf.position + cmTrsf.forward * 0.5f;
    }
    
    /// <summary>
    /// This function takes in a string, a float, a color, and a text alignment option, and sets the text, font size, color,
    /// and alignment of the text mesh pro component of the game object that this script is attached to
    /// </summary>
    /// <param name="newText">The text you want to display</param>
    /// <param name="fontSize">The size of the text.</param>
    /// <param name="newColor">The color of the text.</param>
    /// <param name="newAlign"></param>
    public void SetText(String newText, float fontSize, Color newColor, TextAlignmentOptions newAlign = TextAlignmentOptions.Center)
    {
        TextMeshPro txtField = GetComponent<TextMeshPro>();
        txtField.text = newText;
        txtField.alignment = newAlign;
        txtField.fontSize = fontSize;
        txtField.color = newColor;
    }
}
