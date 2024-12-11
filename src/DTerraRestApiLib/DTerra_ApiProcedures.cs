using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DTerraRestApiLib.Enumerations;
using DTerraRestApiLib.Classes;
using System.Buffers.Text;
using System.Net;
using System.IO;

namespace DTerraRestApiLib
{

    public class DTerra_ApiProcedures
    {
        private DTerra_Connection p_Connection;

        public DTerra_ApiProcedures(DTerra_Connection p_Connection)
        {
            this.p_Connection = p_Connection;
        }

        #region API: Проекты и публикации
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-proyekte-publikatsii
        public ProjectOrPublication_Info? GetProjectOrPublicationInfo(string id)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{id}", "");
            return ProjectOrPublication_Info.LoadFrom(result.Result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-vsekh-proyektov-i-publikatsiy
        public ProjectOrPublication_Info[]? GetProjectsAndPublicationsInfo()
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects", "");
            return (ProjectOrPublication_Info[]?)JsonSerializer.Deserialize(result.Result.Response,
                             typeof(ProjectOrPublication_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-spiska-publikatsiy-dostupnyh-avtorizovannomu-chitatelyu
        public ProjectOrPublication_Info[]? GetProjectsAndPublicationsInfoForUser(string userLogin)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"users/{userLogin}/projects", "");
            return (ProjectOrPublication_Info[]?)JsonSerializer.Deserialize(result.Result.Response,
                             typeof(ProjectOrPublication_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-izmeneniye-vidimosti-publikatsii
        public void EditPublicationVisibility(string idPublication, PublicationVisibility_Info publInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"projects/{idPublication}", publInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-publikatsiya-proyekta
        public void PublishProject(string idPublication, PublicationCreate_Info publication_Info)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-publikatsii
        public void UpdatePublication(string idPublication, PublicationUpdate_Info publication_Info)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson());
        }

        #endregion


        #region API: Отчетность и аналитика
        #endregion

        #region API: Поиск
        #endregion

        #region API: Хранилище

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-faila
        public Storage_FileInfo? GetFileInfoFromStorage(string path, string format = "base64")
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?format={format}", "");
            return Storage_FileInfo.LoadFrom(result.Result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-neskolkikh-faylakh
        public Storage_FileInfo[]? GetFilesInfoFromStorage(string path, string filter = "*", bool isRecursive = false)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?filter={filter}&isRecursive={isRecursive}", "");

            return (Storage_FileInfo[]?)JsonSerializer.Deserialize(result.Result.Response,
                             typeof(Storage_FileInfo[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-proverka-nalichiya-fayla-ili-papki
        public bool IsFileExistsInStorage(string path)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.HEAD, $"storage/{path}", "");
            if (result.Result.StatusCode == HttpStatusCode.OK) return true;
            return false;
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-faila
        public void UpdateFileInStorage(string path, Storage_FileUpdateInfo fileInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"storage/{path}", fileInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-faila
        public void DeleteFileInStorage(string path)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"storage/{path}", "");
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-neskolkikh-failov
        public void DeleteFilesInStorage(string[] paths)
        {
            Storage_FilesDelete data = new Storage_FilesDelete(paths);
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"storage", data.ToJson());
        }
        #endregion

        #region API: Элементы дерева страницы
        #endregion

        #region API: Страницы
        #endregion

        #region API: Пользователи
        #endregion
    }
}
