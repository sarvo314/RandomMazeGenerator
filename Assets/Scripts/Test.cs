using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Map
{
    public int x;
    public int z;

    public Map(int _x, int _z)
    {
        x = _x;
        z = _z;
    }
    public Vector2 ToVector()
    {
        return new Vector2(x, z);
    }

    public static Map operator +(Map a, Map b)
        => new Map(a.x + b.x, a.z + b.z);
}

public class Test : MonoBehaviour
{
    //[SerializeField]
    //GameObject cubePrefab;
    //[SerializeField]
    //GameObject plane;
    [SerializeField]
    [Tooltip("Scale of the cube")]
    int scale = 10;

    List<List<int>> Graph = new List<List<int>>();

    float maxWidth;
    float maxHeight;

    public byte[,] map;


    void Start()
    {
        Initialise();
        GenerateBoundary();
        DrawMap();

    }
    void Initialise()
    {
        for (int x = 0; x < maxWidth; x++)
        {
            for (int z = 0; z < maxHeight; z++)
            {
                map[x, z] = 1;

            }
        }
    }

    void GenerateBoundary()
    {
        for (int x = 0; x < maxWidth; x++)
        {
            for (int z = 0; z < maxHeight; z++)
            {
                if (Random.Range(0, 100) < 50)
                    map[x, z] = 0;
            }
        }
    }
    void DrawMap()
    {
        for (int z = 0; z < maxHeight; z++)
            for (int x = 0; x < maxWidth; x++)
            {
                if (map[x, z] == 1)
                {
                    Debug.Log("We created a cube");
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                }
            }
    }


}
