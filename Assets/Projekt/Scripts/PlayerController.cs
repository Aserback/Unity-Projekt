using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  public static string PLAYER_NAME = "Paladin";

  private float walkspeed = 5;
  Animator playerAnimation;
  private bool isFacingRight = true;
  private bool isDead = false;
  private int actual_layer = 0;
  private int d_cont = 0;
  public bool isHit = false;
  private bool hasTwinkled = false;
  private bool isHealing = false;

  public GameObject bot_arc;
  public GameObject top_arc;
  public GameObject normal_arc;
  public GameObject area;

  public Sprite basicArcImage;
  public Sprite greenArcImage;
  public Sprite pinkArcImage;

  public GameObject Lifebar;
  public GameObject Lifebar_group;
  private float lifebarValue = 0;
  private Vector3 initial_localscale;

  private static bool playerExists;
  public string startPoint;

  private PlayerStats playerStats;
  public string levelToLoad;

  private SFXManager sfxManager;

  private void Start() {
    sfxManager = FindObjectOfType<SFXManager>();

    lifebarValue = Lifebar.GetComponent<Renderer>().bounds.size.x;
    initial_localscale = new Vector3(Lifebar.transform.localScale.x, Lifebar.transform.localScale.y, Lifebar.transform.localScale.z);

    // avoids duplicate players when changing scene
    if (!playerExists) {
      playerExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else
      Destroy(gameObject);

    playerAnimation = this.gameObject.GetComponent<Animator>();
    Set_Layer();
    playerAnimation.SetBool("walk", false);//Laufanimnation deaktiviert
    playerAnimation.SetBool("down", false);//Sterbeanimation deaktiviert
    playerAnimation.SetBool("up", false);//Sprunganimation deaktiviert
    playerAnimation.SetBool("down_attack", false);
    playerAnimation.SetBool("up_attack", false);
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.name == "Mucus_Area")
      isHit = true;
  }


  void FixedUpdate() {
    if (!isHealing && !isHit && !isDead) {
      isHealing = true;
      Invoke("Healing_", 5f);
    }
    if (isHit) {
      if ((d_cont < 8) && (!hasTwinkled)) {
        d_cont++;
        hasTwinkled = true;
        Invoke("Twinkle_", 0.1f);
      }
      if (d_cont == 8) {
        Life_Down();
        d_cont = 0;
        isHit = false;
      }
    }
  }





  private void Update() {
    if (isDead) {
      playerAnimation.SetBool("dead", true);
      this.gameObject.GetComponent<Collider2D>().enabled = false;
      this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

      Lifebar_Dead();
    } else {
      setAttackStatus();
      GetKeyboardInputs();
      GetMouseInputs();
      CheckWalkDirections();
    }
  }

  private void Set_Layer() {
    switch (actual_layer) {
      case 0:
        Set_Arc_Color(basicArcImage);
        playerAnimation.SetLayerWeight(0, 1f);
        playerAnimation.SetLayerWeight(1, 0f);
        playerAnimation.SetLayerWeight(2, 0f);
        break;
      case 1:
        Set_Arc_Color(greenArcImage);
        playerAnimation.SetLayerWeight(1, 1f);
        playerAnimation.SetLayerWeight(0, 0f);
        playerAnimation.SetLayerWeight(2, 0f);
        break;
      case 2:
        Set_Arc_Color(pinkArcImage);
        playerAnimation.SetLayerWeight(2, 1f);
        playerAnimation.SetLayerWeight(1, 0f);
        playerAnimation.SetLayerWeight(0, 0f);
        break;
    }
  }

  void ChangeLevel() {
    SceneManager.LoadScene(levelToLoad);
  }


  void Activate_arc_down() {
    bot_arc.SetActive(true);
  }
  void Activate_arc_up() {
    top_arc.SetActive(true);
  }
  void activate_arc_normal() {
    normal_arc.SetActive(true);
  }
  void Flip() {
    isFacingRight = !isFacingRight;
    Vector3 theScale = transform.localScale;
    theScale.x *= -1;
    transform.localScale = theScale;

    theScale = Lifebar_group.transform.localScale;
    theScale.x *= -1;
    Lifebar_group.transform.localScale = theScale;
  }

  void Set_Arc_Color(Sprite auxsprite) {
    SpriteRenderer top = top_arc.GetComponent<SpriteRenderer>();
    SpriteRenderer normal = normal_arc.GetComponent<SpriteRenderer>();
    SpriteRenderer bot = bot_arc.GetComponent<SpriteRenderer>();
    top.sprite = auxsprite;
    normal.sprite = auxsprite;
    bot.sprite = auxsprite;
  }

  void Lifebar_Dead() {
    if (!isDead) {
      if ((Lifebar.GetComponent<Renderer>().bounds.size.x <= 0) || (Lifebar.transform.localScale.x <= 0)) {
        playerAnimation.SetBool("dead", true);
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        isDead = true;
        CheckWalkDirections();
        Destroy(Lifebar_group);
        sfxManager.playerDead.Play();
        Invoke("ChangeLevel", 1.9f);
      }
    }
  }

  void Life_Down() {
    float aux_c = Lifebar.GetComponent<Renderer>().bounds.size.x;
    Lifebar.transform.localScale += new Vector3(-lifebarValue / 4, 0, 0);
    Vector3 auxve = new Vector3(Lifebar.transform.position.x, Lifebar.transform.position.y, Lifebar.transform.position.z);
    auxve.x = auxve.x - (aux_c - Lifebar.GetComponent<Renderer>().bounds.size.x) / 2;
    Lifebar.transform.position = auxve;
  }

  void Healing_() {
    if (!isDead) {
      if (Lifebar.transform.localScale.x > 0) {
        float aux_c = Lifebar.GetComponent<Renderer>().bounds.size.x;
        if (Lifebar.transform.localScale.x + lifebarValue / 8 >= initial_localscale.x) {
          Lifebar.transform.localScale = new Vector3(initial_localscale.x, initial_localscale.y, initial_localscale.z);
        } else {
          Lifebar.transform.localScale += new Vector3(+lifebarValue / 8, 0, 0);
        }
        Vector3 auxve = new Vector3(Lifebar.transform.position.x, Lifebar.transform.position.y, Lifebar.transform.position.z);
        auxve.x = auxve.x - (aux_c - Lifebar.GetComponent<Renderer>().bounds.size.x) / 2;
        Lifebar.transform.position = auxve;
      }
    }
    isHealing = false;
  }

  private void Twinkle_() {
    SpriteRenderer pj_renderer = this.gameObject.GetComponent<SpriteRenderer>();
    pj_renderer.enabled = !pj_renderer.enabled;
    hasTwinkled = false;
  }
  private void setAttackStatus() {
    if (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Down_Attack")) {
      Invoke("activate_arc_down", 0.1f);
    } else {
      playerAnimation.SetBool("down_attack", false);
      bot_arc.SetActive(false);
      area.GetComponent<Collider2D>().enabled = false;
    }
    if (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Up_Attack")) {
      Invoke("activate_arc_up", 0.1f);
    } else {
      playerAnimation.SetBool("up_attack", false);
      top_arc.SetActive(false);
      area.GetComponent<Collider2D>().enabled = false;
    }
    if (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Normal_Attack")) {
      Invoke("activate_arc_normal", 0.2f);
    } else {
      playerAnimation.SetBool("attack", false);
      normal_arc.SetActive(false);
      area.GetComponent<Collider2D>().enabled = false;
    }
  }

  private void GetKeyboardInputs() {
    if (Input.GetKeyUp("5")) {
      isHit = true;
    }
    //--Gun bzw. Tastatureingabe
    if (Input.GetKeyUp("1")) {
      actual_layer = 0;
      Set_Layer();
    }
    if (Input.GetKeyUp("2")) {
      actual_layer = 1;
      Set_Layer();
    }
    if (Input.GetKeyUp("3")) {
      actual_layer = 2;
      Set_Layer();
    }

    //Die shortcut
    if (Input.GetKey("k")) {
      playerAnimation.SetBool("dead", true);
      isDead = true;
      sfxManager.playerDead.Play();
      Invoke("ChangeLevel", 1.9f);
    }
  }

  private void GetMouseInputs() {
    if (Input.GetMouseButtonDown(0)) {
      sfxManager.playerAttack4.Play();
      if ((playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Down")) || (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Stop_Down"))) {
        playerAnimation.SetBool("down_attack", true);
        area.GetComponent<Collider2D>().enabled = true;
      }
      if ((playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Up")) || (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Stop_Up"))) {
        playerAnimation.SetBool("up_attack", true);
        area.GetComponent<Collider2D>().enabled = true;
      }
      if ((playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Walking")) || (playerAnimation.GetCurrentAnimatorStateInfo(0).IsName("Normal_Stop"))) {
        playerAnimation.SetBool("attack", true);
        area.GetComponent<Collider2D>().enabled = true;
      }
    }
  }

  private void CheckWalkDirections() {
    float walkY = Input.GetAxis("Vertical");
    float walkX = Input.GetAxis("Horizontal");
    if (isDead == true) {
      walkY = 0;
      walkX = 0;
    }
    if (walkX > 0) {//Rechts gehen
      playerAnimation.SetBool("walk", true);//Laufanimation deaktiviert
      if (isFacingRight == false) {
        Flip();
      }
    }
    if (walkX == 0) {//Stopp
      playerAnimation.SetBool("walk", false);
    }
    if ((walkX < 0)) {//Links gehen
      playerAnimation.SetBool("walk", true);
      if (isFacingRight == true) {
        Flip();
      }
    }

    if (walkY > 0) {//Rechts gehen
      playerAnimation.SetBool("up", true);//Walking animation is activated
      playerAnimation.SetBool("down", false);
    }
    if (walkY == 0) {//Stopp
      playerAnimation.SetBool("up", false);
      playerAnimation.SetBool("down", false);
    }
    if ((walkY < 0)) {//Links gehen
      playerAnimation.SetBool("up", false);
      playerAnimation.SetBool("down", true);
    }
    GetComponent<Rigidbody2D>().velocity = new Vector2(walkX * walkspeed / 2, walkY * walkspeed / 2);
  }

}
