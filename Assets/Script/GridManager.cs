
using UnityEngine;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject[] orangePiecePrefabs; // Mảng chứa 4 prefab mảnh cam
    public GameObject obstaclePrefab; // Prefab chướng ngại vật
    public int obstacleCount = 4;
    public int gridSize = 4;
    public float cellSize = 1f;

    private List<OrangePiece> orangePieces = new List<OrangePiece>();
    private List<Vector2> availablePositions = new List<Vector2>();
    private List<Vector2> obstaclePositions = new List<Vector2>();
    private MovementController movementController;
    internal int height;
    internal int width;

    void Start()
    {
        movementController = gameObject.AddComponent<MovementController>();
        movementController.cellSize = cellSize;
        //movementController.gridSize = gridSize;

        GenerateGridPositions();
        PlaceObstacles(); // đặt chướng ngại
        PlaceOrangePieces();
        movementController.SetOrangePieces(orangePieces);
        //movementController.SetObstacles(obstaclePositions); // truyền vị trí chướng ngại
    }

    void GenerateGridPositions()
    {
        Vector3 squarePos = transform.position;
        float startX = squarePos.x - (gridSize * cellSize) / 2 + cellSize / 2;
        float startY = squarePos.y - (gridSize * cellSize) / 2 + cellSize / 2;

        availablePositions.Clear();
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                float posX = startX + col * cellSize;
                float posY = startY + row * cellSize;
                availablePositions.Add(new Vector2(posX, posY));
            }
        }
    }

    void PlaceObstacles()
    {
        if (obstaclePrefab == null)
        {
            Debug.LogError("Chưa gán obstaclePrefab!");
            return;
        }

        obstaclePositions.Clear();

        for (int i = 0; i < obstacleCount && availablePositions.Count > 0; i++)
        {
            int index = Random.Range(0, availablePositions.Count);
            Vector2 pos = availablePositions[index];

            Instantiate(obstaclePrefab, new Vector3(pos.x, pos.y, 0), Quaternion.identity);
            obstaclePositions.Add(pos);
            availablePositions.RemoveAt(index);
        }
    }

    void PlaceOrangePieces()
    {
        if (orangePiecePrefabs == null || orangePiecePrefabs.Length < 4)
        {
            Debug.LogError("Please assign 4 orange piece prefabs!");
            return;
        }

        orangePieces.Clear();
        for (int i = 0; i < 4; i++)
        {
            if (availablePositions.Count == 0) break;

            int randomIndex = Random.Range(0, availablePositions.Count);
            Vector2 position = availablePositions[randomIndex];

            if (orangePiecePrefabs[i] != null)
            {
                GameObject orangePiece = Instantiate(orangePiecePrefabs[i], new Vector3(position.x, position.y, 0), Quaternion.identity);
                OrangePiece pieceComponent = orangePiece.GetComponent<OrangePiece>();
                if (pieceComponent != null)
                {
                    orangePieces.Add(pieceComponent);
                }
                else
                {
                    Debug.LogError("OrangePiece component not found on prefab " + orangePiecePrefabs[i].name);
                }
                availablePositions.RemoveAt(randomIndex);
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 squarePos = transform.position;
        float startX = squarePos.x - (gridSize * cellSize) / 2;
        float startY = squarePos.y - (gridSize * cellSize) / 2;

        for (int row = 0; row <= gridSize; row++)
        {
            Gizmos.DrawLine(
                new Vector3(startX, startY + row * cellSize, 0),
                new Vector3(startX + gridSize * cellSize, startY + row * cellSize, 0)
            );
        }
        for (int col = 0; col <= gridSize; col++)
        {
            Gizmos.DrawLine(
                new Vector3(startX + col * cellSize, startY, 0),
                new Vector3(startX + col * cellSize, startY + gridSize * cellSize, 0)
            );
        }
    }

    internal bool IsValidPosition(Vector2Int targetPos)
    {
        throw new System.NotImplementedException();
    }

    internal bool IsBlocked(Vector2Int targetPos)
    {
        throw new System.NotImplementedException();
    }

    internal object GetTile(int startX, int startY)
    {
        throw new System.NotImplementedException();
    }
}
