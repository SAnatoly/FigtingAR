using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Girl : MonoBehaviour
{

    public int health = 100; // жизнь персонажа
    public int damage = 10; //урон по врагу
    public Transform Fist; // положение кулака

    public Transform target; // положение цели
    public float distance = 1; // расстояние на котором срабатывает удар

    Animator anim; // аниматор

    public Slider healthSlider;

    bool Death; // если умер

    void Start ()
    {
        anim = GetComponent<Animator>(); // получаем компанент аниматор
        healthSlider.value = health;
	}
	
	public void Attack()
    {

        if (Death)
        {
            return;
        }
        anim.SetTrigger("Punch");

        // проверка дистанции до врага, если она меньше DamageDistance то наносим урон
        if (Vector3.Distance(Fist.position, target.position) <= distance)
            DealDamage();

        
    }

    // наносит урон цели
    public void DealDamage()
    {
        if (target.GetComponentInChildren<Renderer>().enabled == false)
        {
            return;
        }
        // Girl enemy = target.GetComponent<Girl>(); 
        var enemy = target.GetComponent<Girl>();
        if (enemy != null)
        {

            enemy.health -= damage;
            enemy.healthSlider.value = enemy.health; // изменяет жизнь врага на слайдоре

            if (enemy.health <= 0)
            {
                enemy.Die();
            }
        }
    }


    public void Die()
    {
        anim.SetBool("Death", true);
        Death = true;
    }

	void Update ()
    {
		
	}
}
