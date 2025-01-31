using System.Collections.Generic; // ѕодключаем пространство имен дл€ работы со списками
using UnityEngine; 

public class SpawnGrounds : MonoBehaviour 
{
    public GameObject[] grounds;        // ћассив префабов участков земли
    private List<GameObject> groundsList = new List<GameObject>(); // —писок дл€ хранени€ сгенерированных участков земли

    private float spawnPos = 0;         // ѕозици€ дл€ спавна следующего участка земли
    private float groundLength = 100;   // ƒлина одного участка земли

    public Transform player;            // —сылка на игрока
    private int startGround = 6;        //  оличество начальных участков земли

    void Start()
    {
        // √енерируем начальные участки земли
        for (int i = 0; i < startGround; i++)
        {
            // √енерируем участок земли с случайным индексом из массива grounds
            Spawn(Random.Range(0, grounds.Length));
        }
    }

    // ћетод дл€ генерации нового участка земли
    void Spawn(int index)
    {
        // —оздаем новый участок земли на основе префаба из массива grounds по индексу
        GameObject nextGround = Instantiate(grounds[index], transform.forward * spawnPos, transform.rotation);
        // ƒобавл€ем новый участок земли в список groundsList
        groundsList.Add(nextGround);
        // ”величиваем spawnPos на длину участка земли дл€ следующей генерации
        spawnPos += groundLength;
    }

    // ћетод дл€ удалени€ самого первого участка земли
    void DestroyGrounds()
    {
        // ”дал€ем самый первый участок земли из списка groundsList
        Destroy(groundsList[0]);
        // ”дал€ем самый первый участок земли из списка groundsList
        groundsList.RemoveAt(0);
    }

    void Update() // ћетод, вызываемый каждый кадр
    {
        // ѕровер€ем, находитс€ ли игрок за пределами текущего участка земли
        if (player.position.z - 100 > spawnPos - (startGround * groundLength))
        {
            // √енерируем случайный индекс дл€ следующего участка земли
            Spawn(Random.Range(0, grounds.Length));
            // ”дал€ем самый первый участок земли
            DestroyGrounds();
        }
    }
}
