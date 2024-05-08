using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.CategoryValidation
{
	public class CreateCategoryValidation : AbstractValidator<Category>
	{
		public CreateCategoryValidation()
		{
			RuleFor(x => x.CategoryName)
				.NotEmpty()
				.WithMessage("Kategori adını boş geçemezsiniz.");

			RuleFor(x => x.CategoryName)
				.MinimumLength(3)
				.WithMessage("Kategori adını en az 3 karakter olarak giriniz.");

			RuleFor(x => x.CategoryName)
				.MaximumLength(30)
				.WithMessage("Kategori adını en fazla 30 karakter olarak giriniz.");
		}
	}
}