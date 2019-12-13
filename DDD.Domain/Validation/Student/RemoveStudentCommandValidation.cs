using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Command.Student;

namespace DDD.Domain.Validation.Student
{
    public class RemoveStudentCommandValidation : StudentValidation<RemoveStudentCommand>
    {
        public RemoveStudentCommandValidation()
        {
            ValidateId();
        }
    }
}
