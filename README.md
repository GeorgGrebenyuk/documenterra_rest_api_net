# documenterra_rest_api_net



Source code for Documenterra rest api via .NET and RestSharp package

Исходный код для Nuget-пакета `DocTerraRestApiLib` (`net6.0` и `RestSharp`).



# Функциональность

Далее приведено сопоставление имеющихся методов [API в Документерре](https://docs.documenterra.ru/articles/#!manual/api-dokumenterry) с реализованными в настоящей библиотеке. 

| Группа                  | Название                                                        | Реализация | Метод                                 |
| ----------------------- | --------------------------------------------------------------- | ---------- | ------------------------------------- |
| Проекты и публикации    | Получение информации о проекте/публикации                       | ✔️         | GetProjectOrPublicationInfo           |
|                         | Получение всех проектов и публикаций                            | ✔️         | GetProjectsAndPublicationsInfo        |
|                         | Получение списка публикаций, доступных авторизованному читателю | ✔️         | GetProjectsAndPublicationsInfoForUser |
|                         | Изменение видимости публикации                                  | ✔️         | EditPublicationVisibility             |
|                         | Публикация проекта                                              | ✔️         | PublishProject                        |
|                         | Обновление публикации                                           | ✔️         | UpdatePublication                     |
|                         | Экспорт публикации                                              | ✔️         | ExportPublication                     |
|                         | Получение статуса задачи управления проектом                    | ✔️         | GetPublicationTaskStatus              |
|                         | Создание резервной копии проекта                                | ✔️         | CreateBackupOfProject                 |
| Отчетность и аналитика  | Получение поисковых запросов                                    | ✔️         | GetReportAboutSearchRequests          |
|                         | Получение просмотров страницы                                   | ✔️         | GetReportAboutPageVisits              |
| Поиск                   | Поиск по порталу                                                | ✔️         | GetSearchResultsForPortal             |
| Хранилище               | Получение файла                                                 | ✔️         | GetFileInfoFromStorage                |
|                         | Получение информации о нескольких файлах                        | ✔️         | GetFilesInfoFromStorage               |
|                         | Создание файла или папки                                        | ✔️         | CreateFileOrFolder                    |
|                         | Проверка наличия файла или папки                                | ✔️         | IsFileExistsInStorage                 |
|                         | Обновление файла                                                | ✔️         | UpdateFileInStorage                   |
|                         | Удаление файла                                                  | ✔️         | DeleteFileInStorage                   |
|                         | Удаление нескольких файлов                                      | ✔️         | DeleteFilesInStorage                  |
| Элементы Дерева страниц | Получение элемента Дерева страниц                               | ✔️         | TocGetElement                         |
|                         | Получение нескольких элементов Дерева страниц                   | ✔️         | TocGetElements                        |
|                         | Получение дочерних элементов Дерева страниц                     | ✔️         | TocGetChildElements                   |
|                         | Создание элемента Дерева страниц (папки)                        | ✔️         | TocCreateElement                      |
|                         | Обновление элемента Дерева страниц                              | ✔️         | TocUpdateElement                      |
|                         | Удаление элемента Дерева страниц                                | ✔️         | TocDeleteElement                      |
|                         | Удаление нескольких элементов Дерева страниц                    | ✔️         | TocDeleteElements                     |
| Страницы                | Получение страницы                                              | ✔️         | GetPage                               |
|                         | Получение всех страниц из проекта/публикации                    | ✔️         | GetPages                              |
|                         | Создание страницы                                               | ✔️         | PageCreateNew                         |
|                         | Обновление страницы                                             | ✔️         | PageUpdate                            |
|                         | Удаление страницы                                               | ✔️         | PageDelete                            |
|                         | Удаление нескольких страниц                                     | 5          | PagesDelete                           |
| Пользователи            | Получение профиля авторизованного читателя                      | ✔️         | GetUserProfile                        |
|                         | Создание учетной записи авторизованного читателя                | ✔️         | CreateNewUserProfile                  |
|                         | Изменение профиля авторизованного читателя                      | ✔️         | UpdateUserProfile                     |
|                         | Получение токена входа                                          | ✔️         | GetUserToken                          |

# Примеры

Приведены в папке `example`:

- `ModifyImagesBorder`: редактирование ресурсов проекта - простановка у картинок границ настраиваемой ширины и цвета (в силу отсутствия такого механизма у движка Документерры);
