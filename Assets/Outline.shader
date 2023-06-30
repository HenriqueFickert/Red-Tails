﻿Shader "Kiike/OutLineShader"
{
	Properties
	{
		_Color("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex("Texture", 2D) = "white" {}
		_OutlineColor("OutLine Color", Color) = (1,1,1,1)
		_OutlineSize("OutLine Size", Range(1.0,5.0)) = 1.01
	}

		CGINCLUDE
#include "UnityCG.cginc"
			struct appdata {
			float4 vertex : POSITION;
			float3 normal : NORMAL;
		};

		struct v2f {
			float4 pos : POSITION;
			float4 color : COLOR;
			float3 normal : NORMAL;
		};

		float4 _OutlineColor;
		float _OutlineSize;

		v2f vert(appdata v) {
			v.vertex.xyz *= _OutlineSize;
			v2f o;
			o.pos = UnityObjectToClipPos(v.vertex);
			return o;
		}
		ENDCG

			SubShader
		{
			Tags { "Queue" = "Transparent"}

			//Render the outline
			Pass {
				ZWrite Off


				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag


				 half4 frag(v2f i) : COLOR
				{
					return _OutlineColor;
				 }
			 ENDCG

		}

			//Render the object 
		Pass {
				ZWrite On

				Material {
				Diffuse[_Color]
				Ambient[_Color]
				}

				Lighting On

				SetTexture[_MainTex]
				{
					ConstantColor[_Color]
				}
				SetTexture[_MainTex]{
					Combine previous * Primary DOUBLE
				}

			}
		}
}