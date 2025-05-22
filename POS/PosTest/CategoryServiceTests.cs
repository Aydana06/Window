using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.Data.Sqlite;


namespace PosTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using PosLibrary.Model;
    using PosLibrary.Repo;
    using PosLibrary.Services;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    namespace PosTests
    {
        [TestClass]
        public class CategoryServiceTests
        {
            private Mock<ICategoryRepository> _mockRepo;
            private CategoryService _service;

            [TestInitialize]
            public void Setup()
            {
                _mockRepo = new Mock<ICategoryRepository>();
                _service = new CategoryService(_mockRepo.Object);
            }

            [TestMethod]
            public void AddCategory_ValidName_CallsRepoAdd()
            {
                string categoryName = "Food";

                _service.AddCategory(categoryName);

                _mockRepo.Verify(repo => repo.Add(It.Is<Category>(c => c.Name == "Food")), Times.Once);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void AddCategory_EmptyName_ThrowsException()
            {
                _service.AddCategory("");
            }

            [TestMethod]
            public void GetCategories_ReturnsFromRepo()
            {
                var expected = new List<Category> { new Category { Id = 1, Name = "Food" } };
                _mockRepo.Setup(repo => repo.GetAll()).Returns(expected);

                var result = _service.GetCategories();

                Assert.AreEqual(1, ((List<Category>)result).Count);
                Assert.AreEqual("Food", ((List<Category>)result)[0].Name);
            }

            [TestMethod]
            public void UpdateCategory_ValidInput_CallsRepoUpdate()
            {
                int id = 1;
                string newName = "Drinks";

                _service.UpdateCategory(id, newName);

                _mockRepo.Verify(repo => repo.Update(It.Is<Category>(c => c.Id == id && c.Name == "Drinks")), Times.Once);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void UpdateCategory_EmptyName_ThrowsException()
            {
                _service.UpdateCategory(1, "");
            }

            [TestMethod]
            public void DeleteCategory_ValidId_CallsRepoDelete()
            {
                _service.DeleteCategory(1);

                _mockRepo.Verify(repo => repo.Delete(1), Times.Once);
            }

            [TestMethod]
            public void GetCategoryById_ReturnsCorrectCategory()
            {
                var category = new Category { Id = 5, Name = "Candy" };
                _mockRepo.Setup(repo => repo.GetById(5)).Returns(category);

                var result = _service.GetCategoryById(5);

                Assert.AreEqual("Candy", result.Name);
            }
        }

       
    }
}
