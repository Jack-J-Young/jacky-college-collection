method Filter<T>(a: array<T>, P: T -> bool) returns (s: seq<T>)
{
    var i := 0;
    s := [];

    while i < a.Length
    {
        if (P(a[i]))
        {
            s := s + [a[i]];
        }
        i := i + 1;
    }
}