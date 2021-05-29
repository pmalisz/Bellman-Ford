# Teoria Grafów - projekt zaliczeniowy by Paweł Malisz

**Część analityczna znajduje się w pliku "Część analityczna.pdf"**  

**Instrukcja do części programistycznej:**  
Program domyślnie pobiera dane z pliku graph.txt, w formie listy sądiedztwa.
Można zmienić plik, z którego pobierane są dane zmieniając wartość zmiennej path w metodzie Main klasy Program (nalezy podać ścieżkę absolutną).
Aby uruchomić program należy sklonować solucje, oraz uruchomić za pomocą dowolnego IDE obsługujacego język C# (preferowane Visual Studio).
Następnie można ewentualnie zmienić ścieżkę do pliku, z którego brane są dane oraz zmienić wierzchołek źródłowy (domyslnie 0) w argumencie funkcji BellmanFord wywoływanej na obiekcie graph, po czym można uruchomić program.
Program wypisze w konsoli odległości wszystkich wierzchołków od źródła, lub błąd w przypadku, gdy w grafie znajduje się cykl ujemny, bądź jeśli podane zostanie nieistniejące źródło.

**Analiza algorytmu:**  
Algorytm Bellmana-Forda służy do wyszukiwania najkrótszych ścieżek z wierzchołka źródłowego do wszystkich innych wierzchołków w grafie ważonym.
W przeciwieństwie do algorytmu Dijkstry potrafi on to robić również dla ujemnych wag krawędzi jednak działa dużo wolniej.
Może on także służyć do wyszukiwania ujemnych cykli w grafie.
Złożoność tego algorytmu wynosi O(VE), gdzie V to liczba wierzchołków, a E liczba krawędzi (dla porównania algorytm Djikstry ma złożoność O(VLogV))
Algorytm ten jest używany do routingu np w protokole RIP (Routing Information Protocol), służący do obliczania najlepszej trasy do celu w sieci.
Obecnie do rozwiązywania problemów znajdowania najkrótszych ścieżek w grafie korzysta się najczęściej z algorytmów Djikstry, Floyda-Warshalla oraz Johnsona.
