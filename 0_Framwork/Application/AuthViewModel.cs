using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Mobile { get; set; }
        public string Permissions { get; set; }
        public List<int> PermissionList { get; set; }
        public AuthViewModel()
        {

        }
        public AuthViewModel(long id, long roleId, string fullName, string username,string mobile,List<int> permissionList)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            Username = username;
            Mobile = mobile;
            PermissionList = permissionList;
        }
    }
}
