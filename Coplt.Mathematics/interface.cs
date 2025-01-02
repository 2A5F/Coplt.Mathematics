// generated by template, do not modify manually

namespace Coplt.Mathematics;

public interface IVectorBitops;

public interface IVector 
{
    public static abstract bool IsSimdAccelerated { get; }
    public static abstract int Length { get; }
    public static abstract int SizeByte { get; }
    public static abstract int SizeBit { get; }
}

public interface IVector2 : IVector;
public interface IVector3 : IVector;
public interface IVector4 : IVector;

public interface IVector<T> : IVector
{
    public T this[int i] { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
}

public interface IVector2Components<T>
{
    public T x { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
    public T y { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }

    public T r { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
    public T g { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
}
public interface IVector3Components<T> : IVector2Components<T>
{
    public T z { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }

    public T b { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
}
public interface IVector4Components<T> : IVector3Components<T>
{
    public T w { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }

    public T a { [MethodImpl(256 | 512)] get; [MethodImpl(256 | 512)] set; }
}
public interface IVector2<T> : IVector<T>, IVector2, IVector2Components<T>
{
    [MethodImpl(256 | 512)]
    public void Deconstruct(out T x, out T y);
}
public interface IVector3<T> : IVector<T>, IVector3, IVector3Components<T>
{
    [MethodImpl(256 | 512)]
    public void Deconstruct(out T x, out T y, out T z);
}
public interface IVector4<T> : IVector<T>, IVector4, IVector4Components<T>
{
    [MethodImpl(256 | 512)]
    public void Deconstruct(out T x, out T y, out T z, out T w);
}

public interface IVectorSelf<Self> where Self : IVectorSelf<Self>, IVector
{
    public static abstract Self Zero { [MethodImpl(256 | 512)] get; }
    public static abstract Self One { [MethodImpl(256 | 512)] get; }
}

public interface IVectorSelf<T, Self> where Self : IVectorSelf<T, Self>, IVectorSelf<Self>, IVector<T>
{
    [MethodImpl(256 | 512)]
    public static abstract Self Scalar(T value);

    [MethodImpl(256 | 512)]
    public static abstract Self Load(ReadOnlySpan<T> span);

    #pragma warning disable CS8500
    [MethodImpl(256 | 512)]
    public static abstract unsafe Self Load(T* span);
    #pragma warning restore CS8500
}

public interface IMatrixBitops;

public interface IMatrix
{
    public static abstract bool IsSimdAccelerated { [MethodImpl(256 | 512)] get; }
    public static abstract int Length { [MethodImpl(256 | 512)] get; }
    public static abstract int2 Size { [MethodImpl(256 | 512)] get; }
}

public interface IMatrix<T> : IMatrix;

public interface IMatrix2x2 : IMatrix;
public interface IMatrix2x2<T> : IMatrix<T>, IMatrix2x2;
public interface IMatrix2x3 : IMatrix;
public interface IMatrix2x3<T> : IMatrix<T>, IMatrix2x3;
public interface IMatrix2x4 : IMatrix;
public interface IMatrix2x4<T> : IMatrix<T>, IMatrix2x4;
public interface IMatrix3x2 : IMatrix;
public interface IMatrix3x2<T> : IMatrix<T>, IMatrix3x2;
public interface IMatrix3x3 : IMatrix;
public interface IMatrix3x3<T> : IMatrix<T>, IMatrix3x3;
public interface IMatrix3x4 : IMatrix;
public interface IMatrix3x4<T> : IMatrix<T>, IMatrix3x4;
public interface IMatrix4x2 : IMatrix;
public interface IMatrix4x2<T> : IMatrix<T>, IMatrix4x2;
public interface IMatrix4x3 : IMatrix;
public interface IMatrix4x3<T> : IMatrix<T>, IMatrix4x3;
public interface IMatrix4x4 : IMatrix;
public interface IMatrix4x4<T> : IMatrix<T>, IMatrix4x4;

public interface IMatrixSelf<Self> where Self : IMatrixSelf<Self>
{
    public static abstract Self Zero { [MethodImpl(256 | 512)] get; }
    public static abstract Self One { [MethodImpl(256 | 512)] get; }
    public static abstract Self Identity { [MethodImpl(256 | 512)] get; }
}
