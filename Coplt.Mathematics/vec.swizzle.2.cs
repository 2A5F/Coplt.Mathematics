// generated by template, do not modify manually

namespace Coplt.Mathematics;

#region float2

public partial struct float2 
{
    public float2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public float2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public float2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public float2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public float2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public float2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public float2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public float2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // float2

#region double2

public partial struct double2 
{
    public double2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public double2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public double2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public double2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public double2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public double2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public double2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public double2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // double2

#region short2

public partial struct short2 
{
    public short2 xx
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public short2 rr
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public short2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public short2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public short2 yx
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public short2 gr
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public short2 yy
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
    public short2 gg
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
}

#endregion // short2

#region ushort2

public partial struct ushort2 
{
    public ushort2 xx
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public ushort2 rr
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public ushort2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public ushort2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public ushort2 yx
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public ushort2 gr
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public ushort2 yy
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
    public ushort2 gg
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
}

#endregion // ushort2

#region int2

public partial struct int2 
{
    public int2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public int2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public int2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public int2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public int2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public int2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public int2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public int2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // int2

#region uint2

public partial struct uint2 
{
    public uint2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public uint2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public uint2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public uint2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public uint2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public uint2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public uint2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public uint2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // uint2

#region long2

public partial struct long2 
{
    public long2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public long2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public long2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public long2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public long2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public long2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public long2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public long2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create(1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // long2

#region ulong2

public partial struct ulong2 
{
    public ulong2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public ulong2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public ulong2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public ulong2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public ulong2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public ulong2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public ulong2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public ulong2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // ulong2

#region decimal2

public partial struct decimal2 
{
    public decimal2 xx
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public decimal2 rr
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public decimal2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public decimal2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public decimal2 yx
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public decimal2 gr
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public decimal2 yy
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
    public decimal2 gg
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
}

#endregion // decimal2

#region half2

public partial struct half2 
{
    public half2 xx
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public half2 rr
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public half2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public half2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public half2 yx
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public half2 gr
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public half2 yy
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
    public half2 gg
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
}

#endregion // half2

#region b16v2

public partial struct b16v2 
{
    public b16v2 xx
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public b16v2 rr
    {
        [MethodImpl(256 | 512)]
        get => new(x, x);
    }
    public b16v2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b16v2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b16v2 yx
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b16v2 gr
    {
        [MethodImpl(256 | 512)]
        get => new(y, x);
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b16v2 yy
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
    public b16v2 gg
    {
        [MethodImpl(256 | 512)]
        get => new(y, y);
    }
}

#endregion // b16v2

#region b32v2

public partial struct b32v2 
{
    public b32v2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public b32v2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public b32v2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b32v2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b32v2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b32v2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b32v2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public b32v2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector64.Shuffle(vector, Vector64.Create((uint)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // b32v2

#region b64v2

public partial struct b64v2 
{
    public b64v2 xx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public b64v2 rr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)0, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(x, x);
#endif // NET8_0_OR_GREATER
    }
    public b64v2 xy
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b64v2 rg
    {
        [MethodImpl(256 | 512)]
        get => this;
        [MethodImpl(256 | 512)]
        set => this = value;
    }
    public b64v2 yx
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b64v2 gr
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 0)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, x);
#endif // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        set => this = value.yx;
    }
    public b64v2 yy
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
    public b64v2 gg
    {
#if NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(Vector128.Shuffle(vector, Vector128.Create((ulong)1, 1)));
#else // NET8_0_OR_GREATER
        [MethodImpl(256 | 512)]
        get => new(y, y);
#endif // NET8_0_OR_GREATER
    }
}

#endregion // b64v2
