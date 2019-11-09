using System.Collections.Generic;

namespace InventarioApi.Entities
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}