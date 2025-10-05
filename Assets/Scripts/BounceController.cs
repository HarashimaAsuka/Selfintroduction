using UnityEngine;
using UnityEngine.UI;

public class BounceController : MonoBehaviour
{
    public float speed = 200f;
    private RectTransform rectTransform;
    private Vector2 direction;

    private Canvas canvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();

        direction = new Vector2(Random.value > 0.5 ? 1 : -1,
                                Random.value > 0.5f ? 1:-1);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += direction * speed * Time.deltaTime;

        CheckBounds();
    }

    void CheckBounds(){
        RectTransform canvasRect = canvas.GetComponent<RectTransform>();
        Vector2 pos = rectTransform.anchoredPosition;
        Vector2 size = rectTransform.sizeDelta * rectTransform.localScale;

        float halfWidth = canvasRect.rect.width / 2;
        float halfHeight = canvasRect.rect.height / 2;

        if(pos.x + size.x / 2 > halfWidth || pos.x - size.x / 2 < -halfWidth){
            direction.x *= -1;
            pos.x = Mathf.Clamp(pos.x, -halfWidth + size.x / 2, halfWidth - size.x / 2);
        }

        if(pos.y + size.y / 2 > halfHeight || pos.y - size.y / 2 < -halfHeight){
            direction.y *= -1;
            pos.y = Mathf.Clamp(pos.y, -halfHeight + size.y / 2, halfHeight - size.y / 2);
        }

        rectTransform.anchoredPosition = pos;
    }
}
