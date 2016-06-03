using UnityEngine;
using System.Collections;

public class BehaviorRules
{


	public float Rule(float distance, float health, float bonus, float score)
	{
		FuzzyValue fuzzyValue = new FuzzyValue();
		//distance
		float distanceNearValue = fuzzyValue.DistanceNear(distance);
		float distanceMedValue = fuzzyValue.DistanceMed(distance);
		float distanceFarValue = fuzzyValue.DistanceFar(distance);

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



		float w1 = Min(distanceNearValue, healthFewValue, bonusFewValue, scoreLowValue);
		float w2 = Min(distanceMedValue, healthFewValue, bonusFewValue, scoreLowValue);
		float w3 = Min(distanceFarValue, healthFewValue, bonusFewValue, scoreLowValue);
		float w4 = Min(distanceNearValue, healthMedValue, bonusFewValue, scoreLowValue);
		float w5 = Min(distanceMedValue, healthMedValue, bonusFewValue, scoreLowValue);
		float w6 = Min(distanceFarValue, healthMedValue, bonusFewValue, scoreLowValue);
		float w7 = Min(distanceNearValue, healthManyValue, bonusFewValue, scoreLowValue);
		float w8 = Min(distanceMedValue, healthManyValue, bonusFewValue, scoreLowValue);
		float w9 = Min(distanceFarValue, healthManyValue, bonusFewValue, scoreLowValue);
		float w10 = Min(distanceNearValue, healthFewValue, bonusMedValue, scoreLowValue);
		float w11 = Min(distanceMedValue, healthFewValue, bonusMedValue, scoreLowValue);
		float w12 = Min(distanceFarValue, healthFewValue, bonusMedValue, scoreLowValue);
		float w13 = Min(distanceNearValue, healthMedValue, bonusMedValue, scoreLowValue);
		float w14 = Min(distanceMedValue, healthMedValue, bonusMedValue, scoreLowValue);
		float w15 = Min(distanceFarValue, healthMedValue, bonusMedValue, scoreLowValue);
		float w16 = Min(distanceNearValue, healthManyValue, bonusMedValue, scoreLowValue);
		float w17 = Min(distanceMedValue, healthManyValue, bonusMedValue, scoreLowValue);
		float w18 = Min(distanceFarValue, healthManyValue, bonusMedValue, scoreLowValue);
		float w19 = Min(distanceNearValue, healthFewValue, bonusManyValue, scoreLowValue);
		float w20 = Min(distanceMedValue, healthFewValue, bonusManyValue, scoreLowValue);
		float w21 = Min(distanceFarValue, healthFewValue, bonusManyValue, scoreLowValue);
		float w22 = Min(distanceNearValue, healthMedValue, bonusManyValue, scoreLowValue);
		float w23 = Min(distanceMedValue, healthMedValue, bonusManyValue, scoreLowValue);
		float w24 = Min(distanceFarValue, healthMedValue, bonusManyValue, scoreLowValue);
		float w25 = Min(distanceNearValue, healthManyValue, bonusManyValue, scoreLowValue);
		float w26 = Min(distanceMedValue, healthManyValue, bonusManyValue, scoreLowValue);
		float w27 = Min(distanceFarValue, healthManyValue, bonusManyValue, scoreLowValue);
		float w28 = Min(distanceNearValue, healthFewValue, bonusFewValue, scoreMedValue);
		float w29 = Min(distanceMedValue, healthFewValue, bonusFewValue, scoreMedValue);
		float w30 = Min(distanceFarValue, healthFewValue, bonusFewValue, scoreMedValue);
		float w31 = Min(distanceNearValue, healthMedValue, bonusFewValue, scoreMedValue);
		float w32 = Min(distanceMedValue, healthMedValue, bonusFewValue, scoreMedValue);
		float w33 = Min(distanceFarValue, healthMedValue, bonusFewValue, scoreMedValue);
		float w34 = Min(distanceNearValue, healthManyValue, bonusFewValue, scoreMedValue);
		float w35 = Min(distanceMedValue, healthManyValue, bonusFewValue, scoreMedValue);
		float w36 = Min(distanceFarValue, healthManyValue, bonusFewValue, scoreMedValue);
		float w37 = Min(distanceNearValue, healthFewValue, bonusMedValue, scoreMedValue);
		float w38 = Min(distanceMedValue, healthFewValue, bonusMedValue, scoreMedValue);
		float w39 = Min(distanceFarValue, healthFewValue, bonusMedValue, scoreMedValue);
		float w40 = Min(distanceNearValue, healthMedValue, bonusMedValue, scoreMedValue);
		float w41 = Min(distanceMedValue, healthMedValue, bonusMedValue, scoreMedValue);
		float w42 = Min(distanceFarValue, healthMedValue, bonusMedValue, scoreMedValue);
		float w43 = Min(distanceNearValue, healthManyValue, bonusMedValue, scoreMedValue);
		float w44 = Min(distanceMedValue, healthManyValue, bonusMedValue, scoreMedValue);
		float w45 = Min(distanceFarValue, healthManyValue, bonusMedValue, scoreMedValue);
		float w46 = Min(distanceNearValue, healthFewValue, bonusManyValue, scoreMedValue);
		float w47 = Min(distanceMedValue, healthFewValue, bonusManyValue, scoreMedValue);
		float w48 = Min(distanceFarValue, healthFewValue, bonusManyValue, scoreMedValue);
		float w49 = Min(distanceNearValue, healthMedValue, bonusManyValue, scoreMedValue);
		float w50 = Min(distanceMedValue, healthMedValue, bonusManyValue, scoreMedValue);
		float w51 = Min(distanceFarValue, healthMedValue, bonusManyValue, scoreMedValue);
		float w52 = Min(distanceNearValue, healthManyValue, bonusManyValue, scoreMedValue);
		float w53 = Min(distanceMedValue, healthManyValue, bonusManyValue, scoreMedValue);
		float w54 = Min(distanceFarValue, healthManyValue, bonusManyValue, scoreMedValue);
		float w55 = Min(distanceNearValue, healthFewValue, bonusFewValue, scoreHighValue);
		float w56 = Min(distanceMedValue, healthFewValue, bonusFewValue, scoreHighValue);
		float w57 = Min(distanceFarValue, healthFewValue, bonusFewValue, scoreHighValue);
		float w58 = Min(distanceNearValue, healthMedValue, bonusFewValue, scoreHighValue);
		float w59 = Min(distanceMedValue, healthMedValue, bonusFewValue, scoreHighValue);
		float w60 = Min(distanceFarValue, healthMedValue, bonusFewValue, scoreHighValue);
		float w61 = Min(distanceNearValue, healthManyValue, bonusFewValue, scoreHighValue);
		float w62 = Min(distanceMedValue, healthManyValue, bonusFewValue, scoreHighValue);
		float w63 = Min(distanceFarValue, healthManyValue, bonusFewValue, scoreHighValue);
		float w64 = Min(distanceNearValue, healthFewValue, bonusMedValue, scoreHighValue);
		float w65 = Min(distanceMedValue, healthFewValue, bonusMedValue, scoreHighValue);
		float w66 = Min(distanceFarValue, healthFewValue, bonusMedValue, scoreHighValue);
		float w67 = Min(distanceNearValue, healthMedValue, bonusMedValue, scoreHighValue);
		float w68 = Min(distanceMedValue, healthMedValue, bonusMedValue, scoreHighValue);
		float w69 = Min(distanceFarValue, healthMedValue, bonusMedValue, scoreHighValue);
		float w70 = Min(distanceNearValue, healthManyValue, bonusMedValue, scoreHighValue);
		float w71 = Min(distanceMedValue, healthManyValue, bonusMedValue, scoreHighValue);
		float w72 = Min(distanceFarValue, healthManyValue, bonusMedValue, scoreHighValue);
		float w73 = Min(distanceNearValue, healthFewValue, bonusManyValue, scoreHighValue);
		float w74 = Min(distanceMedValue, healthFewValue, bonusManyValue, scoreHighValue);
		float w75 = Min(distanceFarValue, healthFewValue, bonusManyValue, scoreHighValue);
		float w76 = Min(distanceNearValue, healthMedValue, bonusManyValue, scoreHighValue);
		float w77 = Min(distanceMedValue, healthMedValue, bonusManyValue, scoreHighValue);
		float w78 = Min(distanceFarValue, healthMedValue, bonusManyValue, scoreHighValue);
		float w79 = Min(distanceNearValue, healthManyValue, bonusManyValue, scoreHighValue);
		float w80 = Min(distanceMedValue, healthManyValue, bonusManyValue, scoreHighValue);
		float w81 = Min(distanceFarValue, healthManyValue, bonusManyValue, scoreHighValue);

		float z1 = 0.5f;
		float z2 = 0.5f;
		float z3 = 0f;
		float z4 = 0.5f;
		float z5 = 0.5f;
		float z6 = 0f;
		float z7 = 0.5f;
		float z8 = 1f;
		float z9 = 1f;
		float z10 = 0.5f;
		float z11 = 0.5f;
		float z12 = 0f;
		float z13 = 0.5f;
		float z14 = 0f;
		float z15 = 0f;
		float z16 = 0.5f;
		float z17 = 1f;
		float z18 = 0f;
		float z19 = 0.5f;
		float z20 = 0.5f;
		float z21 = 0f;
		float z22 = 0.5f;
		float z23 = 0f;
		float z24 = 0f;
		float z25 = 1f;
		float z26 = 1f;
		float z27 = 0f;
		float z28 = 0.5f;
		float z29 = 0.5f;
		float z30 = 0f;
		float z31 = 0.5f;
		float z32 = 0.5f;
		float z33 = 0f;
		float z34 = 0.5f;
		float z35 = 1f;
		float z36 = 0.5f;
		float z37 = 1f;
		float z38 = 0f;
		float z39 = 0f;
		float z40 = 0.5f;
		float z41 = 0f;
		float z42 = 0f;
		float z43 = 1f;
		float z44 = 1f;
		float z45 = 1f;
		float z46 = 0.5f;
		float z47 = 0.5f;
		float z48 = 0f;
		float z49 = 0f;
		float z50 = 0f;
		float z51 = 0f;
		float z52 = 0.5f;
		float z53 = 0.5f;
		float z54 = 1f;
		float z55 = 0.5f;
		float z56 = 0.5f;
		float z57 = 0f;
		float z58 = 1f;
		float z59 = 1f;
		float z60 = 0f;
		float z61 = 0.5f;
		float z62 = 0.5f;
		float z63 = 1f;
		float z64 = 1f;
		float z65 = 1f;
		float z66 = 0.5f;
		float z67 = 0.5f;
		float z68 = 0f;
		float z69 = 0f;
		float z70 = 1f;
		float z71 = 1f;
		float z72 = 0f;
		float z73 = 0f;
		float z74 = 1f;
		float z75 = 0f;
		float z76 = 0.5f;
		float z77 = 1f;
		float z78 = 0f;
		float z79 = 1f;
		float z80 = 1f;
		float z81 = 1f;


		float pembilang = 
			(w1 * z1) + (w2 * z2) + (w3 * z3) + (w4 * z4) + (w5 * z5) +
			(w6 * z6) + (w7 * z7) + (w8 * z8) + (w9 * z9) + (w10 * z10) +
			(w11 * z11) + (w12 * z12) + (w13 * z13) + (w14 * z14) + (w15 * z15) +
			(w16 * z16) + (w17 * z17) + (w18 * z18) + (w19 * z19) + (w20 * z20) +
			(w21 * z21) + (w22 * z22) + (w23 * z23) + (w24 * z24) + (w25 * z25) +
			(w26 * z26) + (w27 * z27) + (w28 * z28) + (w29 * z29) + (w30 * z30) +
			(w31 * z31) + (w32 * z32) + (w33 * z33) + (w34 * z34) + (w35 * z35) +
			(w36 * z36) + (w37 * z37) + (w38 * z38) + (w39 * z39) + (w40 * z40) +
			(w41 * z41) + (w42 * z42) + (w43 * z43) + (w44 * z44) + (w45 * z45) +
			(w46 * z46) + (w47 * z47) + (w48 * z48) + (w49 * z49) + (w50 * z50) +
			(w51 * z51) + (w52 * z52) + (w53 * z53) + (w54 * z54) + (w55 * z55) +
			(w56 * z56) + (w57 * z57) + (w58 * z58) + (w59 * z59) + (w60 * z60) +
			(w61 * z61) + (w62 * z62) + (w63 * z63) + (w64 * z64) + (w65 * z65) +
			(w66 * z66) + (w67 * z67) + (w68 * z68) + (w69 * z69) + (w70 * z70) +
			(w71 * z71) + (w72 * z72) + (w73 * z73) + (w74 * z74) + (w75 * z75) +
			(w76 * z76) + (w77 * z77) + (w78 * z78) + (w79 * z79) + (w80 * z80) +
			(w81 * z81);
		float penyebut = 
			w1 + w2 + w3 + w4 + w5 + w6 + w7 + w8 + w9 + w10 +
			w11 + w12 + w13 + w14 + w15 + w16 + w17 + w18 + w19 +
			w20 + w21 + w22 + w23 + w24 + w25 + w26 + w27 + w28 +
			w29 + w30 + w31 + w32 + w33 + w34 + w35 + w36 + w37 +
			w38 + w39 + w40 + w41 + w42 + w43 + w44 + w45 + w46 +
			w47 + w48 + w49 + w50 + w51 + w52 + w53 + w54 + w55 +
			w56 + w57 + w58 + w59 + w60 + w61 + w62 + w63 + w64 +
			w65 + w66 + w67 + w68 + w69 + w70 + w71 + w72 + w73 +
			w74 + w75 + w76 + w77 + w78 + w79 + w80 + w81;

		float result = pembilang / penyebut;
		Debug.Log("Distance = " + distance + ", Health = " + health + ", Bonus = " + bonus + ", Score = " + score + ", Hasil Defuzzifikasi = " + result);
		return result;
	}

	float Min(float x1, float x2, float x3, float x4)
	{
		float min1 = Mathf.Min(x1, x2);
		float min2 = Mathf.Min(min1, x3);
		float min3 = Mathf.Min(min2, x4);
		return min3;
	}
}
