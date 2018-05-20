using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SortMoves : IComparer<Move> {

	public int Compare(Move x, Move y){
		if(x.caster.speed > y.caster.speed)
		{
			return -1;
		}
		if(x.caster.speed < y.caster.speed)
		{
			return 1;
		}
		if(x.caster.speed == y.caster.speed)
		{
			int i = UnityEngine.Random.Range (-1, 1);
			return i;
		}
		return 0;
	}
}

