﻿namespace Catel.Examples.Validation.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Models;
    using MVVM;

    public class ValidationWithDataAnnotationsViewModel : ViewModelBase
    {
        public ValidationWithDataAnnotationsViewModel(ModelWithoutValidation person = null, bool deferValidationUntilFirstSave = true)
        {
            if (person is null)
            {
                person = new ModelWithoutValidation();
            }

            Person = person;
            DeferValidationUntilFirstSaveCall = deferValidationUntilFirstSave;

            Title = "Validation with data annotations";
        }

        [Model]
        public ModelWithoutValidation Person { get; private set; }

        [Required(ErrorMessage = "First name cannot be empty")]
        [ViewModelToModel("Person")]
        public string FirstName { get; set; }

        [ViewModelToModel("Person")]
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Last name cannot be empty")]
        [ViewModelToModel("Person")]
        public string LastName { get; set; }
    }
}
