﻿#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.Wasm;
using System.Runtime.Intrinsics.X86;
using X86 = System.Runtime.Intrinsics.X86;

namespace Coplt.Mathematics;

public static partial class simd
{
    #region Cmp

    [MethodImpl(256 | 512)]
    public static Vector64<float> Ne(Vector64<float> a, Vector64<float> b)
    {
        if (Sse.IsSupported)
        {
            return Sse.CompareNotEqual(a.ToVector128(), b.ToVector128()).GetLower();
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.CompareNotEqual(a.ToVector128(), b.ToVector128()).GetLower();
        }
        return ~Vector64.Equals(a, b);
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Ne(Vector128<float> a, Vector128<float> b)
    {
        if (Sse.IsSupported)
        {
            return Sse.CompareNotEqual(a, b);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.CompareNotEqual(a, b);
        }
        return ~Vector128.Equals(a, b);
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Ne(Vector128<double> a, Vector128<double> b)
    {
        if (Sse2.IsSupported)
        {
            return Sse2.CompareNotEqual(a, b);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.CompareNotEqual(a, b);
        }
        return ~Vector128.Equals(a, b);
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Ne(Vector256<double> a, Vector256<double> b)
    {
        if (Avx.IsSupported)
        {
            return Avx.CompareNotEqual(a, b);
        }
        return ~Vector256.Equals(a, b);
    }

    #endregion

    #region Round

    [MethodImpl(256 | 512)]
    public static Vector64<float> Round(Vector64<float> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToNearestInteger(x.ToVector128()).GetLower();
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.RoundToNearest(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.RoundToNearest(x.ToVector128()).GetLower();
        }
        return Vector64.Create(
            MathF.Round(x.GetElement(0)),
            MathF.Round(x.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Round(Vector128<float> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToNearestInteger(x);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.RoundToNearest(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.RoundToNearest(x);
        }
        return Vector128.Create(
            MathF.Round(x.GetElement(0)),
            MathF.Round(x.GetElement(1)),
            MathF.Round(x.GetElement(2)),
            MathF.Round(x.GetElement(3))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Round(Vector128<double> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToNearestInteger(x);
        }
        if (AdvSimd.Arm64.IsSupported)
        {
            return AdvSimd.Arm64.RoundToNearest(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.RoundToNearest(x);
        }
        return Vector128.Create(
            Math.Round(x.GetElement(0)),
            Math.Round(x.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Round(Vector256<double> x)
    {
        if (Avx.IsSupported)
        {
            return Avx.RoundToNearestInteger(x);
        }
        if (AdvSimd.Arm64.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.Arm64.RoundToNearest(x.GetLower()),
                AdvSimd.Arm64.RoundToNearest(x.GetUpper())
            );
        }
        if (PackedSimd.IsSupported)
        {
            return Vector256.Create(
                PackedSimd.RoundToNearest(x.GetLower()),
                PackedSimd.RoundToNearest(x.GetUpper())
            );
        }
        return Vector256.Create(
            Math.Round(x.GetElement(0)),
            Math.Round(x.GetElement(1)),
            Math.Round(x.GetElement(2)),
            Math.Round(x.GetElement(3))
        );
    }

    #endregion

    #region Truncate

    [MethodImpl(256 | 512)]
    public static Vector64<float> Truncate(Vector64<float> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToZero(x.ToVector128()).GetLower();
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.RoundToZero(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.Truncate(x.ToVector128()).GetLower();
        }
        return Vector64.Create(
            MathF.Truncate(x.GetElement(0)),
            MathF.Truncate(x.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Truncate(Vector128<float> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToZero(x);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.RoundToZero(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.Truncate(x);
        }
        return Vector128.Create(
            MathF.Truncate(x.GetElement(0)),
            MathF.Truncate(x.GetElement(1)),
            MathF.Truncate(x.GetElement(2)),
            MathF.Truncate(x.GetElement(3))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Truncate(Vector128<double> x)
    {
        if (Sse41.IsSupported)
        {
            return Sse41.RoundToZero(x);
        }
        if (AdvSimd.Arm64.IsSupported)
        {
            return AdvSimd.Arm64.RoundToZero(x);
        }
        if (PackedSimd.IsSupported)
        {
            return PackedSimd.Truncate(x);
        }
        return Vector128.Create(
            Math.Truncate(x.GetElement(0)),
            Math.Truncate(x.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Truncate(Vector256<double> x)
    {
        if (Avx.IsSupported)
        {
            return Avx.RoundToZero(x);
        }
        if (AdvSimd.Arm64.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.Arm64.RoundToZero(x.GetLower()),
                AdvSimd.Arm64.RoundToZero(x.GetUpper())
            );
        }
        if (PackedSimd.IsSupported)
        {
            return Vector256.Create(
                PackedSimd.Truncate(x.GetLower()),
                PackedSimd.Truncate(x.GetUpper())
            );
        }
        return Vector256.Create(
            Math.Truncate(x.GetElement(0)),
            Math.Truncate(x.GetElement(1)),
            Math.Truncate(x.GetElement(2)),
            Math.Truncate(x.GetElement(3))
        );
    }

    #endregion

    #region ModF

    [MethodImpl(256 | 512)]
    public static Vector64<float> ModF(Vector64<float> d, out Vector64<float> i)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            i = Truncate(d);
            return d - i;
        }
        if (Vector64.IsHardwareAccelerated)
        {
            var r128 = ModF(d.ToVector128(), out var i128);
            i = i128.GetLower();
            return r128.GetLower();
        }

        var r = Vector64.Create(
            d.GetElement(0).modf(out var i0),
            d.GetElement(1).modf(out var i1)
        );
        i = Vector64.Create(i0, i1);
        return r;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> ModF(Vector128<float> d, out Vector128<float> i)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            i = Truncate(d);
            return d - i;
        }

        var r = Vector128.Create(
            d.GetElement(0).modf(out var i0),
            d.GetElement(1).modf(out var i1),
            d.GetElement(2).modf(out var i2),
            d.GetElement(3).modf(out var i3)
        );
        i = Vector128.Create(i0, i1, i2, i3);
        return r;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> ModF(Vector128<double> d, out Vector128<double> i)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            i = Truncate(d);
            return d - i;
        }

        var r = Vector128.Create(
            d.GetElement(0).modf(out var i0),
            d.GetElement(1).modf(out var i1)
        );
        i = Vector128.Create(i0, i1);
        return r;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> ModF(Vector256<double> d, out Vector256<double> i)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            i = Truncate(d);
            return d - i;
        }
        if (Vector128.IsHardwareAccelerated)
        {
            var i_l = Truncate(d.GetLower());
            var i_u = Truncate(d.GetUpper());
            var r_l = d.GetLower() - i_l;
            var r_u = d.GetUpper() - i_l;
            i = Vector256.Create(i_l, i_u);
            return Vector256.Create(r_l, r_u);
        }

        var r = Vector256.Create(
            d.GetElement(0).modf(out var i0),
            d.GetElement(1).modf(out var i1),
            d.GetElement(2).modf(out var i2),
            d.GetElement(3).modf(out var i3)
        );
        i = Vector256.Create(i0, i1, i2, i3);
        return r;
    }

    #endregion

    #region Sign

    [MethodImpl(256 | 512)]
    public static Vector64<T> SignInt<T>(Vector64<T> v)
    {
        var pos = Vector64.GreaterThan(v, default) & Vector64<T>.One;
        var neg = Vector64.LessThan(v, default) & -Vector64<T>.One;
        return pos | neg;
    }

    [MethodImpl(256 | 512)]
    public static Vector64<T> SignUInt<T>(Vector64<T> v)
    {
        return Vector64.GreaterThan(v, default) & Vector64<T>.One;
    }

    [MethodImpl(256 | 512)]
    public static Vector64<T> SignFloat<T>(Vector64<T> v)
    {
        var a = v & -Vector64<T>.Zero | Vector64<T>.One;
        var c = Vector64.Equals(v, default);
        return Vector64.AndNot(a, c);
    }

    [MethodImpl(256 | 512)]
    public static unsafe Vector128<T> SignInt<T>(Vector128<T> v)
    {
        var pos = Vector128.GreaterThan(v, default) & Vector128<T>.One;
        var neg = Vector128.LessThan(v, default) & -Vector128<T>.One;
        return pos | neg;
    }

    [MethodImpl(256 | 512)]
    public static unsafe Vector128<T> SignUInt<T>(Vector128<T> v)
    {
        return Vector128.GreaterThan(v, default) & Vector128<T>.One;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<T> SignFloat<T>(Vector128<T> v)
    {
        var a = v & -Vector128<T>.Zero | Vector128<T>.One;
        var c = Vector128.Equals(v, default);
        return Vector128.AndNot(a, c);
    }

    [MethodImpl(256 | 512)]
    public static unsafe Vector256<T> SignInt<T>(Vector256<T> v)
    {
        var pos = Vector256.GreaterThan(v, default) & Vector256<T>.One;
        var neg = Vector256.LessThan(v, default) & -Vector256<T>.One;
        return pos | neg;
    }

    [MethodImpl(256 | 512)]
    public static unsafe Vector256<T> SignUInt<T>(Vector256<T> v)
    {
        return Vector256.GreaterThan(v, default) & Vector256<T>.One;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<T> SignFloat<T>(Vector256<T> v)
    {
        var a = v & -Vector256<T>.Zero | Vector256<T>.One;
        var c = Vector256.Equals(v, default);
        return Vector256.AndNot(a, c);
    }

    #endregion

    #region Fma

    [MethodImpl(256 | 512)]
    public static Vector64<float> Fma(Vector64<float> a, Vector64<float> b, Vector64<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAdd(a.ToVector128(), b.ToVector128(), c.ToVector128()).GetLower();
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.FusedMultiplyAdd(c, a, b);
        }
        return a * b + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Fma(Vector128<float> a, Vector128<float> b, Vector128<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAdd(a, b, c);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.FusedMultiplyAdd(c, a, b);
        }
        return a * b + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Fma(Vector128<double> a, Vector128<double> b, Vector128<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAdd(a, b, c);
        }
        return a * b + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<float> Fma(Vector256<float> a, Vector256<float> b, Vector256<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAdd(a, b, c);
        }
        if (AdvSimd.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.FusedMultiplyAdd(c.GetLower(), a.GetLower(), b.GetLower()),
                AdvSimd.FusedMultiplyAdd(c.GetUpper(), a.GetUpper(), b.GetUpper())
            );
        }
        return a * b + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Fma(Vector256<double> a, Vector256<double> b, Vector256<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAdd(a, b, c);
        }
        return a * b + c;
    }

    #endregion

    #region IsInfinity

    [MethodImpl(256 | 512)]
    public static Vector64<int> IsInfinity(Vector64<float> f)
    {
        var bits = f.AsInt32();
        return Vector64.Equals(bits & Vector64.Create(int.MaxValue), Vector64.Create(0x7F800000));
    }

    [MethodImpl(256 | 512)]
    public static Vector128<int> IsInfinity(Vector128<float> f)
    {
        var bits = f.AsInt32();
        return Vector128.Equals(bits & Vector128.Create(int.MaxValue), Vector128.Create(0x7F800000));
    }

    [MethodImpl(256 | 512)]
    public static Vector128<long> IsInfinity(Vector128<double> f)
    {
        var bits = f.AsInt64();
        return Vector128.Equals(bits & Vector128.Create(long.MaxValue), Vector128.Create(0x7FF0000000000000L));
    }

    [MethodImpl(256 | 512)]
    public static Vector256<long> IsInfinity(Vector256<double> f)
    {
        var bits = f.AsInt64();
        return Vector256.Equals(bits & Vector256.Create(long.MaxValue), Vector256.Create(0x7FF0000000000000L));
    }

    #endregion

    #region Log

    [MethodImpl(256 | 512)]
    public static Vector64<float> Log(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Log(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Log(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Log(d.GetLower()),
                simd_float.Log(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log(),
            d.GetElement(2).log(),
            d.GetElement(3).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Log(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Log(d);
        }
        return Vector128.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Log(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Log(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Log(d.GetLower()),
                simd_double.Log(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log(),
            d.GetElement(2).log(),
            d.GetElement(3).log()
        );
    }

    #endregion

    #region Log Fast

    [MethodImpl(256 | 512)]
    public static Vector64<float> LogFast(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.LogFast(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.LogFast(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> LogFast(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.LogFast(d);
        }
        return Vector128.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log(),
            d.GetElement(2).log(),
            d.GetElement(3).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector64<float> LogFastFast(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.LogFast(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.LogFastFast(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> LogFastFast(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.LogFastFast(d);
        }
        return Vector128.Create(
            d.GetElement(0).log(),
            d.GetElement(1).log(),
            d.GetElement(2).log(),
            d.GetElement(3).log()
        );
    }

    #endregion

    #region Log2

    [MethodImpl(256 | 512)]
    public static Vector64<float> Log2(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Log2(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log2(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).log2(),
            d.GetElement(1).log2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Log2(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log2(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Log2(d.GetLower()),
                simd_float.Log2(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).log2(),
            d.GetElement(1).log2(),
            d.GetElement(2).log2(),
            d.GetElement(3).log2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Log2(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Log2(d);
        }
        return Vector128.Create(
            d.GetElement(0).log2(),
            d.GetElement(1).log2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Log2(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Log2(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Log2(d.GetLower()),
                simd_double.Log2(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).log2(),
            d.GetElement(1).log2(),
            d.GetElement(2).log2(),
            d.GetElement(3).log2()
        );
    }

    #endregion

    #region Log10

    [MethodImpl(256 | 512)]
    public static Vector64<float> Log10(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Log10(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log10(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).log10(),
            d.GetElement(1).log10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Log10(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Log10(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Log10(d.GetLower()),
                simd_float.Log10(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).log10(),
            d.GetElement(1).log10(),
            d.GetElement(2).log10(),
            d.GetElement(3).log10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Log10(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Log10(d);
        }
        return Vector128.Create(
            d.GetElement(0).log10(),
            d.GetElement(1).log10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Log10(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Log10(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Log10(d.GetLower()),
                simd_double.Log10(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).log10(),
            d.GetElement(1).log10(),
            d.GetElement(2).log10(),
            d.GetElement(3).log10()
        );
    }

    #endregion

    #region Exp

    [MethodImpl(256 | 512)]
    public static Vector64<float> Exp(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Exp(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).exp(),
            d.GetElement(1).exp()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Exp(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Exp(d.GetLower()),
                simd_float.Exp(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).exp(),
            d.GetElement(1).exp(),
            d.GetElement(2).exp(),
            d.GetElement(3).exp()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Exp(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Exp(d);
        }
        return Vector128.Create(
            d.GetElement(0).exp(),
            d.GetElement(1).exp()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Exp(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Exp(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Exp(d.GetLower()),
                simd_double.Exp(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).exp(),
            d.GetElement(1).exp(),
            d.GetElement(2).exp(),
            d.GetElement(3).exp()
        );
    }

    #endregion

    #region Pow

    [MethodImpl(256 | 512)]
    public static Vector64<float> Pow(Vector64<float> a, Vector64<float> b)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Pow(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Pow(a.ToVector128(), b.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).pow(b.GetElement(0)),
            a.GetElement(1).pow(b.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Pow(Vector128<float> a, Vector128<float> b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Pow(a, b);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Pow(a.GetLower(), b.GetLower()),
                simd_float.Pow(a.GetUpper(), b.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).pow(b.GetElement(0)),
            a.GetElement(1).pow(b.GetElement(1)),
            a.GetElement(2).pow(b.GetElement(2)),
            a.GetElement(3).pow(b.GetElement(3))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Pow(Vector128<double> a, Vector128<double> b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Pow(a, b);
        }
        return Vector128.Create(
            a.GetElement(0).pow(b.GetElement(0)),
            a.GetElement(1).pow(b.GetElement(1))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Pow(Vector256<double> a, Vector256<double> b)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Pow(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Pow(a.GetLower(), b.GetLower()),
                simd_double.Pow(a.GetUpper(), b.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).pow(b.GetElement(0)),
            a.GetElement(1).pow(b.GetElement(1)),
            a.GetElement(2).pow(b.GetElement(2)),
            a.GetElement(3).pow(b.GetElement(3))
        );
    }

    #endregion

    #region Pow Scalar

    [MethodImpl(256 | 512)]
    public static Vector64<float> Pow(Vector64<float> a, float b)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Pow(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Pow(a.ToVector128(), b).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).pow(b),
            a.GetElement(1).pow(b)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Pow(Vector128<float> a, float b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Pow(a, b);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Pow(a.GetLower(), b),
                simd_float.Pow(a.GetUpper(), b)
            );
        }
        return Vector128.Create(
            a.GetElement(0).pow(b),
            a.GetElement(1).pow(b),
            a.GetElement(2).pow(b),
            a.GetElement(3).pow(b)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Pow(Vector128<double> a, double b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Pow(a, b);
        }
        return Vector128.Create(
            a.GetElement(0).pow(b),
            a.GetElement(1).pow(b)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Pow(Vector256<double> a, double b)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Pow(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Pow(a.GetLower(), b),
                simd_double.Pow(a.GetUpper(), b)
            );
        }
        return Vector256.Create(
            a.GetElement(0).pow(b),
            a.GetElement(1).pow(b),
            a.GetElement(2).pow(b),
            a.GetElement(3).pow(b)
        );
    }

    #endregion
}

#endif
