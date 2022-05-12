using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour{
    Vector2 mousePosition;
    Rigidbody2D rigidbody2D;

    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
}
