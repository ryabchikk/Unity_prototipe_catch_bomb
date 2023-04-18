using System;
public class GunParametrsClass
{
    private float speed;
    private float leftAndRightEdge;
    private float chanceToChangeDirection;
    private float secondsBetweenBombDrops;
    
    public GunParametrsClass(float speed, float leftAndRightEdge, float chanceToChangeDirection, float secondsBetweenBombDrops)
    {
        this.speed = speed;
        this.leftAndRightEdge = leftAndRightEdge;
        this.chanceToChangeDirection = chanceToChangeDirection;
        this.secondsBetweenBombDrops = secondsBetweenBombDrops;
    }

    public void setSpeed(float newSpeed) { speed = newSpeed; }
    public void setLeftAndRightEdge(float newLeftAndRightEdge) { leftAndRightEdge = newLeftAndRightEdge; }
    public void setChanceToChangeDirection(float newChanceToChangeDirection) { chanceToChangeDirection = newChanceToChangeDirection; }
    public void setSecondsBetweenBombDrops(float newSecondsBetweenBombDrops) { secondsBetweenBombDrops = newSecondsBetweenBombDrops; }
    
    public float getSpeed() { return speed; }
    public float getLeftAndRightEdge() { return leftAndRightEdge; }
    public float getChanceToChangeDirection() { return chanceToChangeDirection; }
    public float getSecondsBetweenBombDrops() { return (float)Math.Round(secondsBetweenBombDrops,2); }
}
