using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Command.Student;

namespace DDD.Domain.Validation.Student
{
    public class UpdateStudentCommandValidation : StudentValidation<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
            ValidatePhone();
        }
    }
}
