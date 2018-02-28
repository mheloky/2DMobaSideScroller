﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackingProjectile : BaseProjectile {

	GameObject m_target;
	public GameObject target;

	void Update(){
		if(m_target){
			transform.position = Vector3.MoveTowards (transform.position, m_target.transform.position, speed * Time.deltaTime);

		}
	}

	public override void FireProjectile (GameObject launcher, GameObject target, int damage){
		if(target){
			m_target = target;
		}
	}


}
