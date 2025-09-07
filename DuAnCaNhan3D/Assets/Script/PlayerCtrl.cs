using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float radius;
    public List<string> enemyTags;       // list các tag enemy
    public float attackCooldown = 1f;    // thời gian hồi chiêu
    private float attackTimer;

    PlayerMove playermove;
    private void Start()
    {
        playermove = GameObject.Find("Player/PlayerMove").GetComponent<PlayerMove>();
    }
    private void Update()
    {
        attackTimer -= Time.deltaTime;

        // khi player di chuyển thì check
        DetectAndAttack();
    }

    void DetectAndAttack()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        foreach (Collider hit in hits)
        {
            if (enemyTags.Contains(hit.tag)) // kiểm tra có tag enemy không
            {
                if (attackTimer <= 0f)
                {
                    AttackEnemy(hit.gameObject);
                    attackTimer = attackCooldown;
                }
            }
        }
    }

    void AttackEnemy(GameObject enemy)
    {
        Debug.Log("Tấn công enemy: " + enemy.name);
        // Xoay mặt về phía enemy
        Vector3 direction = (enemy.transform.position - transform.position).normalized;
        direction.y = 0; // giữ player không bị ngẩng/nhìn xuống
        if (direction != Vector3.zero)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 80f);
        }
        playermove.animator.SetTrigger("isAttack");

    }

    // Vẽ phạm vi radius trong Scene cho dễ debug
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

}
