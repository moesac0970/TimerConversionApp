using FluentValidation;
using Xamarin.Forms;

namespace B4.PE2.ManuVanLook.Domain.Validators
{
    public class FeedbackValidator : AbstractValidator<Entry>
    {
        public FeedbackValidator()
        {
            RuleFor(lbl => lbl.Text).NotEmpty();
            RuleFor(lbl => lbl.Text).Length(3, 50);

        }
    }
}
