using UnityEngine;

namespace DataStructure
{
    /// <summary>
    /// �Է¿� �����ϴ� �޴���
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// Ⱦ�̵�
        /// </summary>
        public static float Horizontal { get; private set; } = 0f;
        /// <summary>
        ///  ���̵�
        /// </summary>
        public static float Vertical { get; private set; } = 0f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Horizontal = -1f;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Horizontal = 1f;
            }
            if (!Input.GetKeyDown(KeyCode.A) && !Input.GetKeyDown(KeyCode.D))
            {
                Horizontal = 0f;
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Vertical = 1f;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vertical = -1f;
            }
            if (!Input.GetKeyDown(KeyCode.W) && !Input.GetKeyDown(KeyCode.S))
            {
                Vertical = 0f;
            }
        }
    }
}