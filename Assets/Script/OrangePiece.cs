//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class OrangePiece : MonoBehaviour
//{
//    private Vector3 offset;
//    private Camera mainCamera;
//    private bool isDragging = false;
//    private MovementController movementController;
//    void Start()
//    {
//        mainCamera = Camera.main;
//        movementController = FindObjectOfType<MovementController>();
//    }

//    void OnMouseDown()
//    {
//        isDragging = true;
//        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);
//    }

//    void OnMouseDrag()
//    {
//        if (isDragging)
//        {
//            Vector3 newScreenPosition = Input.mousePosition;
//            Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(newScreenPosition) + offset;

//            Vector2 direction = Vector2.zero;
//            if (Mathf.Abs(newWorldPosition.x - transform.position.x) > Mathf.Abs(newWorldPosition.y - transform.position.y))
//            {
//                direction = newWorldPosition.x > transform.position.x ? Vector2.right : Vector2.left;
//            }
//            else
//            {
//                direction = newWorldPosition.y > transform.position.y ? Vector2.up : Vector2.down;
//            }

//            movementController.MoveAllPieces(direction);
//        }
//    }

//    void OnMouseUp()
//    {
//        isDragging = false;
//    }

//    internal void Initialize(Vector2Int position)
//    {
//        throw new NotImplementedException();
//    }
//}

using System;
using UnityEngine;

public class OrangePiece : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;
    private bool isDragging = false;
    private MovementController movementController;
    private bool hasMoved = false;
    private AudioSource audioSource;
    void Start()
    {
        mainCamera = Camera.main;
        movementController = FindObjectOfType<MovementController>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        hasMoved = false;
        offset = transform.position - mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Phát âm thanh khi bắt đầu kéo
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void OnMouseDrag()
    {
        if (isDragging && !hasMoved)
        {
            Vector3 newScreenPosition = Input.mousePosition;
            Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(newScreenPosition) + offset;

            Vector2 direction = Vector2.zero;
            float dx = newWorldPosition.x - transform.position.x;
            float dy = newWorldPosition.y - transform.position.y;

            if (Mathf.Abs(dx) > 0.2f || Mathf.Abs(dy) > 0.2f)
            {
                if (Mathf.Abs(dx) > Mathf.Abs(dy))
                {
                    direction = dx > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    direction = dy > 0 ? Vector2.up : Vector2.down;
                }

                movementController.MovePiece(this, direction); // Di chuyển mảnh cam duy nhất
                hasMoved = true;
            }
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
        hasMoved = false;
    }
}
