
using UnityEngine;
using System;
using System.Collections;

//충돌 방지용 감싸기
namespace DataStructure
{

    /// <summary>
    /// 직접 구현하는 동적 배열
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]//커스텀자료형 직렬화
    public class List<T> : IEnumerator
    {
        #region 외부 프로퍼티 
        /// <summary>
        /// List의 크기
        /// </summary>
        public int Capacity { get { return _capacity; } }
        //public int Capacity { get; private set; } = 4;//개정됨
        /// <summary>
        /// List에 저장된 요소의 갯수
        /// </summary>
        public int Size { get { return _size; } }


        /// <summary>
        /// 현재 값 위치를 아리키는 변수
        /// </summary>
        public object Current { get => _current; }

        //public int Size { get { return _size; } }
        #endregion

        #region 내부변수

        /// <summary>
        /// 자료공간 저장
        /// </summary>
        [UnityEngine.SerializeField]
        private T[] _data;

        /// <summary>
        /// List에 저장된 요소의 갯수
        /// </summary>
        private int _size = 0;

        /// <summary>
        /// List의 크기
        /// </summary>
        private int _capacity = 4;
        #endregion

        /// <summary>
        /// 현재 인덱스를 가리키는 변수
        /// </summary>
        private int _index;

        /// <summary>
        /// 현재 값의 위치를 가리키는 변수
        /// </summary>
        private T _current;

        /// <summary>
        /// 생성자
        /// </summary>
        public List()
        {
            _data = new T[Capacity];

            _size = 0;
        }

        /// <summary>
        /// 인덱서로 접근
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T this[int index]
        {
            get { return _data[index]; }
        }

        /// <summary>
        /// 요소 1개 데이터 추가 함수
        /// </summary>
        /// <param name="newData"></param>
        public void Add(T newData)
        {
            ///현재 배열이 다 찼으면 새로 할당
            if (_size == _capacity)
            {
                ReAllocate(_capacity * 2); //2배
            }

            //배열에 저장된 제일 마지막 위치에 데이터 추가
            _data[_size] = newData;
            //배열의 크기 1 증가
            _size++;
        }

        /// <summary>
        /// 요소 삭제하는 메서드
        /// </summary>
        /// <param name="removeData"></param>
        /// <returns></returns>
        public bool Remove(T removeData)
        {
            //갯수가 0이라면 삭제를 할 수 없다 : 예외상황
            if (_size == 0)
            {
                //삭제 실패
                return false;
            }

            //삭제할 배열의 인덱스 값
            int targetIndex = -1;

            //검색
            for (int ix = 0; ix < _size; ix++)
            {
                if (_data[ix].Equals(removeData) == true)//찾은 경우
                {
                    targetIndex = ix;
                    break;
                }
            }

            //찾았다면
            if (targetIndex >= 0)
            {
                RemoveAt(targetIndex);//삭제
                return true;
            }

            return false;//존재하지 않음으로 실패

        }

        /// <summary>
        /// 인덱스를 사용하여 삭제하는 함수
        /// </summary>
        /// <param name="targetIndex"></param>
        public void RemoveAt(int targetIndex)
        {
            //실제 갯수 0 이거나, 타겟 인덱스가 유효한지 검사
            if (_size == 0 || targetIndex < 0 || targetIndex >= _size)
            {
                return;//예외 반환
            }

            //데이터 보존에 사용할 인덱스 값
            int listIndex = 0;

            for (int ix = 0; ix < _size; ix++)//검사
            {
                if (ix == targetIndex)//삭제할 인덱스는 스킵
                {
                    continue;
                }//중간 삭제 한다 했을 때 

                //이외 데이터는 누적
                _data[listIndex++] = _data[ix];
                //++listIndex;
            }

            //식제 후 요소 갯수를 감소
            --_size;

            _data[_size] = default(T);//쓰레기 값이 저장되는 것을 방지하기 위함 
        }

        /// <summary>
        /// 배열 재할당 함수 (내부에서 활용)
        /// </summary>
        /// <param name="newCapacity"></param>
        private void ReAllocate(int newCapacity)
        {
            ///<summary>
            ///임시담을 배열생성 : 파라미터의 크기를 할당
            /// </summary>
            T[] newData = new T[newCapacity];

            ///<summary> 공간보다 실제 요소갯수가 많다면 예외처리 : 삭제할 때</summary>
            if (newCapacity < _size)
            {
                _size = newCapacity;
            }//C#은 줄인다.  의미없는 코드

            ///<summary> 기존 데이터 복사, 성능 많이 먹음 </summary>
            for (int ix = 0; ix < _size; ix++)
            {
                newData[ix] = _data[ix];
            }

            ///<summary>내부 배열 바꾸기</summary>
            _data = newData;

            ///<summary> 크기확장 </summary>
            _capacity = newCapacity;
        }

        public bool MoveNext()
        {
            //인덱스 크기가 유효하다면
            if (_index < _size)
            {
                //현재 위치에 대입
                _current = _data[_index++];
                return true;
            }

            return false;
        }

        public void Reset()
        {
            _index = 0;
        }

        /// <summary>
        /// IEnumerator를 반환하는 함수
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            Reset();
            return this;
        }
    }


}