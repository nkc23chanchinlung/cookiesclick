using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public int Coin;
    int _clickAddition = 1;
    public GameObject Ui_AddnumberPre;
    public Text Coin_Text;
    public int Click_Level;
    public Text Click_Level_Text;
    public Text Click_Cost_Text;
    public float Max_Timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Coin_Text.text ="Coin:" + Coin.ToString();
        Click_Level_Text.text = "Click Level: " + Click_Level.ToString();
        Click_Cost_Text.text = "Upgrade Cost: " + (10 * (Click_Level + Click_Level)).ToString();
        AutoAddition(); 
    }
    //クリック増加用関数 
    public void ClickAddition(int _clickAddition)

    {
        _clickAddition =this. _clickAddition;
        Coin += _clickAddition+Click_Level;
        CreateUi_AddnumberPre(_clickAddition+Click_Level, Ui_AddnumberPre);
    }
    //自動増加用関数
    void AutoAddition()
    {
        
        Max_Timer -= Time.deltaTime;
        if(Max_Timer <= 0)
        {
            Coin += Click_Level*Click_Level;
            CreateUi_AddnumberPre(Click_Level*Click_Level, Ui_AddnumberPre);
            Max_Timer = 0.5f;
        }
    }
    void CreateUi_AddnumberPre(int num,GameObject Ui_AddnumberPre)
    {
        Vector3 mousePos =Input.mousePosition;
        var obj = Instantiate(Ui_AddnumberPre, Vector3.zero, Quaternion.identity);
        var number = obj.GetComponentInChildren<Text>().gameObject;
        number.transform.position = mousePos;
        number.transform.DOMoveY(mousePos.y + 100, 1f).SetEase(Ease.OutCubic);
        Destroy(obj,1f);
        obj.transform.localScale = Vector3.one;
        Text text = obj.GetComponentInChildren<Text>();
        text.text="+" + num.ToString();
    }
    public void UpgradeClick()
    {
        int cost = 10 * (Click_Level + Click_Level);
        if (Coin >= cost)
        {
            Coin -= cost;
            Click_Level += 1;
          
           
        }
    }
    


}
