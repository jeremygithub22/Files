using Microsoft.SharePoint.Client;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDG.Application.Unity;
using MDG.PMAP.REST.ServerStub.ClientCallableTypes;
using MDG.PMAP.Business.Service;
using Microsoft.SharePoint;
using System.Web;
using MDG.PMAP.Entity;
using MDG.PMAP.Common.SharePoint;
using MDG.PMAP.Common;
using MDG.PMAP.Entity.StoredProceduresEntity;
using static MDG.PMAP.Common.ApplicationConstants;

namespace MDG.PMAP.REST.ServerStub
{
    [ClientCallableType(Name = "MDG", ServerTypeId = "{B3AEC492-14F0-4A6F-A96A-4047B650A8FC}", FactoryType = typeof(ObjectFactory))]
    public class MDG
    {
        private readonly IUnityContainer _container;

        public string ApplicationConstant { get; private set; }

        public MDG()
        {
            IHttpUnityApplication app = (IHttpUnityApplication)System.Web.HttpContext.Current.ApplicationInstance;
            _container = app.UnityContainer;
        }

        private static string Serialize(object _object)
        {
            return JsonConvert.SerializeObject(_object, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        private ConvertType SafeConvertDictionaryValue<ConvertType>(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                Type type = typeof(ConvertType);
                return (ConvertType)Convert.ChangeType(dictionary[key], type);
            }
            return default(ConvertType);
        }

        private DateTime? SafeConvertNullableDate(Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.ContainsKey(key))
            {
                return Convert.ToDateTime(dictionary[key]);
            }
            return null;
        }

        [ClientCallableMethod]
        public ResultMessage GetCurrentUser()
        {
            var service = _container.Resolve<IUserService>("UserService");

            var msg = new ResultMessage
            {
                HasError = false
            };
            var loginId = SPContext.Current.Web.CurrentUser.Name;
            msg.Data = Serialize(service.GetUserByLoginId(loginId));

            return msg;
        }

