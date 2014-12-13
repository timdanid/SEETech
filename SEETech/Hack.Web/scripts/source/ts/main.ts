/// <reference path="../../typing/jquery/jquery.d.ts" />
/// <reference path="../../typing/sammy/sammyjs.d.ts" />

var app: Sammy.Application = Sammy();
var router: Hack.Router = new Hack.Router("http://hackapi.azurewebsites.net/api/");

var partials: { [key: string]: string; } = {};

partials["about"] = "/views/about.html";
partials["info"] = "/views/info.html";
partials["list"] = "/views/list.html";
partials["map"] = "/views/map.html";
partials["search"] = "/views/search.html";


app.get('#/about', (context: Sammy.EventContext) => {
    context.partial(partials["about"], (context: Sammy.EventContext) => {
    });
});
app.get('#/info', (context: Sammy.EventContext) => {
    context.partial(partials["info"], (context: Sammy.RenderContext) => {
    });
});


app.get('#/map', (context: Sammy.EventContext) => {
    console.log(context);
    context.partial(partials["map"], (context: Sammy.RenderContext) => {
        console.log(context);
    });
});





app.run('#/');