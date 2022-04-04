using UnityEngine;

public class BrightnessAdjustment : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.color = Color.black;
    }
    
    public void DecreaseBrightness(float decreaseAmount)
    {
        ChangeAlphaValue(decreaseAmount * -1);
    }

    public void IncreaseBrightness( float increaseAmount)
    {
        ChangeAlphaValue(increaseAmount);
    }

    public void Resize(Vector3 min, Vector3 max)
    {
        var bounds = _spriteRenderer.bounds;
        var boundsMin = bounds.min;
        var boundsMax = bounds.max;
        var scale = transform.localScale;
      
        if (min.y < boundsMin.y)
        {
            var newScaleY = Mathf.Abs(min.y * scale.y / boundsMin.y);
            transform.localScale = new Vector3(scale.x, newScaleY);
        }
        
        if (min.x < boundsMin.x)
        {
            var newScaleX = Mathf.Abs(min.x * scale.x / boundsMin.x);

            transform.localScale = new Vector3(newScaleX, scale.y);
        }

        if (max.y > boundsMax.y)
        {
            var newScaleY = Mathf.Abs(max.y * scale.y / boundsMax.y);
            transform.localScale = new Vector3(scale.x, newScaleY);
        }


        if (max.x > boundsMax.x)
        {
            var newScaleX =  Mathf.Abs(max.x * scale.x / boundsMax.x);
            transform.localScale = new Vector3(newScaleX, scale.y);
        }
        
    }

    private void ChangeAlphaValue(float amount)
    {
        var newAlpha = _spriteRenderer.color.a + amount;

        if (newAlpha < 0)
        {
            newAlpha = 0;
        }
        else if (newAlpha > 1)
        {
            newAlpha = 1;
        }

        Color color = Color.black;
        color.a = newAlpha;
        _spriteRenderer.color = color;
    }
}
