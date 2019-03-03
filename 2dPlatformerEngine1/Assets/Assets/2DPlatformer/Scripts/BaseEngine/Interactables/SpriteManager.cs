using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._2DPlatformer.Scripts.BaseEngine.Interactables
{
    public class SpriteManager: MonoBehaviour, ASpriteManager
    {
        #region Properties
        Animator TheAnimator;
        SpriteRenderer TheSpriteRenderer;
        PhysicsObject ThePhysicsObject;
        InputManagerPlayer TheInputManagerPlayer;
        #endregion

        private void Start()
        {

        }

        void ExecuteFlipSpriteLogic()
        {
            var  move = Vector2.zero;
             
            move.x = TheInputManagerPlayer.NetworkHorizontalAxis;
             
            if (move.x < 0f)
            {

                TheSpriteRenderer.flipX = true;
            }
            if (move.x > .0f)
            {

                TheSpriteRenderer.flipX = false;
            }

            ThePhysicsObject.TargetVelocity = move * ThePhysicsObject.TheMaxSpeed;
        }

        void ExecueChangeAnimationLogic()
        {
            TheAnimator.SetFloat("velocityX", Mathf.Abs(ThePhysicsObject.Velocity.x) / ThePhysicsObject.TheMaxSpeed);
            TheAnimator.SetBool("IsRunning", TheInputManagerPlayer.NetworkHorizontalAxis != 0f);
            TheAnimator.SetBool("IsBasicAttacking", Input.GetKey(KeyCode.X));
            TheAnimator.SetBool("IsBasicGuarding", Input.GetKey(KeyCode.Z));
        }

        void FixedUpdate()
        {
            ExecuteFlipSpriteLogic();
        }
    }
}
