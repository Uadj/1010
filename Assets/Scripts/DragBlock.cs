using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBlock : MonoBehaviour
{
    [SerializeField]
    private AnimationCurve curveMovement;
    [SerializeField]
    private AnimationCurve curveScale;
    private float appearTime = 0.5f;
    private float returnTime = 0.1f;

    [field:SerializeField]
    public Vector2Int BlockCount { private set; get; }
    public void Setup(Vector3 parentPosition)
    {
        StartCoroutine(OnMoveTo(parentPosition, appearTime));
    }
    private void OnMouseDrag()
    {
        Vector3 gap = new Vector3(0, BlockCount.y * 0.5f + 1, 10);
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + gap;
    }
    private void OnMouseUp()
    {
        StopCoroutine("OnScaleTo");
        StartCoroutine("OnScaleTo", Vector3.one * 0.5f);
        StartCoroutine(OnMoveTo(transform.parent.position, returnTime));
    }
    private IEnumerator OnScaleTo(Vector3 end)
    {
        Vector3 start = transform.localScale;
        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / returnTime;
            transform.position = Vector3.Lerp(start, end, curveMovement.Evaluate(percent));

            yield return null;
        }
    }
    private IEnumerator OnMoveTo(Vector3 end, float time)
    {
        Vector3 start = transform.position;
        float current = 0;
        float percent = 0;

        while(percent < 1)
        {
            current += Time.deltaTime;
            percent = current / time;
            transform.position = Vector3.Lerp(start, end, curveMovement.Evaluate(percent));

            yield return null;
        }
    }

}
