using UnityEngine;
using UnityEngine.UI;
public class Lose : MonoBehaviour
{
    [SerializeField] private HealthAndScoreController healthAndScoreController;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collideWith = collision.gameObject;

        if(collideWith.GetComponent<CatchObject>() != null ) {
            CatchObject catchObject = collideWith.GetComponent<CatchObject>();
            
            if (catchObject.GetEffect() != null) { 
                GameObject effect = Instantiate(catchObject.GetEffect(), collideWith.transform.position, Quaternion.identity);
                effect.transform.parent = collideWith.transform;
            }
            
            if (catchObject.GetBool()) {
                healthAndScoreController.ApplyDamage(0);
            }
            else { 
                healthAndScoreController.ApplyDamage(catchObject.GetHealthChange());
            }

            catchObject.PlaySoundAndDestroy();
        }
    }

}
