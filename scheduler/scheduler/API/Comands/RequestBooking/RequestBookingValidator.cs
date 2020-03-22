using FluentValidation;

namespace Scheduler.API.Comands
{
    public class RequestBookingValidator : AbstractValidator<RequestBooking>
    {
        public RequestBookingValidator()
        {
            RuleFor(request => request.PatientRequest)
                .NotEmpty();

            RuleFor(request => request.SurgeonRequests)
                .NotEmpty();

            RuleForEach(request => request.SurgeonRequests)
                .SetValidator(new SurgeonRequestValidator());

            RuleFor(request => request.PatientRequest)
                .SetValidator(new PatientRequestValidator());
        }
    }

    public class PatientRequestValidator : AbstractValidator<PatientRequest>
    {
        public PatientRequestValidator()
        {
            RuleFor(request => request.PatientId)
                .Must(patientId => patientId > 0);

            RuleFor(request => request.DateFrom)
                .NotEmpty();

            RuleFor(request => request.DateTo)
                .NotEmpty();
        }
    }

    public class SurgeonRequestValidator : AbstractValidator<SurgeonRequest>
    {
        public SurgeonRequestValidator()
        {
            RuleFor(request => request.SurgeonId)
                .Must(surgeonId => surgeonId > 0);

            RuleFor(request => request.DateFrom)
                .NotEmpty();

            RuleFor(request => request.DateTo)
                .NotEmpty();

            RuleFor(request => request.ProcedureIds)
                .NotEmpty();

            RuleForEach(request => request.ProcedureIds)
                .NotEmpty();

            RuleForEach(request => request.AssistantIds)
                .NotEmpty();
        }
    }
}