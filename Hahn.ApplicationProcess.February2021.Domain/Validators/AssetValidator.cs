using System;
using FluentValidation;
using FluentValidation.Results;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Entities;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<AssetDto>
    {
        public AssetValidator(ICountrySearch countrySearch)
        {

            RuleFor(x => x.AssetName)
                    .MinimumLength(5)
                    .WithMessage("Asset name must be a minimum of 5 characters");
            RuleFor(x => x.Department)
                    // .IsInEnum()
                    .Must(CheckEnum)
                    .WithMessage("Department is not valid");
            RuleFor(x => x.PurchaseDate)
                .GreaterThanOrEqualTo(DateTimeOffset.UtcNow.AddYears(-1))
                .WithMessage("Purchase date must not be older then one year");
            RuleFor(x => x.EMailAdressOfDepartment)
                .NotEmpty()
                .WithMessage("Email Address is required")
                .EmailAddress()
                .WithMessage("Email Address is not valid");
            RuleFor(x => x.CountryOfDepartment)
                .MustAsync(async (country, cancellationToken) =>
               {
                   var result = await countrySearch.SearchByName(country);
                   return result;
               }).WithMessage("country is invalid");



        }

        protected override bool PreValidate(ValidationContext<AssetDto> context, ValidationResult result)
        {
            if (context.InstanceToValidate == null)
            {
                result.Errors.Add(new ValidationFailure("", "Please submit a non-null model."));

                return false;
            }
            return true;
        }

        private bool CheckEnum(string department)
        {
            var departmentType = (DepartmentType)Enum.Parse(typeof(DepartmentType), department);

            return Enum.IsDefined(typeof(DepartmentType), departmentType);

        }
    }
}