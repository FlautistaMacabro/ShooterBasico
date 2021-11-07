using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] AudioClip deadFx;
    GameObject player;
    Animator anim;

    AudioSource EnemyFx;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        anim = GetComponentsInChildren<Animator>()[0];
        EnemyFx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null && isAlive){
            Aim();
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
    private void Aim(){
        Vector2 offset = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle-90);
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Bullet")){
            anim.SetTrigger("Dead");
            isAlive = false;
            EnemyFx.PlayOneShot(deadFx);
            Destroy(gameObject, 0.5f);
        }
    }
}
