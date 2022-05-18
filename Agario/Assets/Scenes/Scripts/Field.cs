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
        return (int) worldSize.x / 2;
    }

    public Vector2 GetRandomSpawnPoint(){
        var halfWorldSize = HalfWorldSize();
        var randomSpawnPoint = random.Next(-halfWorldSize, halfWorldSize);
        return new Vector2(randomSpawnPoint, randomSpawnPoint);
    }
    
}
