using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortMoves : IComparer<Move> {

	public int Compare(Move x, Move y){
		float totalX = 1;
		float totalY = 1;

		for (int i = 0; i < 4; i++) {
			totalX += x.caster.mods [i].speedMod;
			totalY += y.caster.mods [i].speedMod;
		}

		float xSpeed = (x.caster.speed * totalX);
		float ySpeed = (y.caster.speed * totalY);

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
			return UnityEngine.Random.Range(-1, 1);
		}
		return 0;
	}
}

