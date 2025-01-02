// generated by template, do not modify manually

namespace Coplt.Mathematics.Simd;

public static partial class simd_math
{
    #region Sin Cos

    #region SinCos

    [MethodImpl(512)]
    public static Vector64<f32> SinCos(Vector64<f32> x) => Sin_impl(x + Vector64.Create(0.0f, math.F_Half_PI));

    [MethodImpl(512)]
    public static Vector128<f32> SinCos(Vector128<f32> x) => Sin_impl(x + Vector128.Create(0.0f, 0.0f, math.F_Half_PI, math.F_Half_PI));

    [MethodImpl(512)]
    public static Vector256<f32> SinCos(Vector256<f32> x) =>
        Sin_impl(x + Vector256.Create(0.0f, 0.0f, 0.0f, 0.0f, math.F_Half_PI, math.F_Half_PI, math.F_Half_PI, math.F_Half_PI));

    #endregion

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Cos(Vector64<f32> x) => Sin_impl(x + Vector64.Create(math.F_Half_PI));

    [MethodImpl(512)]
    public static Vector64<f32> Sin(Vector64<f32> x) => Sin_impl(x);

    [MethodImpl(256 | 512)]
    private static Vector64<f32> Sin_impl(Vector64<f32> x)
    {
        // Since sin() is periodic around 2pi, this converts x into the range of [0, 2pi]
        var xt = Wrap0To2Pi(x);

        // Since sin() in [0, 2pi] is an odd function around pi, this converts the range to [0, pi], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector64.GreaterThan(xt, Vector64.Create(math.F_PI));
        xt -= is_neg & Vector64.Create(math.F_PI);

        is_neg &= Vector64.Create(-2.0f);
        is_neg += Vector64<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector64.GreaterThan(x, Vector64.Create(f32.MaxValue));
        is_nan += Vector64.LessThan(x, Vector64.Create(f32.MinValue));

        // Since sin() on [0, pi] is an even function around pi/2, this "folds" the range into [0, pi/2]. I.e. 3pi/5 becomes 2pi/5.
        xt = Vector64.Create(math.F_Half_PI) - Vector64.Abs(xt - Vector64.Create(math.F_Half_PI));

        var sq = xt * xt;
        var r = simd.Fma(sq, Vector64.Create(-0.0000000000007384998082865f), Vector64.Create(0.000000000160490521296459f));
        r = simd.Fma(r, sq, Vector64.Create(-0.00000002505191090496049f));
        r = simd.Fma(r, sq, Vector64.Create(0.00000275573170815073144f));
        r = simd.Fma(r, sq, Vector64.Create(-0.00019841269828860068271f));
        r = simd.Fma(r, sq, Vector64.Create(0.008333333333299304989001f));
        r = simd.Fma(r, sq, Vector64.Create(-0.166666666666663509013977f));
        r = simd.Fma(r, sq, Vector64<f32>.One);

        r *= xt;

        r = simd.Fma(r, is_neg, is_nan);

        return r;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Cos(Vector128<f32> x) => Sin_impl(x + Vector128.Create(math.F_Half_PI));

    [MethodImpl(512)]
    public static Vector128<f32> Sin(Vector128<f32> x) => Sin_impl(x);

    [MethodImpl(256 | 512)]
    private static Vector128<f32> Sin_impl(Vector128<f32> x)
    {
        // Since sin() is periodic around 2pi, this converts x into the range of [0, 2pi]
        var xt = Wrap0To2Pi(x);

        // Since sin() in [0, 2pi] is an odd function around pi, this converts the range to [0, pi], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector128.GreaterThan(xt, Vector128.Create(math.F_PI));
        xt -= is_neg & Vector128.Create(math.F_PI);

        is_neg &= Vector128.Create(-2.0f);
        is_neg += Vector128<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector128.GreaterThan(x, Vector128.Create(f32.MaxValue));
        is_nan += Vector128.LessThan(x, Vector128.Create(f32.MinValue));

        // Since sin() on [0, pi] is an even function around pi/2, this "folds" the range into [0, pi/2]. I.e. 3pi/5 becomes 2pi/5.
        xt = Vector128.Create(math.F_Half_PI) - Vector128.Abs(xt - Vector128.Create(math.F_Half_PI));

        var sq = xt * xt;
        var r = simd.Fma(sq, Vector128.Create(-0.0000000000007384998082865f), Vector128.Create(0.000000000160490521296459f));
        r = simd.Fma(r, sq, Vector128.Create(-0.00000002505191090496049f));
        r = simd.Fma(r, sq, Vector128.Create(0.00000275573170815073144f));
        r = simd.Fma(r, sq, Vector128.Create(-0.00019841269828860068271f));
        r = simd.Fma(r, sq, Vector128.Create(0.008333333333299304989001f));
        r = simd.Fma(r, sq, Vector128.Create(-0.166666666666663509013977f));
        r = simd.Fma(r, sq, Vector128<f32>.One);

        r *= xt;

        r = simd.Fma(r, is_neg, is_nan);

        return r;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Cos(Vector256<f32> x) => Sin_impl(x + Vector256.Create(math.F_Half_PI));

    [MethodImpl(512)]
    public static Vector256<f32> Sin(Vector256<f32> x) => Sin_impl(x);

    [MethodImpl(256 | 512)]
    private static Vector256<f32> Sin_impl(Vector256<f32> x)
    {
        // Since sin() is periodic around 2pi, this converts x into the range of [0, 2pi]
        var xt = Wrap0To2Pi(x);

        // Since sin() in [0, 2pi] is an odd function around pi, this converts the range to [0, pi], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector256.GreaterThan(xt, Vector256.Create(math.F_PI));
        xt -= is_neg & Vector256.Create(math.F_PI);

        is_neg &= Vector256.Create(-2.0f);
        is_neg += Vector256<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector256.GreaterThan(x, Vector256.Create(f32.MaxValue));
        is_nan += Vector256.LessThan(x, Vector256.Create(f32.MinValue));

        // Since sin() on [0, pi] is an even function around pi/2, this "folds" the range into [0, pi/2]. I.e. 3pi/5 becomes 2pi/5.
        xt = Vector256.Create(math.F_Half_PI) - Vector256.Abs(xt - Vector256.Create(math.F_Half_PI));

        var sq = xt * xt;
        var r = simd.Fma(sq, Vector256.Create(-0.0000000000007384998082865f), Vector256.Create(0.000000000160490521296459f));
        r = simd.Fma(r, sq, Vector256.Create(-0.00000002505191090496049f));
        r = simd.Fma(r, sq, Vector256.Create(0.00000275573170815073144f));
        r = simd.Fma(r, sq, Vector256.Create(-0.00019841269828860068271f));
        r = simd.Fma(r, sq, Vector256.Create(0.008333333333299304989001f));
        r = simd.Fma(r, sq, Vector256.Create(-0.166666666666663509013977f));
        r = simd.Fma(r, sq, Vector256<f32>.One);

        r *= xt;

        r = simd.Fma(r, is_neg, is_nan);

        return r;
    }

    #endregion

    #endregion

    #region Tan

    #region Vector64<f32>

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(512)]
    public static Vector64<f32> SinIn0P4(Vector64<f32> x) => SinIn0P4_impl(x);

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector64<f32> SinIn0P4_impl(Vector64<f32> x)
    {
        var sq = x * x;

        // This is an odd-only Taylor series approximation of sin() on [0, pi/4]. 
        var r = simd.Fma(sq, Vector64.Create(0.0000000001590238118466f), Vector64.Create(-0.0000000250508528135474f));
        r = simd.Fma(r, sq, Vector64.Create(0.0000027557314284120030f));
        r = simd.Fma(r, sq, Vector64.Create(-0.00019841269831470328245f));
        r = simd.Fma(r, sq, Vector64.Create(0.008333333333324419158220f));
        r = simd.Fma(r, sq, Vector64.Create(-0.1666666666666663969165095f));
        r = simd.Fma(r, sq, Vector64<f32>.One);
        r *= x;

        return r;
    }

    [MethodImpl(512)]
    public static Vector64<f32> Tan(Vector64<f32> x)
    {
        // Since tan() is periodic around pi, this converts x into the range of [0, pi]
        var xt = Wrap0ToPi(x);

        // Since tan() in [0, pi] is an odd function around pi/2, this converts the range to [0, pi/2], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector64.GreaterThan(xt, Vector64.Create(math.F_Half_PI));
        xt += is_neg & ((xt - Vector64.Create(math.F_Half_PI)) * -2);

        is_neg &= Vector64.Create(-2.0f);
        is_neg += Vector64<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector64.GreaterThan(x, Vector64.Create(float.MaxValue));
        is_nan += Vector64.LessThan(x, Vector64.Create(float.MinValue));

        // Since tan() on [0, pi/2] is an inversed function around pi/4, this "folds" the range into [0, pi/4]. I.e. 3pi/10 becomes 2pi/10.
        var do_inv_mask = Vector64.GreaterThan(xt, Vector64.Create(math.F_Quarter_PI));
        var no_inv_mask = Vector64.LessThanOrEqual(xt, Vector64.Create(math.F_Quarter_PI));
        xt = Vector64.Create(math.F_Quarter_PI) - Vector64.Abs(xt - Vector64.Create(math.F_Quarter_PI));

        var xx = SinIn0P4_impl(xt);

        xt = Vector64.Sqrt(Vector64<f32>.One - xx * xx);

        xx = (do_inv_mask & (xt / xx)) + (no_inv_mask & (xx / xt));

        xx = simd.Fma(xx, is_neg, is_nan);
        return xx;
    }

    #endregion

    #region Vector128<f32>

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(512)]
    public static Vector128<f32> SinIn0P4(Vector128<f32> x) => SinIn0P4_impl(x);

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector128<f32> SinIn0P4_impl(Vector128<f32> x)
    {
        var sq = x * x;

        // This is an odd-only Taylor series approximation of sin() on [0, pi/4]. 
        var r = simd.Fma(sq, Vector128.Create(0.0000000001590238118466f), Vector128.Create(-0.0000000250508528135474f));
        r = simd.Fma(r, sq, Vector128.Create(0.0000027557314284120030f));
        r = simd.Fma(r, sq, Vector128.Create(-0.00019841269831470328245f));
        r = simd.Fma(r, sq, Vector128.Create(0.008333333333324419158220f));
        r = simd.Fma(r, sq, Vector128.Create(-0.1666666666666663969165095f));
        r = simd.Fma(r, sq, Vector128<f32>.One);
        r *= x;

        return r;
    }

