using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CharacterAnimation : MonoBehaviour
{
    public string idleAnimation = "idle";
    public string runAnimation = "running";
    public string jumpAnimation = "jumping";
    public string deathAnimation = "dying";

    enum State { IDLE, RUNNING, JUMPING, DEAD, NONE};
    // Start is called before the first frame update

    State state = State.NONE;
    private DragonBones.UnityArmatureComponent armatureComponent;

    void Start()
    {
        armatureComponent = transform.GetComponentInChildren<DragonBones.UnityArmatureComponent>();
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Idle()
    {
        if (state != State.DEAD && state != State.IDLE)
        {
            armatureComponent.animation.FadeIn(idleAnimation, 0.25f, -1);
            armatureComponent.animation.timeScale = 1f;
            state = State.IDLE;
        }
    }


    public void Run(float speed)
    {
        if (state != State.DEAD)
        {
            if (speed > 0 && transform.lossyScale.x > 0 || speed < 0 && transform.lossyScale.x < 0)
            {
                if (state != State.RUNNING)
                {
                    armatureComponent.animation.FadeIn(runAnimation, 0.25f - 1);
                    state = State.RUNNING;
                }
                armatureComponent.animation.timeScale = speed;
            }
            else if (speed < 0 && transform.lossyScale.x > 0 || speed > 0 && transform.lossyScale.x < 0)
            {
                if (state != State.RUNNING)
                {
                    armatureComponent.animation.FadeIn(runAnimation, 0.25f, -1);
                    state = State.RUNNING;
                }
                armatureComponent.animation.timeScale = -speed;
            }
        }
    }


    public void Jump()
    {
        if (state != State.DEAD && state != State.JUMPING)
        {
            armatureComponent.animation.FadeIn(jumpAnimation, 0.125f, 1);
            armatureComponent.animation.timeScale = 0.8f;
            state = State.JUMPING;
        }
    }

    public void Die()
    {
        if (state != State.DEAD)
        {
            armatureComponent.animation.FadeIn(deathAnimation, 0.25f, 1);
            armatureComponent.animation.timeScale = 1f;
            state = State.DEAD;
        }
    }



}
