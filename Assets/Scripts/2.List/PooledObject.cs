using System;
using System.Runtime.CompilerServices;
using DataStructure.List;
using UnityEngine;//우리가 작성한 list 사용하기 위함

/// <summary>
/// 구현된 object
/// </summary>
public class PooledObject : MonoBehaviour
{
    
    /// <summary>
    ///오브젝트 풀에서 아이템을 식별하기 위한 이름 
    /// </summary>
    public string itemName = string.Empty;//숫자랑 숫자끼리 성능해야한다. string 대 string 비추 (역할: 해시 함수)

    /// <summary>
    /// 아이템을 생성할 때 부모로 지정할 트랜스폼
    /// </summary>
    public Transform defaultParantTransform;

    /// <summary>
    /// 생성할 프리펩 참조 변수
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// 에디터에서 지정할 예정 (처음 생성할 아이템의 수)
    /// </summary>
    public int initialPoolCount = 0;

    [SerializeField]
    private List<GameObject> poolList = new List<GameObject>();

    /// <summary>
    /// 초기화 함수
    /// </summary>
    /// <param name="parant"></param>
    public void Initialize(Transform parant = null)
    {
        //예외
        if (initialPoolCount == 0)
        {
            return;
        }
        for (int ix = 0; ix < initialPoolCount; ++ix)//필요한 만큼 생성한 뒤 저장
        { 
            poolList.Add(CreateItem(defaultParantTransform));

        }
    }

    /// <summary>
    /// 아이템 반환 함수
    /// </summary>
    /// <param name="item"></param>
    /// <param name="parent"></param>
    public void PushToPool(GameObject item, Transform parent = null)
    {
        //전달된 부모 트랜스폼이 있으면 설정하고 없으면 기본 부모 트랜스폼을 설정
        item.transform.SetParent(parent == null ? defaultParantTransform : parent);

        //아이템 게임 오브젝트 비활성화
        item.SetActive(false);

        //오브젝트 풀에[ 다시 추가
        poolList.Add(item);
    }

    /// <summary>
    /// 아이템을 구하는 함수
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    public GameObject PopFromPool(Transform parent = null)
    {
        //리스트에 아이템이 없으면 생성 후 추가
        if (poolList.Size == 0)
        { 
            poolList.Add(CreateItem(parent == null? defaultParantTransform: parent));
        }

        //리스트의 첫 번째 아이템을 빼낸 후 반환
        GameObject item = poolList[0];

        //풀에서 제거
        poolList.RemoveAt(0);

        //반환
        return item;
    }

    /// <summary>
    /// 아이템 생성 함수
    /// </summary>
    /// <param name="parent"></param>
    /// <returns></returns>
    private GameObject CreateItem(Transform parent = null)
    {
        //프리펩을 기반으로 게임 오브젝트 생성
        GameObject item = Instantiate(prefab);

        //아이템 이름 및 부모 트랜스폼 설정
        item.name = itemName;
        item.transform.SetParent(parent);

        //생성한 후에는 비활성화
        item.SetActive(false);

        return item;
    }
}
/*
 * 한번 생성해 두면 어느정도 수정이 있어도, 거의 변화가 없다.
 * List
 * 
 */

