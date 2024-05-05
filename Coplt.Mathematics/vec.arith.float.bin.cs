// generated by template, do not modify manually

namespace Coplt.Mathematics;

#region float2

public partial struct float2
{
    public static float2 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f); 
    }
    public static float2 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f);
    }
    public static float2 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static float2 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f);
    }
    public static float2 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static float2 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f);
    }
    public static float2 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f); 
    }
    public static float2 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f);
    }
    public static float2 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f);
    }
    public static float2 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b32v2 isInf(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v2 isPosInf(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector64.Equals(a.vector, Vector64.Create(float.PositiveInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v2 isNegInf(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector64.Equals(a.vector, Vector64.Create(float.NegativeInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 log(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 log2(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 log(this float2 a, float2 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 log10(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 pow(this float2 a, float2 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static float2 fma(this float2 a, float2 b, float2 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float2

#region float3

public partial struct float3
{
    public static float3 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f); 
    }
    public static float3 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f);
    }
    public static float3 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static float3 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f);
    }
    public static float3 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static float3 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f);
    }
    public static float3 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f); 
    }
    public static float3 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f);
    }
    public static float3 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f);
    }
    public static float3 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b32v3 isInf(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v3 isPosInf(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(float.PositiveInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v3 isNegInf(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(float.NegativeInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 log(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log(), a.z.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 log2(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2(), a.z.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 log(this float3 a, float3 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 log10(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10(), a.z.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 pow(this float3 a, float3 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static float3 fma(this float3 a, float3 b, float3 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float3

#region float4

public partial struct float4
{
    public static float4 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f); 
    }
    public static float4 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f);
    }
    public static float4 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static float4 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f);
    }
    public static float4 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static float4 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f);
    }
    public static float4 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f); 
    }
    public static float4 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f);
    }
    public static float4 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f);
    }
    public static float4 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b32v4 isInf(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf(), a.w.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v4 isPosInf(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(float.PositiveInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf(), a.w.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b32v4 isNegInf(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(float.NegativeInfinity)).AsUInt32());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf(), a.w.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 log(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log(), a.z.log(), a.w.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 log2(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2(), a.z.log2(), a.w.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 log(this float4 a, float4 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z), a.w.log(b.w));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 log10(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10(), a.z.log10(), a.w.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 pow(this float4 a, float4 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z), a.w.pow(b.w));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static float4 fma(this float4 a, float4 b, float4 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z), a.w.fma(b.w, c.w));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float4

#region double2

public partial struct double2
{
    public static double2 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277); 
    }
    public static double2 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923);
    }
    public static double2 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static double2 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846);
    }
    public static double2 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static double2 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862);
    }
    public static double2 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094); 
    }
    public static double2 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009);
    }
    public static double2 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861);
    }
    public static double2 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b64v2 isInf(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v2 isPosInf(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(double.PositiveInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v2 isNegInf(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Equals(a.vector, Vector128.Create(double.NegativeInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 log(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 log2(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 log(this double2 a, double2 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 log10(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 pow(this double2 a, double2 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static double2 fma(this double2 a, double2 b, double2 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double2

#region double3

public partial struct double3
{
    public static double3 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277); 
    }
    public static double3 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923);
    }
    public static double3 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static double3 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846);
    }
    public static double3 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static double3 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862);
    }
    public static double3 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094); 
    }
    public static double3 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009);
    }
    public static double3 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861);
    }
    public static double3 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b64v3 isInf(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v3 isPosInf(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Equals(a.vector, Vector256.Create(double.PositiveInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v3 isNegInf(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Equals(a.vector, Vector256.Create(double.NegativeInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 log(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log(), a.z.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 log2(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2(), a.z.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 log(this double3 a, double3 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 log10(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10(), a.z.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 pow(this double3 a, double3 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static double3 fma(this double3 a, double3 b, double3 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double3

#region double4

public partial struct double4
{
    public static double4 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277); 
    }
    public static double4 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923);
    }
    public static double4 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static double4 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846);
    }
    public static double4 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static double4 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862);
    }
    public static double4 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094); 
    }
    public static double4 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009);
    }
    public static double4 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861);
    }
    public static double4 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144);
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b64v4 isInf(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.IsInfinity(a.vector).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf(), a.w.isInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v4 isPosInf(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Equals(a.vector, Vector256.Create(double.PositiveInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf(), a.w.isPosInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static b64v4 isNegInf(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Equals(a.vector, Vector256.Create(double.NegativeInfinity)).AsUInt64());
        #else // NET8_0_OR_GREATER
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf(), a.w.isNegInf());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 log(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(), a.y.log(), a.z.log(), a.w.log());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 log2(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log2(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log2(), a.y.log2(), a.z.log2(), a.w.log2());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 log(this double4 a, double4 b)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log(a.vector) / simd.Log(b.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z), a.w.log(b.w));
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 log10(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Log10(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.log10(), a.y.log10(), a.z.log10(), a.w.log10());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 pow(this double4 a, double4 b)
    {
        #if NET8_0_OR_GREATER && false
        return new(); // new(simd.Exp(simd.Log(a.vector) * b.vector)); // todo exp
        #else // NET8_0_OR_GREATER
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z), a.w.pow(b.w));
        #endif // NET8_0_OR_GREATER
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static double4 fma(this double4 a, double4 b, double4 c)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Fma(a.vector, b.vector, c.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z), a.w.fma(b.w, c.w));
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double4

#region half2

public partial struct half2
{
    public static half2 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f.half()); 
    }
    public static half2 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f.half());
    }
    public static half2 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static half2 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f.half());
    }
    public static half2 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static half2 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f.half());
    }
    public static half2 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f.half()); 
    }
    public static half2 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f.half());
    }
    public static half2 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f.half());
    }
    public static half2 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f.half());
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b16v2 isInf(this half2 a)
    {
        return new(a.x.isInf(), a.y.isInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v2 isPosInf(this half2 a)
    {
        return new(a.x.isPosInf(), a.y.isPosInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v2 isNegInf(this half2 a)
    {
        return new(a.x.isNegInf(), a.y.isNegInf());
    }

    [MethodImpl(256 | 512)]
    public static half2 log(this half2 a)
    {
        return new(a.x.log(), a.y.log());
    }

    [MethodImpl(256 | 512)]
    public static half2 log2(this half2 a)
    {
        return new(a.x.log2(), a.y.log2());
    }

    [MethodImpl(256 | 512)]
    public static half2 log(this half2 a, half2 b)
    {
        return new(a.x.log(b.x), a.y.log(b.y));
    }

    [MethodImpl(256 | 512)]
    public static half2 log10(this half2 a)
    {
        return new(a.x.log10(), a.y.log10());
    }

    [MethodImpl(256 | 512)]
    public static half2 pow(this half2 a, half2 b)
    {
        return new(a.x.pow(b.x), a.y.pow(b.y));
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static half2 fma(this half2 a, half2 b, half2 c)
    {
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y));
    }
}

#endregion // half2

#region half3

public partial struct half3
{
    public static half3 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f.half()); 
    }
    public static half3 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f.half());
    }
    public static half3 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static half3 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f.half());
    }
    public static half3 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static half3 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f.half());
    }
    public static half3 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f.half()); 
    }
    public static half3 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f.half());
    }
    public static half3 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f.half());
    }
    public static half3 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f.half());
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b16v3 isInf(this half3 a)
    {
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v3 isPosInf(this half3 a)
    {
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v3 isNegInf(this half3 a)
    {
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf());
    }

    [MethodImpl(256 | 512)]
    public static half3 log(this half3 a)
    {
        return new(a.x.log(), a.y.log(), a.z.log());
    }

    [MethodImpl(256 | 512)]
    public static half3 log2(this half3 a)
    {
        return new(a.x.log2(), a.y.log2(), a.z.log2());
    }

    [MethodImpl(256 | 512)]
    public static half3 log(this half3 a, half3 b)
    {
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z));
    }

    [MethodImpl(256 | 512)]
    public static half3 log10(this half3 a)
    {
        return new(a.x.log10(), a.y.log10(), a.z.log10());
    }

    [MethodImpl(256 | 512)]
    public static half3 pow(this half3 a, half3 b)
    {
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z));
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static half3 fma(this half3 a, half3 b, half3 c)
    {
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z));
    }
}

