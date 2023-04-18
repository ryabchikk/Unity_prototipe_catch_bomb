using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    private Vector3 GetMousePointerCoordinate() 
    { 
        return Input.mousePosition;
    }

    private Vector3 ConvertTo3DCoordinates(Vector3 mousePos2D) 
    {
        mousePos2D.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos2D);
    }

    private void OnMouseDrag()
    {
        Vector3 pos =transform.position;
        pos.x = ConvertTo3DCoordinates(GetMousePointerCoordinate()).x;
        transform.position = pos;
    }
}
