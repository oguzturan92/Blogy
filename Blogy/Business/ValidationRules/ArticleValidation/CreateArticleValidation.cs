using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using FluentValidation;

namespace Business.ValidationRules.ArticleValidation
{
	public class CreateArticleValidation : AbstractValidator<Article>
	{
		public CreateArticleValidation()
		{
			RuleFor(x => x.CategoryId)
				.NotEmpty()
				.WithMessage("Lütfen makale için bir kategori seçiniz.");

			RuleFor(x => x.ArticleTitle)
				.NotEmpty()
				.WithMessage("Lütfen makale için bir başlık giriniz.");

			RuleFor(x => x.ArticleDescription)
				.NotEmpty()
				.WithMessage("Lütfen makale için bir açıklama giriniz.");

			RuleFor(x => x.ArticleTitle)
				.MinimumLength(5)
				.WithMessage("Lütfen başlığa en az 5 karakter veri girişi yapınız.");

			RuleFor(x => x.ArticleTitle)
				.MaximumLength(100)
				.WithMessage("Lütfen başlığa en fazla 100 karakter giriniz.");
		}
	}
}