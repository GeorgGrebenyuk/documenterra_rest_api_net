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
        private string p_Responce_JSON = "";
        private HttpStatusCode p_Responce_Status;

        public HttpStatusCode GetLastStatusCode { get {  return p_Responce_Status; } }

        public string GetLastResponce { get { return p_Responce_JSON; } }

        private void reset_data()
        {
            p_Responce_JSON = "";
        }

        public DTerra_ApiProcedures(DTerra_Connection p_Connection)
        {
            this.p_Connection = p_Connection;
            reset_data();
        }

        #region API: Проекты и публикации
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-proyekte-publikatsii
        public ProjectOrPublication_Info? GetProjectOrPublicationInfo(string id)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{id}", "", out p_Responce_JSON, out p_Responce_Status);

            return ProjectOrPublication_Info.LoadFrom(p_Responce_JSON);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-vsekh-proyektov-i-publikatsiy
        public ProjectOrPublication_Info[]? GetProjectsAndPublicationsInfo()
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects", "", out p_Responce_JSON, out p_Responce_Status);
            return (ProjectOrPublication_Info[]?)JsonSerializer.Deserialize(p_Responce_JSON,
                             typeof(ProjectOrPublication_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-spiska-publikatsiy-dostupnyh-avtorizovannomu-chitatelyu
        public ProjectOrPublication_Info[]? GetProjectsAndPublicationsInfoForUser(string userLogin)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"users/{userLogin}/projects", "", out p_Responce_JSON, out p_Responce_Status);
            return (ProjectOrPublication_Info[]?)JsonSerializer.Deserialize(p_Responce_JSON,
                             typeof(ProjectOrPublication_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-izmeneniye-vidimosti-publikatsii
        public void EditPublicationVisibility(string idPublication, PublicationVisibility_Info publInfo)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"projects/{idPublication}", publInfo.ToJson(), out p_Responce_JSON, out p_Responce_Status);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-publikatsiya-proyekta
        public void PublishProject(string idPublication, PublicationCreate_Info publication_Info)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson(), out p_Responce_JSON, out p_Responce_Status);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-publikatsii
        public void UpdatePublication(string idPublication, PublicationUpdate_Info publication_Info)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson(), out p_Responce_JSON, out p_Responce_Status);
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
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?format={format}", "", out p_Responce_JSON, out p_Responce_Status);
            return Storage_FileInfo.LoadFrom(p_Responce_JSON);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-neskolkikh-faylakh
        public Storage_FileInfo[]? GetFilesInfoFromStorage(string path, string filter = "*", bool isRecursive = false)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?filter={filter}&isRecursive={isRecursive}", "", out p_Responce_JSON, out p_Responce_Status);

            return (Storage_FileInfo[]?)JsonSerializer.Deserialize(p_Responce_JSON,
                             typeof(Storage_FileInfo[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-proverka-nalichiya-fayla-ili-papki
        public bool IsFileExistsInStorage(string path)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.HEAD, $"storage/{path}", "", out p_Responce_JSON, out p_Responce_Status);
            if (p_Responce_Status == HttpStatusCode.OK) return true;
            return false;
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-faila
        public void UpdateFileInStorage(string path, Storage_FileUpdateInfo fileInfo)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"storage/{path}", fileInfo.ToJson(), out p_Responce_JSON, out p_Responce_Status);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-faila
        public void DeleteFileInStorage(string path)
        {
            reset_data();
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"storage/{path}", "", out p_Responce_JSON, out p_Responce_Status);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-neskolkikh-failov
        public void DeleteFilesInStorage(string[] paths)
        {
            reset_data();
            Storage_FilesDelete data = new Storage_FilesDelete(paths);
            p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"storage", data.ToJson(), out p_Responce_JSON, out p_Responce_Status);
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
