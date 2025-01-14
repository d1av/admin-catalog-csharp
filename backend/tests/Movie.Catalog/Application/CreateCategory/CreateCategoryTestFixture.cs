﻿using Moq;
using Movie.Catalog.Application.Interfaces;
using Movie.Catalog.Application.UseCases.Category.CreateCategory;
using Movie.Catalog.Domain.Repository;
using Movie.Catalog.UnitTests.Common;
using Xunit;

namespace Movie.Catalog.UnitTests.Application.CreateCategory
{
    public class CreateCategoryTestFixtureCollection : ICollectionFixture<CreateCategoryTestFixture>
    { }


    public class CreateCategoryTestFixture : BaseFixture
    {
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

        public bool GetRandomBoolean()
            => (new Random()).NextDouble() < 0.5;


        public CreateCategoryInput GetValidInput()
            => new(GetValidCategoryName(),
                GetValidCategoryDescription(),
                GetRandomBoolean()
                );

        public Mock<ICategoryRepository> GetRepositoryMock()
          => new();

        public Mock<IUnitOfWork> GetUnitOfWorkMock()
            => new();
    }
}
