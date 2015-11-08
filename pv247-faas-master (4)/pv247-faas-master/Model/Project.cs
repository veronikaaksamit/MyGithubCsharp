using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<FormType> FormTypes { get; set; }

        public ICollection<Form> Forms { get; set; }

        public Project()
        {
            Users = new List<User>();
            FormTypes = new List<FormType>();
            Forms = new List<Form>();
        }
    }
}
