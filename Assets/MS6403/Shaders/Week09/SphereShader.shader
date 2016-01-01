Shader "MS6403/SphereShader" {
	Properties
	{
		fAnimationTime( "Animation Time", Float) = 0.0
		fVertNoiseOffset ("Vertex Noise Offset", Float) = 0.3
		fVertNoiseScalar ("Vertex Noise Scalar", Float) = 1.0
		fPixelNoiseOffset ("Pixel  Noise Offset", Float) = 0.0
		fPixelNoiseScalar ("Pixel Noise Scalar", Float) = 0.0
	}
  SubShader {
    Pass {
      CGPROGRAM

      #pragma vertex vert
      #pragma fragment frag
      #include "UnityCG.cginc"
      #include "noiseSimplex.cginc"
      
      struct v2f {
          float4 pos : SV_POSITION;
          fixed4 color : COLOR;
          float4 modelpos : TEXCOORD;
      };
      
      float fAnimationTime;
      float fVertNoiseOffset;
      float fVertNoiseScalar;
      float fPixelNoiseOffset;
      float fPixelNoiseScalar;
      
      v2f vert (appdata_base v)
      {
          v2f o;
          
		  float4 tempPos = v.vertex;
		  float fNoise = snoise((tempPos.xyz + fVertNoiseOffset * fAnimationTime) * fVertNoiseScalar);
		  fNoise = clamp(fNoise, 0.0f, 1.0f);

		  tempPos.xyz += v.normal.xyz * fNoise;
		  tempPos.w = 1.0f;

          o.modelpos = v.vertex;
          o.pos = mul(UNITY_MATRIX_MVP, tempPos);
		  o.color.xyz = v.normal * 0.5 + 0.5;
		  o.color.w = 1.0;

          return o;
      }

      fixed4 frag (v2f i) : COLOR0 
      { 
      	float fNoise = snoise((i.modelpos + fPixelNoiseOffset * fAnimationTime) * fPixelNoiseScalar );
      	
      	fNoise = clamp(fNoise, 0.0f, 1.0f);
      	
      	float4 outColor;
      	outColor.r = fNoise * 5.0f;
      	outColor.g = fNoise * 2.0f;
      	outColor.b = fNoise * 1.0f;
      	outColor.a = 1.0f;
      	
      	return outColor; 
      }

      ENDCG
    }
  } 
}