using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CFundManager : MonoBehaviour
{
	#region inspector
	[SerializeField] private float _fund;
	[SerializeField] private Text _fundText;
	#endregion

	#region private var
	private static CFundManager _instance;
	#endregion

	#region property
	public static CFundManager Instance => _instance;
    #endregion

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        else if (_instance == null)
        {
            _instance = this;
        }

        UpdateFundText();
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public static bool SpendFund(float amount)
    {
        if(_instance == null)
        {
            return false;
        }

        if(amount > _instance._fund)
        {
            return false;
        }

        _instance._fund -= amount;
        _instance.UpdateFundText();
        return true;
    }

    public static void GainFund(float amount)
    {
        if(_instance == null)
        {
            return;
        }

        _instance._fund += amount;
        _instance.UpdateFundText();
    }


    private void UpdateFundText()
    {
        _fundText.text = $"{_fund}$";
    }

}
