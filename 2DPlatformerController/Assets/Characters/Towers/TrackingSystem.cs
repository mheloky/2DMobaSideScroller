using UnityEngine;
using System.Collections;

public class TrackingSystem : MonoBehaviour {
	
	public float speed = 100.0f;

	public GameObject m_target = null;
	public GameObject ammo;

	Vector3 m_lastKnownPosition = Vector3.zero;
	Quaternion m_lookAtRotation;

	void Update () {
		if(m_target){
			if(m_lastKnownPosition != m_target.transform.position){
				m_lastKnownPosition = m_target.transform.position;
				m_lookAtRotation = Quaternion.LookRotation(m_lastKnownPosition - transform.position);
			}

			if(transform.rotation != m_lookAtRotation){
				transform.rotation = Quaternion.RotateTowards(transform.rotation, m_lookAtRotation, speed * Time.deltaTime);
			}
		}
	}

	bool SetTarget(GameObject target){
		if(!target){
			return false;
		}

		m_target = target;

		return true;
	}


}