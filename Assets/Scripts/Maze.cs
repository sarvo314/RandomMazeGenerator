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
    //[SerializeField]
    //GameObject cubePrefab;
    //[SerializeField]
    //GameObject plane;
    [SerializeField]
    [Tooltip("Scale of the cube")]
    int scale = 10;

    List<List<int>> Graph = new List<List<int>>();

    int maxWidth = 9;
    int maxHeight = 9;

    public byte[,] map;

    public Transform cubeParent;


    void Start()
    {
        MakeMaze();
    }

    public void MakeMaze()
    {
        Initialise();
        GenerateBoundary();
        DrawMap();
    }

    void Initialise()
    {
        DestroyChildren(cubeParent);
        map = new byte[maxWidth, maxHeight];
        for (int x = 0; x < maxWidth; x++)
        {
            Debug.Log("We ddo this");
            for (int z = 0; z < maxHeight; z++)
            {
                map[x, z] = 1;
            }
        }
    }
    private void DestroyChildren(Transform obj)
    {
        foreach (Transform item in obj)
        {
            Destroy(item.gameObject);
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
        for (int x = 0; x < maxHeight; x++)
            for (int z = 0; z < maxWidth; z++)
            {
                if (map[x, z] == 1)
                {
                    Debug.Log("We created a cube");
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    wall.transform.parent = cubeParent;
                }
            }
    }


}
