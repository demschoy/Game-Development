Shader "Shaders/Pixelization Effect Shader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _PixelWidth("PixelWidth", float) = 15
        _PixelHeight("PixelHeight", float) = 15
    }

    SubShader
    {   
        Pass
        {
            CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex: POSITION;
                float2 uv: TEXCOORD0;
            };

            struct v2f
            {
                float4 vertex: SV_POSITION;
                float2 uv: TEXCOORD0;
            };

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
			float _PixelWidth;
            float _PixelHeight;

            float4 frag(v2f i) : SV_Target
            {
                float dx = (1 / _ScreenParams.x) * _PixelWidth;
                float dy = (1 / _ScreenParams.y) * _PixelHeight;

				float2 pixelatedUV = float2(i.uv.x / dx, i.uv.y / dy);
                pixelatedUV = floor(float2(pixelatedUV.x, pixelatedUV.y));
                pixelatedUV = float2(dx * pixelatedUV.x * _Time.x, dy * pixelatedUV.y * _Time.x);
                
				float4 color = tex2D(_MainTex, pixelatedUV);
				return color;
            }
            ENDCG
        }
    }
}