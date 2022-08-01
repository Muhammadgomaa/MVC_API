using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace MVC1.Models
{
    public class Student
    {
        [Key]
        public long Stud_ID { get; set; }

        [Required(ErrorMessage ="This Field is Required")]
        [Range(1,200,ErrorMessage ="Please Enter Valid Age")]
        public long Stud_Age { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        [StringLength(250,MinimumLength =3,ErrorMessage ="Please Enter Valid Name")]
        [Remote("CheckStud","Student",ErrorMessage ="This Name is Already Exist",AdditionalFields ="Stud_ID")]
        public string Stud_Name { get; set; }

        public long Dep_ID { get; set; }

        public virtual Department Department { get; set; }
    }
}