        #region Application Settings
        [ClientCallableMethod]
        public ResultMessage GetApplicationSettings()
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.GetApplicationSettings());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetApplicationSettingsById(int id)
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.GetApplicationSettingById(id));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetApplicationSettingsByCode(string code)
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.GetApplicationSettingByCode(code));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage AddApplicationSetting(string form)
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var entity = JsonConvert.DeserializeObject<ApplicationSetting>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.AddApplicationSetting(entity));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateApplicationSetting(string form)
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var entity = JsonConvert.DeserializeObject<ApplicationSetting>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.UpdateApplicationSetting(entity));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteApplicationSetting(int id)
        {
            var service = _container.Resolve<IApplicationSettingService>("ApplicationSettingService");
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.TagDeletedApplicationSetting(id));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }
        #endregion

        #region Users
        [ClientCallableMethod]
        public ResultMessage AddUser(string form)
        {
            var service = _container.Resolve<IUserService>("UserService");
            var entity = JsonConvert.DeserializeObject<Entity.StoredProceduresEntity.SpUser>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.AddUser(entity, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateUser(string form)
        {
            var service = _container.Resolve<IUserService>("UserService");
            var entity = JsonConvert.DeserializeObject<Entity.StoredProceduresEntity.SpUser>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.UpdateUser(entity, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteUser(string form)
        {
            var userService = _container.Resolve<IUserService>("UserService");
            var userRoleService = _container.Resolve<IUserRoleService>("UserRoleService");
            var entity = JsonConvert.DeserializeObject<Entity.StoredProceduresEntity.SpUser>(form);
            string loginId = entity.LoginId;
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(userService.TagDeletedUser(loginId, null) && userRoleService.TagDeletedUserRoles(loginId, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetUsers()
        {
            var service = _container.Resolve<IUserService>("UserService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetUsers());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetUserByLoginId(string loginId)
        {
            var service = _container.Resolve<IUserService>("UserService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetUserByLoginId(loginId));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        #endregion

        #region Departments
        [ClientCallableMethod]
        public ResultMessage AddDepartment(string form)
        {
            var service = _container.Resolve<IDepartmentService>();
            var entity = JsonConvert.DeserializeObject<Department>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddDepartment(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateDepartment(string form)
        {
            var service = _container.Resolve<IDepartmentService>();
            var entity = JsonConvert.DeserializeObject<Department>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            msg.Data = Serialize(service.UpdateDepartment(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteDepartment(string code)
        {
            var service = _container.Resolve<IDepartmentService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedDepartment(code));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetDepartments()
        {
            var service = _container.Resolve<IDepartmentService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetDepartments());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetDepartmentById(string code)
        {
            var service = _container.Resolve<IDepartmentService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetDepartmentByCode(code));

            return msg;
        }
        #endregion

        #region FormerApprovalCode
        public ResultMessage CreateFormerApprovalCode(string form)
        {
            var service = _container.Resolve<IFormerApprovalCodeService>("FormerApprovalCodeService");
            var entity = JsonConvert.DeserializeObject<FormerApprovalCode>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.CreateFormerApprovalCode(entity).Result);
            return msg;
        }
        public ResultMessage UpdateFormerApprovalCode(string form)
        {
            var service = _container.Resolve<IFormerApprovalCodeService>("FormerApprovalCodeService");
            var entity = JsonConvert.DeserializeObject<FormerApprovalCode>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.UpdateFormerApprovalCode(entity).Result);
            return msg;
        }
        public ResultMessage DeleteFormerApprovalCode(string approvalCode)
        {
            var service = _container.Resolve<IFormerApprovalCodeService>("FormerApprovalCodeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.DeleteFormerApprovalCode(approvalCode).Result);
            return msg;
        }
        public ResultMessage GetFormerApprovalCode(string approvalCode)
        {
            var service = _container.Resolve<IFormerApprovalCodeService>("FormerApprovalCodeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetFormerApprovalCode(approvalCode));
            return msg;
        }
        public ResultMessage GetFormerApprovalCodes()
        {
            var service = _container.Resolve<IFormerApprovalCodeService>("FormerApprovalCodeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetFormerApprovalCodes());
            return msg;
        }
        #endregion

        #region GroupType
        [ClientCallableMethod]
        public ResultMessage AddGroupType(string form)
        {
            var service = _container.Resolve<IGroupTypeService>();
            var entity = JsonConvert.DeserializeObject<GroupType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddGroupType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateGroupType(string form)
        {
            var service = _container.Resolve<IGroupTypeService>();
            var entity = JsonConvert.DeserializeObject<GroupType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.UpdateGroupType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteGroupType(int id)
        {
            var service = _container.Resolve<IGroupTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedGroupType(id));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetGroupTypes()
        {
            var service = _container.Resolve<IGroupTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetGroupTypes());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetGroupTypeById(int id)
        {
            var service = _container.Resolve<IGroupTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetGroupTypeById(id));

            return msg;
        }
        #endregion

        #region UserTypes
        [ClientCallableMethod]
        public ResultMessage AddUserType(string form)
        {
            var service = _container.Resolve<IUserTypeService>("UserTypeService");
            var entity = JsonConvert.DeserializeObject<UserType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddUserType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateUserType(string form)
        {
            var service = _container.Resolve<IUserTypeService>("UserTypeService");
            var entity = JsonConvert.DeserializeObject<UserType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.UpdateUserType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteUserType(int id)
        {
            var service = _container.Resolve<IUserTypeService>("UserTypeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedUserType(id));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetUserTypes()
        {
            var service = _container.Resolve<IUserTypeService>("UserTypeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetUserTypes());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetUserTypeById(int id)
        {
            var service = _container.Resolve<IUserTypeService>("UserTypeService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetUserTypeById(id));

            return msg;
        }
        #endregion

        #region Products
        [ClientCallableMethod]
        public ResultMessage AddProduct(string form)
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var entity = JsonConvert.DeserializeObject<Product>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.AddProduct(entity));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateProduct(string form)
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var entity = JsonConvert.DeserializeObject<Product>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(service.UpdateProduct(entity));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteProduct(int id)
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.TagDeletedProduct(id));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetActiveProducts()
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetActiveProducts());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetProducts()
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetProducts());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetProductById(int id)
        {
            var service = _container.Resolve<IProductService>("ProductService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetProductById(id));

            return msg;
        }
        #endregion

        #region Role
        [ClientCallableMethod]
        public ResultMessage AddRole(string form)
        {
            var service = _container.Resolve<IUserRoleService>("UserRoleService");
            var entity = JsonConvert.DeserializeObject<SpUserRole>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.AddUserRoleWithRole(entity, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateRole(string form)
        {
            var service = _container.Resolve<IUserRoleService>("UserRoleService");
            var entity = JsonConvert.DeserializeObject<SpUserRole>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.UpdateUserRoleWithRole(entity, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteRole(int id)
        {
            var service = _container.Resolve<IUserRoleService>("UserRoleService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.TagDeletedUserRole(id, null));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetRoles()
        {
            var service = _container.Resolve<IUserRoleService>("UserRoleService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetUserRolesWithUserAndRoles());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetRoleById(int id)
        {
            var service = _container.Resolve<IUserRoleService>("UserRoleService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetUserRoleWithUserAndRole(id));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        #endregion

        #region DirectedAts
        [ClientCallableMethod]
        public ResultMessage AddDirectedAt(string form)
        {
            var service = _container.Resolve<IDirectedAtService>();
            var entity = JsonConvert.DeserializeObject<DirectedAt>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddDirectedAt(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateDirectedAt(string form)
        {
            var service = _container.Resolve<IDirectedAtService>();
            var entity = JsonConvert.DeserializeObject<DirectedAt>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            msg.Data = Serialize(service.UpdateDirectedAt(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteDirectedAt(int id)
        {
            var service = _container.Resolve<IDirectedAtService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedDirectedAt(id));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetDirectedAts()
        {
            var service = _container.Resolve<IDirectedAtService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetDirectedAts());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetDirectedAtById(int id)
        {
            var service = _container.Resolve<IDirectedAtService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetDirectedAtById(id));

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetDirectedAtByCode(string code)
        {
            var service = _container.Resolve<IDirectedAtService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetDirectedAtByCode(code));

            return msg;
        }
        #endregion

        #region MaterialTypes
        [ClientCallableMethod]
        public ResultMessage AddMaterialType(string form)
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var entity = JsonConvert.DeserializeObject<MaterialType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddMaterialType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateMaterialType(string form)
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var entity = JsonConvert.DeserializeObject<MaterialType>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.UpdateMaterialType(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteMaterialType(int id)
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedMaterialType(id));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetMaterialTypes()
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetMaterialTypes());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetMaterialTypeById(int id)
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetMaterialTypeById(id));

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetMaterialTypeByCode(string code)
        {
            var service = _container.Resolve<IMaterialTypeService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetMaterialTypeByCode(code));

            return msg;
        }
        #endregion

        #region ItemClassifications
        [ClientCallableMethod]
        public ResultMessage AddItemClassification(string form)
        {
            var service = _container.Resolve<IItemClassificationService>();
            var entity = JsonConvert.DeserializeObject<ItemClassification>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.AddItemClassification(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateItemClassification(string form)
        {
            var service = _container.Resolve<IItemClassificationService>();
            var entity = JsonConvert.DeserializeObject<ItemClassification>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.UpdateItemClassification(entity));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteItemClassification(int id)
        {
            var service = _container.Resolve<IItemClassificationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.TagDeletedItemClassification(id));

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetItemClassifications()
        {
            var service = _container.Resolve<IItemClassificationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetItemClassifications());

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetItemClassificationById(int id)
        {
            var service = _container.Resolve<IItemClassificationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetItemClassificationById(id));

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage GetItemClassificationByCode(string code)
        {
            var service = _container.Resolve<IItemClassificationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = Serialize(service.GetItemClassificationByCode(code));

            return msg;
        }
        #endregion

        #region RAF Application Forms
        [ClientCallableMethod]
        public ResultMessage SaveRAF(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var formValues = JsonConvert.DeserializeObject<Entity.RAF>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(rafservice.SaveRAF(formValues));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage ReuploadRafMaterials(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var formValues = JsonConvert.DeserializeObject<Entity.RAFReuploadData>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(rafservice.ReuploadRafMaterials(formValues));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage SaveEventRaf(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var rafeventservice = _container.Resolve<IRAFEventService>("RAFEventService");
            var formValues = JsonConvert.DeserializeObject<Entity.RAFEventData>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(rafservice.SaveRafEvent(formValues));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage SaveMaterialRaf(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var rafmaterialservice = _container.Resolve<IRAFMaterialService>("RAFMaterialService");
            var formValues = JsonConvert.DeserializeObject<Entity.RAFMaterialData>(form);
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(rafservice.SaveRafMaterial(formValues));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage EditRaf(int rafId)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var rafeventservice = _container.Resolve<IRAFEventService>("RAFEventService");
            var raffiledetailservice = _container.Resolve<IRAFFileDetailService>("RAFFileDetailService");
            var rafchecklistanswerservice = _container.Resolve<IRAFChecklistAnswerService>("RAFChecklistAnswerService");
            var rafchecklistservice = _container.Resolve<IRAFChecklistService>("RAFChecklistService");
            var usertypeservice = _container.Resolve<IUserTypeService>("UserTypeService");

            var userTypes = usertypeservice.GetUserTypes();
            var proponentType = userTypes.FirstOrDefault(x => x.Name.ToUpper() == RAFUserTypes.Proponent) ?? new UserType();
            var approverType = userTypes.FirstOrDefault(x => x.Name.ToUpper() == RAFUserTypes.Approver) ?? new UserType();
            int _rafId = Convert.ToInt32(rafId);
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {

                var data = rafservice.LoadRafById(_rafId);
                if (data != null && (data.RafInformation.StatusCode == ApplicationConstants.RAFStatus.Draft ||
                    data.RafInformation.StatusCode == ApplicationConstants.RAFStatus.ForRevision ||
                    data.RafInformation.StatusCode == ApplicationConstants.RAFStatus.ApprovedWithChanges))
                {

                    if (data.RafInformation.RAFType == ApplicationConstants.RAFTypes.Event)
                    {
                        var rafEventData = new Entity.RAFEventData(data);

                        rafEventData.RafMaterials = data.FileDetails
                            .GroupBy(x => x.RowNumber)
                            .Select(x => new RAFMaterialFiles()
                            {
                                RowNumber = x.Key,
                                Products = x.DistinctBy(y => y.ProductCode).Select(y => new Product() { Code = y.ProductCode, Name = y.ProductName }).ToList(),
                                RafFiles = x.DistinctBy(y => y.FileName).Select(y => new RAFFile()
                                {
                                    FileName = y.FileName,
                                    FileUrl = y.FileUrl,
                                    FileListItemUri = y.FileListItemUri,
                                    FileVersion = y.Version,
                                    FormerApprovalCode = y.FormerApprovalCode,
                                    FormerApprovalDate = y.FormerApprovalDate
                                }).ToList()
                            }).ToList();

                        rafEventData.RafChecklistAnswers = rafchecklistanswerservice.GetRAFChecklistAnswers(_rafId, SharePointHelper.CurrentUserLoginId, data.RafInformation.FolioId).Select(x => new SpQuestionsChecklist(x)).ToList();
                        var opioidanswers = rafEventData.RafChecklistAnswers.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Remarks));
                        if (opioidanswers != null)
                        {
                            rafEventData.OpioidRemarks = opioidanswers.Remarks;
                        }

                        var checklist = rafchecklistservice.GetLatestChecklistByFolioId(data.RafInformation.FolioId, data.RafInformation.RAFId, SharePointHelper.CurrentUserLoginId, ChecklistStatus.APPROVED);
                        if (checklist != null)
                        {
                            rafEventData.ApprovalRemarks = checklist.Remarks;
                            rafEventData.ApprovalStatus = checklist.Status;
                        }

                        msg.Data = Serialize(rafEventData);
                    }
                    else
                    {
                        var rafMaterialData = new Entity.RAFMaterialData(data);

                        rafMaterialData.RafMaterials = data.FileDetails
                            .GroupBy(x => x.RowNumber)
                            .Select(x => new RAFMaterialFiles()
                            {
                                RowNumber = x.Key,
                                Products = x.DistinctBy(y => y.ProductCode).Select(y => new Product() { Code = y.ProductCode, Name = y.ProductName }).ToList(),
                                RafFiles = x.DistinctBy(y => y.FileName).Select(y => new RAFFile()
                                {
                                    FileName = y.FileName,
                                    FileUrl = y.FileUrl,
                                    FileListItemUri = y.FileListItemUri,
                                    FileVersion = y.Version,
                                    FormerApprovalCode = y.FormerApprovalCode,
                                    FormerApprovalDate = y.FormerApprovalDate
                                }).ToList()
                            }).ToList();

                        rafMaterialData.RafChecklistAnswers = rafchecklistanswerservice.GetRAFChecklistAnswers(_rafId, SharePointHelper.CurrentUserLoginId, data.RafInformation.FolioId).Select(x => new SpQuestionsChecklist(x)).ToList();
                        var opioidanswers = rafMaterialData.RafChecklistAnswers.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Remarks));
                        if (opioidanswers != null)
                        {
                            rafMaterialData.OpioidRemarks = opioidanswers.Remarks;
                        }

                        var checklist = rafchecklistservice.GetLatestChecklistByFolioId(data.RafInformation.FolioId, data.RafInformation.RAFId, SharePointHelper.CurrentUserLoginId, ChecklistStatus.APPROVED);
                        if (checklist != null)
                        {
                            rafMaterialData.ApprovalRemarks = checklist.Remarks;
                            rafMaterialData.ApprovalStatus = checklist.Status;
                        }

                        msg.Data = Serialize(rafMaterialData);
                    }


                }
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage LoadRaf(int rafId, bool includeChecklists)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(rafservice.GetRaf(rafId, SharePointHelper.CurrentUserLoginId, includeChecklists));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage LoadRAFsInProgress(string userType)
        {
            var rafservice = _container.Resolve<IRAFService>();
            List<SpRAFMaterialData> items = null;
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                switch (userType)
                {
                    case ApplicationConstants.RAFUserTypes.Proponent:
                        items = rafservice.GetRafsInProgress(SharePointHelper.CurrentUserLoginId, ApplicationConstants.RAFUserTypes.Proponent);
                        break;
                    case ApplicationConstants.RAFUserTypes.Reviewer:
                        items = rafservice.GetRafsForApproval(SharePointHelper.CurrentUserLoginId, ApplicationConstants.RAFUserTypes.Reviewer);
                        break;
                    case ApplicationConstants.RAFUserTypes.Approver:
                        items = rafservice.GetRafsForApproval(SharePointHelper.CurrentUserLoginId, ApplicationConstants.RAFUserTypes.Approver);
                        break;
                    case ApplicationConstants.RAFUserTypes.Administrator:
                        items = rafservice.GetRafsInProgress(SharePointHelper.CurrentUserLoginId, ApplicationConstants.RAFUserTypes.Administrator);
                        break;
                    case ApplicationConstants.RAFUserTypes.PmapChampion:
                        items = rafservice.GetRafsInProgress(SharePointHelper.CurrentUserLoginId, ApplicationConstants.RAFUserTypes.PmapChampion);
                        break;
                }
                msg.Data = Serialize(items);
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetRafForApproval(int rafId, string sn)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var s = rafservice.GetRafForApproval(rafId, sn, SharePointHelper.CurrentUserLoginId);
                msg.Data = Serialize(s);
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }
            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage SubmitApprovalDecision(string form)
        {
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var rafservice = _container.Resolve<IRAFService>();
                var formValues = JsonConvert.DeserializeObject<Entity.StoredProceduresEntity.SpApprovalDecision>(form);
                var result = rafservice.SubmitApprovalDecision(formValues).Result;
                msg.Data = result.Value;
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage LoadRAFsCompleted(string userType)
        {
            var rafservice = _container.Resolve<IRAFService>(); ;
            var msg = new ResultMessage
            {
                HasError = false
            };

            try
            {
                msg.Data = Serialize(rafservice.GetRAFsCompleted(userType));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage DeleteDraftRAF(int rafId)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                rafservice.DeleteDraftRaf(rafId);
                msg.Data = true.ToString();
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage CancelRAF(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var formValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(form);
                var rafId = Convert.ToInt32(formValues["RafId"]);
                var reason = formValues["Reason"];
                rafservice.CancelRaf(rafId, reason);
                msg.Data = true.ToString();
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage ChangeLevelRAF(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var formValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(form);
                var rafId = Convert.ToInt32(formValues["RafId"]);
                var reason = formValues["Reason"];
                rafservice.ChangeLevelRaf(rafId, reason);
                msg.Data = true.ToString();
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage LinkExistingReferences(string form)
        {
            var referenceService = _container.Resolve<IRAFReferenceService>("RAFReferenceService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var references = JsonConvert.DeserializeObject<List<RAFReference>>(form);
                foreach (var item in references)
                {
                    if (string.IsNullOrEmpty(item.CreatedBy))
                    {
                        item.CreatedBy = SharePointHelper.FormattedLoginName(item.CreatedBy);
                    }

                    if (string.IsNullOrEmpty(item.ModifiedBy))
                    {
                        item.ModifiedBy = SharePointHelper.FormattedLoginName(item.ModifiedBy);
                    }
                }
                referenceService.AddRafReferences(references);
                msg.Data = true.ToString();
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetUsersToDelegate(string departmentCode, string levelCode, string proponent)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                proponent = proponent.Replace("/", "\\");
                msg.Data = Serialize(rafservice.GetUsersToDelegate(SharePointHelper.CurrentUserLoginId, departmentCode, levelCode, proponent));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }
        [ClientCallableMethod]
        public ResultMessage SubmitDelegateApproval(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var formValues = JsonConvert.DeserializeObject<SpUserApprovalDelegation>(form);
                formValues.CurrentUserLoginId = SharePointHelper.CurrentUserLoginId;
                rafservice.InsertUserApprovalDelegation(formValues);
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public bool NotifyApprover(int rafId, string sn, string approver, string delegated)
        {
            var rafservice = _container.Resolve<IRAFService>();
            approver = approver.Replace("/", "\\");
            delegated = delegated.Replace("/", "\\");
            return rafservice.NotifyApprover(rafId, sn, approver, delegated, SharePointHelper.CurrentUserLoginId);
        }

        [ClientCallableMethod]
        public ResultMessage GetFileVersions(string url)
        {
            var service = _container.Resolve<IRAFFileDetailService>("RAFFileDetailService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.GetFileVersions(url));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage CleanRAFsPdfUrl()
        {
            var rafservice = _container.Resolve<IRAFService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(rafservice.CleanRAFsPdfUrl());
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return msg;
        }
        #endregion

        #region RAF File Details
        [ClientCallableMethod]
        public ResultMessage DeleteRAFFileDetails(int rafId, string fileUrl)
        {
            var raffiledetailservice = _container.Resolve<IRAFFileDetailService>("RAFFileDetailService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            msg.Data = JsonConvert.SerializeObject(raffiledetailservice.DeleteRafFileDetails(rafId, fileUrl));
            return msg;
        }
        #endregion

        #region ChecklistQuestions
        [ClientCallableMethod]
        public ResultMessage GetChecklistQuestions(string form)
        {
            var rafservice = _container.Resolve<IRAFService>();
            var formValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(form);
            string departmentCode = formValues["departmentCode"];
            string productCodes = formValues["productCodes"];
            var msg = new ResultMessage
            {
                HasError = false
            };
            var d = rafservice.GetQuestionsChecklists(departmentCode, productCodes);
            msg.Data = Serialize(d);
            return msg;
        }
        #endregion

        #region Pdf
        [ClientCallableMethod]
        public ResultMessage SubmitFileAnnotations(string form)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var pdfService = _container.Resolve<IPdfService>("PdfService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var fileAnnotation = JsonConvert.DeserializeObject<SpAnnotation>(form);
                float width = 0;
                float height = 0;
                pdfService.GetPageWidthAndHeight(fileAnnotation.DocumentId, 1, out width, out height);
                fileAnnotation.PageHeight = (double)height;
                fileAnnotation.PageWidth = (double)width;
                fileAnnotation.CreatedDate = DateTime.Now;
                fileAnnotation.CreatedBy = SharePointHelper.CurrentUserLoginId;
                //fileAnnotation.LoginId = SharePointHelper.CurrentUserLoginId;
                //fileAnnotation.AnnotationDate = DateTime.Now;
                // msg.Data = Serialize(service.Add(fileAnnotation));
                //service.InsertAnnotation(fileAnnotation);
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        public ResultMessage UpdateFileAnnotations(string form)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var pdfService = _container.Resolve<IPdfService>("PdfService");
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var fileAnnotation = JsonConvert.DeserializeObject<List<SpAnnotation>>(form);
                int fileVersion = pdfService.GetLatestVersion(fileAnnotation.First().DocumentId);
                msg.Data = Serialize(service.UpdateAnnotations(fileAnnotation, fileVersion));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage GetFileAnnotations(string fileUrl)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var items = service.GetAnnotations(fileUrl, 0);
                msg.Data = Serialize(items);
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage IsFileCheckedOut(int rafId, string fileUrl)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var msg = new ResultMessage
            {
                Data = null,
                HasError = false
            };
            try
            {
                var file = service.GetFile(rafId, fileUrl);
                if (file != null && file.IsCheckedOut && file.CheckedOutBy != SharePointHelper.CurrentUserLoginId)
                {
                    msg.Data = Serialize(file);
                }
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage CheckOutFile(int rafId, string fileUrl)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.CheckOutFile(rafId, fileUrl, SharePointHelper.CurrentUserLoginId));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage CheckInFile(int rafId, string fileUrl)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                msg.Data = Serialize(service.CheckInFile(rafId, fileUrl, SharePointHelper.CurrentUserLoginId));
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteFileAnnotation(int annotationId)
        {
            var service = _container.Resolve<IFileAnnotationService>();
            var msg = new ResultMessage
            {
                HasError = false
            };
            try
            {
                service.Delete(annotationId);
                msg.Data = "";
            }
            catch (Exception ex)
            {
                msg.HasError = true;
                msg.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }

            return msg;
        }
        #endregion

        #region Business Holidays
        [ClientCallableMethod]
        public ResultMessage LoadBusinessHolidays()
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var businessHolidays = _container.Resolve<IBusinessHolidaysService>();
                List<BusinessHoliday> holidays = null;
                holidays = businessHolidays.GetBusinessHolidays();
                resultMessage.Data = Serialize(holidays);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallable]
        public ResultMessage GetBusinessHolidayById(int Id)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var businessHolidays = _container.Resolve<IBusinessHolidaysService>();
                BusinessHoliday holiday = null;
                holiday = businessHolidays.GetBusinessHolidayById(Id);
                resultMessage.Data = Serialize(holiday);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;

        }

        [ClientCallableMethod]
        public ResultMessage AddBusinessHoliday(string day)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var businessHolidays = _container.Resolve<IBusinessHolidaysService>();
                var entity = JsonConvert.DeserializeObject<BusinessHoliday>(day);


                resultMessage.Data = Serialize(businessHolidays.InsertBusinessHoliday(entity).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteBusinessHoliday(int holidayId)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var businessHolidays = _container.Resolve<IBusinessHolidaysService>();
                resultMessage.Data = Serialize(businessHolidays.DeleteBusinessHoliday(holidayId).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateBusinessHoliday(string day)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var businessHolidays = _container.Resolve<IBusinessHolidaysService>();
                var entity = JsonConvert.DeserializeObject<BusinessHoliday>(day);

                resultMessage.Data = Serialize(businessHolidays.UpdateBusinessHoliday(entity).Result);


            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }



        #endregion
        
        #region EmailTemplate

        [ClientCallableMethod]
        public ResultMessage AddEmailTemplate(string template)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var emailTemplateRepository = _container.Resolve<IEmailTemplateService>();
                var entity = JsonConvert.DeserializeObject<EmailTemplate>(template);


                resultMessage.Data = Serialize(emailTemplateRepository.InsertEmailTemplate(entity).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateEmailTemplate(string template)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var emailTemplateRepository = _container.Resolve<IEmailTemplateService>();
                var entity = JsonConvert.DeserializeObject<EmailTemplate>(template);

                resultMessage.Data = Serialize(emailTemplateRepository.UpdateEmailTemplate(entity).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteEmailTemplate(string TemplateCode)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {

                var emailTemplateRepository = _container.Resolve<IEmailTemplateService>();
                resultMessage.Data = Serialize(emailTemplateRepository.DeleteEmailTemplate(TemplateCode).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage LoadEmailTemplate()
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var emailTemplateRepository = _container.Resolve<IEmailTemplateService>();
                List<EmailTemplate> emailTemplates = null;
                emailTemplates = emailTemplateRepository.GetAllEmailTemplate();
                resultMessage.Data = Serialize(emailTemplates);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallable]
        public ResultMessage GetEmailTemplateById(string TemplateCode)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            
            try
            {
                var emailTemplateRepository = _container.Resolve<IEmailTemplateService>();
                EmailTemplate emailTemplateEntity = null;
                emailTemplateEntity = emailTemplateRepository.GetEmailTemplate(TemplateCode);
                resultMessage.Data = Serialize(emailTemplateEntity);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;

        }

        #endregion

        #region RAFStatus
        [ClientCallableMethod]
        public ResultMessage AddRAFStatus(string status)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var rafStatusRepository = _container.Resolve<IRAFStatusService>();
                var entity = JsonConvert.DeserializeObject<RAFStatusTable>(status);


                resultMessage.Data = Serialize(rafStatusRepository.InsertRAFStatus(entity).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateRAFStatus(string status)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var rafStatusRepository = _container.Resolve<IRAFStatusService>();
                var entity = JsonConvert.DeserializeObject<RAFStatusTable>(status);

                resultMessage.Data = Serialize(rafStatusRepository.UpdateRAFStatus(entity).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteRAFStatus(int rafStatusId)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {

                var rafStatusRepository = _container.Resolve<IRAFStatusService>();
                resultMessage.Data = Serialize(rafStatusRepository.DeleteRAFStatus(rafStatusId).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage LoadRAFStatus()
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var rafStatusRepository = _container.Resolve<IRAFStatusService>();
                List<RAFStatusTable> rafStatusList = null;
                rafStatusList = rafStatusRepository.GetAllRAFStatus();
                resultMessage.Data = Serialize(rafStatusList);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallable]
        public ResultMessage GetRAFStatusById(int rafStatusId)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var rafStatusRepository = _container.Resolve<IRAFStatusService>();
                RAFStatusTable rafStatusEntity = null;
                rafStatusEntity = rafStatusRepository.GetRAFStatus(rafStatusId);
                resultMessage.Data = Serialize(rafStatusEntity);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;

        }
        #endregion

        #region Sub-Group Type
        [ClientCallableMethod]
        public ResultMessage AddSubGroupType(string subGroupTypes)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var subGroupTypesRepository = _container.Resolve<ISubGroupTypesService>();
                var entity = JsonConvert.DeserializeObject<SubGroupTypes>(subGroupTypes);


                resultMessage.Data = Serialize(subGroupTypesRepository.InsertSubGroupTypes(entity).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateSubGroupType(string subGroupTypes)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var subGroupTypesRepository = _container.Resolve<ISubGroupTypesService>();
                var entity = JsonConvert.DeserializeObject<SubGroupTypes>(subGroupTypes);


                resultMessage.Data = Serialize(subGroupTypesRepository.UpdateSubGroupTypes(entity).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteSubGroupType(int iD)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {

                var subGroupTypesRepository = _container.Resolve<ISubGroupTypesService>();
                resultMessage.Data = Serialize(subGroupTypesRepository.DeleteSubGroupTypes(iD).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage LoadSubGroupType()
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var subGroupTypesRepository = _container.Resolve<ISubGroupTypesService>();
                List<SubGroupTypes> subGroupTypeList = null;
                subGroupTypeList = subGroupTypesRepository.GetAllSubGroupTypes();
                resultMessage.Data = Serialize(subGroupTypeList);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallable]
        public ResultMessage GetSubGroupTypeById(int iD)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var subGroupTypesRepository = _container.Resolve<ISubGroupTypesService>();
                SubGroupTypes subGroupTypeEntity = null;
                subGroupTypeEntity = subGroupTypesRepository.GetSubGroupTypes(iD);
                resultMessage.Data = Serialize(subGroupTypeEntity);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;

        }
        #endregion

        #region Product Sub Group
        [ClientCallableMethod]
        public ResultMessage AddProductSubGroup(string productSubGroup)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var productSubGroupRepository = _container.Resolve<IProductSubGroupService>();
                var entity = JsonConvert.DeserializeObject<ProductSubGroup>(productSubGroup);


                resultMessage.Data = Serialize(productSubGroupRepository.InsertProductSubGroup(entity).Result);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage UpdateProductSubGroup(string productSubGroup)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var productSubGroupRepository = _container.Resolve<IProductSubGroupService>();
                var entity = JsonConvert.DeserializeObject<ProductSubGroup>(productSubGroup);


                resultMessage.Data = Serialize(productSubGroupRepository.UpdateProductSubGroup(entity).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallableMethod]
        public ResultMessage DeleteProductSubGroup(int iD)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {

                var productSubGroupRepository = _container.Resolve<IProductSubGroupService>();
                resultMessage.Data = Serialize(productSubGroupRepository.DeleteProductSubGroup(iD).Result);

            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.Message;
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }
        
        [ClientCallableMethod]
        public ResultMessage LoadProductSubGroup()
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };
            try
            {
                var productSubGroupRepository = _container.Resolve<IProductSubGroupService>();
                List<ProductSubGroup> productSubGroupList = null;
                productSubGroupList = productSubGroupRepository.GetAllProductSubGroup();
                resultMessage.Data = Serialize(productSubGroupList);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;
        }

        [ClientCallable]
        public ResultMessage GetProductSubGroupById(int iD)
        {
            var resultMessage = new ResultMessage
            {
                HasError = false
            };

            try
            {
                var productSubGroupRepository = _container.Resolve<IProductSubGroupService>();
                ProductSubGroup productSubGroupEntity = null;
                productSubGroupEntity = productSubGroupRepository.GetProductSubGroupById(iD);
                resultMessage.Data = Serialize(productSubGroupEntity);
            }
            catch (Exception ex)
            {
                resultMessage.HasError = true;
                resultMessage.ErrorMessage = ex.ToString();
                LogManager.WriteToULS(ex);
            }
            return resultMessage;

        }
        #endregion
    }
}
