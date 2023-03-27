using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnimationController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    /// <summary>
    /// Button�ɐG��Ă���Ƃ��傫���Ȃ�
    /// </summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1.2f, 1.2f), 0.2f);
    }

    /// <summary>
    /// button���痣�ꂽ�猳�ɖ߂�
    /// </summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(new Vector2(1f, 1f), 0.2f);
    }
}
