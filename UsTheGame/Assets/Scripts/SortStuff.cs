using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortStuff : IComparer<Character> {

	public int Compare(Character x, Character y){
		if(x.speed > y.speed)
		{
			return -1;
		}
		if(x.speed < y.speed)
		{
			return 1;
		}
		if(x.speed == y.speed)
		{
			return Random.Range(-1, 1);
		}
		return 0;
	}
}
