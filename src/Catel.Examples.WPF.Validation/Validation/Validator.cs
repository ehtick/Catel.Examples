﻿namespace Catel.Examples.Validation.Validation
{
    using System.Collections.Generic;
    using Data;
    using ViewModels;

    public class Validator : ValidatorBase<ValidationInIValidatorViewModel>
    {
        protected override void ValidateFields(ValidationInIValidatorViewModel instance, List<IFieldValidationResult> validationResults)
        {
            if (string.IsNullOrEmpty(instance.FirstName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(ValidationInIValidatorViewModel.FirstName), "First name cannot be empty"));
            }

            if (string.IsNullOrEmpty(instance.LastName))
            {
                validationResults.Add(FieldValidationResult.CreateError(nameof(ValidationInIValidatorViewModel.LastName), "Last name cannot be empty"));
            }
        }

        protected override void ValidateBusinessRules(ValidationInIValidatorViewModel instance, List<IBusinessRuleValidationResult> validationResults)
        {
            // No business rules (yet)
        }
    }
}
