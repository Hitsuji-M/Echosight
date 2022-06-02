Shader "Custom/SoundWave"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Isolation ("Sound Isolation", Range(0,1)) = 0
        _Modifier("Sound Color Modifier", Color) = (0, 0, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldPos;

        };

        half _Isolation;
        fixed4 _Color;
        fixed4 _Modifier;
        fixed4 _WaveOrigin[10];
        fixed2 _WaveParam;
        float waveColor;
        // A shader that is used to create a wave effect.
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex)* (_Color - _Modifier);

            for (int i = 0; i < 10; i++) {
            /************/
                float distance = (length( IN.worldPos.xyz - _WaveOrigin[i].xyz ) - (_WaveParam[0] * _WaveOrigin[i].w));
                float lowerDistance = distance - _WaveParam[1] * 0.5;
                float upperDistance = distance + _WaveParam[1] * 0.5;

                // Albedo comes from a texture tinted by color
                waveColor += pow(max (0, (1 - (abs(distance)/(_WaveParam[1]*0.5)) ) * 3) , 3)
                * (lowerDistance < 0 && upperDistance > 0 ) * pow((1 - _WaveOrigin[i].w), 10) * (1 - _Isolation);
            }
            o.Emission = waveColor * c.rgb ;
            // Metallic and smoothness come from slider variables

            o.Alpha = c.a;
            o.Albedo = 0;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
