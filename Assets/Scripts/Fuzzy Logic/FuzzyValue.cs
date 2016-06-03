using UnityEngine;
using System.Collections;

public class FuzzyValue
{

	//distance
	public float DistanceNear(float distance)
	{
		float near = MembershipFunction.TrapezoidalRight(distance, 450f, 1000);
		return near;
	}

	public float DistanceMed(float distance)
	{
		float medium = MembershipFunction.Triangular(distance, 600f, 1000f, 1600f);
		return medium;
	}

	public float DistanceFar(float distance)
	{
		float far = MembershipFunction.TrapezoidalLeft(distance, 1200f, 1800f);
		return far;
	}

	//health
	public float HealthFew(float health)
	{
		float few = MembershipFunction.TrapezoidalRight(health, 15f, 45f);
		return few;
	}

	public float HealthMedium(float health)
	{
		float medium = MembershipFunction.Triangular(health, 25f, 50f, 75f);
		return medium;
	}

	public float HealthMany(float health)
	{
		float many = MembershipFunction.TrapezoidalLeft(health, 60f, 85f);
		return many;
	}

	//bonus
	public float BonusFew(float bonus)
	{
		float few = MembershipFunction.TrapezoidalRight(bonus, 3f, 5f);
		return few;

	}

	public float BonusMedium(float bonus)
	{
		float medium = MembershipFunction.Triangular(bonus, 4f, 6f, 8f);
		return medium;
	}

	public float BonusMany(float bonus)
	{
		float many = MembershipFunction.TrapezoidalLeft(bonus, 7f, 10f);
		return many;
	}

	//score
	public float ScoreLow(float score)
	{
		float low = MembershipFunction.TrapezoidalRight(score, 300f, 2000f);
		return low;
	}

	public float ScoreMedium(float score)
	{
		float medium = MembershipFunction.Triangular(score, 1000f, 3000f, 4750f);
		return medium;
	}

	public float ScoreHigh(float score)
	{
		float high = MembershipFunction.TrapezoidalLeft(score, 3000, 5000f);
		return high;
	}

}
