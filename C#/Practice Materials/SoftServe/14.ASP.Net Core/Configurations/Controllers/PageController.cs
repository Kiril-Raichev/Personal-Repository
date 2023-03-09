using Configurations.Options;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Configurations.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PageController : ControllerBase
    {
        private readonly PageOptions _options;

        public PageController(IOptions<PageOptions> options)
        {
            _options = options.Value;
        }

        [HttpGet]
        public string GetPageSize()
        {
            return $"Page Size: {_options.PageSize}\n" +
                $"Max Count Before: {_options.MaxPageBeforecurrent}\n" +
                $"Max Count After: {_options.MaxPageAftercurrent}";
        }
    }
}
