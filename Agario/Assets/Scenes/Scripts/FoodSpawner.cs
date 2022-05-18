using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{
    public Field gameField;
    [SerializeField] List<GameObject> foodPool;
    [SerializeField] float spawnTimer = 5f;

    IEnumerator Start(){
        foreach (var food in foodPool){
            yield return new WaitForSeconds(spawnTimer);
            food.SetActive(true);
            food.transform.position = gameField.GetRandomSpawnPoint();
        }
    }
}
