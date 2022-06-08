using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Circle : MonoBehaviour
{
    public float Radius{ get; set; }
    public float Diameter{ get; set; }

    float area;

    const float pi = 3.14f;
    

    void Awake(){
        Radius = transform.localScale.x;
        area = CalculateArea(Radius);
        Diameter = Radius * 2;
    }

    void Update(){
        if ( Input.GetButtonDown("Fire1")){
            NewSize(2f);
        }
        if (Radius != transform.localScale.x){
            transform.localScale = UpdateSize();
        }
    }

    Vector3 UpdateSize(){
        var newSize = new Vector3(Radius, Radius, 1);
        Debug.Log($"New size is {newSize}");
        return newSize;
    }

    float CalculateArea(float radius){
        area = pi * radius * radius;
        Debug.Log($"area is {this.area}");
        return this.area;
    }

    float CalculateRadius(float area){
        var radius = Mathf.Sqrt(area / pi);
        Debug.Log($"Radius is {radius}");
        return radius;
    }

    void NewSize(float otherSize){
        var otherArea = CalculateArea(otherSize);
        var newArea = this.area + otherArea;
        var newRadius = CalculateRadius(newArea);
        Radius = newRadius;
    }
}
