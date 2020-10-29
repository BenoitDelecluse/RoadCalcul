using System;
using System.Collections.Generic;
using System.Text;

namespace Exercice3Library.Security
{
    public enum Roletype : int { Admin = 1, Other = 0 };
    public class SecurityContext
    {
        public SecurityContext(Roletype roletype, List<string> accessiblePathFile = null)
        {
            this.RoleType = roletype;
            this.AccessiblePathFile = accessiblePathFile;
            if (accessiblePathFile == null)
            {
                this.AccessiblePathFile = new List<string>();
            }
        }
        private Roletype RoleType { get;set;}

        private List<string> AccessiblePathFile { get; set; }

        public bool CheckRolesForFile(string path)
        {
            if (RoleType == Roletype.Admin )
            {
                return true;
            }
            if (AccessiblePathFile.Contains(path))
            {
                return true;
            }
            return false;
        }

    }
}
