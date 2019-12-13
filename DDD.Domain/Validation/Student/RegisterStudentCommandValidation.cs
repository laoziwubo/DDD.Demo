using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Command.Student;

namespace DDD.Domain.Validation.Student
{
    public class RegisterStudentCommandValidation : StudentValidation<RegisterStudentCommand>
    {
        public RegisterStudentCommandValidation()
        {
            ValidateName();//验证姓名
            ValidateBirthDate();//验证年龄
            ValidateEmail();//验证邮箱
            ValidatePhone();//验证手机号
        }
    }
}
