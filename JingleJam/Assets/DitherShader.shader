Shader "Unlit/DitherShader"
{
    Properties
    {
		_Color1("Color", Color) = (1, 1, 1, 1)
		_Color2("Color", Color) = (1, 1, 1, 1)
		_Color3("Color", Color) = (1, 1, 1, 1)
		_Color4("Color", Color) = (1, 1, 1, 1)
		_Color5("Color", Color) = (1, 1, 1, 1)
		_Color6("Color", Color) = (1, 1, 1, 1)
		_MainTex ("Texture", 2D) = "white" {}
    }

    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100
		Blend SrcAlpha OneMinusSrcAlpha

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
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			fixed4 _Color1;
			fixed4 _Color2;
			fixed4 _Color3;
			fixed4 _Color4;
			fixed4 _Color5;
			fixed4 _Color6;
			fixed4 Colours2[6];

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

			float getLimit(int x, int y)
			{

				int dither[8][8] = {
				{ 0, 32, 8, 40, 2, 34, 10, 42},
				{48, 16, 56, 24, 50, 18, 58, 26},
				{12, 44, 4, 36, 14, 46, 6, 38},
				{60, 28, 52, 20, 62, 30, 54, 22},
				{ 3, 35, 11, 43, 1, 33, 9, 41},
				{51, 19, 59, 27, 49, 17, 57, 25},
				{15, 47, 7, 39, 13, 45, 5, 37},
				{63, 31, 55, 23, 61, 29, 53, 21} };

				float limit = 0.0;
				if (x < 8)
				{
					limit = (dither[x][y] + 1) / 64.0;
				}

				return limit;
			}

			fixed4 find_closest(fixed4 color)	{
				fixed4 tempCol = color;
							fixed4 Colours[6] = {
			_Color1,
			_Color2,
			_Color3,
			_Color4,
			_Color5,
			_Color6,
			};
				/*if (color.r < limit)
				{
					tempCol.r = 0.0;
				}

				if (color.g < limit)
				{
					tempCol.g = 0.0;
				}

				if (color.b < limit)
				{
					tempCol.b = 0.0;
				}*/
				
				fixed4 closestColor = (1, 1, 1, 1);
				float minDelta = 9999999;

				for (int i = 0; i < 6; i++) {
					float deltaTest = length(abs(tempCol - Colours2[i]));
					if (deltaTest < minDelta)
					{
						minDelta = deltaTest;
						closestColor = Colours2[i];
					}
				}
				return closestColor;
			}

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float matx = i.vertex.x * 0.5 % 8;
				float maty = i.vertex.y * 0.5 % 8;

				fixed4 Threshold = (256 / 4, 256 / 4, 256 / 4, 0);

				float factor = getLimit(matx, maty);
				col.r += 0.1 * factor;
				col.g += 0.1 * factor;
				col.b += 0.1 * factor;
				//col.r += find_closest(matx, maty, col.r) * ;
				//col.r = _Colour;
				//col.g += find_closest(matx, maty, col.g);
				//col.b += find_closest(matx, maty, col.b);

				col.rgb = find_closest(col).rgb;

				//col = _Color1;
				//col.a = 1.0;

                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
