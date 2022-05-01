using System;
using UnityEngine;

namespace Nature
{
	public static class Utility
	{
		public static bool IsPointInsideSquare(Vector2 a_point, Vector2 a_squareCenter, float a_squareLength, float a_squareRotationAngle)
		{
			a_point -= a_squareCenter; //translate
			a_point = Rotate2dPoint(a_point, -a_squareRotationAngle);//rotate

			if (a_point.x <= a_squareLength / 2 && a_point.x >= -a_squareLength / 2 &&
				a_point.y <= a_squareLength / 2 && a_point.y >= -a_squareLength / 2) //check if point into sqr bounds
				return true;

			return false;
		}
		public static Vector2 Rotate2dPoint(Vector2 a_point, float a_angle)
		{
			float l_cosT = Mathf.Cos(a_angle * Mathf.Deg2Rad);
			float l_sinT = Mathf.Sin(a_angle * Mathf.Deg2Rad);

			return new Vector2(
				a_point.x * l_cosT - a_point.y * l_sinT,
				a_point.x * l_sinT + a_point.y * l_cosT
				);
		}
		public static Color GetRandomColor()
		{
			return new Color(UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f), UnityEngine.Random.Range(0f, 1f));
		}
	}
}
