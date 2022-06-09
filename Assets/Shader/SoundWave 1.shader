Shader "Custom/SoundWave1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0


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

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        fixed4 _WaveOrigin[20];
        fixed4 _WaveParams[20]; //impactStr, sharpness, fade, offset
        float waveColor;
        float radius[20];
        // A shader that is used to create a wave effect.
        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex)* _Color;

            for (int i = 0; i < 20; i++) {
                
                /**********/
                float distance = length( IN.worldPos.xyz - _WaveOrigin[i].xyz ) - radius[i];
                float lowerDistance = distance - _WaveParams[i][1] * 0.5;
                float upperDistance = distance + _WaveParams[i][1] * 0.5;

                float wshape = pow(max (0, (1 - (abs(distance)/(_WaveParams[i][1]*0.5)) ) * 3) , 3) * (lowerDistance < 0 && upperDistance > 0 );
                float wfade = pow(max( (1 - (radius[i]/_WaveParams[i][0])), 0), _WaveParams[i][2]) ;                
                if (wfade < 0.01f) {
                    wfade = 0;
                } 
                // Albedo comes from a texture tinted by color
                waveColor += wshape * wfade;
            }
            o.Emission = waveColor * c.rgb ;
            // Metallic and smoothness come from slider variables
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness; 
            o.Alpha = c.a;
            o.Albedo = o.Emission;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
