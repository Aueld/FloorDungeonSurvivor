Shader "Custom/BulletTimeEffect"
{
    Properties
    {
        _MainTex("Base (RGB)", 2D) = "white" { }
        _FadeAmount("Fade Amount", Range(0, 1)) = 0.5
        _Speed("Speed", Range(0, 10)) = 1
    }

    SubShader
    {
        Tags { "Queue" = "Overlay" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };

            uniform float _Speed;
            uniform float _FadeAmount;

            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.color = lerp(fixed4(1,1,1,1), fixed4(0,0,0,0), _FadeAmount);
                return o;
            }
            fixed4 frag(v2f i) : COLOR
            {
                return i.color;
            }
            ENDCG
        }
    }
}