#endregion // half3

#region half4

public partial struct half4
{
    public static half4 E
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.7182818284590452353602874713526624977572470936999595749669676277f.half()); 
    }
    public static half4 PI
    { 
        [MethodImpl(256 | 512)] 
        get => new(3.1415926535897932384626433832795028841971693993751058209749445923f.half());
    }
    public static half4 π
    { 
        [MethodImpl(256 | 512)] 
        get => PI;
    }
    public static half4 PI2
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795864769252867665590057683943387987502116419498891846f.half());
    }
    public static half4 π2
    { 
        [MethodImpl(256 | 512)] 
        get => PI2;
    }
    public static half4 Tau
    { 
        [MethodImpl(256 | 512)] 
        get => new(6.2831853071795862f.half());
    }
    public static half4 Log2
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.6931471805599453094172321214581765680755001343602552541206800094f.half()); 
    }
    public static half4 Log10
    { 
        [MethodImpl(256 | 512)] 
        get => new(2.3025850929940456840179914546843642076011014886287729760333279009f.half());
    }
    public static half4 RadToDeg
    { 
        [MethodImpl(256 | 512)] 
        get => new(57.295779513082320876798154814105170332405472466564321549160243861f.half());
    }
    public static half4 DegToRad
    { 
        [MethodImpl(256 | 512)] 
        get => new(0.0174532925199432957692369076848861271344287188854172545609719144f.half());
    }
}

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static b16v4 isInf(this half4 a)
    {
        return new(a.x.isInf(), a.y.isInf(), a.z.isInf(), a.w.isInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v4 isPosInf(this half4 a)
    {
        return new(a.x.isPosInf(), a.y.isPosInf(), a.z.isPosInf(), a.w.isPosInf());
    }

    [MethodImpl(256 | 512)]
    public static b16v4 isNegInf(this half4 a)
    {
        return new(a.x.isNegInf(), a.y.isNegInf(), a.z.isNegInf(), a.w.isNegInf());
    }

    [MethodImpl(256 | 512)]
    public static half4 log(this half4 a)
    {
        return new(a.x.log(), a.y.log(), a.z.log(), a.w.log());
    }

    [MethodImpl(256 | 512)]
    public static half4 log2(this half4 a)
    {
        return new(a.x.log2(), a.y.log2(), a.z.log2(), a.w.log2());
    }

    [MethodImpl(256 | 512)]
    public static half4 log(this half4 a, half4 b)
    {
        return new(a.x.log(b.x), a.y.log(b.y), a.z.log(b.z), a.w.log(b.w));
    }

    [MethodImpl(256 | 512)]
    public static half4 log10(this half4 a)
    {
        return new(a.x.log10(), a.y.log10(), a.z.log10(), a.w.log10());
    }

    [MethodImpl(256 | 512)]
    public static half4 pow(this half4 a, half4 b)
    {
        return new(a.x.pow(b.x), a.y.pow(b.y), a.z.pow(b.z), a.w.pow(b.w));
    }

    /// <summary>
    /// Fusion Addition and Multiplication
    /// <code>(a * b) + c</code>
    /// </summary>
    /// <param name="a">Multiplier a</param>
    /// <param name="b">Multiplier b</param>
    /// <param name="c">Addend c</param>
    [MethodImpl(256 | 512)]
    public static half4 fma(this half4 a, half4 b, half4 c)
    {
        return new(a.x.fma(b.x, c.x), a.y.fma(b.y, c.y), a.z.fma(b.z, c.z), a.w.fma(b.w, c.w));
    }
}

#endregion // half4
