using FluentValidation;
using System;

namespace Scheduler.Comands
{
    public class RequestBookingValidator : AbstractValidator<RequestBooking>
    {
        public RequestBookingValidator()
        {
            RuleFor(request => request.PatientRequest).NotNull().WithMessage("Patient information is required.");
            RuleFor(request => request.PatientRequest).SetValidator(new PatientRequestValidator());
        }
    }

    public class PatientRequestValidator : AbstractValidator<PatientRequest>
    {
        public PatientRequestValidator()
        {
            RuleFor(request => request.PatientId).Must(patientId => patientId > 0)
              .WithMessage("PatientId is required.");

            RuleFor(request => request.DateFrom).NotEqual(default(DateTimeOffset))
              .WithMessage("DateFrom is required.");

            RuleFor(request => request.DateTo).NotEqual(default(DateTimeOffset))
              .WithMessage("DateTo is required.");
        }
    }
}