using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.CategoryValidation
{
	public class UpdateCategoryValidation : AbstractValidator<Category>
	{
		public UpdateCategoryValidation()
		{
			RuleFor(x => x.CategoryName)
				.NotEmpty()
				.WithMessage("Kategori adını boş geçemezsiniz.")
				.MinimumLength(3)
				.WithMessage("Kategori adını en az 3 karakter olarak giriniz.")
				.MaximumLength(30)
				.WithMessage("Kategori adını en fazla 30 karakter olarak giriniz.")
				.Equal("a")
				.WithMessage("Kategori adına a harfi ekleyiniz.");
		}
	}
}