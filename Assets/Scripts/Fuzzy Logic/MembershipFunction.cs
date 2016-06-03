using System.Collections;

public class MembershipFunction
{

	public static float TrapezoidalRight(float x, float a, float b)
	{
		float trapRight = 0;

		if (x < a)
			trapRight = 1;
		else if (a <= x && x <= b)
			trapRight = (b - x) / (b - a);
		else if (x >= b)
			trapRight = 0;

		return trapRight;
	}

	public static float Triangular(float x, float a, float b, float c)
	{
		float triangular = 0;

		if (x <= a || c <= x)
			triangular = 0;
		else if (a <= x && x <= b)
			triangular = (x - a) / (b - a);
		else if (b <= x && x <= c)
			triangular = (c - x) / (c - b);

		return triangular;
	}

	public static float TrapezoidalLeft(float x, float a, float b)
	{
		float trapLeft = 0;

		if (x <= a)
			trapLeft = 0;
		else if (a <= x && x <= b)
			trapLeft = (x - a) / (b - a);
		else if (x >= b)
			trapLeft = 1;

		return trapLeft;
	}
}
