method swap(a: array<int>, i: nat, j: nat)
    modifies a
    requires a.Length > i;
    requires a.Length > j;
    ensures a[i] == old(a[j])
    ensures a[j] == old(a[i])
{
    var temp := a[i];
    a[i] := a[j];
    a[j] := temp;
}