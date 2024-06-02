// generated by template, do not modify manually

namespace Coplt.Mathematics;

#region float4

public partial struct float4 
{
    [MethodImpl(256 | 512)]
    public float4(float3 xyz, float w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public float4(float x, float3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, x), Vector128.Create(3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal float4(float3 xzw, float y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, y), Vector128.Create(0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal float4(float3 xyw, float z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, z), Vector128.Create(0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static float4 Ix(this float3 yzw, float x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static float4 Iy(this float3 xzw, float y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static float4 Iz(this float3 xyw, float z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static float4 Iw(this float3 xyz, float w) => new(xyz, w);
}

#endregion // float4

#region double4

public partial struct double4 
{
    [MethodImpl(256 | 512)]
    public double4(double3 xyz, double w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public double4(double x, double3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, x), Vector256.Create(3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal double4(double3 xzw, double y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, y), Vector256.Create(0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal double4(double3 xyw, double z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, z), Vector256.Create(0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static double4 Ix(this double3 yzw, double x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static double4 Iy(this double3 xzw, double y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static double4 Iz(this double3 xyw, double z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static double4 Iw(this double3 xyz, double w) => new(xyz, w);
}

#endregion // double4

#region short4

public partial struct short4 
{
    [MethodImpl(256 | 512)]
    public short4(short3 xyz, short w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }

    [MethodImpl(256 | 512)]
    public short4(short x, short3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    [MethodImpl(256 | 512)]
    internal short4(short3 xzw, short y, insert_y _)
    {
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
    }

    [MethodImpl(256 | 512)]
    internal short4(short3 xyw, short z, insert_z _)
    {
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static short4 Ix(this short3 yzw, short x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static short4 Iy(this short3 xzw, short y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static short4 Iz(this short3 xyw, short z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static short4 Iw(this short3 xyz, short w) => new(xyz, w);
}

#endregion // short4

#region ushort4

public partial struct ushort4 
{
    [MethodImpl(256 | 512)]
    public ushort4(ushort3 xyz, ushort w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }

    [MethodImpl(256 | 512)]
    public ushort4(ushort x, ushort3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    [MethodImpl(256 | 512)]
    internal ushort4(ushort3 xzw, ushort y, insert_y _)
    {
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
    }

    [MethodImpl(256 | 512)]
    internal ushort4(ushort3 xyw, ushort z, insert_z _)
    {
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ushort4 Ix(this ushort3 yzw, ushort x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ushort4 Iy(this ushort3 xzw, ushort y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ushort4 Iz(this ushort3 xyw, ushort z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ushort4 Iw(this ushort3 xyz, ushort w) => new(xyz, w);
}

#endregion // ushort4

#region int4

public partial struct int4 
{
    [MethodImpl(256 | 512)]
    public int4(int3 xyz, int w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public int4(int x, int3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, x), Vector128.Create(3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal int4(int3 xzw, int y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, y), Vector128.Create(0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal int4(int3 xyw, int z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, z), Vector128.Create(0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static int4 Ix(this int3 yzw, int x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static int4 Iy(this int3 xzw, int y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static int4 Iz(this int3 xyw, int z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static int4 Iw(this int3 xyz, int w) => new(xyz, w);
}

#endregion // int4

#region uint4

public partial struct uint4 
{
    [MethodImpl(256 | 512)]
    public uint4(uint3 xyz, uint w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public uint4(uint x, uint3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, x), Vector128.Create((uint)3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal uint4(uint3 xzw, uint y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, y), Vector128.Create((uint)0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal uint4(uint3 xyw, uint z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, z), Vector128.Create((uint)0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static uint4 Ix(this uint3 yzw, uint x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static uint4 Iy(this uint3 xzw, uint y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static uint4 Iz(this uint3 xyw, uint z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static uint4 Iw(this uint3 xyz, uint w) => new(xyz, w);
}

#endregion // uint4

#region long4

public partial struct long4 
{
    [MethodImpl(256 | 512)]
    public long4(long3 xyz, long w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public long4(long x, long3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, x), Vector256.Create(3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal long4(long3 xzw, long y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, y), Vector256.Create(0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal long4(long3 xyw, long z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, z), Vector256.Create(0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static long4 Ix(this long3 yzw, long x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static long4 Iy(this long3 xzw, long y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static long4 Iz(this long3 xyw, long z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static long4 Iw(this long3 xyz, long w) => new(xyz, w);
}

#endregion // long4

#region ulong4

public partial struct ulong4 
{
    [MethodImpl(256 | 512)]
    public ulong4(ulong3 xyz, ulong w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public ulong4(ulong x, ulong3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, x), Vector256.Create((ulong)3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal ulong4(ulong3 xzw, ulong y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, y), Vector256.Create((ulong)0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal ulong4(ulong3 xyw, ulong z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, z), Vector256.Create((ulong)0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ulong4 Ix(this ulong3 yzw, ulong x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ulong4 Iy(this ulong3 xzw, ulong y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ulong4 Iz(this ulong3 xyw, ulong z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static ulong4 Iw(this ulong3 xyz, ulong w) => new(xyz, w);
}

#endregion // ulong4

#region decimal4

public partial struct decimal4 
{
    [MethodImpl(256 | 512)]
    public decimal4(decimal3 xyz, decimal w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }

    [MethodImpl(256 | 512)]
    public decimal4(decimal x, decimal3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    [MethodImpl(256 | 512)]
    internal decimal4(decimal3 xzw, decimal y, insert_y _)
    {
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
    }

    [MethodImpl(256 | 512)]
    internal decimal4(decimal3 xyw, decimal z, insert_z _)
    {
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static decimal4 Ix(this decimal3 yzw, decimal x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static decimal4 Iy(this decimal3 xzw, decimal y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static decimal4 Iz(this decimal3 xyw, decimal z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static decimal4 Iw(this decimal3 xyz, decimal w) => new(xyz, w);
}

#endregion // decimal4

#region half4

public partial struct half4 
{
    [MethodImpl(256 | 512)]
    public half4(half3 xyz, half w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }

    [MethodImpl(256 | 512)]
    public half4(half x, half3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    [MethodImpl(256 | 512)]
    internal half4(half3 xzw, half y, insert_y _)
    {
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
    }

    [MethodImpl(256 | 512)]
    internal half4(half3 xyw, half z, insert_z _)
    {
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static half4 Ix(this half3 yzw, half x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static half4 Iy(this half3 xzw, half y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static half4 Iz(this half3 xyw, half z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static half4 Iw(this half3 xyz, half w) => new(xyz, w);
}

#endregion // half4

#region b16v4

public partial struct b16v4 
{
    [MethodImpl(256 | 512)]
    public b16v4(b16v3 xyz, b16 w)
    {
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
    }

    [MethodImpl(256 | 512)]
    public b16v4(b16 x, b16v3 yzw)
    {
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
    }

    [MethodImpl(256 | 512)]
    internal b16v4(b16v3 xzw, b16 y, insert_y _)
    {
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
    }

    [MethodImpl(256 | 512)]
    internal b16v4(b16v3 xyw, b16 z, insert_z _)
    {
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b16v4 Ix(this b16v3 yzw, b16 x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b16v4 Iy(this b16v3 xzw, b16 y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b16v4 Iz(this b16v3 xyw, b16 z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b16v4 Iw(this b16v3 xyz, b16 w) => new(xyz, w);
}

#endregion // b16v4

#region b32v4

public partial struct b32v4 
{
    [MethodImpl(256 | 512)]
    public b32v4(b32v3 xyz, b32 w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public b32v4(b32 x, b32v3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, x), Vector128.Create((uint)3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal b32v4(b32v3 xzw, b32 y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, y), Vector128.Create((uint)0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal b32v4(b32v3 xyw, b32 z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector128.Shuffle(xzw.vector.WithElement(3, z), Vector128.Create((uint)0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b32v4 Ix(this b32v3 yzw, b32 x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b32v4 Iy(this b32v3 xzw, b32 y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b32v4 Iz(this b32v3 xyw, b32 z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b32v4 Iw(this b32v3 xyz, b32 w) => new(xyz, w);
}

#endregion // b32v4

#region b64v4

public partial struct b64v4 
{
    [MethodImpl(256 | 512)]
    public b64v4(b64v3 xyz, b64 w)
    {
        #if NET8_0_OR_GREATER
        vector = xyz.vector.WithElement(3, w);
        #else // NET8_0_OR_GREATER
        this.x = xyz.x;
        this.y = xyz.y;
        this.z = xyz.z;
        this.w = w;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    public b64v4(b64 x, b64v3 yzw)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, x), Vector256.Create((ulong)3, 0, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = x;
        this.y = yzw.x;
        this.z = yzw.y;
        this.w = yzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal b64v4(b64v3 xzw, b64 y, insert_y _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, y), Vector256.Create((ulong)0, 3, 1, 2));
        #else // NET8_0_OR_GREATER
        this.x = xzw.x;
        this.y = y;
        this.z = xzw.y;
        this.w = xzw.z;
        #endif // NET8_0_OR_GREATER
    }

    [MethodImpl(256 | 512)]
    internal b64v4(b64v3 xyw, b64 z, insert_z _)
    {
        #if NET8_0_OR_GREATER
        vector = Vector256.Shuffle(xzw.vector.WithElement(3, z), Vector256.Create((ulong)0, 1, 3, 2));
        #else // NET8_0_OR_GREATER
        this.x = xyw.x;
        this.y = xyw.y;
        this.z = z;
        this.w = xyw.z;
        #endif // NET8_0_OR_GREATER
    }
}

public static partial class math
{
    /// <summary>
    /// Insert X component
    /// <code>X -> (y, z, w) => (X, y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b64v4 Ix(this b64v3 yzw, b64 x) => new(x, yzw);

    /// <summary>
    /// Insert Y component
    /// <code>Y -> (x, z, w) => (x, Y, z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b64v4 Iy(this b64v3 xzw, b64 y) => new(xzw, y, new insert_y());

    /// <summary>
    /// Insert Z component
    /// <code>Z -> (x, y, w) => (x, y, Z, w)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b64v4 Iz(this b64v3 xyw, b64 z) => new(xyw, z, new insert_z());

    /// <summary>
    /// Insert W component
    /// <code>W -> (x, y, z) => (x, y, z, W)</code>
    /// </summary>
    [MethodImpl(256 | 512)]
    public static b64v4 Iw(this b64v3 xyz, b64 w) => new(xyz, w);
}

#endregion // b64v4
