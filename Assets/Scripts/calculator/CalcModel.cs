using UniRx;
using UnityEngine;

public class CalcModel : MonoBehaviour
{
    private string preval;
    private string confirmedPreval;
    private string tempval;
    private float ftempval;
    private string tempop;
    public string Tempop
    {
        get
        {
            return tempop;
        }
        set
        {
            tempop = value;
        }
    }
    private bool isOperator;
    private bool isFirstEqual;

    public IReadOnlyReactiveProperty<string> DispNum => dispNum;
    private readonly StringReactiveProperty dispNum = new StringReactiveProperty();

    private void Start() {
        preval = "";
        this.Tempop = "";
        confirmedPreval = "0";

    }
    public void InputValue(string num)
    {
        if (isOperator == true)
        {
            this.Clear();
        }
        if(isFirstEqual == true)
        {
            this.Tempop = "";
            confirmedPreval = "0";
            isFirstEqual = false;
        }
        isOperator = false;
        tempval = preval + num;
        preval = tempval;
        dispNum.Value = tempval;
 
    }

    public void SetTempOperator(string op)
    {
        //confirmedPreval = tempval;
        this.Tempop = op;
        isOperator = true;
        preval = "";
    }

    public void Calculate()
    {
        tempop = this.Tempop;
        Debug.Log(tempop);
        Debug.Log(tempop.GetType());

        switch(tempop)
        {
            case "+":
                ftempval = float.Parse(confirmedPreval) + float.Parse(tempval);
                confirmedPreval = ftempval.ToString();
                dispNum.Value = confirmedPreval;
                break;
            case "-":
                ftempval = float.Parse(confirmedPreval) - float.Parse(tempval);
                confirmedPreval = ftempval.ToString();
                dispNum.Value = confirmedPreval;

                break;
            case "*":
                ftempval = float.Parse(confirmedPreval) * float.Parse(tempval);
                confirmedPreval = ftempval.ToString();
                dispNum.Value = confirmedPreval;

                break;
            case "/":
                ftempval = float.Parse(confirmedPreval) / float.Parse(tempval);
                confirmedPreval = ftempval.ToString();
                dispNum.Value = confirmedPreval;
                break;
            default:
                Debug.Log("default");
                dispNum.Value = tempval;
                confirmedPreval = tempval;
                break;
        }
        isOperator = true;
    }
    
    public void SetEqual()
    {
        isFirstEqual = true;
    }

    public void Clear(){
        preval = "";
        //this.Tempop = "";
        //confirmedPreval = "0";
        //dispNum.Value = "0";
    }

    public void AllClear()
    {
        preval = "";
        this.Tempop = "";
        confirmedPreval = "0";
        dispNum.Value = "0";
    }
}
