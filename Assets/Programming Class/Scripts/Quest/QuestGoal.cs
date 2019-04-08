[System.Serializable]
// allows us to display information in the inspector
public class QuestGoal
{
    //goal type
    public GoalType goalType;

    //required amount
    public int requiredAmount;

    //current amount
    public int currentAmount;

    //is Reached
    public bool IsReached()//default false, it'll return true once current amount > requiredamount
    
    {
        return (currentAmount >= requiredAmount);
    }

    //EnemyKilled
    public void enemyKilled()
    {
        if(goalType == GoalType.Kill)
        {
            currentAmount++; 
        }
    }

    //Object Collected
    public void ObjectCollected()
    {
        if(goalType == GoalType.Gather)
        {
            currentAmount++; 
        }
    }

}


public enum GoalType
{
    Kill,
    Gather

}