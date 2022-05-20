using UnityEngine;

public class Movement : MonoBehaviour{
    public Field gameField;
    [SerializeField] float moveSpeed = 10f;
    Vector2 mousePosition;
    new Rigidbody2D rigidbody2D;

    void Awake(){
        gameField = GetComponent<Field>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update(){
        MoveTowards();
    }

    bool ClampToWorldPosition(){
        var topRight = gameField.GetTopRight();
        var bottomLeft = gameField.GetBottomLeft();
        return true;
    }
    void MoveTowards(){
        if (Camera.main is not null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //TODO: Movement seems somewhat staggering
        var mouseDirection = mousePosition - (Vector2)transform.position;
        var newPosition = (Vector2) this.transform.position + mouseDirection.normalized * Time.deltaTime * moveSpeed;
        rigidbody2D.MovePosition(newPosition);
    }
}
