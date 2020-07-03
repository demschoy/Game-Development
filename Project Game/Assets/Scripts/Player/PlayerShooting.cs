using UnityEngine;

using static Controllers;

public class PlayerShooting : MonoBehaviour
{
    public Camera fpsCam;
    [SerializeField]
    private float maxSpeed = 25f;
    void Update()
    {
        if (Input.GetKeyDown(FirstPlayerShootKey))
        {
            Shoot();
        }

        if (Input.GetKeyDown(SecondPlayerShootKey))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hitInfo;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward,out hitInfo))
        {
            EnemyHealth enemy = hitInfo.transform.GetComponent<EnemyHealth>();
             
             if(enemy != null)
             {
                  enemy.TakeDamage();
             }
        
        
        }

    }

    
}
