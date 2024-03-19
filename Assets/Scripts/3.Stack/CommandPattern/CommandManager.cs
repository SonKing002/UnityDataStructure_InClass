
using System.Windows.Input;
using UnityEditor.ShaderGraph;
using UnityEngine;
using DataStructure.Stack;
//ICommand = DataStucture.Stack.ICommand;

namespace DataStructure.Stack
{
    /// <summary>
    /// ��ҿ� ����࿡ ���� CommandManager
    /// </summary>
    public class CommandManager : SingletonOfT<CommandManager>
    {
        /// <summary>
        /// ���� (Undo ����)
        /// </summary>
        private Stack<ICommand> _undos;

        /// <summary>
        /// ���� (Redo ����)
        /// </summary>
        private Stack<ICommand> _redos;

        // ShiftŰ �� ���ȴ��� Ȯ���ϴ� ����
        private bool isShift = false;

        private void Awake()
        {
            //ĳ��
            _undos = new Stack<ICommand>();
            _redos = new Stack<ICommand>();
        }

        private void Update()
        {
            //��ó�� �ϴ� ��
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
        /// ��� �߰� �Լ�
        /// </summary>
        /// <param name="newCommand">���� �߰��� ���</param>
        public void AddCpmmand(ICommand newCommand)
        {
            //���� �߰��� ����� ������ �Ŀ� undo���ÿ� �߰�
            newCommand.Excute();
            _undos.Push(newCommand);

        }
        //Undo �Լ�
        public void Undo()
        {
            if (_undos.IsEmpty == true)
            {
                return;
            }

            //���� �������� �߰��� ����� ������ Undo �Լ� ����
            ICommand command = _undos.Pop();
            command.Undo();
        }
        //Redo �Լ�
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

#region ����
/*
 * excute �̵� -> Ctrl +Z -> Undo �̵� -> Ctrl + Shift + z -> Redo �̵�
 * 
 */

/* ���� ���� ��� �����ϴ� ���� ������ ���� : ���� ���� ��� üũ
 * 1. �ε��� ���� 
 * 2. �ƿ� ���Ӱ� ���� �ױ�
 * 
 */
#endregion
