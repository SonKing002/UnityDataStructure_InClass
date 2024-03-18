using UnityEngine;

public class ItemSpawnerWithPool : MonoBehaviour
{
    void Update()
    {
        // 마우스 왼쪽 버튼을 클릭하면, 오브젝트 풀에서 미리 생성해둔 아이템을 가져오는 테스트 진행.
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newItem = ObjectPool.instance.PopFromPool("Item");
            newItem.transform.localPosition = Vector3.zero;
            newItem.SetActive(true);
        }
    }
}
