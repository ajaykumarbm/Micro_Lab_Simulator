using UnityEngine;

public class LiquidController : MonoBehaviour
{
    [Header("References")]
    public Transform buretteLiquid;
    public Transform flaskLiquid;

    public SliderController sliderController;

    [Header("Settings")]
    public float flowSpeed = 0.3f;
    public float maxHeight = 1f;

    private float initialBuretteHeight;
    private float initialFlaskHeight;

    void Start()
    {
        initialBuretteHeight = buretteLiquid.localScale.y;
        initialFlaskHeight = flaskLiquid.localScale.y;
    }

    void Update()
    {
        float flow = sliderController.GetSliderValue();

        if (flow > 0.01f)
        {
            FlowLiquid(flow);
        }
    }

    void FlowLiquid(float flow)
    {
        float delta = flow * flowSpeed * Time.deltaTime;

        Vector3 bScale = buretteLiquid.localScale;
        if (bScale.y > 0)
        {
            bScale.y -= delta;
            bScale.y = Mathf.Clamp(bScale.y, 0, initialBuretteHeight);
            buretteLiquid.localScale = bScale;

            buretteLiquid.localPosition -= new Vector3(0, delta / 2, 0);
        }

        Vector3 fScale = flaskLiquid.localScale;
        fScale.y += delta;
        fScale.y = Mathf.Clamp(fScale.y, 0, maxHeight);
        flaskLiquid.localScale = fScale;

        flaskLiquid.localPosition += new Vector3(0, delta / 2, 0);
    }
}