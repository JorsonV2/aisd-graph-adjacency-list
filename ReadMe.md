# Prosta implementacja grafów

* Krzysztof Molenda
* Na podstawie wielu materiałów z _Stack Overflow_ i różnych podręczników.
* Wersja rozwojowa.
* Cel: edukacja

## Założenia

* `T` - etykiety węzłów grafu
* Brak opakowania "węzły", "krawędzie"
* `IGraph<T>` - interfejs, bardzo ogólny
* `Graph<T>` - prosta implementacja grafu nieskierowanego, nieważonego. Węzły - reprezentowane przez obiekty typu `T` - to tylko etykiety. 
  Krawędzie zrealizowane jako `Tuple<T,T>`.
* `Algorithms` - statyczna klasa z metodami rozszerzającymi, w tym metodami przechodzenia po grafie.
* `Program.cs` - przykładowe użycie.