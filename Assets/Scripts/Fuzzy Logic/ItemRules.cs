using UnityEngine;
using System.Collections;

public class ItemRules
{

	public int Rule(float health, float bonus, float score)
	{
		FuzzyValue fuzzyValue = new FuzzyValue();
		//health
		float healthFewValue = fuzzyValue.HealthFew(health);
		float healthMedValue = fuzzyValue.HealthMedium(health);
		float healthManyValue = fuzzyValue.HealthMany(health);

		//bonus
		float bonusFewValue = fuzzyValue.BonusFew(bonus);
		float bonusMedValue = fuzzyValue.BonusMedium(bonus);
		float bonusManyValue = fuzzyValue.BonusMany(bonus);

		//score
		float scoreLowValue = fuzzyValue.ScoreLow(score);
		float scoreMedValue = fuzzyValue.ScoreMedium(score);
		float scoreHighValue = fuzzyValue.ScoreHigh(score);

		float w1 = Min(healthFewValue, bonusFewValue, scoreLowValue);
		float w2 = Min(healthFewValue, bonusFewValue, scoreLowValue);
		float w3 = Min(healthFewValue, bonusFewValue, scoreLowValue);
		float w4 = Min(healthMedValue, bonusFewValue, scoreLowValue);
		float w5 = Min(healthMedValue, bonusFewValue, scoreLowValue);
		float w6 = Min(healthMedValue, bonusFewValue, scoreLowValue);
		float w7 = Min(healthManyValue, bonusFewValue, scoreLowValue);
		float w8 = Min(healthManyValue, bonusFewValue, scoreLowValue);
		float w9 = Min(healthManyValue, bonusFewValue, scoreLowValue);
		float w10 = Min(healthFewValue, bonusMedValue, scoreLowValue);
		float w11 = Min(healthFewValue, bonusMedValue, scoreLowValue);
		float w12 = Min(healthFewValue, bonusMedValue, scoreLowValue);
		float w13 = Min(healthMedValue, bonusMedValue, scoreLowValue);
		float w14 = Min(healthMedValue, bonusMedValue, scoreLowValue);
		float w15 = Min(healthMedValue, bonusMedValue, scoreLowValue);
		float w16 = Min(healthManyValue, bonusMedValue, scoreLowValue);
		float w17 = Min(healthManyValue, bonusMedValue, scoreLowValue);
		float w18 = Min(healthManyValue, bonusMedValue, scoreLowValue);
		float w19 = Min(healthFewValue, bonusManyValue, scoreLowValue);
		float w20 = Min(healthFewValue, bonusManyValue, scoreLowValue);
		float w21 = Min(healthFewValue, bonusManyValue, scoreLowValue);
		float w22 = Min(healthMedValue, bonusManyValue, scoreLowValue);
		float w23 = Min(healthMedValue, bonusManyValue, scoreLowValue);
		float w24 = Min(healthMedValue, bonusManyValue, scoreLowValue);
		float w25 = Min(healthManyValue, bonusManyValue, scoreLowValue);
		float w26 = Min(healthManyValue, bonusManyValue, scoreLowValue);
		float w27 = Min(healthManyValue, bonusManyValue, scoreLowValue);

		float z1 = 9;
		float z2 = 6;
		float z3 = 6;
		float z4 = 9;
		float z5 = 6;
		float z6 = 3;
		float z7 = 6;
		float z8 = 6;
		float z9 = 3;
		float z10 = 9;
		float z11 = 6;
		float z12 = 6;
		float z13 = 9;
		float z14 = 6;
		float z15 = 3; 
		float z16 = 6;
		float z17 = 6;
		float z18 = 3;
		float z19 = 9;
		float z20 = 9;
		float z21 = 3;
		float z22 = 6;
		float z23 = 3;
		float z24 = 3;
		float z25 = 9;
		float z26 = 3;
		float z27 = 3;


		float pembilang = 
			(w1 * z1) + (w2 * z2) + (w3 * z3) + (w4 * z4) + (w5 * z5) +
			(w6 * z6) + (w7 * z7) + (w8 * z8) + (w9 * z9) + (w10 * z10) +
			(w11 * z11) + (w12 * z12) + (w13 * z13) + (w14 * z14) + (w15 * z15) +
			(w16 * z16) + (w17 * z17) + (w18 * z18) + (w19 * z19) + (w20 * z20) +
			(w21 * z21) + (w22 * z22) + (w23 * z23) + (w24 * z24) + (w25 * z25) + (w26 * z26) + (w27 * z27);

		float penyebut = w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8 + w9 + w10 + w11 + w12 + w13 + w14 + w15 + w16 +
		                 w17 + w18 + w19 + w20 + w21 + w22 + w23 + w24 + w25 + w26 + w27;

		float result = pembilang / penyebut;

		Debug.Log("Jumlah Item : " + Mathf.RoundToInt(result));
		return Mathf.RoundToInt(result);
		
	}


	float Min(float x1, float x2, float x3)
	{
		float min1 = Mathf.Min(x1, x2);
		float min2 = Mathf.Min(min1, x3);
		return min2;
	}
}
