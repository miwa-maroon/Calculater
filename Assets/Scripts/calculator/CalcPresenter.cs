using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class CalcPresenter : MonoBehaviour
{
    [SerializeField] private Button[] btnsNum;
    [SerializeField] private Button[] btnsOp;
    [SerializeField] private Button btnCalc;
    [SerializeField] private Button btnAC;

    


    [SerializeField] private Text display;
    [SerializeField] private CalcModel calcModel;

    private Text btnText;
    private string numText; 
    

    private void Start() {
        foreach(Button btn in btnsNum)
        {
            btn.OnClickAsObservable().Subscribe(key =>
                {
                    btnText = btn.GetComponentInChildren<Text>();
                    calcModel.InputValue(btnText.text);
                }
                
                ).AddTo(this);
        }


        foreach(Button btn in btnsOp)
        {
            btn.OnClickAsObservable().Subscribe(key =>
                {
                    calcModel.Calculate();
                    btnText = btn.GetComponentInChildren<Text>();
                    
                    calcModel.SetTempOperator(btnText.text);
                    
                }
                
                ).AddTo(this);
        }

        btnCalc.OnClickAsObservable().Subscribe(key =>
        {
            calcModel.Calculate();
            calcModel.SetEqual();
        }).AddTo(this);

        btnAC.OnClickAsObservable().Subscribe(key =>
        {
            calcModel.AllClear();
        }
        ).AddTo(this);

        calcModel.DispNum.Subscribe(num =>
        {
            display.text = num;
        }
        ).AddTo(this);
    }
    


}
