// generated by template, do not modify manually

namespace Coplt.Mathematics;

#region float2

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static float2 ceil(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector64.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 floor(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector64.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 round(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 trunc(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 frac(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector64.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float2 rcp(this float2 a)
    {
        #if NET8_0_OR_GREATER
        return float2.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float2

#region float3

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static float3 ceil(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 floor(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor(), a.z.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 round(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round(), a.z.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 trunc(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 frac(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac(), a.z.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float3 rcp(this float3 a)
    {
        #if NET8_0_OR_GREATER
        return float3.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float3

#region float4

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static float4 ceil(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil(), a.w.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 floor(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor(), a.z.floor(), a.w.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 round(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round(), a.z.round(), a.w.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 trunc(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc(), a.w.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 frac(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac(), a.z.frac(), a.w.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static float4 rcp(this float4 a)
    {
        #if NET8_0_OR_GREATER
        return float4.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp(), a.w.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // float4

#region double2

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static double2 ceil(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 floor(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 round(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 trunc(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 frac(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector128.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double2 rcp(this double2 a)
    {
        #if NET8_0_OR_GREATER
        return double2.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double2

#region double3

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static double3 ceil(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 floor(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor(), a.z.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 round(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round(), a.z.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 trunc(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 frac(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector256.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac(), a.z.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double3 rcp(this double3 a)
    {
        #if NET8_0_OR_GREATER
        return double3.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double3

#region double4

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static double4 ceil(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Ceiling(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil(), a.w.ceil());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 floor(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(Vector256.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.floor(), a.y.floor(), a.z.floor(), a.w.floor());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 round(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Round(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.round(), a.y.round(), a.z.round(), a.w.round());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 trunc(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(simd.Truncate(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc(), a.w.trunc());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 frac(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return new(a.vector - Vector256.Floor(a.vector));
        #else // NET8_0_OR_GREATER
        return new(a.x.frac(), a.y.frac(), a.z.frac(), a.w.frac());
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public static double4 rcp(this double4 a)
    {
        #if NET8_0_OR_GREATER
        return double4.One / a;
        #else // NET8_0_OR_GREATER
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp(), a.w.rcp());
        #endif // NET8_0_OR_GREATER
    }
}

#endregion // double4

#region decimal2

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static decimal2 ceil(this decimal2 a)
    {
        return new(a.x.ceil(), a.y.ceil());
    }

    [MethodImpl(256 | 512)]
    public static decimal2 floor(this decimal2 a)
    {
        return new(a.x.floor(), a.y.floor());
    }

    [MethodImpl(256 | 512)]
    public static decimal2 round(this decimal2 a)
    {
        return new(a.x.round(), a.y.round());
    }

    [MethodImpl(256 | 512)]
    public static decimal2 trunc(this decimal2 a)
    {
        return new(a.x.trunc(), a.y.trunc());
    }

    [MethodImpl(256 | 512)]
    public static decimal2 frac(this decimal2 a)
    {
        return new(a.x.frac(), a.y.frac());
    }

    [MethodImpl(256 | 512)]
    public static decimal2 rcp(this decimal2 a)
    {
        return new(a.x.rcp(), a.y.rcp());
    }
}

#endregion // decimal2

#region decimal3

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static decimal3 ceil(this decimal3 a)
    {
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil());
    }

    [MethodImpl(256 | 512)]
    public static decimal3 floor(this decimal3 a)
    {
        return new(a.x.floor(), a.y.floor(), a.z.floor());
    }

    [MethodImpl(256 | 512)]
    public static decimal3 round(this decimal3 a)
    {
        return new(a.x.round(), a.y.round(), a.z.round());
    }

    [MethodImpl(256 | 512)]
    public static decimal3 trunc(this decimal3 a)
    {
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc());
    }

    [MethodImpl(256 | 512)]
    public static decimal3 frac(this decimal3 a)
    {
        return new(a.x.frac(), a.y.frac(), a.z.frac());
    }

    [MethodImpl(256 | 512)]
    public static decimal3 rcp(this decimal3 a)
    {
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp());
    }
}

#endregion // decimal3

#region decimal4

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static decimal4 ceil(this decimal4 a)
    {
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil(), a.w.ceil());
    }

    [MethodImpl(256 | 512)]
    public static decimal4 floor(this decimal4 a)
    {
        return new(a.x.floor(), a.y.floor(), a.z.floor(), a.w.floor());
    }

    [MethodImpl(256 | 512)]
    public static decimal4 round(this decimal4 a)
    {
        return new(a.x.round(), a.y.round(), a.z.round(), a.w.round());
    }

    [MethodImpl(256 | 512)]
    public static decimal4 trunc(this decimal4 a)
    {
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc(), a.w.trunc());
    }

    [MethodImpl(256 | 512)]
    public static decimal4 frac(this decimal4 a)
    {
        return new(a.x.frac(), a.y.frac(), a.z.frac(), a.w.frac());
    }

    [MethodImpl(256 | 512)]
    public static decimal4 rcp(this decimal4 a)
    {
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp(), a.w.rcp());
    }
}

#endregion // decimal4

#region half2

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static half2 ceil(this half2 a)
    {
        return new(a.x.ceil(), a.y.ceil());
    }

    [MethodImpl(256 | 512)]
    public static half2 floor(this half2 a)
    {
        return new(a.x.floor(), a.y.floor());
    }

    [MethodImpl(256 | 512)]
    public static half2 round(this half2 a)
    {
        return new(a.x.round(), a.y.round());
    }

    [MethodImpl(256 | 512)]
    public static half2 trunc(this half2 a)
    {
        return new(a.x.trunc(), a.y.trunc());
    }

    [MethodImpl(256 | 512)]
    public static half2 frac(this half2 a)
    {
        return new(a.x.frac(), a.y.frac());
    }

    [MethodImpl(256 | 512)]
    public static half2 rcp(this half2 a)
    {
        return new(a.x.rcp(), a.y.rcp());
    }
}

#endregion // half2

#region half3

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static half3 ceil(this half3 a)
    {
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil());
    }

    [MethodImpl(256 | 512)]
    public static half3 floor(this half3 a)
    {
        return new(a.x.floor(), a.y.floor(), a.z.floor());
    }

    [MethodImpl(256 | 512)]
    public static half3 round(this half3 a)
    {
        return new(a.x.round(), a.y.round(), a.z.round());
    }

    [MethodImpl(256 | 512)]
    public static half3 trunc(this half3 a)
    {
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc());
    }

    [MethodImpl(256 | 512)]
    public static half3 frac(this half3 a)
    {
        return new(a.x.frac(), a.y.frac(), a.z.frac());
    }

    [MethodImpl(256 | 512)]
    public static half3 rcp(this half3 a)
    {
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp());
    }
}

#endregion // half3

#region half4

public static partial class math
{
    [MethodImpl(256 | 512)]
    public static half4 ceil(this half4 a)
    {
        return new(a.x.ceil(), a.y.ceil(), a.z.ceil(), a.w.ceil());
    }

    [MethodImpl(256 | 512)]
    public static half4 floor(this half4 a)
    {
        return new(a.x.floor(), a.y.floor(), a.z.floor(), a.w.floor());
    }

    [MethodImpl(256 | 512)]
    public static half4 round(this half4 a)
    {
        return new(a.x.round(), a.y.round(), a.z.round(), a.w.round());
    }

    [MethodImpl(256 | 512)]
    public static half4 trunc(this half4 a)
    {
        return new(a.x.trunc(), a.y.trunc(), a.z.trunc(), a.w.trunc());
    }

    [MethodImpl(256 | 512)]
    public static half4 frac(this half4 a)
    {
        return new(a.x.frac(), a.y.frac(), a.z.frac(), a.w.frac());
    }

    [MethodImpl(256 | 512)]
    public static half4 rcp(this half4 a)
    {
        return new(a.x.rcp(), a.y.rcp(), a.z.rcp(), a.w.rcp());
    }
}

#endregion // half4
