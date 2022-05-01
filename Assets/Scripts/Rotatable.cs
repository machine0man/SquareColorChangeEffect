using UnityEngine;

namespace Nature
{
    public class Rotatable : MonoBehaviour
    {
		[SerializeField] bool m_autoRotate;
		[SerializeField] float m_rotationSpeed;

		private void Update()
		{
			float m_curAngle = transform.eulerAngles.z;
			m_curAngle += (m_rotationSpeed);
			if (m_autoRotate)
			{
				transform.rotation = Quaternion.Euler(0f, 0f, m_curAngle);
			}
		}
	}
}   
