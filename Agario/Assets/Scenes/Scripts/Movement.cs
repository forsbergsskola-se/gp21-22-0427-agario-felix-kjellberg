using UnityEngine;

public class Movement : MonoBehaviour{
    [SerializeField] float moveSpeed = 10f;
    Vector2 mousePosition;
    new Rigidbody2D rigidbody2D;

    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Camera.main is not null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        //TODO: Movement seems somewhat staggering
        var mouseDirection = mousePosition - (Vector2)transform.position;
        rigidbody2D.MovePosition((Vector2)this.transform.position + mouseDirection.normalized * Time.deltaTime * moveSpeed);
    }
}
