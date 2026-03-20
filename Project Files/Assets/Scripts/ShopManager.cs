using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    //-----------------Gameobjects and Classes------------------
    //public Player player1;
    public Player[] players;

    public GameObject ball;
    //------------------Player Stats-------------------------
    [Header("DMG Settings")]
    public int priceDMG = 100;
    public int priceWeight_DMG = 100;
    public int initialDMG = 1;
    private int maxDMG = 5;
    [Header("SPD Settings")]
    public int priceSPD = 50;
    public int priceWeight_SPD = 5;
    public int initialSpeed = 20;
    private int speedAdd = 10;
    public float maxSpeed = 50f;
    [Header("AGI Settings")]
    public int priceAGI = 50;
    public int priceWeight_AGI = 10;
    public float initialInertia = 0.9f;
    public float inertiaMinus = 0.3f;
    private float minInertia = 0.3f;
    int AGI_modifier = 10;
    //----------------------Items------------------------------
    [Header("Ball Settings")]
    public int priceBall = 60;
    public int priceWeight_Ball = 5;
    [SerializeField] int[] numBalls = { 0, 0 };

    [Header("FreezeBeam Settings")]
    public GameObject beamPrefab;
    public int priceFreezeBeam = 300;
    public float beamDuration = 2f;
    public float growDuration = 0.5f;
    public float activeDuration = 1f;
    public float postActiveDuration = 0.6f;

    //-------------------UI Zone----------------------
    [Header("UI Settings")]
    public TMP_Text golds_text_1;
    public TMP_Text text_priceDMG_1;
    public TMP_Text text_priceSPD_1;
    public TMP_Text text_priceAGI_1;
    public TMP_Text text_price_Ball_1;

    public TMP_Text golds_text_2;
    public TMP_Text text_priceDMG_2;
    public TMP_Text text_priceSPD_2;
    public TMP_Text text_priceAGI_2;
    public TMP_Text text_price_Ball_2;


    //------------------Start---------------------------
    private void Start()
    {

    }

    //------------------True Update---------------------
    private void Update()
    {
        UpdateGold1();
        UpdateGold2();
    }

    //------------------Player Stats-------------------------
    public string UpgradeDMG(int index)
    {
        int actual_price = priceDMG + (players[index].damage - initialDMG) * priceWeight_DMG;

        if (players[index].Golds >= actual_price && players[index].damage < maxDMG)
        {
            players[index].damage += 1;
            players[index].Golds -= actual_price;
            if (players[index].damage >= maxDMG)
            {
                return string.Format("MAX");
            }
            actual_price = priceDMG + (players[index].damage - initialDMG) * priceWeight_DMG;
            return string.Format("{0}$", actual_price);
        }
        return string.Format("MAX");
    }
    public void UpgradeDMG1()
    {
        text_priceDMG_1.text = UpgradeDMG(0);
    }
    public void UpgradeDMG2()
    {
        text_priceDMG_2.text = UpgradeDMG(1);
    }

    /*
    public void UpgradeDMG1()
    {
        int actual_price = priceDMG + (player1.damage - initialDMG) * priceWeight_DMG;

        if (player1.Golds >= actual_price && player1.damage < maxDMG)
        {
            player1.damage += 1;
            player1.Golds -= actual_price;
            actual_price = priceDMG + (player1.damage - initialDMG) * priceWeight_DMG;
            text_priceDMG1.text = string.Format("{0}$", actual_price);
        }
        if (player1.damage >= maxDMG)
        {
            text_priceDMG1.text = string.Format("MAX");
        }
    }
    */

    public string UpgradeSPD(int index)
    {
        int actual_price = priceSPD + ((int)players[index].moveSpeed - initialSpeed) / 10 * priceWeight_SPD;

        if (players[index].Golds >= actual_price && players[index].moveSpeed < maxSpeed)
        {
            players[index].moveSpeed += speedAdd;

            players[index].Golds -= actual_price;
            if (players[index].moveSpeed >= maxSpeed)
            {
                return string.Format("MAX");
            }
            actual_price = priceSPD + ((int)players[index].moveSpeed - initialSpeed) * priceWeight_SPD;
            return string.Format("{0}$", actual_price);

        }
        return "MAX";
    }
    public void UpgradeSPD1()
    {
        text_priceSPD_1.text = UpgradeSPD(0);
    }
    public void UpgradeSPD2()
    {
        text_priceSPD_2.text = UpgradeSPD(1);
    }

    /*
        public void UpgradeSPD1()
        {
            int actual_price = priceSPD + ((int)player1.moveSpeed - initialSpeed) / 10 * priceWeight_SPD;

            if (player1.Golds >= actual_price && player1.moveSpeed < maxSpeed)
            {
                player1.moveSpeed += speedAdd;

                player1.Golds -= actual_price;
                actual_price = priceSPD + ((int)player1.moveSpeed - initialSpeed) * priceWeight_SPD;
                text_priceSPD1.text = string.Format("{0}$", actual_price);
                if (player1.moveSpeed >= maxSpeed)
                {
                    text_priceSPD1.text = string.Format("MAX");
                }
            }
        }
        */
    public string UpgradeAGI(int index)
    {
        int actual_price = priceAGI + ((int)((initialInertia - players[index].inertia) * AGI_modifier)) * priceWeight_AGI;


        if (players[index].Golds >= actual_price && players[index].inertia > minInertia)
        {
            players[index].Golds -= actual_price;
            players[index].inertia -= inertiaMinus;
        }

        if (players[index].inertia <= minInertia)
        {
            return string.Format("MAX");
        }
        else
        {
            actual_price = priceAGI + ((int)((initialInertia - players[index].inertia) * AGI_modifier)) * priceWeight_AGI;
            return string.Format("{0}$", actual_price);
        }

    }
    public void UpgradeAGI1()
    {
        text_priceAGI_1.text = UpgradeAGI(0);
    }
    public void UpgradeAGI2()
    {
        text_priceAGI_2.text = UpgradeAGI(1);
    }
    /*
       public void UpgradeAGI1()
       {
           int actual_price = priceAGI + ((int)((initialInertia - player1.inertia) * AGI_modifier)) * priceWeight_AGI;


           if (player1.Golds >= actual_price && player1.inertia > minInertia)
           {
               player1.Golds -= actual_price;
               player1.inertia -= inertiaMinus;
           }
           if (player1.inertia <= minInertia)
           {
               text_priceAGI1.text = string.Format("MAX");
           }
           else
           {
               actual_price = priceAGI + ((int)((initialInertia - player1.inertia) * AGI_modifier)) * priceWeight_AGI;
               text_priceAGI1.text = string.Format("{0}$", actual_price);
           }

       }
   */
    public void UpdateGold1()
    {
        golds_text_1.text = string.Format("Golds: {0}", players[0].Golds);
    }
    public void UpdateGold2()
    {
        golds_text_2.text = string.Format("Golds: {0}", players[1].Golds);
    }

    //----------------------Items------------------------------
    public string AddBall(int index)
    {
        int actual_price = priceBall + numBalls[index] * priceWeight_Ball;
        if (actual_price >= 150)
        {
            actual_price = 150;
        }
        if (players[index].Golds >= actual_price)
        {
            if (players[index].CreateBall())
            {
                players[index].Golds -= actual_price;
                numBalls[index]++;
                actual_price = priceBall + numBalls[index] * priceWeight_Ball;
                if (actual_price >= 150)
                {
                    actual_price = 150;
                }
                return string.Format("{0}$", actual_price);
            }
        }
        return string.Format("{0}$", actual_price);
    }

    public void AddBall_1()
    {
        text_price_Ball_1.text = AddBall(0);
    }

    public void AddBall_2()
    {
        text_price_Ball_2.text = AddBall(1);
    }

    //Freeze Beam
    /*
    在-20~20之间找一个X坐标点
    投掷一个光束
    将碰到的玩家静止1s
    光束持续2s?
    光束有一个从细到粗的动画
    0.5s的预留时间
    变粗后开始生效1s
    */

    void BuyFreezeBeam(int index)
    {
        if (players[index].Golds >= priceFreezeBeam)
        {
            ThrowFreezeBeam();
            players[index].Golds -= priceFreezeBeam;
        }
    }

    public void BuyFreezeBeam_1()
    {
        BuyFreezeBeam(0);
    }
    public void BuyFreezeBeam_2()
    {
        BuyFreezeBeam(1);
    }

    public void ThrowFreezeBeam()
    {
        float randomX = Random.Range(-20f, 20f);
        Vector3 spawnPos = new Vector3(randomX, 0f, 0f);

        GameObject beam = Instantiate(beamPrefab, spawnPos, Quaternion.identity);
        StartCoroutine(HandleBeam(beam));
    }

    IEnumerator HandleBeam(GameObject beam)
    {
        // 初始缩放
        Vector3 initialScale = new Vector3(0.5f, 90f, 1f);
        // 最终缩放
        Vector3 finalScale = new Vector3(3f, 90f, 1f);

        // 增长动画
        float elapsedTime = 0f;
        while (elapsedTime < growDuration)
        {
            beam.transform.localScale = Vector3.Lerp(initialScale, finalScale, elapsedTime / growDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        beam.transform.localScale = finalScale;
        beam.GetComponent<BoxCollider2D>().enabled = true;

        // 等待 activeDuration
        yield return new WaitForSeconds(activeDuration);

        SpriteRenderer beamSprite = beam.GetComponent<SpriteRenderer>();
        if (beamSprite != null)
        {
            beamSprite.enabled = false;
        }
        beam.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(postActiveDuration);

        Destroy(beam);

    }

    //---------------Towers-----------------------------
    [Header("Spinner Setting")]
    public int spinnerPrice = 150;
    public GameObject[] spinners;
    public TMP_Text text_price_spinner_1;
    public TMP_Text text_price_spinner_2;
    
    //----------Spinner------------
    string BuySpinner(int index){
        if (players[index].Golds >= spinnerPrice && !spinners[index].activeInHierarchy)
        {
            spinners[index].SetActive(true);
            players[index].Golds -= spinnerPrice;
            return "MAX";
        }
        if (spinners[index].activeInHierarchy)
        {
            return "MAX";
        }
        return "150$";
    }

    public void BuySpinner1(){
        text_price_spinner_1.text = BuySpinner(0);
    }
    public void BuySpinner2(){
        text_price_spinner_2.text = BuySpinner(1);
    }




}
