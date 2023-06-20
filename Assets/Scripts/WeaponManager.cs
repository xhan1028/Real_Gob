using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
   public int id;
   public int prefabId;
   public float damage;
   public int count;
   public float speed;

   float timer;
   Chr_Move chr_move;

   void Awake()
   {
		  chr_move = GameManager.instance.chr_move;
   }
   void Update()
   {
		if (!GameManager.instance.isLive)
            return;

		switch (id)
		{
			case 0:
				transform.Rotate(Vector3.forward * speed * Time.deltaTime);
				break;
			default:
				timer += Time.deltaTime;
				if (timer > speed)
				{
					timer = 0f;
					Tane();
				}
				break;
		}

		//if (Input.GetButtonDown("Jump"))
	//	{
			//LevelUp(5, 1);
		//}
   }

   public void LevelUp(float damage, int count)
   {
		  this.damage = damage;
		  this.count += count;

		  if (id == 0)
			 zizeung();
   }

   public void Init(ItemData data)
   {
		name = "Weapon " + data.itemId;
		transform.parent = chr_move.transform;
		transform.localPosition = Vector3.zero;

		id = data.itemId;
		damage = data.baseDamage;
		count = data.baseCount;

		for (int index=0; index < GameManager.instance.pool.prefabs.Length; index++)
		{
			if (data.projectile == GameManager.instance.pool.prefabs[index])
			{
				prefabId = index;
				break;
			}
		}

		switch (id)
		{
			case 0:
				speed = -150;
				zizeung();
				break;
			default:
				speed = 0.3f;
				break;
		}
   }

   void zizeung()
   {
		for (int index=0; index < count; index++)
		{
			Transform sword;

			if (index < transform.childCount)
			{
				sword = transform.GetChild(index);
			}
			else
			{
				sword = GameManager.instance.pool.Get(prefabId).transform;
				sword.parent = transform;
			}

			sword.localPosition = Vector3.zero;
			sword.localRotation = Quaternion.identity;

			Vector3 rotVec = Vector3.forward * 360 * index / count;
			sword.Rotate(rotVec);
			sword.Translate(sword.up * 1.5f, Space.World);
			sword.GetComponent<Sword>().Init(damage, -1, Vector3.zero);
		}
   }

   void Tane()
   {
		if(!chr_move.scanner.nearestTarget)
			return;

		Vector3 targetPos = chr_move.scanner.nearestTarget.position;
		Vector3 dir = targetPos - transform.position;
		dir = dir.normalized;

		Transform sword = GameManager.instance.pool.Get(prefabId).transform;
		sword.position = transform.position;
		sword.rotation = Quaternion.FromToRotation(Vector3.up, dir); // È¸Àü
		sword.GetComponent<Sword>().Init(damage, count, dir);
   }
}
