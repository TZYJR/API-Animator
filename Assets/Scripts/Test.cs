using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
//RequireComponent  需要一个组件    typeof 类型
public class Test : MonoBehaviour {

    Animator animator;   
    CharacterController characterController;

    void Awake()
    {
        animator = this.GetComponent<Animator>();
        characterController = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        Key();
    }

    /// <summary>
    /// 如果键盘控制
    /// </summary>
    void Key()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                characterController.Move(this.transform.forward * Time.deltaTime * 3);
                SetAllAnimationFalse();
                animator.SetBool("IsRun", true);
            }
            else
            {
                 characterController.Move(this.transform.forward * Time.deltaTime * 3);
                SetAllAnimationFalse();
                animator.SetBool("IsWalk", true);
            }
            
        }
        else if (Input.GetKey(KeyCode.S))
        {
            characterController.Move(-this.transform.forward * Time.deltaTime *1.5f);
            SetAllAnimationFalse();
            animator.SetBool("IsWalk_back", true);
        }
        else
        {
            SetAllAnimationFalse();
            animator.SetBool("Idle_A", true);
        }
    }

    /// <summary>
    /// 将所有动画设为false
    /// </summary>
    void SetAllAnimationFalse()
    {
        animator.SetBool("IsWalk", false);
        animator.SetBool("IsRun", false);
        animator.SetBool("Idle_A", false);
        animator.SetBool("IsWalk_back", false);
    }
}
