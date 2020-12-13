﻿using System;
using System.Collections;
using System.Collections.Generic;
using LukeAJ;
using UnityEngine;

namespace Luke
{
    public class RaycastAvoid : MonoBehaviour
    {
        //references
        private EnemyPatrol enemyPatrol;
        
        //ray casting stuff
        public Ray ray = new Ray();
        public RaycastHit raycastHit = new RaycastHit();
        public LayerMask layer;
        
        //physics stuff
        public float rayDistance;
        public float rotationSpeed;
        private Rigidbody rb;
        public bool rayHasHit = false;

        // Update is called once per frame
        private void Start()
        {
            enemyPatrol = GetComponentInParent<EnemyPatrol>();
            rb = GetComponentInParent<Rigidbody>();
        }

        void Update()
        {
            RaycastOut();
        }

        void RaycastOut()
        {
            Ray ray = new Ray();
            ray.origin = transform.position;
            ray.direction = transform.forward;
            RaycastHit raycastHit = new RaycastHit();

            //TODO: add a layer called obstacles to check for obstacles to avoid
            if (Physics.Raycast(ray, out raycastHit, rayDistance,layer))
            {
                rayHasHit = true;
                    
                if (raycastHit.transform != transform)
                {
                    Debug.DrawLine(ray.origin, raycastHit.point, Color.red);
                    rb.AddTorque(0, rotationSpeed, 0);
                    //need to add a force toward the patrol position but still avoiding
                }
            }
        }
    }
}
