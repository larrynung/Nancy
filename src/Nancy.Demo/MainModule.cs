{
    using Nancy.Demo.Models;
    using Nancy.ViewEngines.Razor;
    using ViewEngines.NDjango;
    using ViewEngines.NHaml;
    using Nancy.Formatters;

    public class Module : NancyModule
    {
        public Module() {
            Get["/"] = x => {
                return "This is the root. Visit /razor, /nhaml or /ndjango!";
            };

            Get["/test"] = x => {
                return "Test";
            };

            Get["/razor"] = x => {
                var model = new RatPack { FirstName = "Frank" };
                return View.Razor("~/views/razor.cshtml", model);
            };

            Get["/nhaml"] = x => {
                var model = new RatPack { FirstName = "Andrew" };
                return View.Haml("~/views/nhaml.haml", model);
            };

            Get["/ndjango"] = x => {
                var model = new RatPack { FirstName = "Michael" };
                return View.Django("~/views/ndjango.django", model);
			};

            Get["/json"] = x => {
                var model = new RatPack { FirstName = "Frank" };
                return Response.AsJson(model);
            };
        }
    }
}
