using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.Entities
{
   public class SignUpModel
    {
        [Required(ErrorMessage = "请输入用户名称"),StringLength(10,ErrorMessage ="长度在5-10个字符",MinimumLength =5)]
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "两次输入的密码不一致")]
        public string Password { get; set; }
        [Required(ErrorMessage = "请再次输入密码")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
