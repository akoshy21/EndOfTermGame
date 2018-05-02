using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortStuff : IComparer<Character> {

	public int Compare(Character x, Character y){

		float totalX = 1;
		float totalY = 1;

		for (int i = 0; i < 4; i++) {
			totalX += x.mods [i].speedMod;
			totalY += y.mods [i].speedMod;
		}

		float xSpeed = (x.speed * totalX);
		float ySpeed = (y.speed * totalY);

		if(xSpeed > ySpeed)
		{
			return -1;
		}
		if(xSpeed < ySpeed)
		{
			return 1;
		}
		if(xSpeed == ySpeed)
		{
			return Random.Range(-1, 1);
		}
		return 0;
	}
}
