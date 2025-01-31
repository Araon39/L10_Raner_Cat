using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Объект CharacterController, который будет управлять персонажем
    private CharacterController controller;

    // Скорость перемещения персонажа
    private int speed = 3;

    // Переменная для определения линии, по которой будет перемещаться персонаж
    private int lineToMove = 1;

    // Расстояние между линиями
    private float lineDistance = 3;

    // Метод Start вызывается перед первым обновлением кадра
    void Start()
    {
        // Получаем компонент CharacterController, прикрепленный к этому GameObject
        controller = GetComponent<CharacterController>();
    }

    // Метод FixedUpdate вызывается с фиксированной частотой
    private void FixedUpdate()
    {
        // Перемещаем персонажа вперед с учетом скорости и времени, прошедшего с последнего кадра
        controller.Move(Vector3.forward * Time.deltaTime * speed);
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша "D"
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Если lineToMove меньше 2, увеличиваем его на 1
            if (lineToMove < 2)
            {
                lineToMove++;
            }
        }

        // Проверяем, нажата ли клавиша "A"
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Если lineToMove больше 0, уменьшаем его на 1
            if (lineToMove > 0)
            {
                lineToMove--;
            }
        }

        // Вычисляем целевую позицию на основе текущей позиции и направления
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        // Если lineToMove равно 0, смещаем целевую позицию влево на lineDistance
        if (lineToMove == 0)
        {
            targetPosition += Vector3.left * lineDistance;
        }
        // Если lineToMove равно 2, смещаем целевую позицию вправо на lineDistance
        else if (lineToMove == 2)
        {
            targetPosition += Vector3.right * lineDistance;
        }

        // Устанавливаем новую позицию объекта
        transform.position = targetPosition;
    }

}
