method Max(a: int, b: int) returns (m: int)
    requires true
    ensures (m == a && a >= b) || (m == b && b >= a)
{
    if (a >= b) {
        m := a;
    }
    else
    {
        m := b;
    }
}