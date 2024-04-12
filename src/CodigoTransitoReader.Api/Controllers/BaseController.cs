using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodigoTransitoReader.Api.Controllers;

[ApiController]
[Route("/v1/[controller]")]
public abstract class BaseController : ControllerBase
{
    private readonly ISender _sender;

    public BaseController(ISender sender)
    {
        _sender = sender;
    }
}