using System.ComponentModel.DataAnnotations;

namespace WebApiDbConnect1502.Models
{
    public class RoleMaster
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }

        public List<LoginMaster> loginMasters { get; set; }
    }
}