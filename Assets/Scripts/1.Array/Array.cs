using System;
using UnityEngine;

namespace DataStructure.Array
{

    /// <summary>
    /// Generic 형태로 여러 형태를 대입하기 위함
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [System.Serializable]
    public struct Array<T>
    {
        /// <summary>
        /// 자료 저장공간
        /// </summary>
        [UnityEngine.SerializeField]
        private T[] _data;

        /// <summary>
        /// 기본 배열의 크기지정 = 5
        /// </summary>
        private const int _defaultLength = 5;

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="size"></param>
        public Array(int size)
        {
            _data = size == 0 ? new T[_defaultLength] : new T[size];//삼항연산자
                                                                    //스택에서 힙을 참조하는 주소값을 가지고 있음
        }

        /// <summary>
        /// GetSet 프로퍼티
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return _data[index]; }
            set { }
        }

        /// <summary>
        /// 길이 프로퍼티
        /// </summary>
        public int Length
        {
            get
            {
                if (_data == null)//없을 때 조건
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
        /// 인덱서 + 제네릭
        /// </summary>
        static void Create02()
        {
            //배열 생성
            int length = 10;
            Array<int> arr = new Array<int>(length);

            //데이터 쓰기 : 값 할당
            for (int ix = 0; ix < arr.Length; ix++)
            {
                arr[ix] = ix + 1;
            }

            //데이터 읽기 : 출력
            for (int ix = 0; ix < arr.Length; ix++)
            {
                Console.WriteLine($"{ix}번째 : {arr[ix]}");
            }

            /*
            foreach (var element in arr)//Enumerator 구현해야 Foreach 문 사용할 수 있다.
            { 

            }
            */

            Console.ReadKey();//바로 종료되지 않도록 추가
        }
    }

}