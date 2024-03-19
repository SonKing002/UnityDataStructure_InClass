using System;
using UnityEngine;

namespace DataStructure.Stack.CommandPattern
{
    public class MoveCommand : ICommand
    {

        //명령 수행에 필요한 두 변수

        /// <summary>
        /// 이동할 대상 트랜스 폼
        /// </summary>
        private Transform target;

        /// <summary>
        /// 이동의 방향
        /// </summary>
        private Vector3 direction;

        /// <summary>
        /// 생성자 초기화 : Dependency Injection (의존성 주입)
        /// </summary>
        /// <param name="target">대상</param>
        /// <param name="direction">방향</param>
        public MoveCommand(Transform target, Vector3 direction) //받아서 초기화
        { 
            this.target = target;
            this.direction = direction;
        }

        public void Excute()
        {
            //컨셉에 따라 구현
            target.position += direction;
            
        }

        public void Undo()
        {
            //컨셉에 따라 구현
            target.position += -direction;
        }
    }
}


#region 예제

/* 설명
 * 좌우 방향키로 큐브를 이동하는 명령을 MoveCommand로 저장
 * 이동은 오른쪽 또는 왼쪽으로 한칸씩 이동
 * 저장할 데이터
 * Transform
 * Vector3
 * Excute 함수 실행 시 원래 진행 방향으로 이동 수행
 * Undo 함수 실행 시 우너래와 반대 방향으로 이동 수행
 * 
 */

/*
 * 2차원의 반대 방향은 = 180도 도는 것과 같다
 */

/* 의존성 주입
 
 * 사용 이유 : 디커플링 기법 ( 한 몸처럼 움직이는 것 ): 연결고리 끊기위함 composition
 * 
 * 커플링 : 내가 끌어다 사용 (상속)
 */

/* 단위 스케일 : 마야 cm, 유니티 m

유니티
 * 움직이는 단위 m 단위
 * 회전각 : 도
 
언리얼
 * cm 단위
 */

/*Stack 예시
 * 바둑
 * 역추적
 */
#endregion
