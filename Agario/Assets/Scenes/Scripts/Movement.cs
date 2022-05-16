using UnityEngine;

public class Movement : MonoBehaviour{
    [SerializeField] float moveSpeed = 0.05f;
    Vector2 mousePosition;
    new Rigidbody2D rigidbody2D;

    void Awake(){
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        if (Camera.main is not null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        //TODO: Make movement speed so the player always moves at the same speed.
        rigidbody2D.MovePosition(Vector2.Lerp(this.transform.position,mousePosition, moveSpeed));
    }
}
