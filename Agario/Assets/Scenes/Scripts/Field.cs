using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = System.Random;


public class Field : MonoBehaviour{
    public Vector2 worldSize;
    Random random;
    

    void Awake(){
        transform.localScale = worldSize;
    }

    void Start(){
        random = new Random();
    }

    int HalfWorldSize(){
        return Mathf.RoundToInt(worldSize.x / 2);
    }

    public Vector2 GetRandomSpawnPoint(){
        var halfWorldSize = HalfWorldSize();
        return new Vector2(random.Next(-halfWorldSize, halfWorldSize), random.Next(-halfWorldSize, halfWorldSize));
    }

    public Vector2[] GetWorldBoundaries(){
        Vector2 bottomLeft = new Vector2(-HalfWorldSize(), -HalfWorldSize());
        Vector2 topRight = new Vector2(HalfWorldSize(), HalfWorldSize());
        return new[]{bottomLeft, topRight};
    }
}
