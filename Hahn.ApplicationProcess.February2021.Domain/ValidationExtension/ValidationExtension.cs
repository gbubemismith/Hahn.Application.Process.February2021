using System.Collections.Generic;
using FluentValidation.Results;
using Hahn.ApplicationProcess.February2021.Domain.Dtos;
using Hahn.ApplicationProcess.February2021.Domain.Interfaces;
using Hahn.ApplicationProcess.February2021.Domain.Validators;

namespace Hahn.ApplicationProcess.February2021.Domain.Extensions
{
    public static class ValidationExtension
    {
        public static bool IsValid(this AssetDto assetDto, ICountrySearch search, out IEnumerable<string> errors)
        {

            var validator = new AssetValidator(search);

            var validationResult = validator.Validate(assetDto);
            errors = AggregateErrors(validationResult);

            return validationResult.IsValid;
        }

        private static List<string> AggregateErrors(ValidationResult validationResult)
        {
            var errors = new List<string>();

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                    errors.Add(error.ErrorMessage);
            }

            return errors;
        }
    }
}