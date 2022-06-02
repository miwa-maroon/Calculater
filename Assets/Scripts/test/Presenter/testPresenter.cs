using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class testPresenter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _text;

    [SerializeField] private model _model;
    // Start is called before the first frame update
    void Start()
    {
        _model.Count.Subscribe(v =>
            {
                _slider.value = ((float)v / _model.MaxCount);

                _text.text = $"{v}%";
            }
        ).AddTo(this);

        _slider.OnValueChangedAsObservable()
            .Subscribe(x =>
                {
                    //model - view 補正もpresenterの責務
                    var value = (int)(100 * x);

                    _model.SetCount(value);
                }
            ).AddTo(this);
    }
}

    
