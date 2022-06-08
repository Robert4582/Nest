// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Heatmap" {
    Properties {
        _HeatTex ("Texture", 2D) = "white" {}
        _PointRadius("Point Radius", Range(0,10)) = 1
        _PointIntensity("Point Intensity", Range(0,10)) = 1
        _Opacity("Opacity", Range(0,1)) = 1
    }
    SubShader {
        Tags {"Queue"="Transparent" "ForceNoShadowCasting" = "True"}
        Blend SrcAlpha OneMinusSrcAlpha // Alpha blend

        Pass {
            CGPROGRAM
            #pragma vertex vert             
            #pragma fragment frag

            struct vertInput {
                float4 pos : POSITION;
            };  

            struct vertOutput {
                float4 pos : POSITION;
                fixed3 worldPos : TEXCOORD1;
            };

            vertOutput vert(vertInput input) {
                vertOutput o;
                o.pos = UnityObjectToClipPos(input.pos);
                o.worldPos = mul(unity_ObjectToWorld, input.pos).xyz;
                return o;
            }

            uniform int _Points_Length = 1023;
            uniform float3 _Points [1023];        // (x, y, z) = position
            uniform float _PointRadius;
            uniform float _PointIntensity;
            uniform float _Opacity;
            
            sampler2D _HeatTex;

            half4 frag(vertOutput output) : COLOR {
                // Loops over all the points
                half h = 0;
                for (int i = 0; i < _Points_Length; i ++)
                {
                    // Calculates the contribution of each point
                    half di = distance(output.worldPos, _Points[i].xyz);

                    half ri = _PointRadius;
                    half hi = 1 - saturate(di / ri);

                    h += hi * _PointIntensity;
                }
                clip(h-0.01);
                // Converts (0-1) according to the heat texture
                h = saturate(h);
                half4 color = tex2D(_HeatTex, fixed2(h, 0.5));
                color.a *= _Opacity;
                return color;
            }
            ENDCG
        }
    } 
    Fallback "Diffuse"
}