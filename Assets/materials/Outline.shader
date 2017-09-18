Shader "Card/Outline"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Tint("Tint",Color)=(1,1,1,1)
		_outline("Outline",Color)=(1,1,1,1)
		_OutlineWidth ("Outline width", Range (0.0, 0.03)) = .005

	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
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
				float2 uv : TEXCOORD0;
				float3 normal: NORMAL;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;

			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _OutlineWidth;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);


			   	o.vertex.xy +=_OutlineWidth;

				return o;
			}

			float GetAlpha(v2f i)
			{
				return tex2D(_MainTex,i.uv.xy).a;
			}

			float4 _outline;
			fixed4 frag(v2f i):SV_Target
			{
				float alpha = GetAlpha(i);
				clip(alpha - 0.5);

				fixed4 col=_outline;
				return col;
			}
			ENDCG
		}

		Pass
		{
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

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Tint;


			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}

			float GetAlpha(v2f i)
			{
				return _Tint.a*tex2D(_MainTex,i.uv.xy).a;
			}

			fixed4 frag (v2f i) : SV_Target
			{
				float alpha = GetAlpha(i);
				clip(alpha - 0.5);

				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				col*=_Tint;
				return col;
			}
			ENDCG
		}
	}
}
