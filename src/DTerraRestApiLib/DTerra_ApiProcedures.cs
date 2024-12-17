using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DocTerraRestApiLib.Enumerations;
using DocTerraRestApiLib.Classes;
using System.Buffers.Text;
using System.Net;
using System.IO;
using System.Collections;
using System.Xml.Linq;
using System.Linq.Expressions;

namespace DocTerraRestApiLib
{

    public class DTerra_ApiProcedures
    {
        private readonly DTerra_Connection p_Connection;

        public DTerra_ApiProcedures(DTerra_Connection p_Connection)
        {
            this.p_Connection = p_Connection;
        }

        #region API: Проекты и публикации
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-proyekte-publikatsii
        public ProjectOrPublicationInfo? GetProjectOrPublicationInfo(string id)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{id}", "");
            return ProjectOrPublicationInfo.LoadFrom(result.Response); //.Result
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-vsekh-proyektov-i-publikatsiy
        public ProjectOrPublicationInfo[]? GetProjectsAndPublicationsInfo()
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects", "");
            return (ProjectOrPublicationInfo[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(ProjectOrPublicationInfo[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-spiska-publikatsiy-dostupnyh-avtorizovannomu-chitatelyu
        public ProjectOrPublicationInfo[]? GetProjectsAndPublicationsInfoForUser(string userLogin)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"users/{userLogin}/projects", "");
            return (ProjectOrPublicationInfo[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(ProjectOrPublicationInfo[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-izmeneniye-vidimosti-publikatsii
        public void EditPublicationVisibility(string idPublication, PublicationVisibilityInfo publInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"projects/{idPublication}", publInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-publikatsiya-proyekta
        public void PublishProject(string idPublication, PublicationCreateInfo_Arguments publication_Info)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-publikatsii
        public void UpdatePublication(string idPublication, PublicationUpdateInfo publication_Info)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=publish", publication_Info.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-eksport-publikatsii
        public PublicationTaskInfo? ExportPublication(string idPublication, PublicationExportInfo_Arguments ExportInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idPublication}?action=export", ExportInfo.ToJson());
            return PublicationTaskInfo.LoadFrom(result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-statusa-zadachi-v-ramkah-proyekta
        public PublicationTaskStatusInfo? GetPublicationTaskStatus(string idTask)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"tasks/{idTask}", "");
            return PublicationTaskStatusInfo.LoadFrom(result.Response);
        }

        public PublicationTaskInfo? CreateBackupOfProject(string idProject, string outputFileName)
        {
            ProjectBackup_Arguments data_temp = new ProjectBackup_Arguments(outputFileName);
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idProject}?action=download", data_temp.ToJson());
            return PublicationTaskInfo.LoadFrom(result.Response);
        }

        #endregion


        #region API: Отчетность и аналитика
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-poiskovykh-zaprosov
        public Report_SearchRequest_Info[]? GetReportAboutSearchRequests(string login, DateTime startTime, DateTime endTime, string? publicationId = null)
        {
            string projectId_adding = $"&projectId={publicationId}";
            string query = $"reports/user-events/{login}/search-queries?startDate={startTime.ToString("O")}&endDate={endTime.ToString("O")}";
            if (publicationId != null) query += projectId_adding;

            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, query, "");
            return (Report_SearchRequest_Info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(Report_SearchRequest_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-prosmotrov-stranitsy
        public Report_PageVisit_info[]? GetReportAboutPageVisits(string login, DateTime startTime, DateTime endTime)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"reports/user-events/{login}/articles?startDate={startTime.ToString("O")}&endDate={endTime.ToString("O")}", "");
            return (Report_PageVisit_info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(Report_PageVisit_info[]), CommonData.p_JsonSerializerOptions_Read);
        }
        #endregion

        #region API: Поиск
        //https://docs.documenterra.ru/articles/#!manual/api-poisk-po-portalu
        public Search_ExplorePortal_Info[]? GetSearchResultsForPortal(Search_ExplorePortal_Arguments searchArguments)
        {
            string query_projectIds = $"projectIds={searchArguments.projectIds}&";
            string query_lang = $"lang={searchArguments.lang}&";
            string query_isReturnSnippets = $"isReturnSnippets={searchArguments.isReturnSnippets}";

            if (searchArguments.projectIds0.Any()) query_projectIds = "";
            if (searchArguments.lang == null) query_lang = "";
            if (searchArguments.isReturnSnippets == null) query_isReturnSnippets = "";

            string query = $"search?count={searchArguments.count}&{query_projectIds}{query_lang}{query_isReturnSnippets}q={searchArguments.q}";

            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, query, "");
            return (Search_ExplorePortal_Info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(Search_ExplorePortal_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }
        #endregion

        #region API: Хранилище

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-faila
        public Storage_FileInfo? GetFileInfoFromStorage(string path, string format = "base64")
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?format={format}", "");
            return Storage_FileInfo.LoadFrom(result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-informatsii-o-neskolkikh-faylakh
        public Storage_FileInfo[]? GetFilesInfoFromStorage(string path, string filter = "*", bool isRecursive = false)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"storage/{path}?filter={filter}&isRecursive={isRecursive}", "");

            return (Storage_FileInfo[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(Storage_FileInfo[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-sozdaniye-fayla-ili-papki
        public void CreateFileOrFolder(string storagePath, FormatVariant format, bool isOverwrite, Storage_FileOrFolderCreation_Arguments? FileOrFolderInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"storage/{storagePath}?format={format.ToString()}&isOverwrite={isOverwrite}", FileOrFolderInfo?.ToJson() ?? "");
        }

        //https://docs.documenterra.ru/articles/#!manual/api-proverka-nalichiya-fayla-ili-papki
        public bool IsFileExistsInStorage(string path)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.HEAD, $"storage/{path}", "");
            if (result.StatusCode == HttpStatusCode.OK) return true;
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
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-elementa-dereva-stranits
        public TOC_Element_Info? TocGetElement(string idProject, string idTocNode)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{idProject}/toc/nodes/{idTocNode}", "");
            return (TOC_Element_Info?)JsonSerializer.Deserialize(result.Response,
                             typeof(TOC_Element_Info), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-neskolkikh-elementov-dereva-stranits
        public TOC_Element_Info[]? TocGetElements(string idProject)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{idProject}/toc/nodes", "");
            return (TOC_Element_Info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(TOC_Element_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-dochernikh-elementov-dereva-stranits
        public TOC_Element_Info[]? TocGetChildElements(string idProject, string idTocNode, bool isRecursive = false)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{idProject}/toc/nodes{idTocNode}/children?isRecursive={isRecursive}", "");
            return (TOC_Element_Info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(TOC_Element_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-sozdaniye-elementa-dereva-stranits-papki
        public void TocCreateElement(string idProject, TOC_ElementNew_Arguments ElementInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idProject}/toc/nodes", ElementInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-elementa-dereva-stranits
        public void TocUpdateElement(string idProject, string idTocNode, TOC_ElementUpdate_Arguments ElementInfo)
        {
            List<string> temp_fields = new List<string>();
            if (ElementInfo.caption != null) temp_fields.Add("caption");
            if (ElementInfo.isShowInToc != null) temp_fields.Add("isShowInToc");
            if (ElementInfo.ordinalNo != null) temp_fields.Add("ordinalNo");
            if (ElementInfo.parentId != null) temp_fields.Add("parentId");
            ElementInfo.updatedFields = string.Join(",", temp_fields);

            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"projects/{idProject}/toc/nodes/{idTocNode}", ElementInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-elementa-dereva-stranits
        public void TocDeleteElement(string idProject, string idTocNode)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"projects/{idProject}/toc/nodes/{idTocNode}", "");
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-neskolkikh-elementov-dereva-stranits
        public void TocDeleteElements(string idProject, string[] idTocNodes)
        {
            TOC_ElementsDelete_Arguments delData = new TOC_ElementsDelete_Arguments(idTocNodes);
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"projects/{idProject}/toc/nodes", delData.ToJson());
        }
        #endregion

        #region API: Страницы
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-stranitsy
        public Pages_Page_Info? GetPage(string idProject, string idTopic)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{idProject}/articles/{idTopic}", "");
            return Pages_Page_Info.LoadFrom(result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-vsekh-stranits-proyekta-publikatsii
        public Pages_Page_Info[]? GetPages(string idProject)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"projects/{idProject}/articles", "");
            return (Pages_Page_Info[]?)JsonSerializer.Deserialize(result.Response,
                             typeof(Pages_Page_Info[]), CommonData.p_JsonSerializerOptions_Read);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-sozdaniye-stranitsy
        public Pages_Page_Info? PageCreateNew(string idProject, Pages_PageCreate_Arguments PageInfo)
        {
            if (PageInfo.assigneeUserName == null) PageInfo.assigneeUserName = this.p_Connection.p_Login;
            if (PageInfo.ownerUserName == null) PageInfo.ownerUserName = this.p_Connection.p_Login;

            var json = PageInfo.ToJson();
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"projects/{idProject}/articles", PageInfo.ToJson());

            return Pages_Page_Info.LoadFrom(result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-obnovleniye-stranitsy
        public void PageUpdate(string idProject, string idTopic, Pages_PageUpdate_Arguments PageInfo)
        {
            List<string> temp_fields = new List<string>();
            if (PageInfo.assigneeUserName != null) temp_fields.Add("assigneeUserName");
            if (PageInfo.body != null) temp_fields.Add("body");
            if (PageInfo.ownerUserName != null) temp_fields.Add("ownerUserName");
            if (PageInfo.statusName != null) temp_fields.Add("statusName");
            if (PageInfo.title != null) temp_fields.Add("title");
            if (PageInfo.indexKeywords != null) temp_fields.Add("indexKeywords");
            PageInfo.updatedFields = string.Join(",", temp_fields);

            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"projects/{idProject}/articles/{idTopic}", PageInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-stranitsy
        public void PageDelete(string idProject, string idTopic)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"projects/{idProject}/articles/{idTopic}", "");
        }

        //https://docs.documenterra.ru/articles/#!manual/api-udaleniye-neskolkikh-stranits
        public void PagesDelete(string idProject, string[] topics)
        {
            Pages_Deleting_Arguments topicsData = new Pages_Deleting_Arguments(topics);
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.DEL, $"projects/{idProject}/articles", topicsData.ToJson());
        }

        #endregion

        #region API: Пользователи
        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-profilya-avtorizovannogo-chitatelya
        public Users_UserProfile_Info? GetUserProfile(string userLogin)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.GET, $"users/{userLogin}", "");
            return Users_UserProfile_Info.LoadFrom(result.Response);
        }

        //https://docs.documenterra.ru/articles/#!manual/api-sozdaniye-uchetnoy-zapisi-avtorizovannogo-chitatelya
        public void CreateNewUserProfile(Users_UserProfileNew_Arguments UserInfo)
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.POST, $"users", UserInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-izmeneniye-profilya-avtorizovannogo-chitatelya
        public void UpdateUserProfile(string userLogin, Users_UserProfileUpdate_Arguments UserInfo)
        {
            List<string> temp_fields = new List<string>();
            if (UserInfo.email != null) temp_fields.Add("email");
            if (UserInfo.userRole != null) temp_fields.Add("userRole");
            if (UserInfo.isEnabled != null) temp_fields.Add("isEnabled");
            UserInfo.updatedFields = string.Join(",", temp_fields);

            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"users/{userLogin}", UserInfo.ToJson());
        }

        //https://docs.documenterra.ru/articles/#!manual/api-polucheniye-tokena-vkhoda
        public Users_UserTolen_Info? GetUserToken(string userLogin, DateTime tokenLife, bool IsReusable = true) 
        {
            var result = p_Connection.CreateRequest(DTerra_Connection.ConnectType.PATCH, $"/users/{userLogin}/tokens?exp={tokenLife.ToString("O")}&muse={IsReusable}", "");
            return Users_UserTolen_Info.LoadFrom(result.Response);
        }
        #endregion
    }
}
