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
    [SerializeField] private GameObject[] catchObjects;
    [SerializeField] private AudioSource sound;

    [HideInInspector] public GunParametrsClass gunParametrs;
    
    private GunClass gunClass;
    private float[] catchObjectsDropChances;

    private void Awake()
    {
        gunParametrs = new GunParametrsClass(speed, leftAndRightEdge, chanceToChangeDirection, secondsBetweenBombDrops);
        gunClass = new GunClass(gunParametrs, transform.position);
        
        catchObjectsDropChances= new float[catchObjects.Length];
    }

    private void Start()
    {        
        for(int i = 0; i < catchObjects.Length; i++)
        {
            catchObjectsDropChances[i] = catchObjects[i].GetComponent<CatchObject>().GetDropChance();
        }

        Invoke("SpawnObject", 2f);
    }
    
    private void FixedUpdate()
    {
        gunClass.Move();
        transform.position = gunClass.gunPosition;
    }
    
    /*
    private void DropObject() 
    {
        int i = Random.Range(0, catchObjects.Length);
        Debug.Log(i);
        GameObject catchObject = Instantiate<GameObject>(catchObjects[i]);
        catchObject.transform.position = transform.position;

        sound.Play();
        
        Invoke("DropObject", gunParametrs.getSecondsBetweenBombDrops());
    }*/

    private void SpawnObject()
    {
        float totalChance = 0f;
        foreach (float chance in catchObjectsDropChances)
        {
            totalChance += chance;
        }

        float randomValue = Random.Range(0f, totalChance);
        float cumulativeChance = 0f;

        for (int i = 0; i < catchObjects.Length; i++)
        {
            cumulativeChance += catchObjectsDropChances[i];
            
            if (randomValue <= cumulativeChance) {
                GameObject catchObject = Instantiate(catchObjects[i]);
                catchObject.transform.position = transform.position;
                break;
            }
        }

        sound.Play();

        Invoke("SpawnObject", gunParametrs.getSecondsBetweenBombDrops());
    }
}
