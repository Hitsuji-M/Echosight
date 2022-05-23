Shader "Custom/PitchBlack"
{
    Properties
    {
        _BaseColor  ("Base Color",  Color)  = (0.1, 0.1, 0.1, 0)
    }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }

        CGPROGRAM

        #pragma surface surf Lambert
        #pragma multi_compile

        struct Input
        {
            float3 worldPos;
        };

        float3 _BaseColor;

        void surf(Input IN, inout SurfaceOutput o)
        {

            // Apply to the surface.
            o.Albedo = _BaseColor;
        }

        ENDCG
    } 
    Fallback "Diffuse"
}
