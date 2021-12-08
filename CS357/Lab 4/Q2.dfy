function Fib(n: nat): nat
{
    if n < 2 then n else Fib(n - 1) + Fib(n - 2)
}

method FibIter(n: nat) returns (x: nat)
    ensures x == Fib(n)
{
    if (n <= 1)
    {
        return n;
    }
    var i := 1;
    x := 1;
    var prev := 0;

    while i < n
        invariant 0 < i <= n
        invariant prev == Fib(i - 1)
        invariant x == Fib(i)
    {
        var temp := x;
        x := x + prev;
        prev := temp;
        i := i + 1;
    }
}