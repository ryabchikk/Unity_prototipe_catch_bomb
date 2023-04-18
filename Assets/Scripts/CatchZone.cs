using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ComplexityClass;

public class CatchZone : MonoBehaviour
{
    [SerializeField] private Text scoreGT;
    [SerializeField] private GameObject gun;

    private GunParametrsClass gunParametrs;
    private int counter = 0;

    private const int POINTS = 100;
    
    private void Start()
    {
        gunParametrs = gun.GetComponent<MoveGun>().gunParametrs;
        PlayerPrefs.GetInt("Score");     
    }

    private void AddPoints()
    {
        int score = int.Parse(scoreGT.text);
        score += POINTS;
        scoreGT.text = score.ToString();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;

        if (collideWith.tag == "Bomb") {
            Destroy(collideWith);
        }
        
        AddPoints();
        ChacngeComplexity(gunParametrs, ref counter);
    }
}
