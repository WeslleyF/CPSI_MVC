using FluentValidation;

namespace CPSI.Negocio.Modelo.Validacao
{
    class DisciplinaValidacao : AbstractValidator<Disciplina> 
    {
        public DisciplinaValidacao()
        {
            RuleFor(D => D.Nome)
                .NotEmpty().WithMessage("É necessário definir o nome da Disciplina")
                .Length(4, 100).WithMessage("O nome da Disciplina precisa ter entre 4 e 100 caracteres");

        }
    }
}
