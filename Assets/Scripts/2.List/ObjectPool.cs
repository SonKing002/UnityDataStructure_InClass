using UnityEngine;
using DataStructure.List;
using Unity.VisualScripting;
using System;

// 오브젝트 풀 클래스 (싱글톤으로 선언함).
public class ObjectPool : SingletonOfT<ObjectPool>
{
    // 여러 오브젝트 풀을 관리할 수 있도록 리스트로 관리.
    public List<PooledObject> objectPool;

    void Awake()
    {
        // 시작할 때 자식 게임 오브젝트에서 PooledObject 컴포넌트를 찾아 저장 후 초기화.
        objectPool = new List<PooledObject>();
        PooledObject[] pooledObjects = GetComponentsInChildren<PooledObject>();
        foreach (PooledObject pool in pooledObjects)
        {
            objectPool.Add(pool);
            pool.Initialize();
        }
    }

    private T[] GetComponentsInChildren<T>()
    {
        throw new NotImplementedException();
    }

    // 오브젝트 풀에 반환할 때 사용하는 함수.
    public bool PushToPool(string itemName, GameObject item, Transform parent = null)
    {
        // 풀 오브젝트의 이름으로 오브젝트 풀을 검색한 뒤,
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null)
        {
            return false;
        }

        // 검색된 오브젝트 풀에 반환.
        pool.PushToPool(item, parent);
        return true;
    }

    // 이름 값으로 아이템을 가져올 때 사용.
    public GameObject PopFromPool(string itemName, Transform parent = null)
    {
        // 이름으로 오브젝트 풀을 검색 후 성공하면 해당 오브젝트를 반환함.
        PooledObject pool = GetPoolItem(itemName);
        if (pool == null)
        {
            Debug.Log("PopFromPool return null");
            return null;
        }

        return pool.PopFromPool(parent);
    }

    // 이름 값으로 오브젝트 풀을 검색할 때 사용하는 함수.
    // 루프로 배열을 
    PooledObject GetPoolItem(string itemName)
    {
        foreach (PooledObject pool in objectPool)
        {
            if (pool.itemName.Equals(itemName) == true)
            {
                return pool;
            }
        }

        Debug.LogWarning("There's no matched pool list.");
        return null;
    }
}