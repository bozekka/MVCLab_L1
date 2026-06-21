# Riffnation

Riffnation to aplikacja internetowa do przeglądania wydarzeń muzycznych oraz rezerwowania biletów na koncerty i festiwale rockowo-metalowe w Polsce.

Projekt został wykonany jako praca zaliczeniowa z przedmiotu dotyczącego tworzenia aplikacji internetowych zgodnie ze wzorcem MVC. Aplikacja została napisana w ASP.NET Core MVC, korzysta z bazy SQLite oraz Entity Framework Core.

## Spis treści

1. Opis projektu
2. Cel projektu
3. Wykorzystane technologie
4. Funkcjonalności aplikacji
5. Model danych
6. Zastosowanie wzorca MVC
7. Uruchomienie aplikacji lokalnie
8. Uruchomienie aplikacji w Dockerze
9. Dane startowe
10. Konta testowe
11. Walidacja i bezpieczeństwo
12. Struktura projektu
13. Podsumowanie

## Opis projektu

Tematem projektu jest prosty serwis do obsługi wydarzeń muzycznych. Aplikacja pozwala użytkownikowi przeglądać koncerty i festiwale, sprawdzać szczegóły wydarzeń, wyszukiwać interesujące go pozycje oraz rezerwować bilety po zalogowaniu.

Projekt jest zawężony tematycznie do sceny rockowej i metalowej. Dzięki temu aplikacja ma konkretny charakter i nie jest tylko ogólną listą wydarzeń. W bazie znajdują się przykładowe koncerty, festiwale, zespoły, miejsca wydarzeń oraz użytkownicy testowi.

## Cel projektu

Celem projektu było przygotowanie działającej aplikacji internetowej, która pokazuje praktyczne wykorzystanie wzorca MVC.

W projekcie zależało mi przede wszystkim na:

- poprawnym podziale aplikacji na modele, widoki i kontrolery,
- przygotowaniu relacji między modelami,
- obsłudze bazy danych przez Entity Framework Core,
- dodaniu formularzy z walidacją,
- stworzeniu prostego systemu logowania,
- ograniczeniu wybranych funkcji tylko dla administratora,
- przygotowaniu danych startowych do łatwego sprawdzenia działania aplikacji,
- umożliwieniu uruchomienia aplikacji lokalnie oraz przez Docker.

## Wykorzystane technologie

W projekcie wykorzystano:

- ASP.NET Core MVC
- .NET 8
- Entity Framework Core
- SQLite
- Razor Views
- HTML
- CSS
- JavaScript
- sesje użytkownika w ASP.NET Core
- Docker

Wykorzystane paczki NuGet:

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Design
- Microsoft.AspNetCore.Cryptography.KeyDerivation

## Funkcjonalności aplikacji

Aplikacja posiada następujące funkcjonalności:

- wyświetlanie listy wydarzeń muzycznych,
- wyszukiwanie wydarzeń po nazwie, mieście lub zespole,
- filtrowanie wydarzeń po gatunku, mieście i typie wydarzenia,
- osobne rozróżnienie koncertów i festiwali,
- widok szczegółów wydarzenia,
- wyświetlanie line-upu wydarzenia,
- wyświetlanie informacji o zespołach,
- obsługa wydarzeń jednodniowych i kilkudniowych,
- rejestracja użytkownika,
- logowanie i wylogowanie użytkownika,
- rezerwacja biletów tylko dla zalogowanych użytkowników,
- wybór kategorii biletu,
- przeliczanie ceny rezerwacji,
- sprawdzanie dostępnej liczby miejsc,
- lista własnych rezerwacji użytkownika,
- możliwość anulowania rezerwacji,
- panel administratora do zarządzania wydarzeniami,
- panel administratora do zarządzania zespołami,
- walidacja formularzy,
- automatyczne dodawanie przykładowych danych przy pierwszym uruchomieniu aplikacji.

Administrator ma dostęp do dodatkowych opcji, takich jak dodawanie, edycja i usuwanie wydarzeń oraz zespołów. Zwykły użytkownik może przeglądać wydarzenia i rezerwować bilety.

## Model danych

W projekcie zostały utworzone następujące modele:

- AppUser
- Event
- Venue
- Band
- EventBand
- FestivalDay
- Reservation

Najważniejsze relacje między modelami:

- jeden użytkownik może mieć wiele rezerwacji,
- jedna rezerwacja należy do jednego użytkownika,
- jedna rezerwacja dotyczy jednego wydarzenia,
- jedno wydarzenie może mieć wiele rezerwacji,
- jedno wydarzenie odbywa się w jednym miejscu,
- jedno miejsce może być przypisane do wielu wydarzeń,
- jedno wydarzenie może mieć wiele zespołów,
- jeden zespół może występować na wielu wydarzeniach,
- relacja między wydarzeniami i zespołami jest obsługiwana przez model EventBand,
- festiwal może mieć przypisane dni festiwalowe przez model FestivalDay.

Modele zawierają również podstawowe reguły walidacji, np. wymagane pola, długości tekstu, poprawność adresu e-mail oraz zakresy wartości liczbowych.

## Zastosowanie wzorca MVC

Projekt został przygotowany zgodnie ze wzorcem MVC.

### Model

Modele znajdują się w folderze `Models`. Odpowiadają za strukturę danych aplikacji, relacje między obiektami oraz część walidacji.

Przykładowe modele:

- `Event`
- `Band`
- `Venue`
- `Reservation`
- `AppUser`

### View

Widoki znajdują się w folderze `Views`. Są to widoki Razor odpowiedzialne za prezentowanie danych użytkownikowi oraz wyświetlanie formularzy.

Przykładowe widoki:

