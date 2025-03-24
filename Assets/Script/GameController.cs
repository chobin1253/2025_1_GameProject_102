using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer = 1.0f;
    public GameObject EnemyObject;

    void Update()
    {
        Timer -= Time.deltaTime;            //�ð��� �� �����Ӹ��� ���� ��Ų�� (deltaTime ������ ������ �ð��� �ǹ��մϴ�)

        if (Timer <= 0)                    //���� Timer�� ��ġ�� 0���Ϸ� ������ ��� (1�ʸ��� ���۵Ǵ� �ൿ�� ���鶧)
        {
            Timer = 1;

            GameObject Temp = Instantiate(EnemyObject);
            Temp.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        }
            if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //Debug.Log($"hit : {hit.collider.name}");
                    hit.collider.gameObject.GetComponent<Enemy>().CharacterHit(30);
                }
            }
        }
    }
}
