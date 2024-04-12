using CarBuilder.Models;
using CarBuilder.Models.DTOs;

List<PaintColor> paintColors = new List<PaintColor>()
{
    new PaintColor()
    {
        Id = 1,
        Price = 1249.99M,
        Color = "Silver"
    },
    new PaintColor()
    {
        Id = 2,
        Price = 1479.99M,
        Color = "Midnight Blue"
    },
    new PaintColor()
    {
        Id = 3,
        Price = 1999.95M,
        Color = "Firebrick Red"
    },
    new PaintColor()
    {
        Id = 4,
        Price = 2359.99M,
        Color = "Spring Green"
    }
};
List<Interior> interiors = new List<Interior>()
{
    new Interior()
    {
        Id = 1,
        Price = 499.99M,
        Material = "Beige Fabric"
    },
    new Interior()
    {
        Id = 2,
        Price = 745.95M,
        Material = "Charcoal Fabric"
    },
    new Interior()
    {
        Id = 3,
        Price = 1199.99M,
        Material = "White Leather"
    },
    new Interior()
    {
        Id = 4,
        Price = 1500.00M,
        Material = "Black Leather"
    }
};
List<Technology> technologies = new List<Technology>()
{
    new Technology()
    {
        Id = 1,
        Price = 185.00M,
        Package = "Basic Package (basic sound system)"
    },
    new Technology()
    {
        Id = 2,
        Price = 279.99M,
        Package = "Navigation Package (includes integrated navigation controls)"
    },
    new Technology()
    {
        Id = 3,
        Price = 549.99M,
        Package = "Visibility Package (includes side and rear cameras)"
    },
    new Technology()
    {
        Id = 4,
        Price = 625.95M,
        Package = "Ultra Package (includes navigation and visibility packages)"
    }
};
List<Wheels> wheels = new List<Wheels>()
{
    new Wheels()
    {
        Id = 1,
        Price = 299.95M,
        Style = "17-inch Pair Radial"
    },
    new Wheels()
    {
        Id = 2,
        Price = 425.00M,
        Style = "17-inch Pair Radial Black"
    },
    new Wheels()
    {
        Id = 3,
        Price = 745.95M,
        Style = "18-inch Pair Spoke Silver"
    },
    new Wheels()
    {
        Id = 4,
        Price = 899.99M,
        Style = "18-inch Pair Spoke Black"
    }
};
List<Style> styles = new List<Style>()
{
    new Style()
    {
        Id = 1,
        Type = "Car",
        PriceMultiplier = 1.0M
    },
    new Style()
    {
        Id = 2,
        Type = "SUV",
        PriceMultiplier = 1.5M
    },
    new Style()
    {
        Id = 3,
        Type = "Truck",
        PriceMultiplier = 2.25M
    }
};
List<Order> orders = new List<Order>()
{
    new Order()
    {
        Id = 1,
        Timestamp = new DateTime(2022, 7, 15),
        PaintId = 1,
        InteriorId = 1,
        TechnologyId = 1,
        WheelsId = 1,
        StyleId = 1
    },
    new Order()
    {
        Id = 2,
        Timestamp = new DateTime(2022, 9, 27),
        PaintId = 2,
        InteriorId = 2,
        TechnologyId = 2,
        WheelsId = 2,
        StyleId = 2
    },
    new Order()
    {
        Id = 3,
        Timestamp = new DateTime(2023, 4, 9),
        PaintId = 3,
        InteriorId = 3,
        TechnologyId = 3,
        WheelsId = 3,
        StyleId = 3
    },
    new Order()
    {
        Id = 4,
        Timestamp = new DateTime(2023, 7, 19),
        PaintId = 4,
        InteriorId = 4,
        TechnologyId = 4,
        WheelsId = 4,
        StyleId = 1
    },
    new Order()
    {
        Id = 5,
        Timestamp = new DateTime(2023, 10, 23),
        PaintId = 2,
        InteriorId = 4,
        TechnologyId = 4,
        WheelsId = 1,
        StyleId = 1
    },
    new Order()
    {
        Id = 6,
        Timestamp = new DateTime(2023, 11, 12),
        PaintId = 4,
        InteriorId = 3,
        TechnologyId = 4,
        WheelsId = 2,
        StyleId = 2
    },
    new Order()
    {
        Id = 7,
        Timestamp = new DateTime(2024, 1, 3),
        PaintId = 3,
        InteriorId = 4,
        TechnologyId = 4,
        WheelsId = 1,
        StyleId = 2
    }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options => 
    {
        options.AllowAnyOrigin();
        options.AllowAnyMethod();
        options.AllowAnyHeader();
    });
}

app.UseHttpsRedirection();