- lista wydarzeń,
- szczegóły wydarzenia,
- formularz rezerwacji,
- logowanie,
- rejestracja,
- lista zespołów,
- panel zarządzania wydarzeniami.

### Controller

Kontrolery znajdują się w folderze `Controllers`. Odpowiadają za obsługę żądań użytkownika, pobieranie danych z bazy oraz przekazywanie ich do widoków.

W projekcie znajdują się między innymi:

- `HomeController`
- `EventsController`
- `ReservationsController`
- `BandsController`
- `AccountController`

Dzięki takiemu podziałowi logika aplikacji, dane i warstwa widoku są od siebie oddzielone.

## Uruchomienie aplikacji lokalnie

Do uruchomienia projektu lokalnie wymagany jest .NET SDK 8.

Po pobraniu repozytorium należy wejść do folderu projektu i wykonać komendy:

```bash
dotnet restore
dotnet run
```

Aplikacja uruchomi się lokalnie pod adresem:

```text
http://localhost:5080
```

Przy pierwszym uruchomieniu tworzona jest baza SQLite oraz dodawane są dane startowe.

Jeżeli trzeba wyczyścić bazę i wygenerować dane od nowa, można usunąć plik:

```text
metalrock.db
```

Po ponownym uruchomieniu aplikacji baza zostanie utworzona ponownie.

## Uruchomienie aplikacji w Dockerze

Projekt zawiera pliki:

- `Dockerfile`
- `docker-compose.yml`

Aplikację można uruchomić przez Docker poleceniem:

```bash
docker compose up --build
```

Po uruchomieniu aplikacja będzie dostępna pod adresem:

```text
http://localhost:8080
```

Docker pozwala uruchomić aplikację w kontenerze, bez konieczności ręcznej konfiguracji środowiska na komputerze.

## Dane startowe

Aplikacja posiada przygotowane dane startowe, które są dodawane automatycznie przy pierwszym uruchomieniu projektu.

Dane znajdują się w pliku:

```text
Data/SeedData.cs
```

Dzięki temu po uruchomieniu aplikacji można od razu sprawdzić jej działanie bez ręcznego dodawania wydarzeń, zespołów i użytkowników.

Przykładowe dane obejmują:

- koncerty,
- festiwale,
- miejsca wydarzeń,
- zespoły,
- przykładowych użytkowników,
- konto administratora.

Przykładowe wydarzenia w aplikacji:

- Impact Festival,
- Mystic Festival,
- Summer Punch Festival,
- Summer Dying Loud,
- koncert Korn,
- koncert Bring Me The Horizon.

## Konta testowe

W aplikacji są przygotowane konta testowe.

Konto zwykłego użytkownika:

```text
Email: demo@riffnation.pl
Hasło: Demo123!
```

Konto administratora:

```text
Email: admin@riffnation.pl
Hasło: Admin123!
```

Zwykły użytkownik może przeglądać wydarzenia i rezerwować bilety.

Administrator ma dodatkowo dostęp do zarządzania wydarzeniami i zespołami.

## Walidacja i bezpieczeństwo

W projekcie została dodana walidacja formularzy. Sprawdzane są między innymi:

- wymagane pola,
- poprawność adresu e-mail,
- długość tekstu,
- liczba biletów,
- dostępność miejsc,
- poprawność danych przy rejestracji,
- zgodność haseł przy zakładaniu konta.

Hasła użytkowników nie są zapisywane w bazie jako zwykły tekst. W projekcie zastosowano hashowanie haseł.

Logowanie działa na podstawie sesji użytkownika. Po zalogowaniu aplikacja zapamiętuje podstawowe informacje o użytkowniku, między innymi to, czy jest administratorem.

Wybrane funkcje, takie jak dodawanie, edycja i usuwanie wydarzeń oraz zespołów, są dostępne tylko dla administratora.

## Struktura projektu

```text
Riffnation
- Controllers
  - AccountController
  - BandsController
  - EventsController
  - HomeController
  - ReservationsController

- Data
  - ApplicationDbContext
  - SeedData

- Helpers
  - EnumExtensions
  - PasswordHelper

- Models
  - AppUser
  - Band
  - Event
  - EventBand
  - FestivalDay
  - Reservation
  - Venue

- Models/Enums
  - EventType
  - MusicGenre
  - TicketStatus

- ViewModels
  - AccountViewModels
  - EventListViewModel

- Views
  - Account
  - Bands
  - Events
  - Home
  - Reservations
  - Shared

- wwwroot
  - css
  - js

- Program.cs
- appsettings.json
- Dockerfile
- docker-compose.yml
- Riffnation.csproj
```

## Najważniejsze elementy projektu

Najważniejsze elementy wykonane w projekcie:

- aplikacja internetowa zgodna ze wzorcem MVC,
- baza danych SQLite obsługiwana przez Entity Framework Core,
- relacje między modelami,
- formularze z walidacją,
- rejestracja i logowanie użytkowników,
- hashowanie haseł,
- rozróżnienie zwykłego użytkownika i administratora,
- wyszukiwanie i filtrowanie danych,
- rezerwowanie biletów,
- przykładowe dane startowe,
- możliwość uruchomienia aplikacji przez Docker.

## Podsumowanie

Riffnation jest prostą aplikacją MVC do obsługi wydarzeń muzycznych i rezerwacji biletów. Projekt pokazuje wykorzystanie modeli, widoków i kontrolerów, pracę z bazą danych, relacje między tabelami, walidację formularzy oraz podstawową obsługę użytkowników.

Aplikacja posiada dane testowe, dlatego po uruchomieniu można od razu sprawdzić jej najważniejsze funkcje: przeglądanie wydarzeń, wyszukiwanie, rezerwację biletów oraz zarządzanie danymi z poziomu administratora.