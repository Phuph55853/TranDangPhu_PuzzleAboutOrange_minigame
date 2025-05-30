//using UnityEngine;
//using System.Collections.Generic;

//public class MovementController : MonoBehaviour
//{
//    public float cellSize = 1f; // Kích thước mỗi ô
//    private List<OrangePiece> orangePieces = new List<OrangePiece>();

//    public void SetOrangePieces(List<OrangePiece> pieces)
//    {
//        orangePieces = pieces;
//    }


//    public void MoveAllPieces(Vector2 direction)
//    {
//        List<Vector2> newPositions = new List<Vector2>();
//        HashSet<Vector2> occupiedPositions = new HashSet<Vector2>();
//        bool canMove = true;

//        foreach (OrangePiece piece in orangePieces)
//        {
//            Vector2 newPos = (Vector2)piece.transform.position + direction * cellSize;

//            if (!IsValidPosition(newPos) || occupiedPositions.Contains(newPos))
//            {
//                canMove = false;
//                break;
//            }

//            occupiedPositions.Add(newPos);
//            newPositions.Add(newPos);
//        }

//        if (canMove)
//        {
//            for (int i = 0; i < orangePieces.Count; i++)
//            {
//                StartCoroutine(SmoothMove(orangePieces[i].transform, newPositions[i], 0.2f));
//            }
//        }
//    }

//    private System.Collections.IEnumerator SmoothMove(Transform obj, Vector3 targetPos, float duration)
//    {
//        Vector3 startPos = obj.position;
//        float elapsed = 0f;

//        while (elapsed < duration)
//        {
//            obj.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
//            elapsed += Time.deltaTime;
//            yield return null;
//        }

//        obj.position = targetPos; // Đảm bảo chính xác vị trí cuối
//    }

//    private HashSet<Vector2> obstaclePositions = new HashSet<Vector2>();


//    public void SetObstacles(List<Vector2> obstacles)
//    {
//        obstaclePositions = new HashSet<Vector2>(obstacles);
//    }


//    private bool IsValidPosition(Vector2 pos)
//    {
//        float gridSize = 4; // Giả định lưới 4x4
//        float minX = transform.position.x - (gridSize * cellSize) / 2;
//        float maxX = transform.position.x + (gridSize * cellSize) / 2;
//        float minY = transform.position.y - (gridSize * cellSize) / 2;
//        float maxY = transform.position.y + (gridSize * cellSize) / 2;
//        return pos.x >= minX && pos.x <= maxX && pos.y >= minY && pos.y <= maxY;
//    }
//}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementController : MonoBehaviour
{
    public float cellSize = 1f;
    private List<OrangePiece> orangePieces = new List<OrangePiece>();
    private HashSet<Vector2> obstaclePositions = new HashSet<Vector2>();

    public void SetOrangePieces(List<OrangePiece> pieces)
    {
        orangePieces = pieces;
    }

    public void SetObstacles(List<Vector2> obstacles)
    {
        obstaclePositions = new HashSet<Vector2>(obstacles);
    }

    public void MovePiece(OrangePiece piece, Vector2 direction)
    {
        Vector2 newPos = (Vector2)piece.transform.position + direction * cellSize;

        if (IsValidPosition(newPos) && !obstaclePositions.Contains(newPos))
        {
            StartCoroutine(SmoothMove(piece.transform, newPos, 0.2f));
        }
    }


    //private IEnumerator SmoothMove(Transform obj, Vector3 targetPos, float duration)
    //{
    //    Vector3 startPos = obj.position;
    //    float elapsed = 0f;

    //    while (elapsed < duration)
    //    {
    //        obj.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
    //        elapsed += Time.deltaTime;
    //        yield return null;
    //    }

    //    obj.position = targetPos;
    //}
    private IEnumerator SmoothMove(Transform obj, Vector3 targetPos, float duration, System.Action onComplete = null)
    {
        Vector3 startPos = obj.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            obj.position = Vector3.Lerp(startPos, targetPos, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPos;

        onComplete?.Invoke(); // Gọi hàm kiểm tra win
    }

    private bool IsValidPosition(Vector2 pos)
    {
        float gridSize = 4f;
        float half = (gridSize * cellSize) / 2f;
        float minX = transform.position.x - half + cellSize / 2f;
        float maxX = transform.position.x + half - cellSize / 2f;
        float minY = transform.position.y - half + cellSize / 2f;
        float maxY = transform.position.y + half - cellSize / 2f;

        return pos.x >= minX && pos.x <= maxX && pos.y >= minY && pos.y <= maxY;
    }
}


