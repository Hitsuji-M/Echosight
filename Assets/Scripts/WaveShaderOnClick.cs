using UnityEngine;

public class WaveShaderOnClick : MonoBehaviour
{
    public WaveShaderExpansion wave;
    private Camera _camera;

    // Update is called once per frame
    private void Awake()
    {
        _camera = Camera.main;
    }

    /// <summary>
    /// If the mouse button is pressed, get the mouse position, convert it to a ray, and if the ray hits something, set the
    /// spawn point to the hit point
    /// </summary>
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        var ray = _camera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit)) return;
        wave.Spawn = hit.point;
    }
}
