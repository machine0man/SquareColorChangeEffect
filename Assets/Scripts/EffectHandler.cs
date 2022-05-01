using System.Collections.Generic;
using UnityEngine;

namespace Nature
{
	public class EffectHandler : MonoBehaviour
	{
		static EffectHandler s_Instance;

		[SerializeField] int m_sqrCount;
		[SerializeField] int m_pointsCount;
		[SerializeField] GameObject m_prefabPoint;

		[SerializeField] List<GameObject> m_lstPoints = new List<GameObject>();

		[SerializeField] Transform m_transCursorSquare;

		void Start()
		{
			CreatePoints();
		}
		void CreateSquares()
		{

		}
		void CreatePoints()
		{
			Vector2 l_screenXY = Camera.main.ScreenToWorldPoint(new Vector3( (float)Screen.width / 2f, (float)Screen.height / 2f, 0f));

#if UNITY_EDITOR
			l_screenXY = new Vector2(4f,4f);
#endif



			for (int i = 0; i < m_pointsCount; i++)
			{
				GameObject l_go = Instantiate(m_prefabPoint);
				l_go.transform.position = new Vector3(Random.Range(-l_screenXY.x, l_screenXY.x), Random.Range(-l_screenXY.y, l_screenXY.y), 0f);
				l_go.GetComponent<SpriteRenderer>().color = Utility.GetRandomColor();
				m_lstPoints.Add(l_go);
			}
		}
		void Update()
		{
			bool l_anyPointInside = false;
			for (int i = 0; i < m_lstPoints.Count; i++)
			{
				if(Utility.IsPointInsideSquare(m_lstPoints[i].transform.position, m_transCursorSquare.position, m_transCursorSquare.localScale.x, 
					m_transCursorSquare.transform.rotation.eulerAngles.z))
				{
					m_transCursorSquare.GetComponent<MeshRenderer>().sharedMaterial.color = m_lstPoints[i].GetComponent<SpriteRenderer>().color;
					l_anyPointInside = true;
				}

			}
			if (!l_anyPointInside)
			{
				//m_transCursorSquare.GetComponent<MeshRenderer>().sharedMaterial.color = Color.white;
			}
		}
	}
}
