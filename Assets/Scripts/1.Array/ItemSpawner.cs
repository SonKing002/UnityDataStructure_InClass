using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject prefab;//생성할 프리펩

    public const int itemSpawnLimit = 5; //고정 크기

    public Array<GameObject> items; //배열

    public float startPositionX = -5f;//물체 생성 초기 x 위치

    private int _itemCount = 0;//물체 수를 체크하기 위한 변수

    private void Awake()
    {
        //배열 생성
        items = new Array<GameObject>(itemSpawnLimit);// 배열 생성
    }

    /// <summary>
    /// 물체 생성 메서드
    /// </summary>
    private void SpawnItem()
    {
        #region
        /* 1. 생성이 가능한가
         *
         *
         */

        //물체가 생성조건 == 공간이 있어야 하고, 카운트가 범위내 있어야 함
        if (prefab != null && _itemCount < itemSpawnLimit)
        {
            items[_itemCount++] = Instantiate(
                prefab, 
                new Vector3(startPositionX * _itemCount *1.5f,0,0 ), //
                Quaternion.identity
                );
            Debug.Log("<color=green> Success To Create new Item </color>");
            return;
        }

        Debug.Log("<color=red>Failed to Create new Item..</color>");
        #endregion

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnItem();
        }
    }
}
//특정한 상황이 아니라면 Awake를 Default로 사용하는 것이 좋다.