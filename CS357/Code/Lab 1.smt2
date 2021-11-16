(declare-fun a() Bool)
(declare-fun b() Bool)
(declare-fun c() Bool)

(declare-fun e() Bool)
(declare-fun f() Bool)

(declare-fun R(Bool) Bool)


; q1

(assert (= (or (not a) b) (=> a b) ))
(check-sat)
(get-model)


; q2

(assert (= (=> a b) (=> (not b) (not a)) ))
(check-sat)
(get-model)


; q3

(assert (= (=> (or a b) c) (=> a (=> a c)) ))
(check-sat)
(get-model)


; q4

(assert (= (and (not e) (not f)) (not (or e f)) ))
(check-sat)
(get-model)


; q5

(assert (= (not (exists ((x Bool)) (not (R x)) )) (forall ((y Bool)) (R y) ) ))
(check-sat)
(get-model)


; q6

(assert (= (exists ((y Bool)) (not (R y)) ) (not (forall ((z Bool)) (R z) )) ))
(check-sat)
(get-model)


; q7

(assert (= (forall ((x Bool)) (R x) ) (not (forall ((y Bool)) (not (R y)) )) ))
(check-sat)
(get-model)







