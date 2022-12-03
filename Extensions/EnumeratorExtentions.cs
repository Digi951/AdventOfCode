using System;

namespace AdventToCode.Extensions;

public static class EnumeratorExtensions
{
    public static CustomIntEnumerator GetEnumerator(this Range range)
    {
        return new CustomIntEnumerator(range);
    }

    public static CustomIntEnumerator GetEnumerator(this Int32 number)
    {
        return new CustomIntEnumerator(new Range(0, number));
    }
}

public ref struct CustomIntEnumerator
{
    private Int32 _current;
    private readonly Int32 _end;

    public CustomIntEnumerator(Range range)
    {
        if (range.End.IsFromEnd)
        {
            throw new NotSupportedException();
        }

        _current = range.Start.Value - 1;
        _end = range.End.Value - 1;
    }

    public Int32 Current => _current;

    public Boolean MoveNext()
    {
        _current++;
        return _current <= _end;
    }
}
