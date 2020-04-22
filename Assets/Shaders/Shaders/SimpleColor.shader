Shader "Sakurumi/Unlit/SimpleColor"
{
	Properties
	{
		_MainColor ("MainColor", Color) = (1,1,1,1)	
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
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;			
				float4 vertex : SV_POSITION;
			};
			
			fixed4 _MainColor;

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;

				// Fix upside down problem  between OpenGl <--> Direct3D
				 if (_ProjectionParams.x > 0)
        			o.uv.y = 1 - o.uv.y;

				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{	
				fixed4 color = fixed4(_MainColor.r * i.uv.x, _MainColor.g * i.uv.y, _MainColor.b, _MainColor.a);
				return color;
			}
			ENDCG
		}
	}
}
