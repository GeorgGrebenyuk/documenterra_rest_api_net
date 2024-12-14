# DocTerraRestApiLib

Библиотека для взаимодействия с сервером [Documenterra ](https://documenterra.ru/) посредством её [REST API](https://docs.documenterra.ru/articles/#!manual/api-dokumenterry) и вспомогательной nuget-библиотеки `RestSharp`.

## Начало использования

```csharp
using DocTerraRestApiLib;
```

Инициализировать параметры подключения к серверу -- класс `DTerra_Connection` при помощи вызова конструктора с указанием базового адреса сервера, логина пользователя и API-ключа согласно [справке Документерры](https://docs.documenterra.ru/articles/#!manual/polucheniye-klyucha-api).

Для упрощения формирования запросов реализован класс `DTerra_ApiProcedures`, содержащий в себе методы для работы со всеми функциями, доступными в Документерра REST API; тем не менее вы можете реализовать свою логику вызова её функций. При желании использовать этот класс необходимо передать ему параметры подключения к серверу `DTerra_Connection`.
