using Assets._2DPlatformer.Scripts.BaseEngine.PhysicsManagers;
using PhysicsObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Interactables
{
    public class AnimationManagerPlayer : MonoBehaviour, AAnimationManager
    {
        #region Properties
        public Animator TheAnimator;
        public AInputManager TheInputManager;
        public APhysicsObject PhysicsObject;
        #endregion

        public void Start()
        {

        }

        public void ExecueChangeAnimationLogic()
        {
            TheAnimator.SetFloat("velocityX", Mathf.Abs(PhysicsObject.Velocity.x) / PhysicsObject.TheMaxSpeed);
            TheAnimator.SetBool("IsRunning", TheInputManager.NetworkHorizontalAxis != 0f);
            TheAnimator.SetBool("IsBasicAttacking", Input.GetKey(KeyCode.X));
            TheAnimator.SetBool("IsBasicGuarding", Input.GetKey(KeyCode.Z));
        }

        public void FixedUpdate()
        {
            ExecueChangeAnimationLogic();
        }
    }
}
