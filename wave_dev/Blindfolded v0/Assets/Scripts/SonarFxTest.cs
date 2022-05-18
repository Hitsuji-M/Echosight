using UnityEngine;
using System.Collections;

public class SonarFxTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<SonarFxSwitcher>().Toggle();
    }
}
