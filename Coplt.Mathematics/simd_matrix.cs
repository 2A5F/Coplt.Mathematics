// generated by template, do not modify manually
#if NET8_0_OR_GREATER
using System.Runtime.Intrinsics.X86;
using System.Runtime.Intrinsics.Arm;

namespace Coplt.Mathematics;

public static partial class simd_matrix
{
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector128<float> c0, Vector128<float> c1, Vector128<float> c2, Vector128<float> c3) Transpose4x4(
        Vector128<float> c0, Vector128<float> c1, Vector128<float> c2, Vector128<float> c3
    )
    {
        if (Sse.IsSupported)
        {
            var a = Sse.Shuffle(c0, c1, 0x44); // a0 a1 b0 b1 => (c0.xy, c1.xy)
            var b = Sse.Shuffle(c2, c3, 0x44); // a0 a1 b0 b1 => (c2.xy, c3.xy)
            var c = Sse.Shuffle(c0, c1, 0xEE); // a2 a3 b2 b3 => (c0.yz, c1.yz)
            var d = Sse.Shuffle(c2, c3, 0xEE); // a2 a3 b2 b3 => (c2.yz, c3.yz)
            var oc0 = Sse.Shuffle(a, b, 0x88); // a0 a2 b0 b2 => (a.xz, b.xz) => (c0.x, c1.x, c2.x, c3.x)
            var oc1 = Sse.Shuffle(a, b, 0xDD); // a1 a3 a1 a3 => (a.yw, b.yw) => (c0.y, c1.y, c2.y, c3.y)
            var oc2 = Sse.Shuffle(c, d, 0x88); // a0 a2 b0 b2 => (c.xz, d.xz) => (c0.z, c1.z, c2.z, c3.z)
            var oc3 = Sse.Shuffle(c, d, 0xDD); // a1 a3 a1 a3 => (c.yw, d.yw) => (c0.w, c1.w, c2.w, c3.w)
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector128.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector128.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector128.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector128.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector256<double> c0, Vector256<double> c1, Vector256<double> c2, Vector256<double> c3) Transpose4x4(
        Vector256<double> c0, Vector256<double> c1, Vector256<double> c2, Vector256<double> c3
    )
    {
        if (Avx.IsSupported)
        {
            var a = Avx.Shuffle(c0, c1, 0x0);
            var b = Avx.Shuffle(c2, c3, 0x0);
            var c = Avx.Shuffle(c0, c1, 0xF);
            var d = Avx.Shuffle(c2, c3, 0xF);
            var oc0 = Avx.Permute2x128(a, b, 0x20);
            var oc1 = Avx.Permute2x128(c, d, 0x20);
            var oc2 = Avx.Permute2x128(a, b, 0x31);
            var oc3 = Avx.Permute2x128(c, d, 0x31);
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector256.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector256.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector256.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector256.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector128<int> c0, Vector128<int> c1, Vector128<int> c2, Vector128<int> c3) Transpose4x4(
        Vector128<int> c0, Vector128<int> c1, Vector128<int> c2, Vector128<int> c3
    )
    {
        if (Sse.IsSupported)
        {
            var ic0 = c0.AsSingle();
            var ic1 = c1.AsSingle();
            var ic2 = c2.AsSingle();
            var ic3 = c3.AsSingle();
            var a = Sse.Shuffle(ic0, ic1, 0x44); // a0 a1 b0 b1 => (c0.xy, c1.xy)
            var b = Sse.Shuffle(ic2, ic3, 0x44); // a0 a1 b0 b1 => (c2.xy, c3.xy)
            var c = Sse.Shuffle(ic0, ic1, 0xEE); // a2 a3 b2 b3 => (c0.yz, c1.yz)
            var d = Sse.Shuffle(ic2, ic3, 0xEE); // a2 a3 b2 b3 => (c2.yz, c3.yz)
            var oc0 = Sse.Shuffle(a, b, 0x88).AsInt32(); // a0 a2 b0 b2 => (a.xz, b.xz) => (c0.x, c1.x, c2.x, c3.x)
            var oc1 = Sse.Shuffle(a, b, 0xDD).AsInt32(); // a1 a3 a1 a3 => (a.yw, b.yw) => (c0.y, c1.y, c2.y, c3.y)
            var oc2 = Sse.Shuffle(c, d, 0x88).AsInt32(); // a0 a2 b0 b2 => (c.xz, d.xz) => (c0.z, c1.z, c2.z, c3.z)
            var oc3 = Sse.Shuffle(c, d, 0xDD).AsInt32(); // a1 a3 a1 a3 => (c.yw, d.yw) => (c0.w, c1.w, c2.w, c3.w)
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector128.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector128.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector128.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector128.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector128<uint> c0, Vector128<uint> c1, Vector128<uint> c2, Vector128<uint> c3) Transpose4x4(
        Vector128<uint> c0, Vector128<uint> c1, Vector128<uint> c2, Vector128<uint> c3
    )
    {
        if (Sse.IsSupported)
        {
            var ic0 = c0.AsSingle();
            var ic1 = c1.AsSingle();
            var ic2 = c2.AsSingle();
            var ic3 = c3.AsSingle();
            var a = Sse.Shuffle(ic0, ic1, 0x44); // a0 a1 b0 b1 => (c0.xy, c1.xy)
            var b = Sse.Shuffle(ic2, ic3, 0x44); // a0 a1 b0 b1 => (c2.xy, c3.xy)
            var c = Sse.Shuffle(ic0, ic1, 0xEE); // a2 a3 b2 b3 => (c0.yz, c1.yz)
            var d = Sse.Shuffle(ic2, ic3, 0xEE); // a2 a3 b2 b3 => (c2.yz, c3.yz)
            var oc0 = Sse.Shuffle(a, b, 0x88).AsUInt32(); // a0 a2 b0 b2 => (a.xz, b.xz) => (c0.x, c1.x, c2.x, c3.x)
            var oc1 = Sse.Shuffle(a, b, 0xDD).AsUInt32(); // a1 a3 a1 a3 => (a.yw, b.yw) => (c0.y, c1.y, c2.y, c3.y)
            var oc2 = Sse.Shuffle(c, d, 0x88).AsUInt32(); // a0 a2 b0 b2 => (c.xz, d.xz) => (c0.z, c1.z, c2.z, c3.z)
            var oc3 = Sse.Shuffle(c, d, 0xDD).AsUInt32(); // a1 a3 a1 a3 => (c.yw, d.yw) => (c0.w, c1.w, c2.w, c3.w)
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector128.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector128.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector128.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector128.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector256<long> c0, Vector256<long> c1, Vector256<long> c2, Vector256<long> c3) Transpose4x4(
        Vector256<long> c0, Vector256<long> c1, Vector256<long> c2, Vector256<long> c3
    )
    {
        if (Avx.IsSupported)
        {
            var ic0 = c0.AsDouble();
            var ic1 = c1.AsDouble();
            var ic2 = c2.AsDouble();
            var ic3 = c3.AsDouble();
            var a = Avx.Shuffle(ic0, ic1, 0x0);
            var b = Avx.Shuffle(ic2, ic3, 0x0);
            var c = Avx.Shuffle(ic0, ic1, 0xF);
            var d = Avx.Shuffle(ic2, ic3, 0xF);
            var oc0 = Avx.Permute2x128(a, b, 0x20).AsInt64();
            var oc1 = Avx.Permute2x128(c, d, 0x20).AsInt64();
            var oc2 = Avx.Permute2x128(a, b, 0x31).AsInt64();
            var oc3 = Avx.Permute2x128(c, d, 0x31).AsInt64();
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector256.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector256.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector256.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector256.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
    #region Transpose 4x4

    [MethodImpl(256 | 512)]
    public static (Vector256<ulong> c0, Vector256<ulong> c1, Vector256<ulong> c2, Vector256<ulong> c3) Transpose4x4(
        Vector256<ulong> c0, Vector256<ulong> c1, Vector256<ulong> c2, Vector256<ulong> c3
    )
    {
        if (Avx.IsSupported)
        {
            var ic0 = c0.AsDouble();
            var ic1 = c1.AsDouble();
            var ic2 = c2.AsDouble();
            var ic3 = c3.AsDouble();
            var a = Avx.Shuffle(ic0, ic1, 0x0);
            var b = Avx.Shuffle(ic2, ic3, 0x0);
            var c = Avx.Shuffle(ic0, ic1, 0xF);
            var d = Avx.Shuffle(ic2, ic3, 0xF);
            var oc0 = Avx.Permute2x128(a, b, 0x20).AsUInt64();
            var oc1 = Avx.Permute2x128(c, d, 0x20).AsUInt64();
            var oc2 = Avx.Permute2x128(a, b, 0x31).AsUInt64();
            var oc3 = Avx.Permute2x128(c, d, 0x31).AsUInt64();
            return (oc0, oc1, oc2, oc3);
        }
        {
            var oc0 = Vector256.Create(c0.GetElement(0), c1.GetElement(0), c2.GetElement(0), c3.GetElement(0));
            var oc1 = Vector256.Create(c0.GetElement(1), c1.GetElement(1), c2.GetElement(1), c3.GetElement(1));
            var oc2 = Vector256.Create(c0.GetElement(2), c1.GetElement(2), c2.GetElement(2), c3.GetElement(2));
            var oc3 = Vector256.Create(c0.GetElement(3), c1.GetElement(3), c2.GetElement(3), c3.GetElement(3));
            return (oc0, oc1, oc2, oc3);
        }
    }

    #endregion
}

#endif
