using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CubeText : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;
    [SerializeField]
    GameObject cube;

    private void Start()
    {

    }
    void Update()
    {
        if (!Application.isPlaying)
        {
            text.text = $"({cube.transform.position.x},{cube.transform.position.z})";
        }
    }
}
