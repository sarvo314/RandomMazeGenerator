using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MapLocation
{
    public int x;
    public int z;

    public MapLocation(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
    public Vector2 ToVector()
    {
        return new Vector2(x, z);
    }

    public static MapLocation operator +(MapLocation a, MapLocation b)
        => new MapLocation(a.x + b.x, a.z + b.z);
}

public class Maze : MonoBehaviour
{
    [SerializeField]
    GameObject cubePrefab;
    [SerializeField]
    GameObject plane;
    [SerializeField]
    [Tooltip("Scale of the cube")]
    int scale = 10;

    List<List<int>> Graph = new List<List<int>>();

    float maxWidth;
    float maxHeight;

    public byte[,] map;


    void Start()
    {
        GenerateBoundary();
    }
    void Initialise()
    {
        for (int x = 0; x < maxWidth; x++)
        {
            for (int z = 0; z < maxHeight; z++)
            {

            }
        }
    }

    void GenerateBoundary()
    {
        for (int x = 0; x < maxWidth; x++)
        {
            for (int z = 0; z < maxHeight; z++)
            {

            }
        }
    }


}