    [MethodImpl(512)]
    public static Vector128<f32> Tan(Vector128<f32> x)
    {
        // Since tan() is periodic around pi, this converts x into the range of [0, pi]
        var xt = Wrap0ToPi(x);

        // Since tan() in [0, pi] is an odd function around pi/2, this converts the range to [0, pi/2], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector128.GreaterThan(xt, Vector128.Create(math.F_Half_PI));
        xt += is_neg & ((xt - Vector128.Create(math.F_Half_PI)) * -2);

        is_neg &= Vector128.Create(-2.0f);
        is_neg += Vector128<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector128.GreaterThan(x, Vector128.Create(float.MaxValue));
        is_nan += Vector128.LessThan(x, Vector128.Create(float.MinValue));

        // Since tan() on [0, pi/2] is an inversed function around pi/4, this "folds" the range into [0, pi/4]. I.e. 3pi/10 becomes 2pi/10.
        var do_inv_mask = Vector128.GreaterThan(xt, Vector128.Create(math.F_Quarter_PI));
        var no_inv_mask = Vector128.LessThanOrEqual(xt, Vector128.Create(math.F_Quarter_PI));
        xt = Vector128.Create(math.F_Quarter_PI) - Vector128.Abs(xt - Vector128.Create(math.F_Quarter_PI));

        var xx = SinIn0P4_impl(xt);

        xt = Vector128.Sqrt(Vector128<f32>.One - xx * xx);

        xx = (do_inv_mask & (xt / xx)) + (no_inv_mask & (xx / xt));

        xx = simd.Fma(xx, is_neg, is_nan);
        return xx;
    }

