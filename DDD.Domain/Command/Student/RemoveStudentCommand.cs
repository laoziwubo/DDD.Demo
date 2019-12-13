using System;
using System.Collections.Generic;
using System.Text;
using DDD.Domain.Validation.Student;

namespace DDD.Domain.Command.Student
{
    public class RemoveStudentCommand : StudentCommand
    {
        public RemoveStudentCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveStudentCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
