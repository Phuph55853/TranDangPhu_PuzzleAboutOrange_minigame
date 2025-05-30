using UnityEngine;
using UnityEngine.EventSystems;

public class Piece : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private Vector2 targetPos;
    private float targetAngle;
    private bool isDragging = false;

    public void SetTarget(Vector2 pos, float angle)
    {
        targetPos = pos;
        targetAngle = angle * Mathf.Deg2Rad;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(eventData.position);
            mousePos.z = 0;
            transform.position = mousePos;

            if (Input.GetMouseButtonDown(1)) // Chuột phải để xoay
            {
                transform.Rotate(0, 0, 90);
            }
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        GameManager.Instance.CheckWinCondition();
    }

    public bool IsInPlace()
    {
        float dist = Vector2.Distance(transform.position, targetPos);
        float angleDiff = Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, targetAngle * Mathf.Rad2Deg));
        return dist < 0.5f && angleDiff < 10f;
    }
}