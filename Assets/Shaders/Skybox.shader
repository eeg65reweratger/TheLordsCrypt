Shader "LowPolySeagull/Skybox Color"
{
    Properties
    {
        _Color ("Skybox Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            Color [_Color]
        }
    }
}
