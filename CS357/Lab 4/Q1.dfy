method SumFirst(n: nat) returns (sum: nat)
    ensures sum == n * (n + 1) / 2
{
    sum := 0;
    var i := 0;
    
    while i < n
    invariant 0 <= i <= n
    invariant sum == i * (i + 1) / 2 {
        i := i + 1;
        sum := sum + i;
    }
}