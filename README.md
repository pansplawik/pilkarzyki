# Projekt studencki na przedmiot Programowanie Aplikacji z Interfejsem Graficznym o nazwie `Piłkarzyki` 
# Autor: Kamil Spławiński IiAM sekcja 1
## Opis
Aplikacja służąca do monitoringu aktywności piłkarzy oraz ich postepów podczas treningów. Aplikacja składa się z:
- kilko okien 
- panelu rejestracji
- panelu logowania
- hashowania hasła
- bazy danych w chmurze
- wgrywania danych
- zczytywnaia danych i tworzenie odpowiednio:
  * tabel
  * wykresów

## Technologie

Wykorzystane środowiska

- `C#` (backend)
- `CSS` i `HTML` (frontend)
- `Google Charts` (wykresy)
-  Azure Microsoft Server SQL (baza danych)

## Jak włączyć?

Aby włączyć aplikację webową wystarczy pobrać repozytorium za pomocą `git pull` (opcjonalnie pobierz projektw postaci zip), a następnie wykonaj poniższe kroki:
1. Otwórz projekt w Visual Studio.
2. Wybierz projekt, którego chcesz skompilować bez debugowania.
3. Kliknij prawym przyciskiem myszy na projekt i wybierz opcję "Właściwości".
4. W oknie właściwości projektu przejdź do sekcji "Debugowanie".
5. Znajdź pole "Tryb debugowania" i zmień jego wartość na "Brak".
6. Kliknij przycisk "OK", aby zaakceptować zmiany.
7. Teraz możesz skompilować projekt bez debugowania, wybierając opcję "Kompiluj" lub używając skrótu klawiaturowego "Ctrl + F7".

## Co nowego w zależności od wersji z zeszłego semestru.

- Lepsze zabezpieczneie danych poprzez logowanie za pomocą loginu i hasła (hashowanie hasła).
- Podłączenie bazy danych w chmurze, zastosowanie Azure
- Lepiej dopasowane dane
- Normalizacja drugiego stopnia bazy danych.
- update widoku

## Trudności

Jako, że aplikacja ma baze danych znajdującą się lokalnie, nie można przesyałc informacji do bazy danych oraz pobierać informacji z niej poza komputerem na którym znajduje się baza danych.

## Dane Testowe do logowania

login: admin
hasło: admin
