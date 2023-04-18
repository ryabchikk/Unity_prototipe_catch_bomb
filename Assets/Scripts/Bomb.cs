using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float bottomY = -20f;
    
    void Update()
    {
        DestroyBomb();
    }

    private void DestroyBomb() 
    {
        if (transform.position.y < bottomY) {
            Destroy(gameObject);
        }
    }
}
