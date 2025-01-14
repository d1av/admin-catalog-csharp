﻿using Moq;
using Movie.Catalog.Application.Interfaces;
using Movie.Catalog.Domain.Repository;
using Movie.Catalog.UnitTests.Common;
using Xunit;
namespace Movie.Catalog.UnitTests.Domain.Entity.Category
{
    public class CategoryTestFixture : BaseFixture
    {
        public CategoryTestFixture() : base() { }

        public string GetValidCategoryName()
        {

            var categoryName = "";
            while (categoryName.Length < 3)
                categoryName = Faker.Commerce.Categories(1)[0];

            if (categoryName.Length > 255)
                categoryName = categoryName[..255];

            return categoryName;
        }

        public string GetValidCategoryDescription()
        {
            var categoryDescription =
                Faker.Commerce.ProductDescription();

            if (categoryDescription.Length > 10_000)
                categoryDescription = categoryDescription[..10_000];

            return categoryDescription;
        }



        public Catalog.Domain.Entity.Category GetValidCategory()
            => new(GetValidCategoryName(),
               GetValidCategoryDescription());

        public Mock<ICategoryRepository> GetRepositoryMock()
            => new Mock<ICategoryRepository>();

        public Mock<IUnitOfWork> GetUnitOfWorkMock()
            => new Mock<IUnitOfWork>();

    }

    [CollectionDefinition(nameof(CategoryTestFixture))]
    public class CategoryTestFixtureCollection : ICollectionFixture<CategoryTestFixture>
    { };
}
