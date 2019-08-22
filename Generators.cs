using Assette.Client;
using AutoFixture;
using AutoFixture.Kernel;
using System.Net.Mail;
using System.Reflection;

namespace Portal.SDK.Test
{
    public class Generators
    {
        public UserToCreateDto GenerateNewUser()
        {
            var fixture = new Fixture();
            
            fixture.Customize<UserToCreateDto>(c => c.With(x => x.Email, fixture.Create<MailAddress>().Address)
                                                    .With(x => x.UserCode,$"IND{fixture.Create<int>().ToString("D6")}")
                                                    .With(x=>x.LanguageCode, "en-US"));

            //fixture.Customize<TranslatableName>(c => c.With(x => x.CultureCode,()=> { return Rand});

            var user = fixture.Create<UserToCreateDto>();
            return user;
        }

        public DocumentDto GenerateNewDocument()
        {
            var fixture = new Fixture();

            return fixture.Create<DocumentDto>();
        }
        public DocumentTypeToCreateDto GenerateNewDocumentType(string docTypeCode,CategoryDto category)
        {
            var fixture = new Fixture();

            var docType= fixture.Create<DocumentTypeToCreateDto>();
            docType.DocTypeCode = docTypeCode;
            docType.CategoryCode = category.Code;
            return docType;
        }
        public CategoryToCreateDto GenerateNewCategory( string categoryName)
        {
            var fixture = new Fixture();

            var category = fixture.Create<CategoryToCreateDto>();
            category.Code = categoryName;

            return category;
        }

        public AssociationDto GenerateNewAssociation(string userCode,string accountCode,string documentTypeCode)
        {
            var fixture = new Fixture();
            var associationDto =fixture.Create<AssociationDto>();
            associationDto.UserCode = userCode;
            associationDto.AccountCode = accountCode;
            associationDto.DocumentTypeCode = documentTypeCode;
            return associationDto;
        }

        public AccountToCreateDto GenerateNewAccount()
        {
            try
            {
                var fixture = new Fixture();

                var nameFr = fixture.Create<TranslatableName>();
                nameFr.CultureCode = "fr-CA";
                var nameEn = fixture.Create<TranslatableName>();
                nameEn.CultureCode = "en-US";
                var names= new TranslatableName[] { nameEn, nameFr };

               fixture.Customize<AccountToCreateDto>(
                   c=>c.With(x => x.TranslatableNames, names)
                    .With(x => x.Code, $"ACT{fixture.Create<int>().ToString("D4")}"));
                var account = fixture.Create<AccountToCreateDto>();

                return account;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }


        public AccountToCreateDto GenerateNewAccount(string english,string french)
        {
            try
            {
                var fixture = new Fixture();

                var nameFr = fixture.Create<TranslatableName>();
                nameFr.CultureCode = french;
                var nameEn = fixture.Create<TranslatableName>();
                nameEn.CultureCode = english;
                var names = new TranslatableName[] { nameEn, nameFr };

                fixture.Customize<AccountToCreateDto>(
                    c => c.With(x => x.TranslatableNames, names)
                     .With(x => x.Code, $"ACT{fixture.Create<int>().ToString("D4")}"));
                var account = fixture.Create<AccountToCreateDto>();

                return account;
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }

        public class CultureCodeBuilder : ISpecimenBuilder
        {
            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo == null || propInfo.Name!="CultureCode" || propInfo.PropertyType!=typeof(string))
                {
                    return new NoSpecimen();
                }
                var sn = context.Resolve(typeof(CultureCode));
                return (string)sn;
            }
        }

        public static class CultureCode
        {

        }
        //public static DocumentDto GenerateNewDocument()
        //{
        //    var fixture = new Fixture();

        //    fixture.Customize<DocumentDto>(c => c.With(x => x.Email, fixture.Create<MailAddress>().Address)
        //                                            .With(x => x.userCode, $"IND{fixture.Create<int>().ToString("D6")}"));

        //    return fixture.Create<DocumentDto>();
        //}
    }
}
