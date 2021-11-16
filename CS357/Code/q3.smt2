( declare-fun P ( Bool ) Bool )
( assert (not (= (not ( forall (( x Bool )) ( P x )))
( exists (( x Bool )) (not ( P x ))))))
( check-sat )
