using MDG.PMAP.REST.ServerStub.ClientCallableTypes;
using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MDG.PMAP.REST.ServerStub.ServerStub
{
    [ServerStub(typeof(MDG), TargetTypeId = "{B3AEC492-14F0-4A6F-A96A-4047B650A8FC}")]
    public class PmapServerStub : Microsoft.SharePoint.Client.ServerStub
    {
        private static Guid _sTargetTypeId;
        static PmapServerStub()
        {
            _sTargetTypeId = new Guid("{B3AEC492-14F0-4A6F-A96A-4047B650A8FC}");
        }

        #region Helper
        protected static TType GetArgumentValue<TType>(ClientValueCollection xmlargs, int index)
        {
            return GetArgument(xmlargs, index).ConvertTo<TType>();
        }
        #endregion

        #region Overrides
        protected override Type TargetType
        {
            get { return typeof(MDG); }
        }

        protected override Guid TargetTypeId
        {
            get { return _sTargetTypeId; }
        }

        protected override string TargetTypeScriptClientFullName
        {
            get { return "SP.MDG"; }
        }

        protected override object GetProperty(object target, string propName, ProxyContext proxyContext)
        {
            if (propName == null)
            {
                throw new ArgumentNullException("propName");
            }
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            MDG site = target as MDG;
            if (site == null)
            {
                throw new ArgumentNullException("target");
            }

            propName = base.GetMemberName(propName, proxyContext);

            return base.GetProperty(target, propName, proxyContext);
        }

        protected override object InvokeConstructor(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            base.CheckBlockedMethod(".ctor", proxyContext);
            return Mdg_ConProxy(xmlargs, proxyContext);
        }

        protected override object InvokeConstructor(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            base.CheckBlockedMethod(".ctor", proxyContext);
            return Mdg_ConProxy(xmlargs, proxyContext);
        }

        protected override ClientLibraryTargets ClientLibraryTargets
        {
            get { return ClientLibraryTargets.All; }
        }

        protected override object InvokeMethod(object target, string methodName, ClientValueCollection xmlargs,
            ProxyContext proxyContext, out bool isVoid)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }
            MDG me = target as MDG;
            if (me == null)
            {
                throw new ArgumentNullException("target");
            }
            methodName = base.GetMemberName(methodName, proxyContext);

            switch (methodName)
            {
                case "Empty":
                    isVoid = true;
                    return null;
                case "GetCurrentUser":
                    isVoid = true;
                    return GetCurrentUser(target, xmlargs, proxyContext);
                #region Application Setting
                case "GetApplicationSettings":
                    isVoid = true;
                    return me.GetApplicationSettings();
                case "GetApplicationSettingById":
                    isVoid = true;
                    return GetApplicationSettingById(target, xmlargs, proxyContext);
                case "GetApplicationSettingByCode":
                    isVoid = true;
                    return GetApplicationSettingByCode(target, xmlargs, proxyContext);
                case "AddApplicationSetting":
                    isVoid = true;
                    return AddApplicationSetting(target, xmlargs, proxyContext);
                case "UpdateApplicationSetting":
                    isVoid = true;
                    return UpdateApplicationSetting(target, xmlargs, proxyContext);
                case "DeleteApplicationSetting":
                    isVoid = true;
                    return DeleteApplicationSetting(target, xmlargs, proxyContext);
                #endregion
                #region User
                case "AddUser":
                    isVoid = true;
                    return AddUser(target, xmlargs, proxyContext);
                case "UpdateUser":
                    isVoid = true;
                    return UpdateUser(target, xmlargs, proxyContext);
                case "DeleteUser":
                    isVoid = true;
                    return DeleteUser(target, xmlargs, proxyContext);
                case "GetUsers":
                    isVoid = true;
                    return me.GetUsers();
                case "GetUserByLoginId":
                    isVoid = true;
                    return GetUserByLoginId(target, xmlargs, proxyContext);
                #endregion
                #region Department
                case "AddDepartment":
                    isVoid = true;
                    return AddDepartment(target, xmlargs, proxyContext);
                case "UpdateDepartment":
                    isVoid = true;
                    return UpdateDepartment(target, xmlargs, proxyContext);
                case "DeleteDepartment":
                    isVoid = true;
                    return DeleteDepartment(target, xmlargs, proxyContext);
                case "GetDepartments":
                    isVoid = true;
                    return me.GetDepartments();
                case "GetDepartmentById":
                    isVoid = true;
                    return GetDepartmentById(target, xmlargs, proxyContext);
                #endregion
                #region FormerApprovalCode
                case "CreateFormerApprovalCode":
                    isVoid = true;
                    return CreateFormerApprovalCode(target, xmlargs, proxyContext);
                case "DeleteFormerApprovalCode":
                    isVoid = true;
                    return DeleteFormerApprovalCode(target, xmlargs, proxyContext);
                case "GetFormerApprovalCode":
                    isVoid = true;
                    return GetFormerApprovalCode(target, xmlargs, proxyContext);
                case "GetFormerApprovalCodes":
                    isVoid = true;
                    return GetFormerApprovalCodes(target, xmlargs, proxyContext);
                case "UpdateFormerApprovalCode":
                    isVoid = true;
                    return UpdateFormerApprovalCode(target, xmlargs, proxyContext);
                #endregion
                #region GroupType
                case "AddGroupType":
                    isVoid = true;
                    return AddGroupType(target, xmlargs, proxyContext);
                case "UpdateGroupType":
                    isVoid = true;
                    return UpdateGroupType(target, xmlargs, proxyContext);
                case "DeleteGroupType":
                    isVoid = true;
                    return DeleteGroupType(target, xmlargs, proxyContext);
                case "GetGroupTypes":
                    isVoid = true;
                    return me.GetGroupTypes();
                case "GetGroupTypeById":
                    isVoid = true;
                    return GetGroupTypeById(target, xmlargs, proxyContext);
                #endregion
                #region Product
                case "AddProduct":
                    isVoid = true;
                    return AddProduct(target, xmlargs, proxyContext);
                case "UpdateProduct":
                    isVoid = true;
                    return UpdateProduct(target, xmlargs, proxyContext);
                case "DeleteProduct":
                    isVoid = true;
                    return DeleteProduct(target, xmlargs, proxyContext);
                case "GetProducts":
                    isVoid = true;
                    return me.GetActiveProducts();
                case "GetAllProducts":
                    isVoid = true;
                    return me.GetProducts();
                case "GetProductById":
                    isVoid = true;
                    return GetProductById(target, xmlargs, proxyContext);
                #endregion
                #region UserType
                case "AddUserType":
                    isVoid = true;
                    return AddUserType(target, xmlargs, proxyContext);
                case "UpdateUserType":
                    isVoid = true;
                    return UpdateUserType(target, xmlargs, proxyContext);
                case "DeleteUserType":
                    isVoid = true;
                    return DeleteUserType(target, xmlargs, proxyContext);
                case "GetUserTypes":
                    isVoid = true;
                    return me.GetUserTypes();
                case "GetUserTypeById":
                    isVoid = true;
                    return GetUserTypeById(target, xmlargs, proxyContext);
                #endregion
                #region Role
                case "AddRole":
                    isVoid = true;
                    return AddRole(target, xmlargs, proxyContext);
                case "UpdateRole":
                    isVoid = true;
                    return UpdateRole(target, xmlargs, proxyContext);
                case "DeleteRole":
                    isVoid = true;
                    return DeleteRole(target, xmlargs, proxyContext);
                case "GetRoles":
                    isVoid = true;
                    return GetRoles(target, xmlargs, proxyContext);
                case "GetRoleById":
                    isVoid = true;
                    return GetRoleById(target, xmlargs, proxyContext);
                #endregion
                #region DirectedAt
                case "AddDirectedAt":
                    isVoid = true;
                    return AddDirectedAt(target, xmlargs, proxyContext);
                case "UpdateDirectedAt":
                    isVoid = true;
                    return UpdateDirectedAt(target, xmlargs, proxyContext);
                case "DeleteDirectedAt":
                    isVoid = true;
                    return DeleteDirectedAt(target, xmlargs, proxyContext);
                case "GetDirectedAts":
                    isVoid = true;
                    return me.GetDirectedAts();
                case "GetDirectedAtById":
                    isVoid = true;
                    return GetDirectedAtById(target, xmlargs, proxyContext);
                case "GetDirectedAtByCode":
                    isVoid = true;
                    return GetDirectedAtByCode(target, xmlargs, proxyContext);
                #endregion
                #region MaterialType
                case "AddMaterialType":
                    isVoid = true;
                    return AddMaterialType(target, xmlargs, proxyContext);
                case "UpdateMaterialType":
                    isVoid = true;
                    return UpdateMaterialType(target, xmlargs, proxyContext);
                case "DeleteMaterialType":
                    isVoid = true;
                    return DeleteMaterialType(target, xmlargs, proxyContext);
                case "GetMaterialTypes":
                    isVoid = true;
                    return me.GetMaterialTypes();
                case "GetMaterialTypeById":
                    isVoid = true;
                    return GetMaterialTypeById(target, xmlargs, proxyContext);
                case "GetMaterialTypeByCode":
                    isVoid = true;
                    return GetMaterialTypeByCode(target, xmlargs, proxyContext);
                #endregion
                #region ItemClassification
                case "AddItemClassification":
                    isVoid = true;
                    return AddItemClassification(target, xmlargs, proxyContext);
                case "UpdateItemClassification":
                    isVoid = true;
                    return UpdateItemClassification(target, xmlargs, proxyContext);
                case "DeleteItemClassification":
                    isVoid = true;
                    return DeleteItemClassification(target, xmlargs, proxyContext);
                case "GetItemClassifications":
                    isVoid = true;
                    return me.GetItemClassifications();
                case "GetItemClassificationById":
                    isVoid = true;
                    return GetItemClassificationById(target, xmlargs, proxyContext);
                case "GetItemClassificationByCode":
                    isVoid = true;
                    return GetItemClassificationByCode(target, xmlargs, proxyContext);
                #endregion
                #region RAF Application Forms
                case "ReuploadRafMaterials":
                    isVoid = true;
                    return ReuploadRafMaterials(target, xmlargs, proxyContext);
                case "SaveRAF":
                    isVoid = true;
                    return SaveRAF(target, xmlargs, proxyContext);
                case "SaveEventRaf":
                    isVoid = true;
                    return SaveEventRaf(target, xmlargs, proxyContext);
                case "SaveMaterialRaf":
                    isVoid = true;
                    return SaveMaterialRaf(target, xmlargs, proxyContext);
                case "EditRaf":
                    isVoid = true;
                    return EditRaf(target, xmlargs, proxyContext);
                case "LoadRaf":
                    isVoid = true;
                    return LoadRaf(target, xmlargs, proxyContext);
                case "LoadRAFsInProgress":
                    isVoid = true;
                    return LoadRAFsInProgress(target, xmlargs, proxyContext);
                case "LoadRAFsCompleted":
                    isVoid = true;
                    return LoadRAFsCompleted(target, xmlargs, proxyContext);
                case "GetRafForApproval":
                    isVoid = true;
                    return GetRafForApproval(target, xmlargs, proxyContext);
                case "SubmitApprovalDecision":
                    isVoid = true;
                    return SubmitApprovalDecision(target, xmlargs, proxyContext);
                case "DeleteDraftRAF":
                    isVoid = true;
                    return DeleteDraftRAF(target, xmlargs, proxyContext);
                case "CancelRAF":
                    isVoid = true;
                    return CancelRAF(target, xmlargs, proxyContext);
                case "ChangeLevelRAF":
                    isVoid = true;
                    return ChangeLevelRAF(target, xmlargs, proxyContext);
                case "LinkExistingReferences":
                    isVoid = true;
                    return LinkExistingReferences(target, xmlargs, proxyContext);
                case "GetUsersToDelegate":
                    isVoid = true;
                    return GetUsersToDelegate(target, xmlargs, proxyContext);
                case "SubmitDelegateApproval":
                    isVoid = true;
                    return SubmitDelegateApproval(target, xmlargs, proxyContext);
                case "NotifyApprover":
                    isVoid = true;
                    return NotifyApprover(target, xmlargs, proxyContext);
                case "GetFileVersions":
                    isVoid = true;
                    return GetFileVersions(target, xmlargs, proxyContext);
                case "CleanRAFsPdfUrl":
                    isVoid = true;
                    return CleanRAFsPdfUrl(target, xmlargs, proxyContext);
                #endregion
                #region RAF File Details
                case "DeleteRAFFileDetails":
                    isVoid = true;
                    return DeleteRAFFileDetails(target, xmlargs, proxyContext);
                #endregion
                #region ChecklistQuestions
                case "GetChecklistQuestions":
                    isVoid = true;
                    return GetChecklistQuestions(target, xmlargs, proxyContext);
                #endregion
                #region Pdf
                case "SubmitFileAnnotations":
                    isVoid = true;
                    return SubmitFileAnnotations(target, xmlargs, proxyContext);
                case "UpdateFileAnnotations":
                    isVoid = true;
                    return UpdateFileAnnotations(target, xmlargs, proxyContext);
                case "GetFileAnnotations":
                    isVoid = true;
                    return GetFileAnnotations(target, xmlargs, proxyContext);
                case "IsFileCheckedOut":
                    isVoid = true;
                    return IsFileCheckedOut(target, xmlargs, proxyContext);
                case "CheckOutFile":
                    isVoid = true;
                    return CheckOutFile(target, xmlargs, proxyContext);
                case "CheckInFile":
                    isVoid = true;
                    return CheckInFile(target, xmlargs, proxyContext);
                case "DeleteFileAnnotation":
                    isVoid = true;
                    return DeleteFileAnnotation(target, xmlargs, proxyContext);
                #endregion
                #region Business Holidays
                case "LoadBusinessHolidays":
                    isVoid = true;
                    return me.LoadBusinessHolidays();

                case "AddBusinessHoliday":
                    isVoid = true;
                    return AddBusinessHoliday(target, xmlargs, proxyContext);

                case "DeleteBusinessHoliday":
                    isVoid = true;
                    return DeleteBusinessHoliday(target, xmlargs, proxyContext);

                case "UpdateBusinessHoliday":
                    isVoid = true;
                    return UpdateBusinessHoliday(target, xmlargs, proxyContext);
                case "GetBusinessHolidayById":
                    isVoid = true;
                    return GetBusinessHolidayById(target, xmlargs, proxyContext);
                #endregion
                #region Email Template
                case "LoadEmailTemplate":
                    isVoid = true;
                    return me.LoadEmailTemplate();

                case "AddEmailTemplate":
                    isVoid = true;
                    return AddEmailTemplate(target, xmlargs, proxyContext);

                case "UpdateEmailTemplate":
                    isVoid = true;
                    return UpdateEmailTemplate(target, xmlargs, proxyContext);

                case "DeleteEmailTemplate":
                    isVoid = true;
                    return DeleteEmailTemplate(target, xmlargs, proxyContext);
                case "GetEmailTemplateById":
                    isVoid = true;
                    return GetEmailTemplateById(target, xmlargs, proxyContext);
                #endregion
                #region RAFStatus
                case "LoadRAFStatus":
                    isVoid = true;
                    return me.LoadRAFStatus();

                case "AddRAFStatus":
                    isVoid = true;
                    return AddRAFStatus(target, xmlargs, proxyContext);

                case "DeleteRAFStatus":
                    isVoid = true;
                    return DeleteRAFStatus(target, xmlargs, proxyContext);

                case "UpdateRAFStatus":
                    isVoid = true;
                    return UpdateRAFStatus(target, xmlargs, proxyContext);
                case "GetRAFStatusById":
                    isVoid = true;
                    return GetRAFStatusById(target, xmlargs, proxyContext);
                #endregion
                #region SubGroupType
                case "LoadSubGroupType":
                    isVoid = true;
                    return me.LoadSubGroupType();

                case "AddSubGroupType":
                    isVoid = true;
                    return AddSubGroupType(target, xmlargs, proxyContext);

                case "DeleteSubGroupType":
                    isVoid = true;
                    return DeleteSubGroupType(target, xmlargs, proxyContext);

                case "UpdateSubGroupType":
                    isVoid = true;
                    return UpdateSubGroupType(target, xmlargs, proxyContext);
                case "GetSubGroupTypeById":
                    isVoid = true;
                    return GetSubGroupTypeById(target, xmlargs, proxyContext);
                #endregion
                #region Product Sub Group
                case "LoadProductSubGroup":
                    isVoid = true;
                    return me.LoadProductSubGroup();

                case "AddProductSubGroup":
                    isVoid = true;
                    return AddProductSubGroup(target, xmlargs, proxyContext);

                case "DeleteProductSubGroup":
                    isVoid = true;
                    return DeleteProductSubGroup(target, xmlargs, proxyContext);

                case "UpdateProductSubGroup":
                    isVoid = true;
                    return UpdateProductSubGroup(target, xmlargs, proxyContext);
                case "GetProductSubGroupById":
                    isVoid = true;
                    return GetProductSubGroupById(target, xmlargs, proxyContext);
                    #endregion
            }

            return base.InvokeMethod(target, methodName, xmlargs, proxyContext, out isVoid);
        }

        protected override IEnumerable<MethodInformation> GetMethods(ProxyContext proxyContext)
        {
            if (proxyContext == null)
            {
                throw new ArgumentNullException("proxyContext");
            }

            MethodInformation ctorInformation = new MethodInformation
            {
                Name = ".ctor",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.RESTful,
                OriginalName = ".ctor",
                WildcardPath = false,
                ReturnType = null,
                ReturnODataType = ODataType.Invalid,
                RESTfulExtensionMethod = false,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.None
            };
            yield return ctorInformation;

            MethodInformation getCurrentUser = new MethodInformation
            {
                Name = "GetCurrentUser",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetCurrentUser",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getCurrentUser;

            #region Application Setting
            MethodInformation getApplicationSettings = new MethodInformation
            {
                Name = "GetApplicationSettings",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetApplicationSettings",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getApplicationSettings;

            MethodInformation getApplicationSettingById = new MethodInformation
            {
                Name = "GetApplicationSettingById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetApplicationSettingById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getApplicationSettingById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getApplicationSettingById;

            MethodInformation getApplicationSettingByCode = new MethodInformation
            {
                Name = "GetApplicationSettingByCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetApplicationSettingByCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getApplicationSettingByCode.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getApplicationSettingByCode;

            MethodInformation addApplicationSetting = new MethodInformation
            {
                Name = "AddApplicationSetting",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddApplicationSetting",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addApplicationSetting.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addApplicationSetting;

            MethodInformation updateApplicationSetting = new MethodInformation
            {
                Name = "UpdateApplicationSetting",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateApplicationSetting",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateApplicationSetting.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateApplicationSetting;

            MethodInformation deleteApplicationSetting = new MethodInformation
            {
                Name = "DeleteApplicationSetting",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteApplicationSetting",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteApplicationSetting.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteApplicationSetting;
            #endregion

            #region User
            MethodInformation addUser = new MethodInformation
            {
                Name = "AddUser",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddUser",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addUser.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addUser;

            MethodInformation updateUser = new MethodInformation
            {
                Name = "UpdateUser",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateUser",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateUser.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateUser;

            MethodInformation deleteUser = new MethodInformation
            {
                Name = "DeleteUser",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteUser",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteUser.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteUser;

            MethodInformation getUsers = new MethodInformation
            {
                Name = "GetUsers",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetUsers",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getUsers;

            MethodInformation getUserByLoginId = new MethodInformation
            {
                Name = "GetUserByLoginId",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetUserByLoginId",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getUserByLoginId.Parameters.Add(new ParameterInformation
            {
                Name = "loginId",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getUserByLoginId;
            #endregion

            #region Department
            MethodInformation addDepartment = new MethodInformation
            {
                Name = "AddDepartment",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddDepartment",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addDepartment.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addDepartment;

            MethodInformation updateDepartment = new MethodInformation
            {
                Name = "UpdateDepartment",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateDepartment",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateDepartment.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateDepartment;

            MethodInformation deleteDepartment = new MethodInformation
            {
                Name = "DeleteDepartment",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteDepartment",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteDepartment.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteDepartment;

            MethodInformation getDepartments = new MethodInformation
            {
                Name = "GetDepartments",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetDepartments",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getDepartments;

            MethodInformation getDepartmentById = new MethodInformation
            {
                Name = "GetDepartmentById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetDepartmentById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getDepartmentById.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getDepartmentById;
            #endregion

            #region FormerApprovalCode
            MethodInformation createFormerApprovalCode = new MethodInformation
            {
                Name = "CreateFormerApprovalCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "CreateFormerApprovalCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            createFormerApprovalCode.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return createFormerApprovalCode;

            MethodInformation deleteFormerApprovalCode = new MethodInformation
            {
                Name = "DeleteFormerApprovalCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteFormerApprovalCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteFormerApprovalCode.Parameters.Add(new ParameterInformation
            {
                Name = "approvalCode",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteFormerApprovalCode;

            MethodInformation getFormerApprovalCode = new MethodInformation
            {
                Name = "GetFormerApprovalCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetFormerApprovalCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getFormerApprovalCode.Parameters.Add(new ParameterInformation
            {
                Name = "approvalCode",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getFormerApprovalCode;

            MethodInformation getFormerApprovalCodes = new MethodInformation
            {
                Name = "GetFormerApprovalCodes",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetFormerApprovalCodes",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getFormerApprovalCodes;

            MethodInformation updateFormerApprovalCode = new MethodInformation
            {
                Name = "UpdateFormerApprovalCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateFormerApprovalCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateFormerApprovalCode.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateFormerApprovalCode;

            #endregion

            #region GroupType
            MethodInformation addGroupType = new MethodInformation
            {
                Name = "AddGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addGroupType;

            MethodInformation updateGroupType = new MethodInformation
            {
                Name = "UpdateGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateGroupType;

            MethodInformation deleteGroupType = new MethodInformation
            {
                Name = "DeleteGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteGroupType;

            MethodInformation getGroupTypes = new MethodInformation
            {
                Name = "GetGroupTypes",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetGroupTypes",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getGroupTypes;

            MethodInformation getGroupTypeById = new MethodInformation
            {
                Name = "GetGroupTypeById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetGroupTypeById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getGroupTypeById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getGroupTypeById;
            #endregion

            #region Product
            MethodInformation addProduct = new MethodInformation
            {
                Name = "AddProduct",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddProduct",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addProduct.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addProduct;

            MethodInformation updateProduct = new MethodInformation
            {
                Name = "UpdateProduct",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateProduct",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateProduct.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateProduct;

            MethodInformation deleteProduct = new MethodInformation
            {
                Name = "DeleteProduct",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteProduct",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteProduct.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteProduct;

            MethodInformation getProducts = new MethodInformation
            {
                Name = "GetProducts",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetProducts",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getProducts;

            MethodInformation getAllProducts = new MethodInformation
            {
                Name = "GetAllProducts",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetAllProducts",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getAllProducts;

            MethodInformation getProductById = new MethodInformation
            {
                Name = "GetProductById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetProductById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getProductById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getProductById;
            #endregion

            #region Role
            MethodInformation addRole = new MethodInformation
            {
                Name = "AddRole",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddRole",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addRole.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addRole;

            MethodInformation updateRole = new MethodInformation
            {
                Name = "UpdateRole",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateRole",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateRole.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateRole;

            MethodInformation deleteRole = new MethodInformation
            {
                Name = "DeleteRole",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteRole",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteRole.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteRole;

            MethodInformation getRoles = new MethodInformation
            {
                Name = "GetRoles",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetRoles",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getRoles;

            MethodInformation getRoleById = new MethodInformation
            {
                Name = "GetRoleById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetRoleById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getRoleById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getRoleById;
            #endregion

            #region UserType
            MethodInformation addUserType = new MethodInformation
            {
                Name = "AddUserType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddUserType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addUserType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addUserType;

            MethodInformation updateUserType = new MethodInformation
            {
                Name = "UpdateUserType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateUserType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateUserType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateUserType;

            MethodInformation deleteUserType = new MethodInformation
            {
                Name = "DeleteUserType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteUserType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteUserType.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteUserType;

            MethodInformation getUserTypes = new MethodInformation
            {
                Name = "GetUserTypes",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetUserTypes",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getUserTypes;

            MethodInformation getUserTypeById = new MethodInformation
            {
                Name = "GetUserTypeById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetUserTypeById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getUserTypeById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getUserTypeById;
            #endregion

            #region DirectedAt
            MethodInformation addDirectedAt = new MethodInformation
            {
                Name = "AddDirectedAt",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddDirectedAt",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addDirectedAt.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addDirectedAt;

            MethodInformation updateDirectedAt = new MethodInformation
            {
                Name = "UpdateDirectedAt",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateDirectedAt",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateDirectedAt.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateDirectedAt;

            MethodInformation deleteDirectedAt = new MethodInformation
            {
                Name = "DeleteDirectedAt",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteDirectedAt",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteDirectedAt.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteDirectedAt;

            MethodInformation getDirectedAts = new MethodInformation
            {
                Name = "GetDirectedAts",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetDirectedAts",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getDirectedAts;

            MethodInformation getDirectedAtById = new MethodInformation
            {
                Name = "GetDirectedAtById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetDirectedAtById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getDirectedAtById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getDirectedAtById;
            MethodInformation getDirectedAtByCode = new MethodInformation
            {
                Name = "GetDirectedAtByCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetDirectedAtByCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getDirectedAtByCode.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getDirectedAtByCode;
            #endregion

            #region MaterialType
            MethodInformation addMaterialType = new MethodInformation
            {
                Name = "AddMaterialType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddMaterialType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addMaterialType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addMaterialType;

            MethodInformation updateMaterialType = new MethodInformation
            {
                Name = "UpdateMaterialType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateMaterialType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateMaterialType.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateMaterialType;

            MethodInformation deleteMaterialType = new MethodInformation
            {
                Name = "DeleteMaterialType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteMaterialType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteMaterialType.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteMaterialType;

            MethodInformation getMaterialTypes = new MethodInformation
            {
                Name = "GetMaterialTypes",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetMaterialTypes",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getMaterialTypes;

            MethodInformation getMaterialTypeById = new MethodInformation
            {
                Name = "GetMaterialTypeById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetMaterialTypeById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getMaterialTypeById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getMaterialTypeById;
            MethodInformation getMaterialTypeByCode = new MethodInformation
            {
                Name = "GetMaterialTypeByCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetMaterialTypeByCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getMaterialTypeByCode.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getMaterialTypeByCode;
            #endregion

            #region ItemClassification
            MethodInformation addItemClassification = new MethodInformation
            {
                Name = "AddItemClassification",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddItemClassification",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addItemClassification.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addItemClassification;

            MethodInformation updateItemClassification = new MethodInformation
            {
                Name = "UpdateItemClassification",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateItemClassification",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateItemClassification.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateItemClassification;

            MethodInformation deleteItemClassification = new MethodInformation
            {
                Name = "DeleteItemClassification",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteItemClassification",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteItemClassification.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteItemClassification;

            MethodInformation getItemClassifications = new MethodInformation
            {
                Name = "GetItemClassifications",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetItemClassifications",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return getItemClassifications;

            MethodInformation getItemClassificationById = new MethodInformation
            {
                Name = "GetItemClassificationById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetItemClassificationById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getItemClassificationById.Parameters.Add(new ParameterInformation
            {
                Name = "id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getItemClassificationById;
            MethodInformation getItemClassificationByCode = new MethodInformation
            {
                Name = "GetItemClassificationByCode",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetItemClassificationByCode",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getItemClassificationByCode.Parameters.Add(new ParameterInformation
            {
                Name = "code",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getItemClassificationByCode;
            #endregion

            #region RAF Application Form
            MethodInformation reuploadRafMaterials = new MethodInformation
            {
                Name = "ReuploadRafMaterials",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "ReuploadRafMaterials",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            reuploadRafMaterials.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return reuploadRafMaterials;

            MethodInformation saveRaf = new MethodInformation
            {
                Name = "SaveRAF",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SaveRAF",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            saveRaf.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return saveRaf;

            MethodInformation saveEventRaf = new MethodInformation
            {
                Name = "SaveEventRaf",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SaveEventRaf",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            saveEventRaf.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return saveEventRaf;

            MethodInformation saveMaterialRaf = new MethodInformation
            {
                Name = "SaveMaterialRaf",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SaveMaterialRaf",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            saveMaterialRaf.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return saveMaterialRaf;

            MethodInformation editRaf = new MethodInformation
            {
                Name = "EditRaf",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "EditRaf",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            editRaf.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return editRaf;

            MethodInformation loadRaf = new MethodInformation
            {
                Name = "LoadRaf",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadRaf",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            loadRaf.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            loadRaf.Parameters.Add(new ParameterInformation
            {
                Name = "includeChecklists",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(bool),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return loadRaf;

            MethodInformation loadRAFsInProgress = new MethodInformation
            {
                Name = "LoadRAFsInProgress",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadRAFsInProgress",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            loadRAFsInProgress.Parameters.Add(new ParameterInformation
            {
                Name = "userType",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return loadRAFsInProgress;

            MethodInformation loadRAFsCompleted = new MethodInformation
            {
                Name = "LoadRAFsCompleted",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadRAFsCompleted",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            loadRAFsCompleted.Parameters.Add(new ParameterInformation
            {
                Name = "userType",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return loadRAFsCompleted;

            MethodInformation getRafForApproval = new MethodInformation
            {
                Name = "GetRafForApproval",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetRafForApproval",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getRafForApproval.Parameters.Add(new ParameterInformation
            {
                Name = "rafid",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            getRafForApproval.Parameters.Add(new ParameterInformation
            {
                Name = "sn",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getRafForApproval;

            MethodInformation submitApprovalDecision = new MethodInformation
            {
                Name = "SubmitApprovalDecision",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SubmitApprovalDecision",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            submitApprovalDecision.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return submitApprovalDecision;

            MethodInformation deleteDraftRaf = new MethodInformation
            {
                Name = "DeleteDraftRAF",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteDraftRAF",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteDraftRaf.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteDraftRaf;

            MethodInformation cancelRaf = new MethodInformation
            {
                Name = "CancelRAF",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "CancelRAF",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            cancelRaf.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return cancelRaf;

            MethodInformation changeLevelRaf = new MethodInformation
            {
                Name = "ChangeLevelRAF",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "ChangeLevelRAF",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            changeLevelRaf.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return changeLevelRaf;

            MethodInformation linkExistingReferences = new MethodInformation
            {
                Name = "LinkExistingReferences",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LinkExistingReferences",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            linkExistingReferences.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return linkExistingReferences;

            MethodInformation getUsersToDelegate = new MethodInformation
            {
                Name = "GetUsersToDelegate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetUsersToDelegate",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getUsersToDelegate.Parameters.Add(new ParameterInformation
            {
                Name = "departmentCode",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            getUsersToDelegate.Parameters.Add(new ParameterInformation
            {
                Name = "levelCode",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            getUsersToDelegate.Parameters.Add(new ParameterInformation
            {
                Name = "proponent",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getUsersToDelegate;

            MethodInformation submitDelegateApproval = new MethodInformation
            {
                Name = "SubmitDelegateApproval",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SubmitDelegateApproval",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            submitDelegateApproval.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return submitDelegateApproval;

            MethodInformation notifyApprover = new MethodInformation
            {
                Name = "NotifyApprover",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "NotifyApprover",
                WildcardPath = false,
                ReturnType = typeof(bool),
                ReturnODataType = ODataType.Primitive,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            notifyApprover.Parameters.Add(new ParameterInformation
            {
                Name = "rafid",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            notifyApprover.Parameters.Add(new ParameterInformation
            {
                Name = "sn",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            notifyApprover.Parameters.Add(new ParameterInformation
            {
                Name = "approver",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            notifyApprover.Parameters.Add(new ParameterInformation
            {
                Name = "delegated",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return notifyApprover;

            MethodInformation getFileVersions = new MethodInformation
            {
                Name = "GetFileVersions",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetFileVersions",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getFileVersions.Parameters.Add(new ParameterInformation
            {
                Name = "url",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getFileVersions;

            MethodInformation cleanRAFsPdfUrl = new MethodInformation
            {
                Name = "CleanRAFsPdfUrl",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "CleanRAFsPdfUrl",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.None
            };
            yield return cleanRAFsPdfUrl;
            #endregion

            #region RAF File Details
            MethodInformation deleteRAFFileDetails = new MethodInformation
            {
                Name = "DeleteRAFFileDetails",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteRAFFileDetails",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteRAFFileDetails.Parameters.Add(new ParameterInformation
            {
                Name = "rafid",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            deleteRAFFileDetails.Parameters.Add(new ParameterInformation
            {
                Name = "fileurl",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteRAFFileDetails;
            #endregion

            #region Checklist Questions
            MethodInformation getChecklistQuestions = new MethodInformation
            {
                Name = "GetChecklistQuestions",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetChecklistQuestions",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getChecklistQuestions.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getChecklistQuestions;
            #endregion

            #region Pdf
            MethodInformation submitFileAnnotations = new MethodInformation
            {
                Name = "SubmitFileAnnotations",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "SubmitFileAnnotations",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            submitFileAnnotations.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return submitFileAnnotations;

            MethodInformation updateFileAnnotations = new MethodInformation
            {
                Name = "UpdateFileAnnotations",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateFileAnnotations",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateFileAnnotations.Parameters.Add(new ParameterInformation
            {
                Name = "form",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateFileAnnotations;

            MethodInformation getFileAnnotations = new MethodInformation
            {
                Name = "GetFileAnnotations",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetFileAnnotations",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            getFileAnnotations.Parameters.Add(new ParameterInformation
            {
                Name = "fileUrl",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getFileAnnotations;

            MethodInformation isFileCheckedOut = new MethodInformation
            {
                Name = "IsFileCheckedOut",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "IsFileCheckedOut",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            isFileCheckedOut.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            isFileCheckedOut.Parameters.Add(new ParameterInformation
            {
                Name = "fileUrl",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return isFileCheckedOut;

            MethodInformation checkOutFile = new MethodInformation
            {
                Name = "CheckOutFile",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "CheckOutFile",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            checkOutFile.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            checkOutFile.Parameters.Add(new ParameterInformation
            {
                Name = "fileUrl",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return checkOutFile;

            MethodInformation deleteFileAnnotation = new MethodInformation
            {
                Name = "DeleteFileAnnotation",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteFileAnnotation",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            deleteFileAnnotation.Parameters.Add(new ParameterInformation
            {
                Name = "annotationId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteFileAnnotation;

            MethodInformation checkInFile = new MethodInformation
            {
                Name = "CheckInFile",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "CheckInFile",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            checkInFile.Parameters.Add(new ParameterInformation
            {
                Name = "rafId",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(int),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            checkInFile.Parameters.Add(new ParameterInformation
            {
                Name = "fileUrl",
                RESTfulParameterSource = RESTfulParameterSource.Default,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.Primitive,
                IsOptional = false,
                DefaultValue = null
            });
            yield return checkInFile;
            #endregion

            #region Business Holidays
            MethodInformation loadBusinessHolidays = new MethodInformation
            {
                Name = "LoadBusinessHolidays",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadBusinessHolidays",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return loadBusinessHolidays;

            MethodInformation addBusinessHoliday = new MethodInformation
            {
                Name = "AddBusinessHoliday",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddBusinessHoliday",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addBusinessHoliday.Parameters.Add(new ParameterInformation
            {
                Name = "day",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addBusinessHoliday;

            MethodInformation deleteBusinessHoliday = new MethodInformation
            {
                Name = "DeleteBusinessHoliday",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteBusinessHoliday",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            deleteBusinessHoliday.Parameters.Add(new ParameterInformation
            {
                Name = "holidayId",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteBusinessHoliday;


            MethodInformation updateBusinessHoliday = new MethodInformation
            {
                Name = "UpdateBusinessHoliday",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateBusinessHoliday",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateBusinessHoliday.Parameters.Add(new ParameterInformation
            {
                Name = "day",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateBusinessHoliday;

            MethodInformation getBusinessHolidayById = new MethodInformation
            {
                Name = "GetBusinessHolidayById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetBusinessHolidayById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            getBusinessHolidayById.Parameters.Add(new ParameterInformation
            {
                Name = "Id",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getBusinessHolidayById;

            #endregion

            #region Email Template
            MethodInformation loadEmailTemplate = new MethodInformation
            {
                Name = "LoadEmailTemplate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadEmailTemplate",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return loadEmailTemplate;

            MethodInformation addEmailTemplate = new MethodInformation
            {
                Name = "AddEmailTemplate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddEmailTemplate",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addEmailTemplate.Parameters.Add(new ParameterInformation
            {
                Name = "template",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addEmailTemplate;

            MethodInformation deleteEmailTemplate = new MethodInformation
            {
                Name = "DeleteEmailTemplate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteEmailTemplate",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            deleteEmailTemplate.Parameters.Add(new ParameterInformation
            {
                Name = "TemplateCode",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteEmailTemplate;


            MethodInformation updateEmailTemplate = new MethodInformation
            {
                Name = "UpdateEmailTemplate",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateEmailTemplate",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateEmailTemplate.Parameters.Add(new ParameterInformation
            {
                Name = "template",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateEmailTemplate;

            MethodInformation getEmailTemplateById = new MethodInformation
            {
                Name = "GetEmailTemplateById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetEmailTemplateById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            getEmailTemplateById.Parameters.Add(new ParameterInformation
            {
                Name = "TemplateCode",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getEmailTemplateById;

            #endregion

            #region RAF Status
            MethodInformation loadRAFStatus = new MethodInformation
            {
                Name = "LoadRAFStatus",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadRAFStatus",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return loadRAFStatus;

            MethodInformation addRAFStatus = new MethodInformation
            {
                Name = "AddRAFStatus",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddRAFStatus",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addRAFStatus.Parameters.Add(new ParameterInformation
            {
                Name = "status",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addRAFStatus;

            MethodInformation deleteRAFStatus = new MethodInformation
            {
                Name = "DeleteRAFStatus",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteRAFStatus",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            deleteRAFStatus.Parameters.Add(new ParameterInformation
            {
                Name = "rafStatusId",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteRAFStatus;


            MethodInformation updateRAFStatus = new MethodInformation
            {
                Name = "UpdateRAFStatus",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateRAFStatus",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateRAFStatus.Parameters.Add(new ParameterInformation
            {
                Name = "status",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateRAFStatus;

            MethodInformation getRAFStatusById = new MethodInformation
            {
                Name = "GetRAFStatusById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetRAFStatusById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            getRAFStatusById.Parameters.Add(new ParameterInformation
            {
                Name = "rafStatusId",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getRAFStatusById;
            #endregion

            #region Sub Group Type
            MethodInformation loadSubGroupType = new MethodInformation
            {
                Name = "LoadSubGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadSubGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return loadSubGroupType;

            MethodInformation addSubGroupType = new MethodInformation
            {
                Name = "AddSubGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddSubGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addSubGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "subGroupTypes",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addSubGroupType;

            MethodInformation deleteSubGroupType = new MethodInformation
            {
                Name = "DeleteSubGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteSubGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            deleteSubGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "iD",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteSubGroupType;


            MethodInformation updateSubGroupType = new MethodInformation
            {
                Name = "UpdateSubGroupType",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateSubGroupType",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateSubGroupType.Parameters.Add(new ParameterInformation
            {
                Name = "subGroupTypes",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateSubGroupType;

            MethodInformation getSubGroupTypeById = new MethodInformation
            {
                Name = "GetSubGroupTypeById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetSubGroupTypeById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            getSubGroupTypeById.Parameters.Add(new ParameterInformation
            {
                Name = "iD",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getSubGroupTypeById;

            #endregion

            #region Product Sub Group
            MethodInformation loadProductSubGroup = new MethodInformation
            {
                Name = "LoadProductSubGroup",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "LoadProductSubGroup",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            yield return loadProductSubGroup;

            MethodInformation addProductSubGroup = new MethodInformation
            {
                Name = "AddProductSubGroup",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "AddProductSubGroup",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            addProductSubGroup.Parameters.Add(new ParameterInformation
            {
                Name = "productSubGroup",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return addProductSubGroup;

            MethodInformation deleteProductSubGroup = new MethodInformation
            {
                Name = "DeleteProductSubGroup",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "DeleteProductSubGroup",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            deleteProductSubGroup.Parameters.Add(new ParameterInformation
            {
                Name = "iD",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return deleteProductSubGroup;


            MethodInformation updateProductSubGroup = new MethodInformation
            {
                Name = "UpdateProductSubGroup",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "UpdateProductSubGroup",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };
            updateProductSubGroup.Parameters.Add(new ParameterInformation
            {
                Name = "productSubGroup",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return updateProductSubGroup;

            MethodInformation getProductSubGroupById = new MethodInformation
            {
                Name = "GetProductSubGroupById",
                IsStatic = false,
                OperationType = OperationType.Default,
                ClientLibraryTargets = ClientLibraryTargets.All,
                OriginalName = "GetProductSubGroupById",
                WildcardPath = false,
                ReturnType = typeof(ResultMessage),
                ReturnODataType = ODataType.ComplexType,
                RESTfulExtensionMethod = true,
                ResourceUsageHints = ResourceUsageHints.None,
                RequiredRight = ResourceRight.Default
            };

            getProductSubGroupById.Parameters.Add(new ParameterInformation
            {
                Name = "iD",
                RESTfulParameterSource = RESTfulParameterSource.Body,
                ParameterType = typeof(string),
                ParameterODataType = ODataType.ComplexType,
                IsOptional = false,
                DefaultValue = null
            });
            yield return getProductSubGroupById;
            #endregion
        }
        #endregion

        #region Proxies

        private static MDG Mdg_ConProxy(XmlNodeList xmlargs, ProxyContext proxyContext)
        {
            return new MDG();
        }

        private static MDG Mdg_ConProxy(ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            return new MDG();
        }

        private object GetCurrentUser(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetCurrentUser();
            }

            return null;
        }

        #region Application Settings
        private object GetApplicationSettingById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetApplicationSettingsById(id);
            }

            return null;
        }
        private object GetApplicationSettingByCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetApplicationSettingsByCode(code);
            }

            return null;
        }
        private object AddApplicationSetting(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddApplicationSetting(form);
            }

            return null;
        }
        private object UpdateApplicationSetting(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateApplicationSetting(form);
            }

            return null;
        }
        private object DeleteApplicationSetting(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteApplicationSetting(id);
            }

            return null;
        }
        #endregion
        #region User
        private object AddUser(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddUser(form);
            }

            return null;
        }
        private object UpdateUser(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateUser(form);
            }

            return null;
        }
        private object DeleteUser(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteUser(form);
            }

            return null;
        }
        private object GetUserByLoginId(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string loginId = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetUserByLoginId(loginId);
            }

            return null;
        }
        #endregion
        #region Department
        private object AddDepartment(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddDepartment(form);
            }

            return null;
        }
        private object UpdateDepartment(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateDepartment(form);
            }

            return null;
        }
        private object DeleteDepartment(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteDepartment(code);
            }

            return null;
        }
        private object GetDepartmentById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetDepartmentById(code);
            }

            return null;
        }
        #endregion
        #region FormerApprovalCode
        private object CreateFormerApprovalCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = new MDG();
            if (me != null)
            {
                return me.CreateFormerApprovalCode(form);
            }
            return null;
        }
        private object UpdateFormerApprovalCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = new MDG();
            if (me != null)
            {
                return me.UpdateFormerApprovalCode(form);
            }
            return null;
        }
        private object DeleteFormerApprovalCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string approvalCode = GetArgumentValue<string>(xmlargs, 0);
            MDG me = new MDG();
            if (me != null)
            {
                return me.DeleteFormerApprovalCode(approvalCode);
            }
            return null;
        }
        private object GetFormerApprovalCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string approvalCode = GetArgumentValue<string>(xmlargs, 0);
            MDG me = new MDG();
            if (me != null)
            {
                return me.GetFormerApprovalCode(approvalCode);
            }
            return null;
        }
        private object GetFormerApprovalCodes(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = new MDG();
            if (me != null)
            {
                return me.GetFormerApprovalCodes();
            }
            return null;
        }
        #endregion
        #region GroupType
        private object AddGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddGroupType(form);
            }

            return null;
        }
        private object UpdateGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateGroupType(form);
            }

            return null;
        }
        private object DeleteGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteGroupType(id);
            }

            return null;
        }
        private object GetGroupTypeById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetGroupTypeById(id);
            }

            return null;
        }
        #endregion
        #region Product
        private object AddProduct(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddProduct(form);
            }

            return null;
        }
        private object UpdateProduct(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateProduct(form);
            }

            return null;
        }
        private object DeleteProduct(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteProduct(id);
            }

            return null;
        }
        private object GetProductById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetProductById(id);
            }

            return null;
        }
        #endregion
        #region UserType
        private object AddUserType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddUserType(form);
            }

            return null;
        }
        private object UpdateUserType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateUserType(form);
            }

            return null;
        }
        private object DeleteUserType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteUserType(id);
            }

            return null;
        }
        private object GetUserTypeById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetUserTypeById(id);
            }

            return null;
        }
        #endregion
        #region Role
        private object AddRole(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddRole(form);
            }

            return null;
        }
        private object UpdateRole(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateRole(form);
            }

            return null;
        }
        private object DeleteRole(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteRole(id);
            }

            return null;
        }
        private object GetRoleById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetRoleById(id);
            }

            return null;
        }
        private object GetRoles(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetRoles();
            }
            return null;
        }
        #endregion
        #region DirectedAt
        private object AddDirectedAt(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddDirectedAt(form);
            }

            return null;
        }
        private object UpdateDirectedAt(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateDirectedAt(form);
            }

            return null;
        }
        private object DeleteDirectedAt(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteDirectedAt(id);
            }

            return null;
        }
        private object GetDirectedAtById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetDirectedAtById(id);
            }

            return null;
        }
        private object GetDirectedAtByCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetDirectedAtByCode(code);
            }

            return null;
        }
        #endregion
        #region MaterialType
        private object AddMaterialType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddMaterialType(form);
            }

            return null;
        }
        private object UpdateMaterialType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateMaterialType(form);
            }

            return null;
        }
        private object DeleteMaterialType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteMaterialType(id);
            }

            return null;
        }
        private object GetMaterialTypeById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetMaterialTypeById(id);
            }

            return null;
        }
        private object GetMaterialTypeByCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetMaterialTypeByCode(code);
            }

            return null;
        }
        #endregion
        #region ItemClassification
        private object AddItemClassification(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.AddItemClassification(form);
            }

            return null;
        }
        private object UpdateItemClassification(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateItemClassification(form);
            }

            return null;
        }
        private object DeleteItemClassification(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteItemClassification(id);
            }

            return null;
        }
        private object GetItemClassificationById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetItemClassificationById(id);
            }

            return null;
        }
        private object GetItemClassificationByCode(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string code = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetItemClassificationByCode(code);
            }

            return null;
        }
        #endregion
        #region RAF Application Form
        private object SaveRAF(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.SaveRAF(form);
            }

            return null;
        }
        private object ReuploadRafMaterials(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.ReuploadRafMaterials(form);
            }

            return null;
        }
        private object SaveEventRaf(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.SaveEventRaf(form);
            }

            return null;
        }

        private object SaveMaterialRaf(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.SaveMaterialRaf(form);
            }

            return null;
        }

        private object EditRaf(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.EditRaf(rafId);
            }

            return null;
        }

        private object LoadRaf(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            bool includeChecklists = GetArgumentValue<bool>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadRaf(rafId, includeChecklists);
            }

            return null;
        }
        private object LoadRAFsInProgress(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string userType = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadRAFsInProgress(userType);
            }

            return null;
        }
        private object LoadRAFsCompleted(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string userType = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadRAFsCompleted(userType);
            }

            return null;
        }
        private object GetRafForApproval(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string sn = GetArgumentValue<string>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetRafForApproval(rafId, sn);
            }

            return null;
        }
        private object SubmitApprovalDecision(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);

            try
            {
                MDG me = target as MDG;
                if (me != null)
                {
                    return me.SubmitApprovalDecision(form);
                }
            }
            catch (Exception ex)
            {
                Common.LogManager.WriteToULS(ex);
            }

            return null;
        }

        private object DeleteDraftRAF(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteDraftRAF(rafId);
            }

            return null;
        }
        private object CancelRAF(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.CancelRAF(form);
            }

            return null;
        }
        private object ChangeLevelRAF(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.ChangeLevelRAF(form);
            }

            return null;
        }
        private object LinkExistingReferences(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LinkExistingReferences(form);
            }

            return null;
        }
        private object GetUsersToDelegate(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string departmentCode = GetArgumentValue<string>(xmlargs, 0);
            string levelCode = GetArgumentValue<string>(xmlargs, 1);
            string proponent = GetArgumentValue<string>(xmlargs, 2);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetUsersToDelegate(departmentCode, levelCode, proponent);
            }

            return null;
        }
        private object SubmitDelegateApproval(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.SubmitDelegateApproval(form);
            }

            return null;
        }
        private object NotifyApprover(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string sn = GetArgumentValue<string>(xmlargs, 1);
            string approver = GetArgumentValue<string>(xmlargs, 2);
            string delegated = GetArgumentValue<string>(xmlargs, 3);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.NotifyApprover(rafId, sn, approver, delegated);
            }

            return null;
        }

        private object GetFileVersions(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string url = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetFileVersions(url);
            }

            return null;
        }

        private object CleanRAFsPdfUrl(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.CleanRAFsPdfUrl();
            }
            return null;
        }
        #endregion
        #region RAF File Details
        private object DeleteRAFFileDetails(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string fileUrl = GetArgumentValue<string>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteRAFFileDetails(rafId, fileUrl);
            }
            return null;
        }
        #endregion
        #region Checklist Questions
        private object GetChecklistQuestions(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetChecklistQuestions(form);
            }
            return null;
        }
        #endregion
        #region Pdf
        private object SubmitFileAnnotations(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.SubmitFileAnnotations(form);
            }

            return null;
        }
        private object UpdateFileAnnotations(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string form = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.UpdateFileAnnotations(form);
            }

            return null;
        }

        private object GetFileAnnotations(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            string fileUrl = GetArgumentValue<string>(xmlargs, 0);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.GetFileAnnotations(fileUrl);
            }

            return null;
        }
        private object CheckOutFile(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string fileUrl = GetArgumentValue<string>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.CheckOutFile(rafId, fileUrl);
            }

            return null;
        }
        private object CheckInFile(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string fileUrl = GetArgumentValue<string>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.CheckInFile(rafId, fileUrl);
            }

            return null;
        }
        private object IsFileCheckedOut(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int rafId = GetArgumentValue<int>(xmlargs, 0);
            string fileUrl = GetArgumentValue<string>(xmlargs, 1);
            MDG me = target as MDG;
            if (me != null)
            {
                return me.IsFileCheckedOut(rafId, fileUrl);
            }

            return null;
        }
        private object DeleteFileAnnotation(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            int id = GetArgumentValue<int>(xmlargs, 0);

            MDG me = target as MDG;
            if (me != null)
            {
                return me.DeleteFileAnnotation(id);
            }

            return null;
        }
        #endregion
        #region Business Holidays
        private object LoadBusinessHolidays(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadBusinessHolidays();
            }
            return null;
        }

        private object AddBusinessHoliday(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.AddBusinessHoliday(form);
            }
            return null;
        }

        private object DeleteBusinessHoliday(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int holidayId = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.DeleteBusinessHoliday(holidayId);
            }
            return null;
        }

        private object UpdateBusinessHoliday(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.UpdateBusinessHoliday(form);
            }
            return null;
        }

        private object GetBusinessHolidayById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int Id = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.GetBusinessHolidayById(Id);
            }
            return null;
        }

        #endregion
        #region Email Template
        private object LoadEmailTemplate(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadEmailTemplate();
            }
            return null;
        }

        private object AddEmailTemplate(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.AddEmailTemplate(form);
            }
            return null;
        }

        private object DeleteEmailTemplate(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string templateCode = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.DeleteEmailTemplate(templateCode);
            }
            return null;
        }

        private object UpdateEmailTemplate(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.UpdateEmailTemplate(form);
            }
            return null;
        }

        private object GetEmailTemplateById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string templateCode = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.GetEmailTemplateById(templateCode);
            }
            return null;
        }

        #endregion
        #region RAFStatus
        private object LoadRAFStatus(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadRAFStatus();
            }
            return null;
        }

        private object AddRAFStatus(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.AddRAFStatus(form);
            }
            return null;
        }

        private object DeleteRAFStatus(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int rafStatusId = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.DeleteRAFStatus(rafStatusId);
            }
            return null;
        }

        private object UpdateRAFStatus(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.UpdateRAFStatus(form);
            }
            return null;
        }

        private object GetRAFStatusById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int rafStatusId = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.GetRAFStatusById(rafStatusId);
            }
            return null;
        }
        #endregion
        #region Sub-Group Type
        private object LoadSubGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadSubGroupType();
            }
            return null;
        }

        private object AddSubGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.AddSubGroupType(form);
            }
            return null;
        }

        private object DeleteSubGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int iD = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.DeleteSubGroupType(iD);
            }
            return null;
        }

        private object UpdateSubGroupType(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.UpdateSubGroupType(form);
            }
            return null;
        }

        private object GetSubGroupTypeById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int iD = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.GetSubGroupTypeById(iD);
            }
            return null;
        }
        #endregion
        #region Product Sub Group
        private object LoadProductSubGroup(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            if (me != null)
            {
                return me.LoadProductSubGroup();
            }
            return null;
        }

        private object AddProductSubGroup(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.AddProductSubGroup(form);
            }
            return null;
        }

        private object DeleteProductSubGroup(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int iD = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.DeleteProductSubGroup(iD);
            }
            return null;
        }

        private object UpdateProductSubGroup(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            string form = GetArgumentValue<string>(xmlargs, 0);
            if (me != null)
            {
                return me.UpdateProductSubGroup(form);
            }
            return null;
        }

        private object GetProductSubGroupById(object target, ClientValueCollection xmlargs, ProxyContext proxyContext)
        {
            MDG me = target as MDG;
            int iD = GetArgumentValue<int>(xmlargs, 0);
            if (me != null)
            {
                return me.GetProductSubGroupById(iD);
            }
            return null;
        }
        #endregion
        #endregion
    }
}
