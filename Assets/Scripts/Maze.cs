using System;
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

    //public static MapLocation operator +(MapLocation a, MapLocation b)
    //   => new MapLocation(a.x + b.x, a.z + b.z);

}

public class Maze : MonoBehaviour
{
    public List<MapLocation> directions = new List<MapLocation>() {
        new MapLocation(1, 0),
        new MapLocation(0, 1),
        new MapLocation(-1, 0), new MapLocation(0, -1) };

    public List<int> nums = new List<int>() { 1, 2, 3, 4 };

    public int width = 30; //x length
    public int depth = 30; //z length
    public byte[,] map;
    public int scale = 6;
    public Vector2Int generationPoint = new Vector2Int(0, 0);

    //MapLocation a, b;
    //MapLocation a = new MapLocation(1,2);
    //MapLocation b = new MapLocation(3, 5);
    //MapLocation a + b;

    GameObject cubeParent;

    // Start is called before the first frame update
    void Start()
    {
        //MapLocation.operator();
        cubeParent = GameObject.FindGameObjectWithTag("cubeParent");
        MakeMaze();
    }

    public void MakeMaze()
    {
        DestroyChilds();
        InitialiseMap();
        Generate();
        DrawMap();
    }

    private void DestroyChilds()
    {
        foreach (Transform item in cubeParent.transform)
        {
            Destroy(item.gameObject);
        }
    }

    void InitialiseMap()
    {
        map = new byte[width, depth];
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                map[x, z] = 1;     //1 = wall  0 = corridor
            }
    }

    public virtual void Generate()
    {
    }

    public void DrawMap()
    {
        for (int z = 0; z < depth; z++)
            for (int x = 0; x < width; x++)
            {
                if (map[x, z] == 1)
                {
                    Vector3 pos = new Vector3(x * scale, 0, z * scale);
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.localScale = new Vector3(scale, scale, scale);
                    wall.transform.position = pos;
                    wall.transform.SetParent(cubeParent.transform);
                }
            }
        //yield return new WaitForSeconds(0.01f);
    }

    public int CountEmptyNeighbours(int x, int z)
    {
        int count = 0;
        //basically if we are at the edge or we are somwhere outside of the maze
        if (x <= 0 || x >= width - 1 || z <= 0 || z >= depth - 1) return 5;
        if (map[x - 1, z] == 0) count++;
        if (map[x + 1, z] == 0) count++;
        if (map[x, z + 1] == 0) count++;
        if (map[x, z - 1] == 0) count++;
        return count;
    }
}
