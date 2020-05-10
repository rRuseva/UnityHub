Shader "CustomShaders/RedPulsingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1, 1, 1, 1)
        _ColorB("TintB", Color) = (1, 1, 1, 1)
        _Slide("Slide", Range(0, 1)) = 0.5
        _PulsRate("PulsRate", Range(0, 10)) = 2
    }
    SubShader
    {
		Tags
		{
			"Queue" = "Transparent"  "RenderType" = "Transparent"
		}
            LOD 100
        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };


            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float4 _Color;
            float4 _ColorB;
            float _Slide;
            float _PulsRate;

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 color = tex2D(_MainTex, i.uv);
                float t = length(i.uv - float2(0.5, 0.5)) * 1.41421356237; // 1.141... = sqrt(2)
                float slide = lerp(_Slide, 0.78f, ((sin(_Time.z* _PulsRate) + 1) / 2.));
                color.rgba = color.rgba * lerp(_Color, _ColorB, t + (slide - 0.5) * 2);
                
                return color;
            }
            ENDCG
        }
    }
}
