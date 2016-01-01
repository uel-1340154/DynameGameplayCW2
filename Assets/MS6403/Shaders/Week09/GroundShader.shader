Shader "MS6403/GroundShader" 
{
	Properties
	{
		fAnimationTime( "Animation Time", Float) = 0.0
	}
	
	SubShader 
	{
      Tags { "RenderType" = "Opaque" }

      CGPROGRAM
	  // Connect our surface shader to our lighting model
      #pragma surface surf Standard 

      #include "UnityCG.cginc"
      #include "noiseSimplex.cginc"

	  // Access to our properties
      float fAnimationTime;

	  // Input Structure
      struct Input 
	  {
			float3 worldPos;
			float4 color : COLOR;
      };

	  // Our actual surface shader
      void surf (Input IN, inout SurfaceOutputStandard o) 
	  {
			float fNoise = snoise((IN.worldPos + fAnimationTime));

			fNoise = clamp(fNoise, 0.0f, 1.0f);
      	
			// This sets the colour.
			// Change these scalar values to tweak the colour.
	      	float4 outColor;
		  	outColor.r = fNoise * 5.0f;
			outColor.g = fNoise * 2.0f;
			outColor.b = fNoise * 1.0f;
			outColor.a = 1.0f;

			o.Albedo = outColor;
      }
      ENDCG
    }
	Fallback "Diffuse"
}