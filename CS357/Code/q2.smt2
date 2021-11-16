( declare-fun p () Bool )
( declare-fun q () Bool )
( assert (not (= (not (or p q )) (and (not p ) (not q )))))
( check-sat )