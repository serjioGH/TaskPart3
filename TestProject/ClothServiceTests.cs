namespace TestProject;

using Cloth.Application;
using Cloth.Application.Extensions;
using Cloth.Domain.Entities;
using Microsoft.Extensions.Logging;
using Moq;

public class ClothServiceTests
{
    private List<Cloth> list { get; set; }
    [Fact]
    public void GetHighlight_TwoValues_Success()
    {
        var repoMock = new Mock<IClothRepository>();
        string input = "red,blue";
        var loggerMock = new Mock<ILogger<ClothService>>();

        var myClass = new ClothService(repoMock.Object, loggerMock.Object);

        var result = myClass.GetHighlights(input);

        foreach (var item in result)
        {
            Assert.Contains(item, input);
        }

    }

    [Fact]
    public void GetUniqueSizes_Success()
    {
        var repoMock = new Mock<IClothRepository>();
        List<Cloth> list = new List<Cloth>()
            {
                new Cloth()
                {
                    Sizes = new List<string>() {"medium", "small"}
                },
                 new Cloth()
                {
                    Sizes = new List<string>() {"large", "small"}
                },
                new Cloth()
                {
                    Sizes = new List<string>() {"large"}
                },
            };
        var loggerMock = new Mock<ILogger<ClothService>>();

        var result = FilterProductExtension.GetUniqueSizes(list);

        Assert.Equal(3, result.Count());
        Assert.Contains("small", result);
        Assert.Contains("large", result);
        Assert.Contains("medium", result);
    }

    [Fact]
    public void GetUniqueSizes_Empty()
    {
        List<Cloth> list = new List<Cloth>();

        var result = FilterProductExtension.GetUniqueSizes(list);

        Assert.Empty(result);
    }

    [Fact]
    public void FilterWithHighlights_Success()
    {
        List<Cloth> list = new List<Cloth>()
            {
                new Cloth()
                {
                    Title = "T-Shirt",
                    Description = "Simple and comfortable basic t-shirt in red for everyday casual wear."
                },
                 new Cloth()
                {
                    Title = "Chic Blouse",
                    Description = "Chic blouse in red to add a touch of sophistication to your wardrobe."
                },
                new Cloth()
                {
                    Title = "Fashionable Jumpsuit",
                    Description = "Trendy jumpsuit in blue for a chic and fashion-forward ensemble."
                },
            };

        List<string> highlights = new List<string>();
        highlights.Add("red");
        highlights.Add("blue");
        var loggerMock = new Mock<ILogger<ClothService>>();

        var result = FilterProductExtension.FilterWithHighlights(list, highlights).ToArray();

        Assert.Contains("<em>red</em>", result[0].Description);
        Assert.Contains("<em>red</em>", result[1].Description);
        Assert.Contains("<em>blue</em>", result[2].Description);

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

        var result = FilterProductExtension.FilterWithHighlights(list, highlights).ToArray();

        Assert.Empty(result[0].Description);
        Assert.Empty(result[1].Description);
        Assert.Empty(result[2].Description);

    }

    [Fact]
    public void FilterWithHighlights_HighLightNotFoundInText()
    {
        List<Cloth> list = new List<Cloth>()
            {
                new Cloth()
                {
                    Title = "T-Shirt",
                    Description = "Simple and comfortable basic t-shirt in red for everyday casual wear."
                },
                 new Cloth()
                {
                    Title = "Chic Blouse",
                    Description = "Chic blouse in red to add a touch of sophistication to your wardrobe."
                },
                new Cloth()
                {
                    Title = "Fashionable Jumpsuit",
                    Description = "Trendy jumpsuit in blue for a chic and fashion-forward ensemble."
                },
            };

        List<string> highlights = new List<string>();
        highlights.Add("testWord");

        var loggerMock = new Mock<ILogger<ClothService>>();

        var result = FilterProductExtension.FilterWithHighlights(list, highlights).ToArray();

        Assert.Equal(list[0].Description, result[0].Description);
        Assert.Equal(list[1].Description, result[1].Description);
        Assert.Equal(list[2].Description, result[2].Description);

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

        var result = FilterProductExtension.GetCommonWords(list);
        Assert.Equal(10, result.Count());
        Assert.DoesNotContain("14", result);
    }
}