    #endregion

    #region Vector256<f32>

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(512)]
    public static Vector256<f32> SinIn0P4(Vector256<f32> x) => SinIn0P4_impl(x);

    /// <summary>
    /// Computes sines in [0,pi/4]
    /// </summary>
    [MethodImpl(256 | 512)]
    public static Vector256<f32> SinIn0P4_impl(Vector256<f32> x)
    {
        var sq = x * x;

        // This is an odd-only Taylor series approximation of sin() on [0, pi/4]. 
        var r = simd.Fma(sq, Vector256.Create(0.0000000001590238118466f), Vector256.Create(-0.0000000250508528135474f));
        r = simd.Fma(r, sq, Vector256.Create(0.0000027557314284120030f));
        r = simd.Fma(r, sq, Vector256.Create(-0.00019841269831470328245f));
        r = simd.Fma(r, sq, Vector256.Create(0.008333333333324419158220f));
        r = simd.Fma(r, sq, Vector256.Create(-0.1666666666666663969165095f));
        r = simd.Fma(r, sq, Vector256<f32>.One);
        r *= x;

        return r;
    }

    [MethodImpl(512)]
    public static Vector256<f32> Tan(Vector256<f32> x)
    {
        // Since tan() is periodic around pi, this converts x into the range of [0, pi]
        var xt = Wrap0ToPi(x);

        // Since tan() in [0, pi] is an odd function around pi/2, this converts the range to [0, pi/2], then stores whether or not the result needs to be negated in is_neg.
        var is_neg = Vector256.GreaterThan(xt, Vector256.Create(math.F_Half_PI));
        xt += is_neg & ((xt - Vector256.Create(math.F_Half_PI)) * -2);

        is_neg &= Vector256.Create(-2.0f);
        is_neg += Vector256<f32>.One;

        var is_nan = simd.Ne(x, x);
        is_nan += Vector256.GreaterThan(x, Vector256.Create(float.MaxValue));
        is_nan += Vector256.LessThan(x, Vector256.Create(float.MinValue));

        // Since tan() on [0, pi/2] is an inversed function around pi/4, this "folds" the range into [0, pi/4]. I.e. 3pi/10 becomes 2pi/10.
        var do_inv_mask = Vector256.GreaterThan(xt, Vector256.Create(math.F_Quarter_PI));
        var no_inv_mask = Vector256.LessThanOrEqual(xt, Vector256.Create(math.F_Quarter_PI));
        xt = Vector256.Create(math.F_Quarter_PI) - Vector256.Abs(xt - Vector256.Create(math.F_Quarter_PI));

        var xx = SinIn0P4_impl(xt);

        xt = Vector256.Sqrt(Vector256<f32>.One - xx * xx);

        xx = (do_inv_mask & (xt / xx)) + (no_inv_mask & (xx / xt));

        xx = simd.Fma(xx, is_neg, is_nan);
        return xx;
    }

    #endregion

    #endregion

    #region Sinh Cosh Tanh

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Sinh(Vector64<f32> x)
    {
        var r = Exp(x);
        var rr = Vector64<f32>.One / r;
        return (r - rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector64<f32> Cosh(Vector64<f32> x)
    {
        var r = Exp(x);
        var rr = Vector64<f32>.One / r;
        return (r + rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector64<f32> Tanh(Vector64<f32> x)
    {
        var r = Exp(x);
        var rr = Vector64<f32>.One / r;
        return (r - rr) / (r + rr);
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Sinh(Vector128<f32> x)
    {
        var r = Exp(x);
        var rr = Vector128<f32>.One / r;
        return (r - rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector128<f32> Cosh(Vector128<f32> x)
    {
        var r = Exp(x);
        var rr = Vector128<f32>.One / r;
        return (r + rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector128<f32> Tanh(Vector128<f32> x)
    {
        var r = Exp(x);
        var rr = Vector128<f32>.One / r;
        return (r - rr) / (r + rr);
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Sinh(Vector256<f32> x)
    {
        var r = Exp(x);
        var rr = Vector256<f32>.One / r;
        return (r - rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector256<f32> Cosh(Vector256<f32> x)
    {
        var r = Exp(x);
        var rr = Vector256<f32>.One / r;
        return (r + rr) * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector256<f32> Tanh(Vector256<f32> x)
    {
        var r = Exp(x);
        var rr = Vector256<f32>.One / r;
        return (r - rr) / (r + rr);
    }

    #endregion

    #region SinhCosh

    [MethodImpl(512)]
    public static Vector128<f32> SinhCosh(Vector128<f32> x)
    {
        var r = Exp(x);
        var rr = Vector128<f32>.One / r;
        var rrr = simd.Fma(rr, Vector128.Create(1.0f, 1.0f, -1.0f, -1.0f), r);
        return rrr * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector128<f32> SinhCoshF64To128(Vector64<f32> x)
    {
        var r = Exp(x);
        var r128 = Vector128.Create(r, r);
        var rr = Vector128<f32>.One / r128;
        var rrr = simd.Fma(rr, Vector128.Create(1.0f, 1.0f, -1.0f, -1.0f), r128);
        return rrr * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector256<f32> SinhCosh(Vector256<f32> x)
    {
        var r = Exp(x);
        var rr = Vector256<f32>.One / r;
        var rrr = simd.Fma(rr, Vector256.Create(1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f), r);
        return rrr * 0.5f;
    }

    [MethodImpl(512)]
    public static Vector256<f32> SinhCoshF128To256(Vector128<f32> x)
    {
        var r = Exp(x);
        var r256 = Vector256.Create(r, r);
        var rr = Vector256<f32>.One / r256;
        var rrr = simd.Fma(rr, Vector256.Create(1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f), r256);
        return rrr * 0.5f;
    }

    #endregion

    #endregion

    #region Asinh Acosh Atanh

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Asinh(Vector64<f32> x)
    {
        var r = simd.Fma(x, x, Vector64<f32>.One);
        r = Vector64.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector64<f32> Acosh(Vector64<f32> x)
    {
        var r = simd.Fma(x, x, -Vector64<f32>.One);
        r = Vector64.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector64<f32> Atanh(Vector64<f32> x)
    {
        var r = (Vector64<f32>.One + x) / (Vector64<f32>.One - x);
        r = Log(r) * 0.5f;
        return r;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Asinh(Vector128<f32> x)
    {
        var r = simd.Fma(x, x, Vector128<f32>.One);
        r = Vector128.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector128<f32> Acosh(Vector128<f32> x)
    {
        var r = simd.Fma(x, x, -Vector128<f32>.One);
        r = Vector128.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector128<f32> Atanh(Vector128<f32> x)
    {
        var r = (Vector128<f32>.One + x) / (Vector128<f32>.One - x);
        r = Log(r) * 0.5f;
        return r;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Asinh(Vector256<f32> x)
    {
        var r = simd.Fma(x, x, Vector256<f32>.One);
        r = Vector256.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector256<f32> Acosh(Vector256<f32> x)
    {
        var r = simd.Fma(x, x, -Vector256<f32>.One);
        r = Vector256.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector256<f32> Atanh(Vector256<f32> x)
    {
        var r = (Vector256<f32>.One + x) / (Vector256<f32>.One - x);
        r = Log(r) * 0.5f;
        return r;
    }

    #endregion

    #region AsinhAcosh

    [MethodImpl(512)]
    public static Vector128<f32> AsinhAcosh(Vector128<f32> x)
    {
        var r = simd.Fma(x, x, Vector128.Create(1.0f, 1.0f, -1.0f, -1.0f));
        r = Vector128.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    [MethodImpl(512)]
    public static Vector256<f32> AsinhAcosh(Vector256<f32> x)
    {
        var r = simd.Fma(x, x, Vector256.Create(1.0f, 1.0f, 1.0f, 1.0f, -1.0f, -1.0f, -1.0f, -1.0f));
        r = Vector256.Sqrt(r);
        r += x;
        r = Log(r);
        return r;
    }

    #endregion

    #endregion

    #region Asin

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Asin(Vector64<f32> d)
    {
        var abs = Vector64.Abs(d);
        var o = Vector64.LessThan(abs, Vector64.Create(0.5f));
        var x2 = Vector64.ConditionalSelect(o, d * d, (Vector64<f32>.One - abs) * Vector64.Create(0.5f));
        var x = Vector64.ConditionalSelect(o, abs, Vector64.Sqrt(x2));

        var u = Vector64.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector64.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.1666677296e+0f));
        u = simd.Fma(u, x * x2, x);

        var r = simd.Fnma(u, Vector64.Create(2f), Vector64.Create(math.F_Half_PI));
        r = Vector64.ConditionalSelect(o, u, r);

        r ^= d & -Vector64<f32>.Zero;
        return r;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Asin(Vector128<f32> d)
    {
        var abs = Vector128.Abs(d);
        var o = Vector128.LessThan(abs, Vector128.Create(0.5f));
        var x2 = Vector128.ConditionalSelect(o, d * d, (Vector128<f32>.One - abs) * Vector128.Create(0.5f));
        var x = Vector128.ConditionalSelect(o, abs, Vector128.Sqrt(x2));

        var u = Vector128.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector128.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.1666677296e+0f));
        u = simd.Fma(u, x * x2, x);

        var r = simd.Fnma(u, Vector128.Create(2f), Vector128.Create(math.F_Half_PI));
        r = Vector128.ConditionalSelect(o, u, r);

        r ^= d & -Vector128<f32>.Zero;
        return r;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Asin(Vector256<f32> d)
    {
        var abs = Vector256.Abs(d);
        var o = Vector256.LessThan(abs, Vector256.Create(0.5f));
        var x2 = Vector256.ConditionalSelect(o, d * d, (Vector256<f32>.One - abs) * Vector256.Create(0.5f));
        var x = Vector256.ConditionalSelect(o, abs, Vector256.Sqrt(x2));

        var u = Vector256.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector256.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.1666677296e+0f));
        u = simd.Fma(u, x * x2, x);

        var r = simd.Fnma(u, Vector256.Create(2f), Vector256.Create(math.F_Half_PI));
        r = Vector256.ConditionalSelect(o, u, r);

        r ^= d & -Vector256<f32>.Zero;
        return r;
    }

    #endregion

    #endregion

    #region Acos

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Acos(Vector64<f32> d)
    {
        var abs = Vector64.Abs(d);
        var o = Vector64.LessThan(abs, Vector64.Create(0.5f));
        var x2 = Vector64.ConditionalSelect(o, d * d, (Vector64<f32>.One - abs) * Vector64.Create(0.5f));
        var x = Vector64.ConditionalSelect(o, abs, Vector64.Sqrt(x2));
        x &= simd.Ne(Vector64<f32>.One, abs);

        var u = Vector64.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector64.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector64.Create(0.1666677296e+0f));
        u *= x * x2;

        var sign = d & -Vector64<f32>.Zero;

        var y = Vector64.Create(math.F_Half_PI) - ((x ^ sign) + (u ^ sign));
        x += u;
        var r = Vector64.ConditionalSelect(o, y, x * 2);
        var c = Vector64.LessThan(d, Vector64<f32>.Zero) & ~o;
        r = Vector64.ConditionalSelect(c, Vector64.Create(math.F_PI) - r, r);
        return r;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Acos(Vector128<f32> d)
    {
        var abs = Vector128.Abs(d);
        var o = Vector128.LessThan(abs, Vector128.Create(0.5f));
        var x2 = Vector128.ConditionalSelect(o, d * d, (Vector128<f32>.One - abs) * Vector128.Create(0.5f));
        var x = Vector128.ConditionalSelect(o, abs, Vector128.Sqrt(x2));
        x &= simd.Ne(Vector128<f32>.One, abs);

        var u = Vector128.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector128.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector128.Create(0.1666677296e+0f));
        u *= x * x2;

        var sign = d & -Vector128<f32>.Zero;

        var y = Vector128.Create(math.F_Half_PI) - ((x ^ sign) + (u ^ sign));
        x += u;
        var r = Vector128.ConditionalSelect(o, y, x * 2);
        var c = Vector128.LessThan(d, Vector128<f32>.Zero) & ~o;
        r = Vector128.ConditionalSelect(c, Vector128.Create(math.F_PI) - r, r);
        return r;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Acos(Vector256<f32> d)
    {
        var abs = Vector256.Abs(d);
        var o = Vector256.LessThan(abs, Vector256.Create(0.5f));
        var x2 = Vector256.ConditionalSelect(o, d * d, (Vector256<f32>.One - abs) * Vector256.Create(0.5f));
        var x = Vector256.ConditionalSelect(o, abs, Vector256.Sqrt(x2));
        x &= simd.Ne(Vector256<f32>.One, abs);

        var u = Vector256.Create(0.4197454825e-1f);
        u = simd.Fma(u, x2, Vector256.Create(0.2424046025e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.4547423869e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.7495029271e-1f));
        u = simd.Fma(u, x2, Vector256.Create(0.1666677296e+0f));
        u *= x * x2;

        var sign = d & -Vector256<f32>.Zero;

        var y = Vector256.Create(math.F_Half_PI) - ((x ^ sign) + (u ^ sign));
        x += u;
        var r = Vector256.ConditionalSelect(o, y, x * 2);
        var c = Vector256.LessThan(d, Vector256<f32>.Zero) & ~o;
        r = Vector256.ConditionalSelect(c, Vector256.Create(math.F_PI) - r, r);
        return r;
    }

    #endregion

    #endregion

    #region Atan

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Atan(Vector64<f32> s)
    {
        var sign = s & -Vector64<f32>.Zero;
        s = Vector64.Abs(s);
        var is_gt_1 = Vector64.GreaterThan(s, Vector64<f32>.One);
        s = Vector64.ConditionalSelect(is_gt_1, Vector64<f32>.One / s, s);

        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector64.Create(0.00282363896258175373077393f), Vector64.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector64.Create(0.0425049886107444763183594f), Vector64.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector64.Create(0.106347933411598205566406f), Vector64.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector64.Create(0.199926957488059997558594f), Vector64.Create(-0.333331018686294555664062f))
            )
        );
        t = simd.Fma(s, t * u, s);

        t = Vector64.ConditionalSelect(
            is_gt_1,
            Vector64.Create(math.F_Half_PI) - t,
            t
        );
        t ^= sign;

        return t;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Atan(Vector128<f32> s)
    {
        var sign = s & -Vector128<f32>.Zero;
        s = Vector128.Abs(s);
        var is_gt_1 = Vector128.GreaterThan(s, Vector128<f32>.One);
        s = Vector128.ConditionalSelect(is_gt_1, Vector128<f32>.One / s, s);

        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector128.Create(0.00282363896258175373077393f), Vector128.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector128.Create(0.0425049886107444763183594f), Vector128.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector128.Create(0.106347933411598205566406f), Vector128.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector128.Create(0.199926957488059997558594f), Vector128.Create(-0.333331018686294555664062f))
            )
        );
        t = simd.Fma(s, t * u, s);

        t = Vector128.ConditionalSelect(
            is_gt_1,
            Vector128.Create(math.F_Half_PI) - t,
            t
        );
        t ^= sign;

        return t;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Atan(Vector256<f32> s)
    {
        var sign = s & -Vector256<f32>.Zero;
        s = Vector256.Abs(s);
        var is_gt_1 = Vector256.GreaterThan(s, Vector256<f32>.One);
        s = Vector256.ConditionalSelect(is_gt_1, Vector256<f32>.One / s, s);

        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector256.Create(0.00282363896258175373077393f), Vector256.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector256.Create(0.0425049886107444763183594f), Vector256.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector256.Create(0.106347933411598205566406f), Vector256.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector256.Create(0.199926957488059997558594f), Vector256.Create(-0.333331018686294555664062f))
            )
        );
        t = simd.Fma(s, t * u, s);

        t = Vector256.ConditionalSelect(
            is_gt_1,
            Vector256.Create(math.F_Half_PI) - t,
            t
        );
        t ^= sign;

        return t;
    }

    #endregion

    #endregion

    #region Atan

    #region Vector64<f32>

    [MethodImpl(512)]
    public static Vector64<f32> Atan2(Vector64<f32> y, Vector64<f32> x)
    {
        var x_is_inf = simd.IsInfinity(x).AsSingle();
        var y_is_inf = simd.IsInfinity(y).AsSingle();
        var x_iz = Vector64.Equals(x, default);
        var y_iz = Vector64.Equals(y, default);
        var y_sign = y & -Vector64<f32>.Zero;
        var x_sign = x & -Vector64<f32>.Zero;
        var y_is_nan = simd.Ne(y, y);
        var x_is_nan = simd.Ne(x, x);

        y = Vector64.Abs(y);
        var x_lz = Vector64.LessThan(x, default);
        x = Vector64.Abs(x);
        var q = x_lz & Vector64.Create(-2f);
        var y_gt_x = Vector64.GreaterThan(y, x);
        q += y_gt_x & Vector64<f32>.One;
        var b = Vector64.Min(x, y);
        b = Vector64.ConditionalSelect(y_gt_x, -b, b);
        var a = Vector64.Max(x, y);

        var s = b / a;
        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector64.Create(0.00282363896258175373077393f), Vector64.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector64.Create(0.0425049886107444763183594f), Vector64.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector64.Create(0.106347933411598205566406f), Vector64.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector64.Create(0.199926957488059997558594f), Vector64.Create(-0.333331018686294555664062f))
            )
        );

        var r = simd.Fma(u, t * s, s);
        r = simd.Fma(q, Vector64.Create(math.F_Half_PI), r);
        r ^= x_sign;
        r = Vector64.ConditionalSelect(x_is_inf | x_iz,
            Vector64.Create(math.F_Half_PI) - (x_is_inf & (Vector64.Create(math.F_Half_PI) ^ x_sign)),
            r
        );
        r = Vector64.ConditionalSelect(y_is_inf,
            Vector64.Create(math.F_Half_PI) - (x_is_inf & (Vector64.Create(math.F_Quarter_PI) ^ x_sign)),
            r);
        r = Vector64.ConditionalSelect(y_iz,
            Vector64.Equals(x_sign.AsInt32(), (-Vector64<f32>.Zero).AsInt32()).AsSingle() & Vector64.Create(math.F_PI),
            r);
        r = Vector64.ConditionalSelect(y_is_nan | x_is_nan,
            Vector64.Create(f32.NaN),
            r ^ y_sign
        );
        return r;
    }

    #endregion

    #region Vector128<f32>

    [MethodImpl(512)]
    public static Vector128<f32> Atan2(Vector128<f32> y, Vector128<f32> x)
    {
        var x_is_inf = simd.IsInfinity(x).AsSingle();
        var y_is_inf = simd.IsInfinity(y).AsSingle();
        var x_iz = Vector128.Equals(x, default);
        var y_iz = Vector128.Equals(y, default);
        var y_sign = y & -Vector128<f32>.Zero;
        var x_sign = x & -Vector128<f32>.Zero;
        var y_is_nan = simd.Ne(y, y);
        var x_is_nan = simd.Ne(x, x);

        y = Vector128.Abs(y);
        var x_lz = Vector128.LessThan(x, default);
        x = Vector128.Abs(x);
        var q = x_lz & Vector128.Create(-2f);
        var y_gt_x = Vector128.GreaterThan(y, x);
        q += y_gt_x & Vector128<f32>.One;
        var b = Vector128.Min(x, y);
        b = Vector128.ConditionalSelect(y_gt_x, -b, b);
        var a = Vector128.Max(x, y);

        var s = b / a;
        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector128.Create(0.00282363896258175373077393f), Vector128.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector128.Create(0.0425049886107444763183594f), Vector128.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector128.Create(0.106347933411598205566406f), Vector128.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector128.Create(0.199926957488059997558594f), Vector128.Create(-0.333331018686294555664062f))
            )
        );

        var r = simd.Fma(u, t * s, s);
        r = simd.Fma(q, Vector128.Create(math.F_Half_PI), r);
        r ^= x_sign;
        r = Vector128.ConditionalSelect(x_is_inf | x_iz,
            Vector128.Create(math.F_Half_PI) - (x_is_inf & (Vector128.Create(math.F_Half_PI) ^ x_sign)),
            r
        );
        r = Vector128.ConditionalSelect(y_is_inf,
            Vector128.Create(math.F_Half_PI) - (x_is_inf & (Vector128.Create(math.F_Quarter_PI) ^ x_sign)),
            r);
        r = Vector128.ConditionalSelect(y_iz,
            Vector128.Equals(x_sign.AsInt32(), (-Vector128<f32>.Zero).AsInt32()).AsSingle() & Vector128.Create(math.F_PI),
            r);
        r = Vector128.ConditionalSelect(y_is_nan | x_is_nan,
            Vector128.Create(f32.NaN),
            r ^ y_sign
        );
        return r;
    }

    #endregion

    #region Vector256<f32>

    [MethodImpl(512)]
    public static Vector256<f32> Atan2(Vector256<f32> y, Vector256<f32> x)
    {
        var x_is_inf = simd.IsInfinity(x).AsSingle();
        var y_is_inf = simd.IsInfinity(y).AsSingle();
        var x_iz = Vector256.Equals(x, default);
        var y_iz = Vector256.Equals(y, default);
        var y_sign = y & -Vector256<f32>.Zero;
        var x_sign = x & -Vector256<f32>.Zero;
        var y_is_nan = simd.Ne(y, y);
        var x_is_nan = simd.Ne(x, x);

        y = Vector256.Abs(y);
        var x_lz = Vector256.LessThan(x, default);
        x = Vector256.Abs(x);
        var q = x_lz & Vector256.Create(-2f);
        var y_gt_x = Vector256.GreaterThan(y, x);
        q += y_gt_x & Vector256<f32>.One;
        var b = Vector256.Min(x, y);
        b = Vector256.ConditionalSelect(y_gt_x, -b, b);
        var a = Vector256.Max(x, y);

        var s = b / a;
        var t = s * s;
        var t2 = t * t;
        var t4 = t2 * t2;
        var u = simd.Fma(t4,
            simd.Fma(t2,
                simd.Fma(t, Vector256.Create(0.00282363896258175373077393f), Vector256.Create(-0.0159569028764963150024414f)),
                simd.Fma(t, Vector256.Create(0.0425049886107444763183594f), Vector256.Create(-0.0748900920152664184570312f))
            ),
            simd.Fma(t2,
                simd.Fma(t, Vector256.Create(0.106347933411598205566406f), Vector256.Create(-0.142027363181114196777344f)),
                simd.Fma(t, Vector256.Create(0.199926957488059997558594f), Vector256.Create(-0.333331018686294555664062f))
            )
        );

        var r = simd.Fma(u, t * s, s);
        r = simd.Fma(q, Vector256.Create(math.F_Half_PI), r);
        r ^= x_sign;
        r = Vector256.ConditionalSelect(x_is_inf | x_iz,
            Vector256.Create(math.F_Half_PI) - (x_is_inf & (Vector256.Create(math.F_Half_PI) ^ x_sign)),
            r
        );
        r = Vector256.ConditionalSelect(y_is_inf,
            Vector256.Create(math.F_Half_PI) - (x_is_inf & (Vector256.Create(math.F_Quarter_PI) ^ x_sign)),
            r);
        r = Vector256.ConditionalSelect(y_iz,
            Vector256.Equals(x_sign.AsInt32(), (-Vector256<f32>.Zero).AsInt32()).AsSingle() & Vector256.Create(math.F_PI),
            r);
        r = Vector256.ConditionalSelect(y_is_nan | x_is_nan,
            Vector256.Create(f32.NaN),
            r ^ y_sign
        );
        return r;
    }

    #endregion

    #endregion
}
