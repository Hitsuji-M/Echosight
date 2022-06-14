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

    // Update is called once per frame
    void Update()
    {
        Transform cmTrsf = _camera.transform;
        transform.rotation = cmTrsf.rotation;
        transform.position = cmTrsf.position + cmTrsf.forward * 0.5f;
    }

    public void SetText(String newText)
    {
        TextMeshPro txtField = GetComponent<TextMeshPro>();
        txtField.text = newText;
        txtField.alignment = TextAlignmentOptions.Center;
        txtField.fontSize = 0.5f;
    }
}
