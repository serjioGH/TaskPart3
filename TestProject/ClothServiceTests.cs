namespace TestProject;

using Cloth.Application.Extensions;
using Cloth.Application.Interfaces.Repositories;
using Cloth.Application.Services;
using Cloth.Domain.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

public class ClothServiceTests
{
    private static List<Cloth>? _list { get; set; }

    public ClothServiceTests()
    {
        _list = new List<Cloth>()
        {
                new Cloth()
                {
                    Title = "T-Shirt",
                    Description = "Simple and comfortable basic t-shirt in red for everyday casual wear.",
                    //Sizes = new List<string>() {"medium", "small"}
                },
                 new Cloth()
                {
                    Title = "Chic Blouse",
                    Description = "Chic blouse in red to add a touch of sophistication to your wardrobe.",
                    //Sizes = new List<string>() {"large", "small"}
                },
                new Cloth()
                {
                    Title = "Fashionable Jumpsuit",
                    Description = "Trendy jumpsuit in blue for a chic and fashion-forward ensemble.",
                    //Sizes = new List<string>() {"large"}
                },
        };
    }

    [Fact]
    public void GetHighlight_TwoValues_Success()
    {
        string input = "red,blue";

        var result = input.GetHighlights();

        foreach (var item in result)
        {
            item.Should().NotBeNull();
            input.Should().Contain(item);
        }
    }

    [Fact]
    public void GetUniqueSizes_Success()
    {
        var result = ListClothExtension.GetUniqueSizes(_list);

        result.Should().NotBeNull();
        result.Should().HaveCount(3);
        result.Should().Contain("small");
        result.Should().Contain("large");
        result.Should().Contain("medium");
    }

    [Fact]
    public void GetUniqueSizes_Empty()
    {
        List<Cloth> list = new List<Cloth>();

        var result = ListClothExtension.GetUniqueSizes(list);

        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public void FilterWithHighlights_Success()
    {
        List<string> highlights = new List<string>();
        highlights.Add("red");
        highlights.Add("blue");

        var result = ListClothExtension.FilterWithHighlights(_list, highlights).ToArray();

        result.Should().NotBeNull();
        result[0].Description.Should().Contain("<em>red</em>");
        result[1].Description.Should().Contain("<em>red</em>");
        result[2].Description.Should().Contain("<em>blue</em>");
    }

    [Fact]
    public void FilterWithHighlights_EmptyDescription()
    {
        var repoMock = new Mock<IClothRepository>();
        List<Cloth> list = new List<Cloth>()
            {
                new Cloth()
                {
                    Title = "T-Shirt",
                    Description = ""
                },
                 new Cloth()
                {
                    Title = "Chic Blouse",
                    Description = ""
                },
                new Cloth()
                {
                    Title = "Fashionable Jumpsuit",
                    Description = ""
                },
            };

        List<string> highlights = new List<string>();
        highlights.Add("red");
        highlights.Add("blue");

        var result = ListClothExtension.FilterWithHighlights(list, highlights).ToArray();

        result[0].Description.Should().BeEmpty();
        result[1].Description.Should().BeEmpty();
        result[2].Description.Should().BeEmpty();
    }

    [Fact]
    public void FilterWithHighlights_HighLightNotFoundInText()
    {
        List<string> highlights = new List<string>();
        highlights.Add("testWord");

        var loggerMock = new Mock<ILogger<ClothService>>();

        var result = ListClothExtension.FilterWithHighlights(_list, highlights).ToArray();

        result[0].Description.Should().BeEquivalentTo(_list[0].Description);
        result[1].Description.Should().BeEquivalentTo(_list[1].Description);
        result[2].Description.Should().BeEquivalentTo(_list[2].Description);
    }

    [Fact]
    public void GetCommonWords_Success()
    {
        List<Cloth> list = new List<Cloth>();
        for (int i = 0; i < 15; i++)
        {
            int current = i;
            string word = string.Empty;
            do
            {
                word = word + i.ToString() + " ";
                current--;
            } while (current > 0);

            list.Add(new Cloth()
            {
                Title = i.ToString(),
                Description = word
            });
        }

        var loggerMock = new Mock<ILogger<ClothService>>();

        var result = ListClothExtension.GetCommonWords(list);
        result.Should().NotBeNull();
        result.Should().HaveCount(10);
        result.Should().Contain("9");
        result.Should().Contain("0");
        result.Should().NotContain("10");
    }
}