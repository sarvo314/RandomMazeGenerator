using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject cubePrefab;
    [SerializeField]
    GameObject plane;

    List<List<int>> Graph = new List<List<int>>();

    float maxWidth;
    float maxHeight;

    private void Awake()
    {
        maxWidth = plane.transform.localScale.x * 4;
        maxHeight = plane.transform.localScale.z * 4;
    }

    void Start()
    {
        GenerateBoundary();
    }

    void GenerateBoundary()
    {

    }

}
