method Eg1(x: int) returns (y: int)
    requires true
    ensures y == (x + 1)
{
        // {true}
        var a := x + 1;

        assert (a - 1 == 0 ==> x == 0) && (a - 1 != 0 ==> a == x + 1);
        // {(a - 1 == 0 ==> x == 0) &&
        // (a - 1 != 0 ==> a == x + 1)}
        if (a - 1 == 0) {
            y := 1;
        } else {
            y := a;
        }
        // {y == (x + 1)}

}