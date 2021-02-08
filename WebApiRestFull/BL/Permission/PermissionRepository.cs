using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model;
namespace BL
{
  public  class PermissionRepository
    {

        internal GenericRepository<PermissionSystemLicense> permissionRepo { get; set; }

        public PermissionRepository()
        {
            permissionRepo= new GenericRepository<PermissionSystemLicense>(DBAccess.GetNewContext());
        }

        /// <summary>
        /// دریافت دسترسی سیستم به برنامه
        /// </summary>
        /// <param name="uid">کد سیستم</param>
        /// <returns></returns>
        public PermissionSystemLicense CheckLicense(string uid)
        {
            return permissionRepo.FindByLasted(c => c.PcCode == uid && c.IsActive, s => s.DateLock.Value, 1).FirstOrDefault();
        }

        /// <summary>
        /// ثبت دسترسی برای سیستم در برنامه
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        public int ActivePermission(PermissionSystemLicense permission)
        {
            permission.DateActive = DateTime.Now;
            return permissionRepo.Insert(permission);
        }
        public int LockLicense(PermissionSystemLicense permission)
        {
            permission.IsActive = false;
            return permissionRepo.Update(permission.ID, permission);
        }


    }
}
