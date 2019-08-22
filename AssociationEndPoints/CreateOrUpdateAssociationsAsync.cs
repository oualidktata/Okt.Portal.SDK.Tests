//using Assette.Client;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Shouldly;
//using Portal.SDK.Test;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace Associations
//{
//    [TestCategory("CreateOrUpdateAssociationsAsync")]
//    [TestClass]
//    public class CreateOrUpdateAssociationsAsync : BaseTest, IDisposable
//    {
//        public CreateOrUpdateAssociationsAsync():base()
//        {
           
//        }
//        void IDisposable.Dispose()
//        {
//            //Clean up
//        }

//        #region Association Creation

//        [TestMethod]
//        public async Task CreateOrUpdateAssociationsAsync_ThreeValidAssociations_ShouldReturnArrayOfSuccessfullResults()
//        {
//            //Arrange
//            var user1 = _generators.GenerateNewUser();
//            var account1 = _generators.GenerateNewAccount();
//            var account2 = _generators.GenerateNewAccount();
//            var account3 = _generators.GenerateNewAccount();
//            var category1 = _generators.GenerateNewCategory("Category001");
//            await _client.CreateOrUpdateCategoriesAsync(new CategoryToCreateDto[] { category1 });
//            //var catResult = await _client.Sea(new CategoryToCreateDto[] { category1 });


//            ////var docType1 = _generators.GenerateNewDocumentType("doc001", catResult.Data.FirstOrDefault().Data);
//            ////var docType2 = _generators.GenerateNewDocumentType("doc002", category1);
//            //var docTypeResult = _client.CreateOrUpdateDocumentTypesAsync(new DocumentTypeToCreateDto[] { docType1});
//            //var result = await _client.CreateOrUpdateAccountsAsync(new AccountToCreateDto[] {account1, account2, account3 });

//            //var association1 = _generators.GenerateNewAssociation(user1.UserCode,account1.Code,docType1.DocTypeCode);
//            //var association2 = _generators.GenerateNewAssociation(user1.UserCode, account2.Code, docType1.DocTypeCode);
//            //var association3 = _generators.GenerateNewAssociation(user1.UserCode, account1.Code, docType1.DocTypeCode);

//           // var resultAccountCreation = await _client.CreateOrUpdateAccountsAsync(new AccountToCreateDto[] { account1 });
//            //Act
//           // var resultAssociationCreation = await _client.CreateDocumentTypeAssociationsAsync(new AssociationDto[] { association1 , association2 , association3 });
//            //Assert
//            //result.ShouldBeOfType<AssociationSimpleDtoListResult>();
//            //result.Data.Count.ShouldBe(3);
//            //result.Data.Count(x => x.Success).ShouldBe(3);//All success
//        }

//       
//        [TestMethod]
//        public async Task CreateOrUpdateAssociationsAsync_UpdateMultipleAssociations_ShouldReturnArrayOfSuccessfullResults()
//        {
//            //Arrange
//            var account1 = _generators.GenerateNewAssociation();
//            var account2 = _generators.GenerateNewAssociation();
//            var resultCreation = await _client.CreateOrUpdateAssociationsAsync(new List<AssociationToCreateDto> { account1,account2 });
//            var resultGetAfterCreation1 = await _client.GetAssociationAsync(account1.Code);
//            var resultGetAfterCreation2 = await _client.GetAssociationAsync(account2.Code);
//            //Act
//            account1.IsActive = !account1.IsActive;
//            account2.IsActive = !account2.IsActive;
//            var resultUpdate1 = await _client.CreateOrUpdateAssociationsAsync(new List<AssociationToCreateDto> { account1 });
//            var resultUpdate2 = await _client.CreateOrUpdateAssociationsAsync(new List<AssociationToCreateDto> { account2 });
//            var resultGetAfterUpdateAssociation1 = await _client.GetAssociationAsync(account1.Code);
//            var resultGetAfterUpdateAssociation2 = await _client.GetAssociationAsync(account2.Code);
//            //Assert
//            resultUpdate1.ShouldBeOfType<AssociationSimpleDtoListResult>();
//            resultCreation.ShouldBeOfType<AssociationSimpleDtoListResult>();
//            resultGetAfterUpdateAssociation1.Data.IsActive.ShouldBe(!resultGetAfterCreation1.Data.IsActive);
//            resultGetAfterUpdateAssociation1.Data.Code.ShouldBe(resultGetAfterCreation1.Data.Code);
//            resultGetAfterUpdateAssociation2.Data.IsActive.ShouldBe(!resultGetAfterCreation2.Data.IsActive);
//            resultGetAfterUpdateAssociation2.Data.Code.ShouldBe(resultGetAfterCreation2.Data.Code);
//        }


//        #endregion

//    }
//}