app.MapGet("/paintcolors", () =>
{
    return paintColors.Select(paintColor => new PaintColorDTO
    {
        Id = paintColor.Id,
        Price = paintColor.Price,
        Color = paintColor.Color
    });
});

app.MapGet("/interiors", () =>
{
    return interiors.Select(interior => new InteriorDTO
    {
        Id = interior.Id,
        Price = interior.Price,
        Material = interior.Material
    });
});

app.MapGet("/technologies", () =>
{
    return technologies.Select(technology => new TechnologyDTO
    {
        Id = technology.Id,
        Price = technology.Price,
        Package = technology.Package
    });
});

app.MapGet("/wheels", () =>
{
    return wheels.Select(wheel => new WheelsDTO
    {
        Id = wheel.Id,
        Price = wheel.Price,
        Style = wheel.Style
    });
});

app.MapGet("/styles", () =>
{
    return styles.Select(style => new StyleDTO
    {
        Id = style.Id,
        Type = style.Type,
        PriceMultiplier = style.PriceMultiplier
    });
});

app.MapGet("/orders", () =>
{
    List<OrderDTO> orderDTOs = new List<OrderDTO>();

    foreach (Order order in orders)
    {
        PaintColor paintColor = paintColors.FirstOrDefault(paintColor => paintColor.Id == order.PaintId);
        Interior interior = interiors.FirstOrDefault(interior => interior.Id == order.InteriorId);
        Technology technology = technologies.FirstOrDefault(technology => technology.Id == order.TechnologyId);
        Wheels wheel = wheels.FirstOrDefault(wheel => wheel.Id == order.WheelsId);
        Style style = styles.FirstOrDefault(style => style.Id == order.StyleId);

        orderDTOs.Add(new OrderDTO()
        {
            Id = order.Id,
            Timestamp = order.Timestamp,
            PaintId = order.PaintId,
            PaintColor = new PaintColorDTO
            {
                Id = paintColor.Id,
                Price = paintColor.Price,
                Color = paintColor.Color
            },
            InteriorId = order.InteriorId,
            Interior = new InteriorDTO
            {
                Id = interior.Id,
                Price = interior.Price,
                Material = interior.Material

            },
            TechnologyId = order.TechnologyId,
            Technology = new TechnologyDTO
            {
                Id = technology.Id,
                Price = technology.Price,
                Package = technology.Package
            },
            WheelsId = order.WheelsId,
            Wheels = new WheelsDTO
            {
                Id = wheel.Id,
                Price = wheel.Price,
                Style = wheel.Style
            },
            StyleId = order.StyleId,
            Style = new StyleDTO
            {
                Id = style.Id,
                Type = style.Type,
                PriceMultiplier = style.PriceMultiplier
            },
            Price = (paintColor.Price + interior.Price + technology.Price + wheel.Price) * style.PriceMultiplier
        });
    }

    return Results.Ok(orderDTOs);
});

app.MapPost("/orders", (Order order) =>
{
    PaintColor paintColor = paintColors.FirstOrDefault(paintColor => paintColor.Id == order.PaintId);
    Interior interior = interiors.FirstOrDefault(interior => interior.Id == order.InteriorId);
    Technology technology = technologies.FirstOrDefault(technology => technology.Id == order.TechnologyId);
    Wheels wheel = wheels.FirstOrDefault(wheel => wheel.Id == order.WheelsId);
    Style style = styles.FirstOrDefault(style => style.Id == order.StyleId);

    if (paintColor == null | interior == null | technology == null | wheel == null | style == null)
    {
        return Results.BadRequest();
    }

    order.Id = orders.Max(order => order.Id) + 1;
    order.Timestamp = DateTime.Now;
    orders.Add(order);

    return Results.Created($"/orders/{order.Id}", new OrderDTO
    {
        Id = order.Id,
        Timestamp = order.Timestamp,
        PaintId = order.PaintId,
        PaintColor = new PaintColorDTO
        {
            Id = paintColor.Id,
            Price = paintColor.Price,
            Color = paintColor.Color
        },
        InteriorId = order.InteriorId,
        Interior = new InteriorDTO
        {
            Id = interior.Id,
            Price = interior.Price,
            Material = interior.Material

        },
        TechnologyId = order.TechnologyId,
        Technology = new TechnologyDTO
        {
            Id = technology.Id,
            Price = technology.Price,
            Package = technology.Package
        },
        WheelsId = order.WheelsId,
        Wheels = new WheelsDTO
        {
            Id = wheel.Id,
            Price = wheel.Price,
            Style = wheel.Style
        },
        StyleId = order.StyleId,
        Style = new StyleDTO
        {
            Id = style.Id,
            Type = style.Type,
            PriceMultiplier = style.PriceMultiplier
        }
    });
});

app.Run();

