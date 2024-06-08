﻿#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.Wasm;
using System.Runtime.Intrinsics.X86;
using X86 = System.Runtime.Intrinsics.X86;

namespace Coplt.Mathematics.Simd;

public static partial class simd
{
    #region Convert

    [MethodImpl(256 | 512)]
    public static Vector128<int> ToInt32(Vector256<double> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector128Int32(v);
        }
        return Vector128.Narrow(Vector128.ConvertToInt64(v.GetLower()), Vector128.ConvertToInt64(v.GetUpper()));
    }

    [MethodImpl(256 | 512)]
    public static Vector128<uint> ToUInt32(Vector256<double> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector128Int32(v).AsUInt32();
        }
        return Vector128.Narrow(Vector128.ConvertToUInt64(v.GetLower()), Vector128.ConvertToUInt64(v.GetUpper()));
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> ToSingle(Vector256<double> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector128Single(v);
        }
        return Vector128.Narrow(v.GetLower(), v.GetUpper());
    }

    [MethodImpl(256 | 512)]
    public static Vector64<float> ToSingle(Vector128<double> v)
    {
        return Vector64.Narrow(v.GetLower(), v.GetUpper());
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> ToDouble(Vector128<float> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector256Double(v);
        }
        var (l, u) = Vector128.Widen(v);
        return Vector256.Create(l, u);
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> ToDouble(Vector64<float> v)
    {
        var (l, u) = Vector64.Widen(v);
        return Vector128.Create(l, u);
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> ToDouble(Vector128<int> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector256Double(v);
        }
        var (l, u) = Vector128.Widen(v);
        return Vector256.Create(Vector128.ConvertToDouble(l), Vector128.ConvertToDouble(u));
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> ToDouble(Vector128<uint> v)
    {
        if (Avx.IsSupported)
        {
            return Avx.ConvertToVector256Double(v.AsInt32());
        }
        var (l, u) = Vector128.Widen(v);
        return Vector256.Create(Vector128.ConvertToDouble(l), Vector128.ConvertToDouble(u));
    }

    #endregion

    #region Low2LowHigh

    /// <summary>
    /// <code>
    /// a (x0, y0, z0, w0) (l0, h0)
    /// b (x1, y1, z1, w1) (l1, h1)
    /// r (x0, y0, x1, y1) (l0, l1)
    /// </code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector128<T> MoveLowToHigh<T>(Vector128<T> a, Vector128<T> b)
    {
        if (Sse.IsSupported)
        {
            return Sse.MoveLowToHigh(a.As<T, float>(), b.As<T, float>()).As<float, T>();
        }
        return a.WithUpper(b.GetLower());
    }

    /// <summary>
    /// <code>
    /// a (x0, y0, z0, w0) (l0, h0)
    /// b (x1, y1, z1, w1) (l1, h1)
    /// r (x0, y0, x1, y1) (l0, l1)
    /// </code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector256<T> MoveLowToHigh<T>(Vector256<T> a, Vector256<T> b)
    {
        if (Avx.IsSupported)
        {
            return Avx.Permute2x128(a.As<T, double>(), b.As<T, double>(), 0b0010_0000).As<double, T>();
        }
        return a.WithUpper(b.GetLower());
    }

    #endregion

    #region High2HighLow

    /// <summary>
    /// <code>
    /// a (x0, y0, z0, w0) (l0, h0)
    /// b (x1, y1, z1, w1) (l1, h1)
    /// r (z1, w1, z0, w0) (h1, h0)
    /// </code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector128<T> MoveHighToLow<T>(Vector128<T> a, Vector128<T> b)
    {
        if (Sse.IsSupported)
        {
            return Sse.MoveHighToLow(a.As<T, float>(), b.As<T, float>()).As<float, T>();
        }
        return a.WithLower(b.GetUpper());
    }

    /// <summary>
    /// <code>
    /// a (x0, y0, z0, w0) (l0, h0)
    /// b (x1, y1, z1, w1) (l1, h1)
    /// r (z1, w1, z0, w0) (h1, h0)
    /// </code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector256<T> MoveHighToLow<T>(Vector256<T> a, Vector256<T> b)
    {
        if (Avx.IsSupported)
        {
            return Avx.Permute2x128(a.As<T, double>(), b.As<T, double>(), 0b0001_0011).As<double, T>();
        }
        return a.WithLower(b.GetUpper());
    }

    #endregion

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
    public static Vector256<float> Ne(Vector256<float> a, Vector256<float> b)
    {
        if (Avx.IsSupported)
        {
            return Avx.CompareNotEqual(a, b);
        }
        return ~Vector256.Equals(a, b);
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

    [MethodImpl(256 | 512)]
    public static Vector512<double> Ne(Vector512<double> a, Vector512<double> b)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.CompareNotEqual(a, b);
        }
        return ~Vector512.Equals(a, b);
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
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                Round(x.GetLower()),
                Round(x.GetUpper())
            );
        }
        return Vector128.Create(
            MathF.Round(x.GetElement(0)),
            MathF.Round(x.GetElement(1)),
            MathF.Round(x.GetElement(2)),
            MathF.Round(x.GetElement(3))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<float> Round(Vector256<float> x)
    {
        if (Avx.IsSupported)
        {
            return Avx.RoundToNearestInteger(x);
        }
        if (Vector128.IsHardwareAccelerated | Vector64.IsHardwareAccelerated)
        {
            return Vector256.Create(
                Round(x.GetLower()),
                Round(x.GetUpper())
            );
        }
        return Vector256.Create(
            MathF.Round(x.GetElement(0)),
            MathF.Round(x.GetElement(1)),
            MathF.Round(x.GetElement(2)),
            MathF.Round(x.GetElement(3)),
            MathF.Round(x.GetElement(4)),
            MathF.Round(x.GetElement(5)),
            MathF.Round(x.GetElement(6)),
            MathF.Round(x.GetElement(7))
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
        if (Vector128.IsHardwareAccelerated || Vector64.IsHardwareAccelerated)
        {
            return Vector256.Create(
                Round(x.GetLower()),
                Round(x.GetUpper())
            );
        }
        return Vector256.Create(
            Math.Round(x.GetElement(0)),
            Math.Round(x.GetElement(1)),
            Math.Round(x.GetElement(2)),
            Math.Round(x.GetElement(3))
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector512<double> Round(Vector512<double> x)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.RoundScale(x, 0);
        }
        if (Vector256.IsHardwareAccelerated || Vector128.IsHardwareAccelerated || Vector64.IsHardwareAccelerated)
        {
            return Vector512.Create(
                Round(x.GetLower()),
                Round(x.GetUpper())
            );
        }
        return Vector512.Create(
            Math.Round(x.GetElement(0)),
            Math.Round(x.GetElement(1)),
            Math.Round(x.GetElement(2)),
            Math.Round(x.GetElement(3)),
            Math.Round(x.GetElement(5)),
            Math.Round(x.GetElement(6)),
            Math.Round(x.GetElement(7)),
            Math.Round(x.GetElement(8))
        );
    }

    public static bool IsRoundF256HardwareAccelerated
    {
        [MethodImpl(256 | 512)]
        get => Avx.IsSupported;
    }

    public static bool IsRoundD512HardwareAccelerated
    {
        [MethodImpl(256 | 512)]
        get => Avx512F.IsSupported;
    }

    #endregion

    #region RoundToZero

    [MethodImpl(256 | 512)]
    public static Vector64<float> RoundToZero(Vector64<float> x)
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
            MathF.Round(x.GetElement(0), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(1), MidpointRounding.ToZero)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> RoundToZero(Vector128<float> x)
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
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                RoundToZero(x.GetLower()),
                RoundToZero(x.GetUpper())
            );
        }
        return Vector128.Create(
            MathF.Round(x.GetElement(0), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(1), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(2), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(3), MidpointRounding.ToZero)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<float> RoundToZero(Vector256<float> x)
    {
        if (Avx.IsSupported)
        {
            return Avx.RoundToZero(x);
        }
        if (Vector128.IsHardwareAccelerated || Vector64.IsHardwareAccelerated)
        {
            return Vector256.Create(
                RoundToZero(x.GetLower()),
                RoundToZero(x.GetUpper())
            );
        }
        return Vector256.Create(
            MathF.Round(x.GetElement(0), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(1), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(2), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(3), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(4), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(5), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(6), MidpointRounding.ToZero),
            MathF.Round(x.GetElement(7), MidpointRounding.ToZero)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> RoundToZero(Vector128<double> x)
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
            Math.Round(x.GetElement(0), MidpointRounding.ToZero),
            Math.Round(x.GetElement(1), MidpointRounding.ToZero)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> RoundToZero(Vector256<double> x)
    {
        if (Avx.IsSupported)
        {
            return Avx.RoundToZero(x);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                RoundToZero(x.GetLower()),
                RoundToZero(x.GetUpper())
            );
        }
        return Vector256.Create(
            Math.Round(x.GetElement(0), MidpointRounding.ToZero),
            Math.Round(x.GetElement(1), MidpointRounding.ToZero),
            Math.Round(x.GetElement(2), MidpointRounding.ToZero),
            Math.Round(x.GetElement(3), MidpointRounding.ToZero)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector512<double> RoundToZero(Vector512<double> x)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.RoundScale(x, 0x03);
        }
        if (Vector256.IsHardwareAccelerated || Vector128.IsHardwareAccelerated)
        {
            return Vector512.Create(
                RoundToZero(x.GetLower()),
                RoundToZero(x.GetUpper())
            );
        }
        return Vector512.Create(
            Math.Round(x.GetElement(0), MidpointRounding.ToZero),
            Math.Round(x.GetElement(1), MidpointRounding.ToZero),
            Math.Round(x.GetElement(2), MidpointRounding.ToZero),
            Math.Round(x.GetElement(3), MidpointRounding.ToZero),
            Math.Round(x.GetElement(4), MidpointRounding.ToZero),
            Math.Round(x.GetElement(5), MidpointRounding.ToZero),
            Math.Round(x.GetElement(6), MidpointRounding.ToZero),
            Math.Round(x.GetElement(7), MidpointRounding.ToZero)
        );
    }

    #endregion

    #region Mod

    [MethodImpl(256 | 512)]
    public static Vector64<float> Mod(Vector64<float> a, Vector64<float> b)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Mod(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Mod(a.ToVector128(), b.ToVector128()).GetLower();
        }

        return Vector64.Create(
            a.GetElement(0) % b.GetElement(0),
            a.GetElement(1) % b.GetElement(1)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Mod(Vector128<float> a, Vector128<float> b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Mod(a, b);
        }

        return Vector128.Create(
            a.GetElement(0) % b.GetElement(0),
            a.GetElement(1) % b.GetElement(1),
            a.GetElement(2) % b.GetElement(2),
            a.GetElement(3) % b.GetElement(3)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Mod(Vector128<double> a, Vector128<double> b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Mod(a, b);
        }

        return Vector128.Create(
            a.GetElement(0) % b.GetElement(0),
            a.GetElement(1) % b.GetElement(1)
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Mod(Vector256<double> a, Vector256<double> b)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Mod(a, b);
        }

        return Vector256.Create(
            a.GetElement(0) % b.GetElement(0),
            a.GetElement(1) % b.GetElement(1),
            a.GetElement(2) % b.GetElement(2),
            a.GetElement(3) % b.GetElement(3)
        );
    }

    #endregion

    #region Mod Scalar

    [MethodImpl(256 | 512)]
    public static Vector64<float> Mod(Vector64<float> a, float b)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Mod(a, b);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Mod(a.ToVector128(), b).GetLower();
        }

        return Vector64.Create(
            a.GetElement(0) % b,
            a.GetElement(1) % b
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Mod(Vector128<float> a, float b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Mod(a, b);
        }

        return Vector128.Create(
            a.GetElement(0) % b,
            a.GetElement(1) % b,
            a.GetElement(2) % b,
            a.GetElement(3) % b
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Mod(Vector128<double> a, double b)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Mod(a, b);
        }

        return Vector128.Create(
            a.GetElement(0) % b,
            a.GetElement(1) % b
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Mod(Vector256<double> a, double b)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Mod(a, b);
        }

        return Vector256.Create(
            a.GetElement(0) % b,
            a.GetElement(1) % b,
            a.GetElement(2) % b,
            a.GetElement(3) % b
        );
    }

    #endregion

    #region ModF

    [MethodImpl(256 | 512)]
    public static Vector64<float> ModF(Vector64<float> d, out Vector64<float> i)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            i = RoundToZero(d);
            return d - i;
        }
        if (Vector128.IsHardwareAccelerated)
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
            i = RoundToZero(d);
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
            i = RoundToZero(d);
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
            i = RoundToZero(d);
            return d - i;
        }
        if (Vector128.IsHardwareAccelerated)
        {
            var i_l = RoundToZero(d.GetLower());
            var i_u = RoundToZero(d.GetUpper());
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

    [MethodImpl(256 | 512)]
    public static Vector512<double> Fma(Vector512<double> a, Vector512<double> b, Vector512<double> c)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.FusedMultiplyAdd(a, b, c);
        }
        return a * b + c;
    }

    #endregion

    #region Fms

    [MethodImpl(256 | 512)]
    public static Vector64<float> Fms(Vector64<float> a, Vector64<float> b, Vector64<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplySubtract(a.ToVector128(), b.ToVector128(), c.ToVector128()).GetLower();
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.FusedMultiplySubtract(c, a, b);
        }
        return a * b - c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Fms(Vector128<float> a, Vector128<float> b, Vector128<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplySubtract(a, b, c);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.FusedMultiplySubtract(c, a, b);
        }
        return a * b - c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Fms(Vector128<double> a, Vector128<double> b, Vector128<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplySubtract(a, b, c);
        }
        return a * b - c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<float> Fms(Vector256<float> a, Vector256<float> b, Vector256<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplySubtract(a, b, c);
        }
        if (AdvSimd.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.FusedMultiplySubtract(c.GetLower(), a.GetLower(), b.GetLower()),
                AdvSimd.FusedMultiplySubtract(c.GetUpper(), a.GetUpper(), b.GetUpper())
            );
        }
        return a * b - c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Fms(Vector256<double> a, Vector256<double> b, Vector256<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplySubtract(a, b, c);
        }
        return a * b - c;
    }

    [MethodImpl(256 | 512)]
    public static Vector512<double> Fms(Vector512<double> a, Vector512<double> b, Vector512<double> c)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.FusedMultiplySubtract(a, b, c);
        }
        return a * b - c;
    }

    #endregion

    #region Fnma

    [MethodImpl(256 | 512)]
    public static Vector64<float> Fnma(Vector64<float> a, Vector64<float> b, Vector64<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAddNegated(a.ToVector128(), b.ToVector128(), c.ToVector128()).GetLower();
        }
        return -(a * b) + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Fnma(Vector128<float> a, Vector128<float> b, Vector128<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAddNegated(a, b, c);
        }
        return -(a * b) + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Fnma(Vector128<double> a, Vector128<double> b, Vector128<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAddNegated(a, b, c);
        }
        return -(a * b) + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<float> Fnma(Vector256<float> a, Vector256<float> b, Vector256<float> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAddNegated(a, b, c);
        }
        return -(a * b) + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Fnma(Vector256<double> a, Vector256<double> b, Vector256<double> c)
    {
        if (X86.Fma.IsSupported)
        {
            return X86.Fma.MultiplyAddNegated(a, b, c);
        }
        return -(a * b) + c;
    }

    [MethodImpl(256 | 512)]
    public static Vector512<double> Fnma(Vector512<double> a, Vector512<double> b, Vector512<double> c)
    {
        if (Avx512F.IsSupported)
        {
            return Avx512F.FusedMultiplyAddNegated(a, b, c);
        }
        return -(a * b) + c;
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

    #region Exp2

    [MethodImpl(256 | 512)]
    public static Vector64<float> Exp2(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Exp2(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp2(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).exp2(),
            d.GetElement(1).exp2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Exp2(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp2(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Exp2(d.GetLower()),
                simd_float.Exp2(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).exp2(),
            d.GetElement(1).exp2(),
            d.GetElement(2).exp2(),
            d.GetElement(3).exp2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Exp2(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Exp2(d);
        }
        return Vector128.Create(
            d.GetElement(0).exp2(),
            d.GetElement(1).exp2()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Exp2(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Exp2(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Exp2(d.GetLower()),
                simd_double.Exp2(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).exp2(),
            d.GetElement(1).exp2(),
            d.GetElement(2).exp2(),
            d.GetElement(3).exp2()
        );
    }

    #endregion

    #region Exp10

    [MethodImpl(256 | 512)]
    public static Vector64<float> Exp10(Vector64<float> d)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Exp10(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp10(d.ToVector128()).GetLower();
        }
        return Vector64.Create(
            d.GetElement(0).exp10(),
            d.GetElement(1).exp10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Exp10(Vector128<float> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Exp10(d);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Exp10(d.GetLower()),
                simd_float.Exp10(d.GetUpper())
            );
        }
        return Vector128.Create(
            d.GetElement(0).exp10(),
            d.GetElement(1).exp10(),
            d.GetElement(2).exp10(),
            d.GetElement(3).exp10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Exp10(Vector128<double> d)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Exp10(d);
        }
        return Vector128.Create(
            d.GetElement(0).exp10(),
            d.GetElement(1).exp10()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Exp10(Vector256<double> d)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Exp10(d);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Exp10(d.GetLower()),
                simd_double.Exp10(d.GetUpper())
            );
        }
        return Vector256.Create(
            d.GetElement(0).exp10(),
            d.GetElement(1).exp10(),
            d.GetElement(2).exp10(),
            d.GetElement(3).exp10()
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

    #region Rcp

    [MethodImpl(256 | 512)]
    public static Vector64<float> Rcp(Vector64<float> a)
    {
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.ReciprocalEstimate(a);
        }
        if (!Vector64.IsHardwareAccelerated && Vector128.IsHardwareAccelerated)
        {
            return Rcp(a.ToVector128()).GetLower();
        }

        return Vector64<float>.One / a;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Rcp(Vector128<float> a)
    {
        if (Sse.IsSupported)
        {
            return Sse.Reciprocal(a);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.ReciprocalEstimate(a);
        }

        return Vector128<float>.One / a;
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Rcp(Vector128<double> a)
    {
        if (AdvSimd.Arm64.IsSupported)
        {
            return AdvSimd.Arm64.ReciprocalEstimate(a);
        }

        return Vector128<double>.One / a;
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Rcp(Vector256<double> a)
    {
        if (AdvSimd.Arm64.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.Arm64.ReciprocalEstimate(a.GetLower()),
                AdvSimd.Arm64.ReciprocalEstimate(a.GetUpper())
            );
        }

        return Vector256<double>.One / a;
    }

    #endregion

    #region RSqrt

    [MethodImpl(256 | 512)]
    public static Vector64<float> RSqrt(Vector64<float> a)
    {
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.ReciprocalSquareRootEstimate(a);
        }
        if (!Vector64.IsHardwareAccelerated && Vector128.IsHardwareAccelerated)
        {
            return RSqrt(a.ToVector128()).GetLower();
        }

        return Vector64<float>.One / Vector64.Sqrt(a);
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> RSqrt(Vector128<float> a)
    {
        if (Sse.IsSupported)
        {
            return Sse.ReciprocalSqrt(a);
        }
        if (AdvSimd.IsSupported)
        {
            return AdvSimd.ReciprocalSquareRootEstimate(a);
        }

        return Vector128<float>.One / Vector128.Sqrt(a);
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> RSqrt(Vector128<double> a)
    {
        if (AdvSimd.Arm64.IsSupported)
        {
            return AdvSimd.Arm64.ReciprocalSquareRootEstimate(a);
        }

        return Vector128<double>.One / Vector128.Sqrt(a);
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> RSqrt(Vector256<double> a)
    {
        if (AdvSimd.Arm64.IsSupported)
        {
            return Vector256.Create(
                AdvSimd.Arm64.ReciprocalSquareRootEstimate(a.GetLower()),
                AdvSimd.Arm64.ReciprocalSquareRootEstimate(a.GetUpper())
            );
        }

        return Vector256<double>.One / Vector256.Sqrt(a);
    }

    #endregion

    #region Sin

    [MethodImpl(256 | 512)]
    public static Vector64<float> Sin(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Sin(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Sin(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).sin(),
            a.GetElement(1).sin()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Sin(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Sin(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Sin(a.GetLower()),
                simd_float.Sin(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).sin(),
            a.GetElement(1).sin(),
            a.GetElement(2).sin(),
            a.GetElement(3).sin()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Sin(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Sin(a);
        }
        return Vector128.Create(
            a.GetElement(0).sin(),
            a.GetElement(1).sin()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Sin(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Sin(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Sin(a.GetLower()),
                simd_double.Sin(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).sin(),
            a.GetElement(1).sin(),
            a.GetElement(2).sin(),
            a.GetElement(3).sin()
        );
    }

    #endregion

    #region Cos

    [MethodImpl(256 | 512)]
    public static Vector64<float> Cos(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Cos(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Cos(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).cos(),
            a.GetElement(1).cos()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Cos(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Cos(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Cos(a.GetLower()),
                simd_float.Cos(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).cos(),
            a.GetElement(1).cos(),
            a.GetElement(2).cos(),
            a.GetElement(3).cos()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Cos(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Cos(a);
        }
        return Vector128.Create(
            a.GetElement(0).cos(),
            a.GetElement(1).cos()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Cos(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Cos(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Cos(a.GetLower()),
                simd_double.Cos(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).cos(),
            a.GetElement(1).cos(),
            a.GetElement(2).cos(),
            a.GetElement(3).cos()
        );
    }

    #endregion

    #region SinCos

    [MethodImpl(256 | 512)]
    public static (Vector64<float> sin, Vector64<float> cos) SinCos(Vector64<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            var r = simd_float.SinCos(Vector128.Create(a, a));
            return (r.GetLower(), r.GetUpper());
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return (Sin(a), Cos(a));
        }
        var v0 = a.GetElement(0).sincos();
        var v1 = a.GetElement(1).sincos();
        return (Vector64.Create(v0.sin, v1.sin), Vector64.Create(v0.cos, v1.cos));
    }

    [MethodImpl(256 | 512)]
    public static (Vector128<float> sin, Vector128<float> cos) SinCos(Vector128<float> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            var r = simd_float.SinCos(Vector256.Create(a, a));
            return (r.GetLower(), r.GetUpper());
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return (Sin(a), Cos(a));
        }
        if (Vector64.IsHardwareAccelerated)
        {
            var v0 = SinCos(a.GetLower());
            var v1 = SinCos(a.GetUpper());
            return (Vector128.Create(v0.sin, v1.sin), Vector128.Create(v0.cos, v1.cos));
        }
        {
            var v0 = a.GetElement(0).sincos();
            var v1 = a.GetElement(1).sincos();
            var v2 = a.GetElement(1).sincos();
            var v3 = a.GetElement(1).sincos();
            return (Vector128.Create(v0.sin, v1.sin, v2.sin, v3.sin), Vector128.Create(v0.cos, v1.cos, v2.cos, v3.cos));
        }
    }

    [MethodImpl(256 | 512)]
    public static (Vector128<double> sin, Vector128<double> cos) SinCos(Vector128<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            var r = simd_double.SinCos(Vector256.Create(a, a));
            return (r.GetLower(), r.GetUpper());
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return (Sin(a), Cos(a));
        }
        var v0 = a.GetElement(0).sincos();
        var v1 = a.GetElement(1).sincos();
        return (Vector128.Create(v0.sin, v1.sin), Vector128.Create(v0.cos, v1.cos));
    }

    [MethodImpl(256 | 512)]
    public static (Vector256<double> sin, Vector256<double> cos) SinCos(Vector256<double> a)
    {
        if (Vector512.IsHardwareAccelerated)
        {
            var r = simd_double.SinCos(Vector512.Create(a, a));
            return (r.GetLower(), r.GetUpper());
        }
        if (Vector256.IsHardwareAccelerated)
        {
            return (Sin(a), Cos(a));
        }
        if (Vector128.IsHardwareAccelerated)
        {
            var v0 = SinCos(a.GetLower());
            var v1 = SinCos(a.GetUpper());
            return (Vector256.Create(v0.sin, v1.sin), Vector256.Create(v0.cos, v1.cos));
        }
        {
            var v0 = a.GetElement(0).sincos();
            var v1 = a.GetElement(1).sincos();
            var v2 = a.GetElement(1).sincos();
            var v3 = a.GetElement(1).sincos();
            return (Vector256.Create(v0.sin, v1.sin, v2.sin, v3.sin), Vector256.Create(v0.cos, v1.cos, v2.cos, v3.cos));
        }
    }

    #endregion

    #region Tan

    [MethodImpl(256 | 512)]
    public static Vector64<float> Tan(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Tan(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Tan(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).tan(),
            a.GetElement(1).tan()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Tan(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Tan(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Tan(a.GetLower()),
                simd_float.Tan(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).tan(),
            a.GetElement(1).tan(),
            a.GetElement(2).tan(),
            a.GetElement(3).tan()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Tan(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Tan(a);
        }
        return Vector128.Create(
            a.GetElement(0).tan(),
            a.GetElement(1).tan()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Tan(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Tan(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Tan(a.GetLower()),
                simd_double.Tan(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).tan(),
            a.GetElement(1).tan(),
            a.GetElement(2).tan(),
            a.GetElement(3).tan()
        );
    }

    #endregion

    #region Sinh

    [MethodImpl(256 | 512)]
    public static Vector64<float> Sinh(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Sinh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Sinh(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).sinh(),
            a.GetElement(1).sinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Sinh(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Sinh(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Sinh(a.GetLower()),
                simd_float.Sinh(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).sinh(),
            a.GetElement(1).sinh(),
            a.GetElement(2).sinh(),
            a.GetElement(3).sinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Sinh(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Sinh(a);
        }
        return Vector128.Create(
            a.GetElement(0).sinh(),
            a.GetElement(1).sinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Sinh(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Sinh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Sinh(a.GetLower()),
                simd_double.Sinh(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).sinh(),
            a.GetElement(1).sinh(),
            a.GetElement(2).sinh(),
            a.GetElement(3).sinh()
        );
    }

    #endregion

    #region Cosh

    [MethodImpl(256 | 512)]
    public static Vector64<float> Cosh(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Cosh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Cosh(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).cosh(),
            a.GetElement(1).cosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Cosh(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Cosh(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Cosh(a.GetLower()),
                simd_float.Cosh(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).cosh(),
            a.GetElement(1).cosh(),
            a.GetElement(2).cosh(),
            a.GetElement(3).cosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Cosh(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Cosh(a);
        }
        return Vector128.Create(
            a.GetElement(0).cosh(),
            a.GetElement(1).cosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Cosh(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Cosh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Cosh(a.GetLower()),
                simd_double.Cosh(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).cosh(),
            a.GetElement(1).cosh(),
            a.GetElement(2).cosh(),
            a.GetElement(3).cosh()
        );
    }

    #endregion

    #region Tanh

    [MethodImpl(256 | 512)]
    public static Vector64<float> Tanh(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Tanh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Tanh(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).tanh(),
            a.GetElement(1).tanh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Tanh(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Tanh(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Tanh(a.GetLower()),
                simd_float.Tanh(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).tanh(),
            a.GetElement(1).tanh(),
            a.GetElement(2).tanh(),
            a.GetElement(3).tanh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Tanh(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Tanh(a);
        }
        return Vector128.Create(
            a.GetElement(0).tanh(),
            a.GetElement(1).tanh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Tanh(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Tanh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Tanh(a.GetLower()),
                simd_double.Tanh(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).tanh(),
            a.GetElement(1).tanh(),
            a.GetElement(2).tanh(),
            a.GetElement(3).tanh()
        );
    }

    #endregion

    #region Asinh

    [MethodImpl(256 | 512)]
    public static Vector64<float> Asinh(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Asinh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Asinh(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).asinh(),
            a.GetElement(1).asinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Asinh(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Asinh(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Asinh(a.GetLower()),
                simd_float.Asinh(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).asinh(),
            a.GetElement(1).asinh(),
            a.GetElement(2).asinh(),
            a.GetElement(3).asinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Asinh(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Asinh(a);
        }
        return Vector128.Create(
            a.GetElement(0).asinh(),
            a.GetElement(1).asinh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Asinh(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Asinh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Asinh(a.GetLower()),
                simd_double.Asinh(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).asinh(),
            a.GetElement(1).asinh(),
            a.GetElement(2).asinh(),
            a.GetElement(3).asinh()
        );
    }

    #endregion

    #region Acosh

    [MethodImpl(256 | 512)]
    public static Vector64<float> Acosh(Vector64<float> a)
    {
        if (Vector64.IsHardwareAccelerated)
        {
            return simd_float.Acosh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Acosh(a.ToVector128()).GetLower();
        }
        return Vector64.Create(
            a.GetElement(0).acosh(),
            a.GetElement(1).acosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<float> Acosh(Vector128<float> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_float.Acosh(a);
        }
        if (Vector64.IsHardwareAccelerated)
        {
            return Vector128.Create(
                simd_float.Acosh(a.GetLower()),
                simd_float.Acosh(a.GetUpper())
            );
        }
        return Vector128.Create(
            a.GetElement(0).acosh(),
            a.GetElement(1).acosh(),
            a.GetElement(2).acosh(),
            a.GetElement(3).acosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector128<double> Acosh(Vector128<double> a)
    {
        if (Vector128.IsHardwareAccelerated)
        {
            return simd_double.Acosh(a);
        }
        return Vector128.Create(
            a.GetElement(0).acosh(),
            a.GetElement(1).acosh()
        );
    }

    [MethodImpl(256 | 512)]
    public static Vector256<double> Acosh(Vector256<double> a)
    {
        if (Vector256.IsHardwareAccelerated)
        {
            return simd_double.Acosh(a);
        }
        if (Vector128.IsHardwareAccelerated)
        {
            return Vector256.Create(
                simd_double.Acosh(a.GetLower()),
                simd_double.Acosh(a.GetUpper())
            );
        }
        return Vector256.Create(
            a.GetElement(0).acosh(),
            a.GetElement(1).acosh(),
            a.GetElement(2).acosh(),
            a.GetElement(3).acosh()
        );
    }

    #endregion
}

#endif
