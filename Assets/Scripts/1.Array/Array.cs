using System;
using UnityEngine;

namespace DataStructure.Array
{

    /// <summary>
    /// Generic ���·� ���� ���¸� �����ϱ� ����
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public struct Array<T>
    {
        /// <summary>
        /// �ڷ� �������
        /// </summary>
        [UnityEngine.SerializeField]
        private T[] _data;

        /// <summary>
        /// �⺻ �迭�� ũ������ = 5
        /// </summary>
        private const int _defaultLength = 5;

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="size"></param>
        public Array(int size)
        {
            _data = size == 0 ? new T[_defaultLength] : new T[size];//���׿�����
                                                                    //���ÿ��� ���� �����ϴ� �ּҰ��� ������ ����
        }

        /// <summary>
        /// GetSet ������Ƽ
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return _data[index]; }
            set { }
        }

        /// <summary>
        /// ���� ������Ƽ
        /// </summary>
        public int Length
        {
            get
            {
                if (_data == null)//���� �� ����
                {
                    _data = new T[_defaultLength];
                }

                return _data.Length;
            }
        }
    }

    public class Array : MonoBehaviour
    {

        /// <summary>
        /// �ε��� + ���׸�
        /// </summary>
        static void Create02()
        {
            //�迭 ����
            int length = 10;
            Array<int> arr = new Array<int>(length);

            //������ ���� : �� �Ҵ�
            for (int ix = 0; ix < arr.Length; ix++)
            {
                arr[ix] = ix + 1;
            }

            //������ �б� : ���
            for (int ix = 0; ix < arr.Length; ix++)
            {
                Console.WriteLine($"{ix}��° : {arr[ix]}");
            }

            /*
            foreach (var element in arr)//Enumerator �����ؾ� Foreach �� ����� �� �ִ�.
            { 

            }
            */

            Console.ReadKey();//�ٷ� ������� �ʵ��� �߰�
        }
    }

}