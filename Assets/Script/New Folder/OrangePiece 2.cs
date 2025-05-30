//using UnityEngine;

//public class OrangePiece2 : MonoBehaviour
//{
//    private Vector2Int gridPosition;
//    private Vector3 mouseStart;
//    private Vector3 pieceStart;
//    private float dragThreshold = 0.3f;

//    public GameObject orangePrefab;

//    void Start()
//    {
//        CreateOrange(new Vector2Int(0, 0));
//        CreateOrange(new Vector2Int(0, 3));
//        CreateOrange(new Vector2Int(3, 0));
//        CreateOrange(new Vector2Int(3, 3));
//    }

//    void CreateOrange(Vector2Int position)
//    {
//        GameObject piece = Instantiate(orangePrefab);
//        piece.GetComponent<OrangePiece>().Initialize(position);
//    }



//    public void Initialize(Vector2Int position)
//    {
//        gridPosition = position;
//        transform.position = new Vector3(position.x, position.y, 0);
//    }

//    void OnMouseDown()
//    {
//        mouseStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        pieceStart = transform.position;
//    }

//    void OnMouseUp()
//    {
//        Vector3 mouseEnd = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        Vector3 delta = mouseEnd - mouseStart;

//        Vector2Int direction = Vector2Int.zero;

//        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
//            direction = delta.x > dragThreshold ? Vector2Int.right : (delta.x < -dragThreshold ? Vector2Int.left : Vector2Int.zero);
//        else
//            direction = delta.y > dragThreshold ? Vector2Int.up : (delta.y < -dragThreshold ? Vector2Int.down : Vector2Int.zero);

//        TryMove(direction);
//    }

//    void TryMove(Vector2Int direction)
//    {
//        Vector2Int newPosition = gridPosition + direction;
//        if (newPosition.x >= 0 && newPosition.x < 4 && newPosition.y >= 0 && newPosition.y < 4)
//        {
//            gridPosition = newPosition;
//            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
//        }
//    }
//}
