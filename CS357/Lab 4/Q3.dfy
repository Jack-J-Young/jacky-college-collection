method Smallest(a: array<int>) returns (minIndex: nat)
    requires a.Length > 0
{
    minIndex := 0;
    
    var i := 0;

    while i < a.Length
        invariant 0 <= minIndex < a.Length
    {
        if (a[i] < a[minIndex])
        {
            minIndex := i;
        }
        i := i + 1;
    }
}