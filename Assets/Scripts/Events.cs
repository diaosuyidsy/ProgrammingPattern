
public class EnemyDied : GameEvent
{
	public int PointValue { get; }

	public EnemyDied(int value)
	{
		PointValue = value;
	}
}
