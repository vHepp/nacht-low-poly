using UnityEngine;

[CreateAssetMenu (menuName = "Countable")]
public class Countable : ScriptableObject
{
	int max, reserve, counter, maxReserve, maxCounter, health;

    // setters
    public void setCounter(int c)
    {
        counter = c;
    }
	public void setMaxCounter(int c)
    {
        maxCounter = c;
    }
	public void setMax(int c)
    {
        max = c;
    }
	public void setReverve(int c)
	{
		reserve = c;
	}
	public void setMaxReverve(int c)
	{
		maxReserve = c;
	}
	public void setHealth(int c)
	{
		health = c;
	}


	// increments and decrements
    public void incrementCounter()
    {
        counter++;
    }
    public void decrementCounter()
    {
        counter--;
    }
	public void incrementHealth()
    {
        health++;
    }
    public void decrementHealth()
	{
		health--;
	}
 	public void incrementReverve()
    {
        reserve++;
    }
    public void decrementReverve()
    {
        reserve--;
    }
	
	
	// Add int c to the value
	public void addCounter(int c)
    {
        counter += c;
    }
	public void subtractCounter(int c)
    {
        counter -= c;
    }
	public void addReverve(int c)
    {
        reserve += c;
    }
	public void subtractReverve(int c)
    {
        reserve -= c;
    }

    // Get the current value of the counter
    public int getCount()
    {
        return counter;
    }
    public int getMax()
    {
        return max;
    }
	public int getMaxCount()
    {
        return maxCounter;
    }
	public int getReserve()
    {
        return reserve;
    }
	public int getMaxReserve()
    {
        return maxReserve;
    }
	public int getHealth()
    {
        return health;
    }
	
	// set reserve and counter their max
	public void maxOut() {
		reserve = maxReserve;
		counter = maxCounter;
	}

	// check if counter and reserve are maxed
	public bool isMaxed() {
		return (reserve == maxReserve && counter == maxCounter);
	 }
}
