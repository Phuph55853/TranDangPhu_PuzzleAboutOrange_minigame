using UnityEngine;

public class GridManager2 : MonoBehaviour
{
    public int width = 4;
    public int height = 4;
    public float cellSize = 1f;
    public Transform cellPrefab;

    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Instantiate(cellPrefab, new Vector3(x * cellSize, y * cellSize, 0), Quaternion.identity, transform);
            }
        }
    }
}
