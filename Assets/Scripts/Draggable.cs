using UnityEngine;

namespace Nature
{
    public class Draggable : MonoBehaviour
    {
		private void Update()
		{
			Vector2 l_mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			transform.position = new Vector3(l_mousePos.x, l_mousePos.y, 1f);
		}
	}
}   
