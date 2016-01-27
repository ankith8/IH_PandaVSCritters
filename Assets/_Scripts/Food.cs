using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public enum FoodType
	{
		ChocolateDuckie = 100,
		Cheese = 70,
		Apple = 40
	}

	public FoodType foodType = FoodType.Apple;
}
