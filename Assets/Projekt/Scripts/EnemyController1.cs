using UnityEngine;
using System.Collections;

public class EnemyController1 : MonoBehaviour
{
  private float walkspeed;
  Animator enemy1Animation;
  private bool faceright = true;
  private bool isdead = false;
  private int d_cont = 0;
  public bool isHit = false;
  public GameObject mucus_area;
  private bool twinkled = false;
  private float speed = 2f;
  private bool isNear = false;
  private bool objetive = false;
  private GameObject pj_;

  public bool attack = false;
  public bool is_attacking = false;

  private float lifebarValue = 0;
  public GameObject lifebar;
  public GameObject lifebar_group;

  private PlayerStats playerstats;
  public int expToGive;

  void Start() {
    lifebarValue = lifebar.GetComponent<Renderer>().bounds.size.x;
    playerstats = FindObjectOfType<PlayerStats>();

    enemy1Animation = this.gameObject.GetComponent<Animator>();
    enemy1Animation.SetBool("walk", false);
    enemy1Animation.SetBool("down_attack", false);
    enemy1Animation.SetBool("normal_attack", false);
    enemy1Animation.SetBool("up_attack", false);
  }
  // Abfragen der Collider zum triggern von events wie z.B "attack"
  void OnTriggerEnter2D(Collider2D other) {
    if (other.name == "Area") {
      isHit = true;
    }
    if (other.name == "Activation_Area") {
      objetive = true;
      pj_ = other.gameObject;
    }
  }

  void OnCollisionEnter2D(Collision2D coll) {
    isNear = true;
    attack = true;
  }

  void OnCollisionExit2D(Collision2D coll) {
    attack = false;
    is_attacking = false;
    Invoke("Go_", 2f);
  }

  void FixedUpdate() {
    if (attack && !is_attacking) {
      is_attacking = true;
      mucus_area.GetComponent<Collider2D>().enabled = true;
      Invoke("Attack_", 0.5f);
    }
    if (isHit) {
      if ((d_cont < 8) && (twinkled == false)) {
        d_cont++;
        twinkled = true;
        Invoke("Twinkle_", 0.1f);
      }
      if (d_cont == 8) {
        Life_Down();//Angabe von Schaden in dem Fall 1/4 Energie
        d_cont = 0;
        isHit = false;
      }
    }
  }

  // Update wird einmal pro Frame durchgeführt
  void Update() {
    if (objetive) {
      float step = speed * Time.deltaTime;
      enemy1Animation.SetBool("walk", true);
      if (isNear) {
        step = 0;
        enemy1Animation.SetBool("walk", false);
      }
      if ((pj_.transform.position.x < this.gameObject.transform.position.x) && (faceright == true)) {
        Flip();
      } else {
        if ((pj_.transform.position.x > this.gameObject.transform.position.x) && (faceright == false)) {
          Flip();
        }
      }
      transform.position = Vector3.MoveTowards(transform.position, pj_.transform.position, step);
    }

    Lifebar_Dead();
  }
  //--Für den Angriff
  void Attack_() {
    mucus_area.GetComponent<Collider2D>().enabled = false;
    Invoke("Attack_Delay", 2.5f);
  }

  void Attack_Delay() {
    is_attacking = false;
  }

  void Twinkle_() {
    SpriteRenderer pj_renderer = this.gameObject.GetComponent<SpriteRenderer>();
    pj_renderer.enabled = !pj_renderer.enabled;
    twinkled = false;
  }

  void Go_() {
    isNear = false;
  }

  void Flip() {
    faceright = !faceright;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;

    theScale = lifebar_group.transform.localScale;
    theScale.x *= -1;
    lifebar_group.transform.localScale = theScale;
  }

  void Lifebar_Dead() {
    if ((lifebar.GetComponent<Renderer>().bounds.size.x <= 0) || (lifebar.transform.localScale.x <= 0)) {
      this.gameObject.GetComponent<Collider2D>().enabled = false;
      this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
      isdead = true;
      Destroy(this.gameObject);
      playerstats.AddExperience(expToGive);
    }
  }
  void Life_Down() {
    float aux_c = lifebar.GetComponent<Renderer>().bounds.size.x;
    lifebar.transform.localScale += new Vector3(-lifebarValue / 4, 0, 0);
    Vector3 auxve = new Vector3(lifebar.transform.position.x, lifebar.transform.position.y, lifebar.transform.position.z);
    auxve.x = auxve.x - (aux_c - lifebar.GetComponent<Renderer>().bounds.size.x) / 2;
    lifebar.transform.position = auxve;
  }

}
