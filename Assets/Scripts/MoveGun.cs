using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGun : MonoBehaviour
{
    [Header("Gun Parametrs")]
    [SerializeField] private float speed = 1f;
    [SerializeField] private float leftAndRightEdge = 10f;
    [SerializeField] private float chanceToChangeDirection = 0.1f;
    [SerializeField] private float secondsBetweenBombDrops = 1f;

    [Space]

    [Header("Prefabs")]
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private AudioSource sound;

    [HideInInspector] public GunParametrsClass gunParametrs;
    
    private GunClass gunClass;
    
    void Start() 
    {
        gunParametrs = new GunParametrsClass(speed, leftAndRightEdge, chanceToChangeDirection, secondsBetweenBombDrops);
        gunClass = new GunClass(gunParametrs, transform.position);
        
        Invoke("DropBomb", 2f);
    }
    
    void FixedUpdate()
    {
        gunClass.Move();
        transform.position = gunClass.gunPosition;
    }

    private void DropBomb() 
    {
        GameObject bomb = Instantiate<GameObject>(bombPrefab);
        bomb.transform.position = transform.position;
        sound.Play();
        Invoke("DropBomb", gunParametrs.getSecondsBetweenBombDrops());
    } 
}
