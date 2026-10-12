using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CFeadbackMessageController : MonoBehaviour
{
    #region inspector
    [SerializeField] private GameObject _messagePrefab;
    [SerializeField] private Transform _messageLayoutTr;
    [SerializeField] private static CFeadbackMessageController _instance;
    #endregion

    #region property
    public static CFeadbackMessageController Instance => _instance;
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

    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public static void ShowFeadbackMessage(string messageTxt)
    {
        if(_instance == null)
        {
            return;
        }

        GameObject message = Instantiate(_instance._messagePrefab, _instance._messageLayoutTr);

        Text text = message.GetComponentInChildren<Text>();
        text.text = messageTxt;

        _instance.StartCoroutine(_instance.CoMessageRoutine(message));
    }

    private IEnumerator CoMessageRoutine(GameObject messageGO)
    {
        CanvasGroup canvasGroup = messageGO.GetComponent<CanvasGroup>();

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.unscaledDeltaTime;
            messageGO.transform.position += Vector3.up * 10 * Time.unscaledDeltaTime;
            yield return null;
        }

        Destroy(messageGO);
    }
}
