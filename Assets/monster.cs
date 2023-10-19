using UnityEngine;
using System.Collections;

public class grabberscript : MonoBehaviour
{
	private Animator animator;
	private float attackInterval = 3.75f; 
	private bool isAttacking = false;
    public GameObject bomb;
    public float throwForceLeft = 10f; 
    public float throwForceUp = 10f;
    public int bombsize = 5;
    public GameObject healcircle;
    public count_score monster_life_change;
    public int throwup_min=5;
    public int throwup_max=15;
    public int throwleft_min=5;
    public int throwleft_max=15;
    public bool heal_or_not = false;

    // Use this for initialization
    void Start()
	{
		animator = GetComponent<Animator>();
        //  rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("heallife", 30f, 30f);
        InvokeRepeating("Attack", attackInterval, attackInterval);

	}
    public void heallife()
    {
        if(heal_or_not)
        {
            monster_life_change.plus_monster_life();
            healcircle.SetActive(true);
            StartCoroutine(wait_for_heal());
        }
       
    }
    IEnumerator wait_for_heal()
    {
        yield return new WaitForSeconds(3f);
        healcircle.SetActive(false) ;
    }
    // Update is called once per frame
    private void Attack()
    {
        if (!isAttacking)
        {

            animator.SetInteger("state", 1);
           // Debug.Log("1");
            isAttacking = true;
            StartCoroutine(ResetAttack());
        }
    }

    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(1.25f);
        ThrowBomb();
       // Debug.Log("2");
        animator.SetInteger("state", 0);
        isAttacking = false;
    }

    void ThrowBomb()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 5, 0); // 新的生成位置
       // Debug.Log("3");
        for (int i = 0; i < bombsize; i++)
        { 
            GameObject newBomb = Instantiate(bomb, spawnPosition, Quaternion.identity);
            newBomb.SetActive(true);
            Rigidbody2D rb = newBomb.GetComponent<Rigidbody2D>();
             Vector2 throwDirection = new Vector2(-1, 1).normalized;
             throwForceUp = Random.Range(throwup_min, throwup_max);
             throwForceLeft = Random.Range(throwleft_min, throwleft_max);
            throwDirection.x *= throwForceLeft;
             throwDirection.y *= throwForceUp;
             rb.AddForce(throwDirection, ForceMode2D.Impulse);

        }
       

    }


}