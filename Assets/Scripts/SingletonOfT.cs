using System;
using UnityEngine;


/// <summary>
/// 싱글톤 클래스 : 한 개만 존재해야한다. 중복시 삭제 / 예외처리해야한다 (미구현)
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonOfT<T> : MonoBehaviour
    where T : MonoBehaviour
{
    private static T _instance;

    public static T instance
    { 
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindAnyObjectByType<T>();

                if (_instance == null)
                {
                    Debug.LogError($"There's no object with type {typeof(T)} in this scene");
                }
            }

            return _instance;
        }

    }
}

