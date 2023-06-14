using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDrawDistance : MonoBehaviour
{
    void Start()
    {
        Terrain.activeTerrain.detailObjectDistance = 1000;
    }
}

