# ghost

Inaccurate implementation of Equals() and GetHashCode could lead to the disappearance of key
that were previously added to Dictionary or HashSet.
This task illustrates such mistakes that have been made in its classes implementation.

GhostTask class`s DoMagic() method was implemented to represent what can go wrong,
when the above-mentioned mistakes are not fixed.