# SimpleWebAPI

Aplikację należy uruchomić z użyciem pliku `docker-compose.yml` komendą `docker-compose up`\
API będzie dostępne pod adresem `http://localhost:5000/person`

## Krótki opis

Aplikacja jest bardzo prosta bo więcej czasu zajęło mi ogarnięcie dockera i entity frameworka.\
Odpowiada na czasowniki http:
- GET /person
- GET /person/{id}
- POST /person
- DELETE /person/{id}
- PUT /person/{id}
- PATCH /person/{id}

Przykładowy JSON do czasowników POST i PUT
```json
{
  "name": "name",
  "lastname": "lastname",
  "city": "city",
  "street": "street",
  "postalCode": "postalcode"
}
```
Przykładowy JSON do czasownika PATCH
```json
[
    {
        "value": "patched lastname",
        "path": "lastname",
        "op": "replace"
    },
    {
        "value": "patched street",
        "path": "street",
        "op": "replace"
    }
]
```


## Baza danych
Użyłem bazy PostgreSQL. W pliku `initdb.sql` zamieściłem potrzebne instrukcje do utworzenia tabel przy pierwszym uruchomieniu kontenera 
