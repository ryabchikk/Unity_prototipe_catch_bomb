using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ComplexityClass;

public class CatchZone : MonoBehaviour
{
    [SerializeField] private HealthAndScoreController healthAndScoreController;
    [SerializeField] private GameObject gun;

    private GunParametrsClass gunParametrs;
    private int counter = 0;

    private void Start()
    {
        gunParametrs = gun.GetComponent<MoveGun>().gunParametrs;
        PlayerPrefs.GetInt("Score");     
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;

        if (collideWith.GetComponent<CatchObject>() != null) {
            CatchObject catchObject = collideWith.GetComponent<CatchObject>();
            
            if (catchObject.GetBool()) {
                healthAndScoreController.ChangeLife(catchObject.GetHealthChange());
            }

            healthAndScoreController.AddPoints(catchObject.GetScoreChange());
            ChangeComplexity(gunParametrs, catchObject.GetScoreChange(), ref counter);
            
            Destroy(collideWith);
        }   
    }
}
