using UnityEngine;

namespace DataStructure.Stack
{
    /// <summary>
    /// 명령(Command)을 인터페이스로 구현
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// 명령이 순방향으로 실행할 때 수행할 함수
        /// </summary>
        void Excute();

        /// <summary>
        /// 명령을 역방향으로 실행할 때 수행할 함수
        /// </summary>
        void Undo();
    }
}

#region 상속에 대한 추가설명
/*
 * 인터페이스를 상속받는 A,B,C 만들고, 각 타입별로 캐싱한다.
 * 
 */

/* 상속에 대한 선택 : 인터페이스
 
 * 1. 중복코드 방지 (노동 절감)
 * 2. 한가지 타입으로 치환이 필요할 때 (노가다성 한 타입으로 치환)
 * 
 
고민해보기 > 이론상 사용처에 맞게 하자
 * - 인터페이스 : 행위 (기능)이 공유되면 사용
 * - 클래스와 구조체 : 프로퍼티 값만 있는 경우 ( 공유되는 함수 x ) 
 */
#endregion

