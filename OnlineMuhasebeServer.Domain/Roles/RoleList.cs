using OnlineMuhasebeServer.Domain.AppEntities;
using OnlineMuhasebeServer.Domain.AppEntities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeServer.Domain.Roles
{
    public sealed class RoleList
    {
        public static List<AppRole> GetStaticRoles()
        {

            #region UCAF
            List<AppRole> appRoles = new List<AppRole>
            {
                new AppRole(
                    title: UCAF,
                    code: UCAFCreateCode,
                    name: UCAFCreateName),

                new AppRole(
                    title: UCAF,
                    code: UCAFUpdateCode,
                    name: UCAFUpdateName),

                new AppRole(
                    title: UCAF,
                    code: UCAFRemoveCode,
                    name: UCAFRemoveName
                    ),

                new AppRole(
                    title: UCAF,
                    code: UCAFReadCode,
                    name: UCAFReadName
                    )
            };
            #endregion

            return appRoles;
        }

        public static List<MainRole> GetStaticMainRoles()
        {
            List<MainRole> mainRoles = new List<MainRole>
            {
                new MainRole(
                    id:Guid.NewGuid().ToString(),
                    title:"Admin",
                    isRoleCreatedByAdmin:true),
                new MainRole(
                    id:Guid.NewGuid().ToString(),
                    title:"Yönetici",
                    isRoleCreatedByAdmin:true),
                new MainRole(
                    id:Guid.NewGuid().ToString(),
                    title:"Kullanıcı",
                    isRoleCreatedByAdmin:true)
            };

            return mainRoles;
        }

        #region RoleTitleName
        public static string UCAF = "Hesap Planı";
        #endregion

        #region RoleCodeAndNames
        public static string UCAFCreateCode = "UCAF.Create";
        public static string UCAFCreateName = "Hesap Planı Kayıt";

        public static string UCAFUpdateCode = "UCAF.Update";
        public static string UCAFUpdateName = "Hesap Planı Güncelle";

        public static string UCAFRemoveCode = "UCAF.Remove";
        public static string UCAFRemoveName = "Hesap Planı Sil";

        public static string UCAFReadCode = "UCAF.Read";
        public static string UCAFReadName = "Hesap Planı Görüntüleme";
        #endregion




    }
}
