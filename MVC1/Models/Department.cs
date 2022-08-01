using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVC1.Models
{
    public class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Students = new HashSet<Student>();
        }

        [Key]
        public long Dep_ID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(250, MinimumLength = 2, ErrorMessage = "Please Enter Valid Name")]
        [Remote("CheckDep", "Department", ErrorMessage = "This Name is Already Exist", AdditionalFields = "Dep_ID")]
        public string Dep_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student> Students { get; set; }
    }
}