
using System.Windows.Input;
using UnityEditor.ShaderGraph;
using UnityEngine;
using DataStructure.Stack;
//ICommand = DataStucture.Stack.ICommand;

namespace DataStructure.Stack
{
    /// <summary>
    /// 취소와 재실행에 대한 CommandManager
    /// </summary>
    public class CommandManager : SingletonOfT<CommandManager>
    {
        /// <summary>
        /// 스택 (Undo 스택)
        /// </summary>
        private Stack<ICommand> _undos;

        /// <summary>
        /// 스택 (Redo 스택)
        /// </summary>
        private Stack<ICommand> _redos;

        // Shift키 가 눌렸는지 확인하는 변수
        private bool isShift = false;

        private void Awake()
        {
            //캐싱
            _undos = new Stack<ICommand>();
            _redos = new Stack<ICommand>();
        }

        private void Update()
        {
            //전처리 하는 법
#if UNITY_EDITOR
            if(Input.GetKey(KeyCode.LeftShift) == true)
            {
                isShift = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) == true)
            {
                isShift = false;
            }

            if (isShift == true && Input.GetKeyDown(KeyCode.Z))
            {
                Undo();
            }

            if (isShift == true && Input.GetKeyDown(KeyCode.R))
            {
                Redo();
            }
#elif UNITY_STANDALONE_WIN
#endif
        }

        /// <summary>
        /// 명령 추가 함수
        /// </summary>
        /// <param name="newCommand">새로 추가할 명령</param>
        public void AddCpmmand(ICommand newCommand)
        {
            //새로 추가한 명령을 실행한 후에 undo스택에 추가
            newCommand.Excute();
            _undos.Push(newCommand);

        }
        //Undo 함수
        public void Undo()
        {
            if (_undos.IsEmpty == true)
            {
                return;
            }

            //제일 마지막에 추가된 명령을 빼내서 Undo 함수 실행
            ICommand command = _undos.Pop();
            command.Undo();
        }
        //Redo 함수
        public void Redo()
        { 
            if(_redos.IsEmpty == true) 
            {
                return;
            }

            ICommand command = _redos.Pop();
            command.Excute();
            _undos.Push(command);
        }
    }
}

#region 설명
/*
 * excute 이동 -> Ctrl +Z -> Undo 이동 -> Ctrl + Shift + z -> Redo 이동
 * 
 */

/* 지금 버전 명령 생성하는 순간 패턴이 깨짐 : 기존 쌓인 명령 체크
 * 1. 인덱스 추적 
 * 2. 아예 새롭게 스택 쌓기
 * 
 */
#endregion
