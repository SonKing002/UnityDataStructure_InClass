using DataStructure.Stack.CommandPattern;
using System;
using UnityEngine;

namespace DataStructure.Stack
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            //입력 확인 후 이동
            if (InputManager.Horizontal != 0f || InputManager.Vertical != 0f)
            {
                //큐브 이동
                /*
                transform.position += new Vector3(
                    InputManager.Horizontal,
                    0f,
                    InputManager.Vertical
                    );
                */

                CommandManager.instance.AddCpmmand(
                    new MoveCommand(transform, new Vector3(InputManager.Horizontal, 0f, InputManager.Vertical))
                    );
            }
        }

    }
}

/*
 * 중간 단계 추가
 * 메니저 관리
 */

