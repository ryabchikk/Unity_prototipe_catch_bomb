using UnityEngine;

public class GunClass
{
    public Vector3 gunPosition;
    public GunParametrsClass gunParametrs;

    public GunClass(GunParametrsClass gunParametrs, Vector3 gunPosition)
    {
        this.gunParametrs = gunParametrs;
        this.gunPosition = gunPosition;
    }

    public void Move()
    {
        TranslateGun();
        ChangeDirection();
        RandomlyChangeDirection();
    }

    private void TranslateGun()
    {
        gunPosition.x += gunParametrs.getSpeed() * Time.deltaTime;
    }

    private void ChangeDirection()
    {
        if (gunPosition.x < gunParametrs.getLeftAndRightEdge()*-1) {
            gunParametrs.setSpeed(Mathf.Abs(gunParametrs.getSpeed()));
        }
        else if (gunPosition.x > gunParametrs.getLeftAndRightEdge()) {
            gunParametrs.setSpeed(-Mathf.Abs(gunParametrs.getSpeed()));
        }
    }

    private void RandomlyChangeDirection()
    {
        if (Random.value < gunParametrs.getChanceToChangeDirection()) {
            float newSpeed = gunParametrs.getSpeed() * -1;
            gunParametrs.setSpeed(newSpeed);
        }
    }
}
