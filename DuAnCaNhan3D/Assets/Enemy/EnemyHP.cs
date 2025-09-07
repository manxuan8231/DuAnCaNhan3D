using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    Animator animator;
    public int hp = 1;
    public List<ItemDrop> dropItems;  // danh sách item có thể rớt
    public Transform dropPoint;
    BoxCollider box;
    private void Start()
    {
        animator = GetComponent<Animator>();
        box = GetComponent<BoxCollider>();
        
    }
    public void TakeDame()
    {
        hp--;
        box.enabled = false;
        animator.SetTrigger("Death");
        Drop();
        Destroy(gameObject, 2f);

    }
    public void Drop()
    {
        float randomValue = Random.Range(0f, 100f);
        float current = 0f;

        foreach (ItemDrop drop in dropItems)
        {
            current += drop.dropChance;
            if (randomValue <= current)
            {
                if (drop.itemPrefab != null)
                {
                    Instantiate(drop.itemPrefab, dropPoint.position, Quaternion.identity);
                    Debug.Log("Drop item: " + drop.itemPrefab.name);
                }
                return; // rớt 1 item xong thì thoát luôn
            }
        }

        Debug.Log("Không rớt item nào!");
    }
}
[System.Serializable]
public class ItemDrop
{
   [UnityEngine.Range(0, 100)]
    public float dropChance; // % tỉ lệ rớt
    public GameObject itemPrefab;


}
