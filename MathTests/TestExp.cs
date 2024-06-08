﻿using System.Runtime.Intrinsics;
using Coplt.Mathematics;

#if NET8_0_OR_GREATER
using Coplt.Mathematics.Simd;
namespace MathTests;

public class TestExp
{
    [Test]
    [Parallelizable]
    public void FloatTestExp([Random(-60f, 60.0f, 1000)] float v)
    {
        var a = simd_float.Exp(new float4(v).UnsafeGetInner()).GetElement(0);
        var b = MathF.Exp(v);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(b, Is.EqualTo(a).Within(0.001f).Percent);
    }
    
    [Test]
    [Parallelizable]
    public void FloatTestExp2_vec_2_4([Random(-60f, 60.0f, 1000)] float v)
    {
        var a = simd_float.Exp(new float4(v).UnsafeGetInner()).GetElement(0);
        var b = simd_float.Exp(new float2(v).UnsafeGetInner()).GetElement(0);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(a, Is.EqualTo(b));
    }
    
    [Test]
    [Parallelizable]
    public void FloatTestExp2Err([Values(0, float.NaN, float.NegativeInfinity, float.PositiveInfinity)] float v)
    {
        var a = simd_float.Exp(new float4(v).UnsafeGetInner()).GetElement(0);
        var b = MathF.Exp(v);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(b, Is.EqualTo(a));
    }
    
    [Test]
    [Parallelizable]
    public void DoubleTestExp([Random(-600f, 600.0f, 1000)] float v)
    {
        var a = simd_double.Exp(new double4(v).UnsafeGetInner()).GetElement(0);
        var b = Math.Exp(v);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(b, Is.EqualTo(a).Within(0.000_000_000_1f).Percent);
    }
    
    [Test]
    [Parallelizable]
    public void DoubleTestExp2_vec_2_4([Random(-600f, 600.0f, 1000)] double v)
    {
        var a = simd_double.Exp(new double4(v).UnsafeGetInner()).GetElement(0);
        var b = simd_double.Exp(new double2(v).UnsafeGetInner()).GetElement(0);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(a, Is.EqualTo(b));
    }
    
    [Test]
    [Parallelizable]
    public void DoubleTestExp2Err([Values(0, double.NaN, double.NegativeInfinity, double.PositiveInfinity)] double v)
    {
        var a = simd_double.Exp(new double4(v).UnsafeGetInner()).GetElement(0);
        var b = Math.Exp(v);
        Console.WriteLine($"{a}");
        Console.WriteLine($"{b}");
        Assert.That(b, Is.EqualTo(a));
    }
  
}

#endif
