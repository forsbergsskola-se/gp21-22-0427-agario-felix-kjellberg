using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour{
    public Field gameField;
    [SerializeField] List<GameObject> foodPool;
    [SerializeField] float spawnTimer = 5f;



    IEnumerator Start(){
        while (true){
            foreach (var food in foodPool){
                yield return new WaitForSeconds(spawnTimer);
                Instantiate(food);
                if (!food.activeSelf){
                    food.SetActive(true);
                }
                food.transform.position = gameField.GetRandomSpawnPoint();
            }
        }
    }

    GameObject FindInactiveInPool(){
        foreach (var food in foodPool){
            if (!food.activeSelf){
                return this.gameObject;
            }
        }
        return null;
    }
}
