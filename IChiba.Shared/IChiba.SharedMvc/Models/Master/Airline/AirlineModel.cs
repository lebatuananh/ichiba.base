﻿using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Validators;
using IChiba.Services.Localization;
using IChiba.Web.Framework.Models;

namespace IChiba.SharedMvc.Models.Master
{
    public partial class AirlineModel : BaseIChibaEntityModel,
        ILocalizedModel<AirlineLocalizedModel>
    {
        public string Code { get; set; } // nvarchar(50)
        public string Prefix { get; set; } // nvarchar(10)
        public string IATA { get; set; } // nvarchar(10)
        public string ICAO { get; set; } // nvarchar(10)
        public string Name { get; set; } // nvarchar(255)
        public string LocalName { get; set; } // nvarchar(255)
        public string Website { get; set; } // nvarchar(500)
        public string Logo { get; set; } // nvarchar(1000)
        public string Note { get; set; } // nvarchar(500)
        public bool Active { get; set; } // bit
        public int DisplayOrder { get; set; } // int

        public IList<AirlineLocalizedModel> Locales { get; set; }

        public IDictionary<string, string> LocaleLabels { get; set; }

        public AirlineModel()
        {
            Active = true;
            DisplayOrder = 1;
            Locales = new List<AirlineLocalizedModel>();
            LocaleLabels = new Dictionary<string, string>();
        }
    }

    public partial class AirlineLocalizedModel : ILocalizedLocaleModel
    {
        public string LanguageId { get; set; }

        public string _LanguageCode { get; set; }

        public string _FlagCode { get; set; }

        public string Name { get; set; }
    }

    public partial class AirlineValidator : AbstractValidator<AirlineModel>
    {
        public AirlineValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Code).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Airlines.Fields.Code")));
            RuleFor(x => x.Code).SetValidator(new MaximumLengthValidator(50))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Airlines.Fields.Code"), 50));

            RuleFor(x => x.Prefix).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.Prefix")));
            RuleFor(x => x.Prefix).SetValidator(new MaximumLengthValidator(3))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Prefix"), 3));

            RuleFor(x => x.IATA).SetValidator(new MaximumLengthValidator(3))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.IATA"), 3));

            RuleFor(x => x.ICAO).SetValidator(new MaximumLengthValidator(4))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.ICAO"), 4));

            RuleFor(x => x.Name).NotEmpty()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Admin.Airlines.Fields.Name")));
            RuleFor(x => x.Name).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Admin.Airlines.Fields.Name"), 255));

            RuleFor(x => x.LocalName).SetValidator(new MaximumLengthValidator(255))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.LocalName"), 255));

            RuleFor(x => x.Website).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Website"), 500));

            RuleFor(x => x.Logo).SetValidator(new MaximumLengthValidator(1000))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Logo"), 1000));

            RuleFor(x => x.Note).SetValidator(new MaximumLengthValidator(500))
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.Characters.MaxLength"), localizationService.GetResource("Common.Fields.Note"), 500));

            RuleFor(x => x.DisplayOrder).NotNull()
                .WithMessage(string.Format(localizationService.GetResource("Common.Validators.InputFields.Required"), localizationService.GetResource("Common.Fields.DisplayOrder")));
        }
    }
}
