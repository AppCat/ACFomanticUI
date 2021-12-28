using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ACFomanticUI.Demo
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        [Display(Name = "年龄")]
        public string Name { get; set; }

        /// <summary>
        /// 年龄
        /// </summary>
        [Display(Name = "年龄", Order = 1)]
        public int Age { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别", Order = 2)]
        public Sex? Sex { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        [Display(Name = "性别", Order = 2, AutoGenerateField = false)]
        public Sex SexTwo { get; set; }
    }
}
