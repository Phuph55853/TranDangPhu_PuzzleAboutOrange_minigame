using UnityEngine;

public class PieceManager : MonoBehaviour
{
    public static PieceManager Instance;
    public GameObject piecePrefab;
    public Transform[] piecePositions; // V? trí ban ??u c?a các m?nh
    public Vector2 targetPosition = new Vector2(0, 0); // V? trí m?c tiêu (gi?a màn hình)
    private GameObject[] pieces;
    private int piecesPerLevel;

    private void Awake()
    {
        Instance = this;
    }

    public void SetupLevel(int level)
    {
        piecesPerLevel = level == 1 ? 4 : level == 2 ? 6 : 8;
        pieces = new GameObject[piecesPerLevel];
        for (int i = 0; i < piecesPerLevel; i++)
        {
            pieces[i] = Instantiate(piecePrefab, piecePositions[i].position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            pieces[i].GetComponent<Piece>().SetTarget(targetPosition, i * (360f / piecesPerLevel));
        }
    }

    public bool AreAllPiecesInPlace()
    {
        foreach (var piece in pieces)
        {
            if (!piece.GetComponent<Piece>().IsInPlace()) return false;
        }
        return true;
    }
}