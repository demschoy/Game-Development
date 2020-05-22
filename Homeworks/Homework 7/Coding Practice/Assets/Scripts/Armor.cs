using UnityEngine;
using static UnityEngine.Mathf;

public class Armor : MonoBehaviour
{
    [SerializeField]
    private int armor = 100;

    private Animator animator = null;
    
    public void TakeArmorDamage()
    {
        int damage = 10;
        armor = Max(armor - damage, 0);
        animator.SetInteger("Armor", armor);
        animator.SetTrigger("TookArmorDamage");
    }

    public int GetArmor()
    {
        return armor;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != transform && collision.gameObject.CompareTag("Hitbox"))
        {
            TakeArmorDamage();
        }
    }
}
